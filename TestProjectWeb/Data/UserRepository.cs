using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public User GetByLogin(string login, string password)
        {
            return _dbSet.SingleOrDefault(user => user.Login == login && user.Password == password);
        }
    }
}
