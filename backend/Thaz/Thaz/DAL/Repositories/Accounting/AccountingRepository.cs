using System;
using System.Collections.Generic;
using System.Linq;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.QueryBuilders;

namespace Thaz.DAL.Repositories.Accounting
{
    public class AccountingRepository : RepositoryBase, IAccountingRepository
    {
        public AccountingRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }

        public List<PartnerCondominiumBalance> PartnerBalances(int page)
        {
            return Condominiums.SelectMany(x => x.Residents, (condominium, partner) => 
                    new PartnerCondominiumBalance(){
                        Partner = partner.ToModel(), 
                        Condominium = condominium.ToModel(),
                        Balance = new Balance() 
                        {
                            BillsFromPartner =
                                partner.Bills.Where(bill => bill.Condominium.Id == condominium.Id)
                                    .Where(bill => !bill.IssuedByCondominium)
                                    .Sum(bill => bill.Items.Sum(item => item.Price)),
                            BillsToPartner =
                                partner.Bills.Where(bill => bill.Condominium.Id == condominium.Id)
                                    .Where(bill => bill.IssuedByCondominium)
                                    .Sum(bill => bill.Items.Sum(x => x.Price)),
                            TransactionFromPartner =                  
                                partner.Transactions.Where(bill => bill.Condominium.Id == condominium.Id)
                                    .Where(transaction => transaction.IsReceived)
                                    .Sum(transaction => transaction.Amount),
                            TransactionToPartner =
                                partner.Transactions.Where(bill => bill.Condominium.Id == condominium.Id)
                                    .Where(transaction => !transaction.IsReceived)
                                    .Sum(transaction => transaction.Amount)
                        }
                    })
                .OrderByDescending(x => x.Balance.BillsToPartner-x.Balance.TransactionFromPartner)
                .Skip(Utils.PageSize * page)
                .Take(Utils.PageSize+1)
                .ToList();
        }
        
        public Balance GetBalance(AccountingParams accountingParams)
        {
            return new Balance()
            {
                BillsFromPartner = Bills
                    .ApplySearch(accountingParams)
                    .Where(x => !x.IssuedByCondominium)
                    .Sum(x => x.Items.Sum(x => x.Price)),
                BillsToPartner = Bills
                    .ApplySearch(accountingParams)
                    .Where(x => x.IssuedByCondominium)
                    .Sum(x => x.Items.Sum(x => x.Price)),
                TransactionFromPartner = Transactions
                    .ApplySearch(accountingParams)
                    .Where(x => x.IsReceived)
                    .Sum(x => x.Amount),
                TransactionToPartner = Transactions
                    .ApplySearch(accountingParams)
                    .Where(x => !x.IsReceived)
                    .Sum(x => x.Amount)
            };
        }
        public Dictionary<string, Balance> GetMonthlyBalanceHistory(AccountingParams accountingParams)
        {
            var now = DateTime.Now;
            var balances = new Dictionary<string, Balance>();

            for (int i = 1; i <= 12; i++)
            {
                var from = now - TimeSpan.FromDays(30 * i);
                var to = now - TimeSpan.FromDays(30 * (i - 1));
                var label = from.ToString("yyyy.MM.dd.") + " -";
                var billsInTime = Bills.Where(x => x.PaymentDeadline > from && x.PaymentDeadline <= to);
                var transactionsInTime = Transactions.Where(x => x.Date > from && x.Date <= to);
                balances.Add(label,
                    new Balance()
                    {
                        BillsFromPartner = billsInTime
                            .ApplySearch(accountingParams)
                            .Where(x => !x.IssuedByCondominium)
                            .Sum(x => x.Items.Sum(x => x.Price)),
                        BillsToPartner = billsInTime
                            .ApplySearch(accountingParams)
                            .Where(x => x.IssuedByCondominium)
                            .Sum(x => x.Items.Sum(x => x.Price)),
                        TransactionFromPartner = transactionsInTime
                            .ApplySearch(accountingParams)
                            .Where(x => x.IsReceived)
                            .Sum(x => x.Amount),
                        TransactionToPartner = transactionsInTime
                            .ApplySearch(accountingParams)
                            .Where(x => !x.IsReceived)
                            .Sum(x => x.Amount)
                    });
            }

            return balances;
            }

        }
        
        
    }