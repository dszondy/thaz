using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories;

namespace Thaz.BLL.Services
{
    public class CondominiumService
    {
        public CondominiumService(ICondominiumRepository condominiumRepository)
        {
            CondominiumRepository = condominiumRepository;
        }

        private ICondominiumRepository CondominiumRepository { get; }
        
        public Condominium Create(Condominium condominium)
        {
            return CondominiumRepository.Create(condominium);
        }

        public Condominium Update(Condominium condominium)
        {
            return CondominiumRepository.Update(condominium);
        }

        public Condominium Get(int id)
        {
            return CondominiumRepository.Get(id);
        }

        public IEnumerable<Condominium> List(CondominiumSearchParams search)
        {
            return CondominiumRepository.List(search);
        }
    }
}