using Microsoft.EntityFrameworkCore;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;

namespace TestProjectWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
 