using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories.Accounting;

namespace Thaz.BLL.Services
{
    public class AccountingService
    {
        public AccountingService(IBillAccountingRepository billAccountingRepository, ICondominiumAccountingRepository condominiumAccountingRepository, IAccountingRepository accountingRepository)
        {
            BillAccountingRepository = billAccountingRepository;
            CondominiumAccountingRepository = condominiumAccountingRepository;
            AccountingRepository = accountingRepository;
        }

        private IBillAccountingRepository BillAccountingRepository { get; }
        private ICondominiumAccountingRepository CondominiumAccountingRepository { get; }
        private IAccountingRepository AccountingRepository { get; }

        public List<BillWithCompletion> GetIssuedBillsWithTotalCompletion(int partnerId, int page)
        {
           return BillAccountingRepository.GetIssuedBillsWithTotalCompletion(partnerId, page);
        }

        public IEnumerable<CondominiumTotals> Debt(int page, bool issued)
        {
            return CondominiumAccountingRepository.Debt(page, issued);
        }

        public List<PartnerBalanceToCondominium> PartnerBalance(int page, int condominiumId)
        {
            return CondominiumAccountingRepository.PartnerBalance(page, condominiumId);
        }

        public List<PartnerCondominiumBalance> PartnerBalances(int page)
        {
            return AccountingRepository.PartnerBalances(page);
        }

        public Balance GetBalance(AccountingParams accountingParams)
        {
            return AccountingRepository.GetBalance(accountingParams);
        }

        public Dictionary<string, Balance> GetMonthlyBalanceHistory(AccountingParams accountingParams)
        {
            return AccountingRepository.GetMonthlyBalanceHistory(accountingParams);
        }
    }
}