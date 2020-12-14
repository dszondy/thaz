using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Thaz.BLL.Model;
using Thaz.BLL.Repositories;

namespace Thaz.DAL.Repositories.Accounting
{
    public class CondominiumAccountingRepository : RepositoryBase, ICondominiumAccountingRepository
    { 
        public IEnumerable<CondominiumTotals> Debt(in int page, bool issued)
        {
            return Condominiums
                .AsNoTracking()
                .Select(x => new CondominiumTotals()
                {
                    Name = x.Name,
                    Address = x.Address.toModel(),
                    Id = x.Id,
                    Bills = x.Bills
                        .Where(bill => bill.IssuedByCondominium == issued)
                        .Sum(b => b.Items.Sum(i => i.Price)),
                    Transactions = x.Transactions
                        .Where(t => t.IsReceived == issued)
                        .Sum(t => t.Amount)
                })
                .OrderByDescending(x => x.Bills-x.Transactions)
                .Skip(page*Utils.PageSize)
                .Take(Utils.PageSize+1)
                .ToList();
        }

        public List<PartnerBalanceToCondominium> PartnerBalance(int page, int condominiumId)
        {
            return Partners
                .Where(x => x.ResidentOf.Any(c => c.Id == condominiumId))
                .Select( x => 
                new PartnerBalanceToCondominium(){
                    Partner = x.ToModel(), 
                    Balance = new Balance() 
                    {
                    BillsFromPartner =
                        x.Bills.Where(bill => bill.Condominium.Id == condominiumId)
                        .Where(bill => !bill.IssuedByCondominium)
                        .Sum(bill => bill.Items.Sum(item => item.Price)),
                    BillsToPartner =
                        x.Bills.Where(bill => bill.Condominium.Id == condominiumId)
                            .Where(bill => bill.IssuedByCondominium)
                        .Sum(bill => bill.Items.Sum(x => x.Price)),
                    TransactionFromPartner =                  
                        x.Transactions.Where(bill => bill.Condominium.Id == condominiumId)
                            .Where(transaction => transaction.IsReceived)
                        .Sum(transaction => transaction.Amount),
                    TransactionToPartner =
                        x.Transactions.Where(bill => bill.Condominium.Id == condominiumId)
                            .Where(transaction => !transaction.IsReceived)
                        .Sum(transaction => transaction.Amount)
                }
                })
                .Skip(Utils.PageSize * page)
                .Take(Utils.PageSize+1)
                .ToList();
        }

        public CondominiumAccountingRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
}