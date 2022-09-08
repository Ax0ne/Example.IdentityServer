using IdentityServer.DbContexts;
using IdentityServer.Models;

namespace IdentityServer.UserService
{
    public class UserService : IUserService
    {
        private readonly TestDbContext _dbContext;

        public UserService(TestDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User GetUser(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUser(string sub)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Name == sub || u.PhoneNumber == sub);
        }

        public bool ValidateCredentials(string username, string password)
        {
            var user = GetUser(username);
            if (user == null) return false;

            return user.Password.Equals(password);
        }
    }
}