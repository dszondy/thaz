using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;

namespace Thaz.BLL.Repositories
{
    public interface IAccountingRepository
    {
        List<PartnerCondominiumBalance> PartnerBalances(int page);
        Balance GetBalance(AccountingParams accountingParams);
        Dictionary<string, Balance> GetMonthlyBalanceHistory(AccountingParams accountingParams);
    }
}