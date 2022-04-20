using Microsoft.EntityFrameworkCore;
using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet; 

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Create(T dbModel)
        {
            _dbSet.Add(dbModel);
            _dbContext.SaveChanges();
        }
        public void Edit(T dbModel)
        {
            _dbSet.Update(dbModel);
            _dbContext.SaveChanges();
        }

        public void Delete(T dbModel)
        {
            _dbSet.Remove(dbModel);
            _dbContext.SaveChanges();
        }
    }
}
