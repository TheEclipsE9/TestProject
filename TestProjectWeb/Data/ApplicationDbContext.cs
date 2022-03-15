using Microsoft.EntityFrameworkCore;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;

namespace TestProjectWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
 