using System.Linq;
using Thaz.BLL.QueryObjects;
using Thaz.DAL.Entities;

namespace Thaz.DAL.QueryBuilders
{
    public static class PartnerQueryBuilder
    {
        public static IQueryable<Partner> ApplySearch(
            this IQueryable<Partner> query, PartnerSearchParams searchParams) 
        {
            if (searchParams.IsResident != null)
                query = query.Where(x => x.IsResident == searchParams.IsResident);
            if (searchParams.IsSupplier != null)
                query = query.Where(x => x.IsSupplier == searchParams.IsSupplier);            
            if (searchParams.Name != null)
                query = query.Where(x => x.Name.Contains(searchParams.Name));
            if (searchParams.CondominiumId != null)
                query = query.Where(x => x.ResidentOf
                    .Any(c => c.Id ==searchParams.CondominiumId));
            return query
                .OrderBy(x => x.Name)
                .Skip(Utils.PageSize * searchParams.Page)
                .Take(Utils.PageSize+1);
        }
    }
}