using System.Linq;
using Microsoft.EntityFrameworkCore;
using Thaz.BLL.Repositories;
using Thaz.DAL.Entities;
using User = Thaz.BLL.Model.User;

namespace Thaz.DAL.Repositories
{
    public class AuthRepository : RepositoryBase, IAuthRepository
    {

        public User Login(string email, string password)
        {
            return Users
                .Single(x => x.Email.Equals(email) && x.Password.Equals(password))
                .ToModel();
        }
        
        public void SetPassword(string password)
        {
            var user =  User;
            user.Password = password;
            DbContext.SaveChanges();
        }


        public AuthRepository(ThazDbContext dbContext) : base(dbContext, null)
        {
        }
    }
}