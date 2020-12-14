using System.Collections.Generic;
using Thaz.BLL.Model;

namespace Thaz.BLL.Repositories
{
    public interface ICondominiumAccountingRepository
    {
        IEnumerable<CondominiumTotals> Debt(in int page, bool issued);
        List<PartnerBalanceToCondominium> PartnerBalance(int page, int condominiumId);
    }
}