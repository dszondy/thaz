using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Thaz.BLL.QueryObjects;
using Thaz.DAL.Entities;

namespace Thaz.DAL.QueryBuilders
{
    public static class AccountingFilterBuilder
    {
        public static IQueryable<Bill> ApplySearch(this IQueryable<Bill> query, AccountingParams filter)
        {
            if (filter.CondominiumId != null)
                query = query.Where(x => x.Condominium.Id == filter.CondominiumId);
            if (filter.PartnerId != null)
                query = query.Where(x => x.Partner.Id == filter.PartnerId);
            if (filter.Tag != null)
            {
                query = query.Where(x => x.Tags.Any(tag => tag.Label.Equals(filter.Tag)));
            }
            return query;
        }

        public static IQueryable<Transaction> ApplySearch(this IQueryable<Transaction> query, AccountingParams filter)
        {
            if (filter.CondominiumId != null)
                query = query.Where(x => x.Condominium.Id == filter.CondominiumId);
            if (filter.PartnerId != null)
                query = query.Where(x => x.Partner.Id == filter.PartnerId);
            if (filter.Tag != null)
            {
                query = query.Where(x => x.Tags.Any(tag => tag.Label.Equals(filter.Tag)));
            }
            return query;
        }
        
    }
}