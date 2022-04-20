using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class QuizRepository : BaseRepository<Quiz>
    {
        public QuizRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public List<Quiz> GetAllByCreaterId(int id)
        {
            return _dbSet.Where(x => x.Creater.Id == id).ToList();
        }        

        public List<Quiz> GetByCreaterId(int id)
        {
            return _dbSet.Where(x => x.Creater.Id == id).ToList();
        }
    }
}
