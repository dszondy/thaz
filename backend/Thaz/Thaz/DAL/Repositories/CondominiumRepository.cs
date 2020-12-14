using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.QueryBuilders;

namespace Thaz.DAL.Repositories
{
    public class CondominiumRepository : RepositoryBase, ICondominiumRepository
    {
        public Condominium Create(Condominium condominium)
        {
            var entity = new Entities.Condominium()
            {
                Address = Entities.Address.FromModel(condominium.Address),
                Name = condominium.Name,
                Owner = User
            };
            DbContext.Add(entity);
            DbContext.SaveChanges();
            return entity.ToModel();
        }
    
        public Condominium Update(Condominium condominium)
        {
            var entity = Condominiums
                .First(x => x.Id == condominium.Id);
            entity.Address = Entities.Address.FromModel(condominium.Address);
            entity.Name = condominium.Name;
            DbContext.SaveChanges();
            return entity.ToModel();
        }
        public Condominium Get(int id) => 
            Condominiums.Single(x => x.Id == id).ToModel();

        public IEnumerable<Condominium> List(CondominiumSearchParams search)
        {
            return Condominiums
                .ApplySearch(search)
                .Select(x => x.ToModel())
                .ToList();
        }


        public CondominiumRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
}