using Microsoft.EntityFrameworkCore;
using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Words).WithOne(x => x.Creater);

            modelBuilder.Entity<User>().HasMany(x => x.Quizzes).WithOne(x => x.Creater);
            modelBuilder.Entity<Quiz>().HasMany(x => x.Questions).WithOne(x => x.Quiz);
            modelBuilder.Entity<Question>().HasMany(x => x.Variants).WithOne(x => x.Question);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
 