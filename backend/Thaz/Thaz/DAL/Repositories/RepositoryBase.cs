using System;
using System.Linq;
using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using Thaz.DAL.Entities;

namespace Thaz.DAL.Repositories
{
    public class RepositoryBase
    {
        public RepositoryBase(ThazDbContext dbContext, BLL.Model.User user)
        {
            userId = user?.Id;
                DbContext = dbContext?? throw  new ArgumentNullException(nameof(dbContext));
        }

        private readonly int? userId;
        protected int UserId { get => userId?? throw new AuthenticationException("Authentication required"); }
        protected  User User { get => Users.First(x => x.Id == UserId); }
        protected ThazDbContext DbContext { get; }
        
        protected IQueryable<Partner> Partners { get => DbContext.Partners.Where(x => x.Owner.Id == UserId); }
        protected IQueryable<User> Users { get => DbContext.Users; }
        protected IQueryable<Bill> Bills { get => DbContext.Bills
            .Where(x => x.Owner.Id == UserId)
            .Include(x => x.Items)
            .Include(x => x.Partner)
            .Include(x => x.Condominium); }
        protected IQueryable<Transaction> Transactions { get => DbContext.Transactions
            .Where(x => x.Owner.Id == UserId)                
            .Include(x=> x.Partner)
            .Include(x => x.Condominium); }
        protected IQueryable<Condominium> Condominiums { get => DbContext.Condominiums.Where(x => x.Owner.Id == UserId); }

        protected IQueryable<BillItem> BillItems { get => DbContext.BillItems; }
        protected IQueryable<BillFile> BillFiles { get => DbContext.BillFiles; }
        
    }
}