using System.Linq;
using Microsoft.EntityFrameworkCore;
using Thaz.BLL.Model;
using Thaz.BLL.Repositories;

namespace Thaz.DAL.Repositories
{
    public class FileRepository: RepositoryBase, IFileRepository
    {        

        public int SaveBillFile(BillFile file)
        {
            var entity = BillFiles
                .SingleOrDefault(x => x.BillId == file.BillId);
            if (entity == null)
            {
                entity = new Entities.BillFile();
                DbContext.Add(entity);
            }

            entity.Data = file.Data;
            entity.Extension = file.Extension;
            entity.Name = file.Name;
            entity.BillId = file.BillId;
            entity.CreatedOn = file.CreatedOn;
            
            DbContext.SaveChanges();
            return file.Id??0;
        }

        public BillFile GetBillFile(int billId)
        {
            return BillFiles
                .Single(x => x.BillId == billId)
                .ToModel();
        }

        public void DeleteBillFile(int billId)
        {
            DbContext.Remove(BillFiles.Single(x => x.BillId == billId));
            DbContext.SaveChanges();
        }
        
        public bool Exists(int billId)
        {
            return BillFiles.Any(x => x.BillId == billId);
        }

        public FileRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
}