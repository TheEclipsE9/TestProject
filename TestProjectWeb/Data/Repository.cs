using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class Repository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
    }
}
