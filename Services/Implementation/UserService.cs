using İdentityCardİnformation.Database;
using İdentityCardİnformation.Services.Interface;

namespace İdentityCardİnformation.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserDataDbContext _dbContext;

        public UserService(UserDataDbContext dbContext)
        {
            _dbContext = dbContext;
  
        }
        public bool CheckUserInDatabase(string identityNumber)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.IdentityNumber == identityNumber);
            if (user == null) return true;

            return false;
        }
    }
}
