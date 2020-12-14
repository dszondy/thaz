using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.QueryBuilders;

namespace Thaz.DAL.Repositories
{
    public class  PartnerRepository : RepositoryBase, IPartnerRepository
    {
        public Partner Create(PartnerDetails partner)
        {
            var entity = new Entities.Partner()
            {
                IsResident = partner.IsResident,
                Address = Entities.Address.FromModel(partner.Address),
                IsSupplier = partner.IsSupplier,
                Name = partner.Name,
                Phone = partner.Phone,
                Owner = User,
                ResidentOf = Condominiums
                                .Where(x => 
                                    partner.Condominiums
                                        .Select(c => c.Id)
                                        .ToArray()
                                        .Contains(x.Id??0)).ToList()
            };
            
            DbContext.Add(entity);
            DbContext.Add(entity.Address);
            DbContext.SaveChanges();
            return entity.ToModel();
        }
    
        public Partner Update(PartnerDetails partner)
        {
            
            var p = Partners
                .Include(x => x.ResidentOf)
                .First(x => x.Id == partner.Id);
            
            p.Address.UpdateFromModel(partner.Address);
            DbContext.Add(p.Address);
            p.Name = partner.Name;
            p.Phone = partner.Phone;
            p.IsResident = partner.IsResident;
            p.IsSupplier = partner.IsSupplier;
            p.ResidentOf = Condominiums
                .Where(x => 
                    partner.Condominiums
                        .Select(c => c.Id)
                        .ToArray()
                        .Contains(x.Id??0)).ToList();
            DbContext.SaveChanges();
            return p.ToModel();
        }
        public PartnerDetails Get(int id)
        {
            var p = Partners
                .Include(x => x.ResidentOf)
                .First(x => x.Id == id);
            return p.ToModelDetails();
        }

        public IEnumerable<Partner> List(PartnerSearchParams search)
        {
            return Partners
                .ApplySearch(search)
                .Select(x => x.ToModel())
                .ToList();
        }

        public PartnerRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
}