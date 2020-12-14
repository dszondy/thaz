using System.Linq;
using Thaz.BLL.QueryObjects;
using Thaz.DAL.Entities;

namespace Thaz.DAL.QueryBuilders
{
    public static class CondominiumQueryBuilder
    {
        public static IQueryable<Condominium> ApplySearch(this IQueryable<Condominium> query, CondominiumSearchParams searchParams)
        {
            if (searchParams.Name != null)
                query = query
                    .Where( x => x.Name.Contains(searchParams.Name));
            return query;
        }
    }
}