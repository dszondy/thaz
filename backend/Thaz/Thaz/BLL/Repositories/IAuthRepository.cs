using Thaz.BLL.Model;

namespace Thaz.BLL.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string password);
        void SetPassword(string password);
    }
}