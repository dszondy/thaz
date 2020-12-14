using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories;

namespace Thaz.BLL.Services
{
    public class BillService
    {
        public BillService(IBillRepository billRepository, IFileRepository fileRepository)
        {
            BillRepository = billRepository;
            FileRepository = fileRepository;
        }

        private IBillRepository BillRepository { get; }
        private IFileRepository FileRepository { get; }
        
        public BillDetails CreateBill(BillDetails bill)
        {
            return BillRepository.CreateBill(bill);
        }

        public BillDetails GetBill(int id)
        {
            return BillRepository.GetBill(id);
        }

        public List<Bill> GetBills(BillSearchParams search)
        {
            return BillRepository.GetBills(search);
        }

        public BillDetails Edit(BillDetails bill)
        {
            return BillRepository.Edit(bill);
        }

        public int SaveBillFile(BillFile file)
        {
            return FileRepository.SaveBillFile(file);
        }

        public BillFile GetBillFile(int billId)
        {
            return FileRepository.GetBillFile(billId);
        }

        public void DeleteBillFile(int billId)
        {
            FileRepository.DeleteBillFile(billId);
        }

        public bool Exists(int billId)
        {
            return FileRepository.Exists(billId);
        }
    }
}