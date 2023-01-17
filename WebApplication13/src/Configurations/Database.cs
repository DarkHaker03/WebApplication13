using Microsoft.EntityFrameworkCore;
using WebApplication6.src.Entities;

namespace WebApplication6.src.Configurations
{
    public class MySqlDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }

    }
}
