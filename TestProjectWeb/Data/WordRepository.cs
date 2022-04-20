using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class WordRepository : BaseRepository<Word>
    {

        public WordRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public List<Word> GetAllByCreaterId(int id)
        {
            return _dbSet.Where( x => x.Creater.Id == id).ToList();
        }

        public Word GetRandomWordFromAll(int index)
        {
            return _dbSet.ToList()[index];
        }

        public Word GetRandomWordFromCurrentUser(int id, int index)
        {
            return _dbSet.Where(x => x.Creater.Id == id).ToList()[index]; 
        }
    }
}
