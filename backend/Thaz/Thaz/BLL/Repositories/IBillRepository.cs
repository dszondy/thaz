using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;

namespace Thaz.BLL.Repositories
{
    public interface IBillRepository
    {
        BillDetails CreateBill(BillDetails bill);
        BillDetails GetBill(int id);
        List<Bill> GetBills(BillSearchParams search );
        BillDetails Edit(BillDetails bill);
    }
}