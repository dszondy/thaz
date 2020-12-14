using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;

namespace Thaz.BLL.Repositories
{
    public interface ICondominiumRepository
    {
        Condominium Create(Condominium condominium);
        Condominium Update(Condominium condominium);
        Condominium Get(int id);
        IEnumerable<Condominium> List(CondominiumSearchParams search);
    }
}