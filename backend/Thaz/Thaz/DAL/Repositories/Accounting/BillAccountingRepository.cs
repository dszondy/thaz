using System.Collections.Generic;
using System.Linq;
using Thaz.BLL.Model;
using Thaz.BLL.Repositories;

namespace Thaz.DAL.Repositories.Accounting
{
    public class BillAccountingRepository : RepositoryBase, IBillAccountingRepository
    {

        public List<BillWithCompletion> GetIssuedBillsWithTotalCompletion(int partnerId, int page)
        {
            double totalValue = Transactions
                .Where(x => x.IsReceived && x.Partner.Id == partnerId)
                .Sum(x => x.Amount);
            
            var done = Bills
                .Where(x => x.IssuedByCondominium && x.Done && x.Partner.Id == partnerId)
                .Select(x => new BillWithCompletion()
                {
                    CompletionRate = 100,
                    Created = x.Created,
                    Id = x.Id ?? 0,
                    Done = x.Done,
                    Serial = x.Serial,
                    Value = x.Items.Sum(i => i.Price)
                });
            var totalCompleted = done.Sum(x => x.Value);
            
            var valueLeft = totalValue - totalCompleted;

            var billsNotDone = Bills
                .Where(x => x.IssuedByCondominium && !x.Done && x.Partner.Id == partnerId);
            
            var notCompleted = billsNotDone
                .OrderBy(x => x.Created)
                .ThenBy(x => x.Id)
                .Select(x =>
                    new
                    {
                        bill = x,
                        totalBefore = billsNotDone
                            .Where(y => y.Created <= x.Created && y.Id < x.Id)
                            .Sum(y => y.Items.Sum(i => i.Price))
                    }
                );

            var partlyCovered = notCompleted
                .Where(x => x.totalBefore < valueLeft)
                .Select(x => new BillWithCompletion()
                {
                    CompletionRate = 
                        (valueLeft >= x.totalBefore+x.bill.Items.Sum(i => i.Price)) ? 
                    100 :
                    (valueLeft-x.totalBefore)/x.bill.Items.Sum(i => i.Price)*100,
                    Created = x.bill.Created,
                    Id = x.bill.Id??0,
                    Done = x.bill.Done,
                    Serial = x.bill.Serial,
                    Value = x.bill.Items.Sum(i => i.Price)
                });
            
            var unCovered = notCompleted
                .Where(x => x.totalBefore >= valueLeft)
                .Select(x => new BillWithCompletion()
                {
                    CompletionRate = 0,
                    Created = x.bill.Created,
                    Id = x.bill.Id??0,
                    Done = x.bill.Done,
                    Serial = x.bill.Serial,
                    Value = x.bill.Items.Sum(i => i.Price)
                        
                });

            var result =
                done
                    .Concat(unCovered)
                    .Concat(partlyCovered)
                    .OrderBy(x => x.Created)
                    .ThenBy(x => x.Id)
                    .Skip(page * Utils.PageSize)
                    .Take(Utils.PageSize+1);
            return result.ToList();

        }
        public BillAccountingRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
}