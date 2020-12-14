using Thaz.BLL.Model;

namespace Thaz.BLL.Repositories
{
    public interface IFileRepository
    {
        int SaveBillFile(BillFile file);
        BillFile GetBillFile(int billId);
        void DeleteBillFile(int billId);
        bool Exists(int billId);
    }
}