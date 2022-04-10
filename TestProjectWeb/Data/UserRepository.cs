using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class UserRepository
    {
        private ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetByLogin(string login, string password)
        {
            return _dbContext.Users.SingleOrDefault(user => user.Login == login && user.Password == password);
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void EditUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
