using İdentityCardİnformation.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace İdentityCardİnformation.Database
{
    public class UserDataDbContext :DbContext
    {
        private readonly IConfiguration _configuration;

        public UserDataDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlDataSource = _configuration.GetConnectionString("UserDataDbContext");
            optionsBuilder.UseNpgsql(sqlDataSource);

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> users { get; set; }
    }
}
