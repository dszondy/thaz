using System.Linq;
using Thaz.BLL.QueryObjects;
using Thaz.DAL.Entities;

namespace Thaz.DAL.QueryBuilders
{
    public static class TransactionQueryBuilder
    {
        public static IQueryable<Transaction> ApplySearch(this IQueryable<Transaction> query, TransactionSearchParams searchParams)
        {
     
            if (searchParams.Before != null)
                query = query.Where(x => x.Date <=searchParams.Before);
            if (searchParams.After != null)
                query = query.Where(x => x.Date >=searchParams.After);
            if (searchParams.AmountLess != null)
                query = query.Where(x => x.Amount <=searchParams.AmountLess);
            if (searchParams.AmountMore != null)
                query = query.Where(x => x.Amount <=searchParams.AmountMore);
            if (searchParams.PartnerId != null)
                query = query.Where(x => x.Partner.Id == searchParams.PartnerId);            
            if (searchParams.AmountMore != null)
                query = query.Where(x => x.AccountNumber.Contains(searchParams.AccountNumber));
            if (searchParams.TransactionIdentifier != null)
                query = query.Where(x => x.TransactionIdentifier.Contains(searchParams.TransactionIdentifier));
            return query
                .Skip(Utils.PageSize * searchParams.Page)
                .Take(Utils.PageSize+1);
        }

    }
}