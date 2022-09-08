using IdentityServer.Models;

namespace IdentityServer.UserService
{
    public interface IUserService
    {
        User GetUser(int userId);
        User GetUser(string sub);
        bool ValidateCredentials(string username, string password);
    }
}
