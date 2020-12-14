using System.Collections.Generic;
using Thaz.BLL.Model;

namespace Thaz.BLL.Repositories
{
    public interface IBillAccountingRepository
    {
        List<BillWithCompletion> GetIssuedBillsWithTotalCompletion(int partnerId, int page);
    }
}