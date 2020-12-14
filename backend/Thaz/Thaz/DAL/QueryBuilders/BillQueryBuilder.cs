using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Thaz.BLL.QueryObjects;
using Thaz.DAL.Entities;

namespace Thaz.DAL.QueryBuilders
{
    public static class BillQueryBuilder
    {
        public static IQueryable<Bill> ApplySearch(this IQueryable<Bill> query, BillSearchParams searchParams)
        {
            if(searchParams.SerialFilter != null)
                query = query.Where(x => x.Serial.Contains(searchParams.SerialFilter));
            if (searchParams.IssuedBefore != null)
                query = query.Where(x => x.Created <= searchParams.IssuedBefore);
            if (searchParams.IssuedAfter != null)
                query = query.Where(x => x.Created >= searchParams.IssuedAfter);
            if (searchParams.DueAfter != null)
                query = query.Where(x => x.PaymentDeadline <= searchParams.IssuedBefore);
            if (searchParams.DueBefore != null)
                query = query.Where(x => x.PaymentDeadline <= searchParams.IssuedBefore);
            if (searchParams.IsDone != null)
                query = query.Where(x => x.Done == searchParams.IsDone);
            if (searchParams.ValueLess != null)
                query = query.Where(x => x.TotalPrice <= searchParams.ValueLess);
            if (searchParams.ValueMore != null)
                query = query.Where(x => x.TotalPrice >= searchParams.ValueMore);
            if (searchParams.PartnerId != null)
                query = query.Where(x => x.Partner.Id == searchParams.PartnerId);
            return query
                .OrderBy(x=> x.Created)
                .ThenBy(x => x.Id)
                .Skip(Utils.PageSize * searchParams.Page)
                .Take(Utils.PageSize+1);
        }
    }
}