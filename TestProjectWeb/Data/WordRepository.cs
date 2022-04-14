using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class WordRepository
    {
        private ApplicationDbContext _dbContext;

        public WordRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Word> GetAll()
        {
            return _dbContext.Words.ToList();
        }

        public List<Word> GetAllByCreaterId(int id)
        {
            return _dbContext.Words.Where( x => x.Creater.Id == id).ToList();
        }
        public Word GetById(int id)
        {
            return _dbContext.Words.Where(word => word.Id == id).FirstOrDefault();
        }
        public Word GetRandomWordFromAll(int index)
        {
            var words = _dbContext.Words.ToList();

            var result = words[index];
            return result;
        }
        public Word GetRandomWordFromCurrentUser(int id, int index)
        {
            var words = _dbContext.Words.Where(x => x.Creater.Id == id).ToList();

            var result = words[index];

            return result;
        }

        public void CreateWord(Word word)
        {
            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();
        }

        public void DeleteWord(Word word)
        {
            _dbContext.Words.Remove(word);
            _dbContext.SaveChanges();
        }
        public void EditWord(Word word)
        {
            _dbContext.Words.Update(word);
            _dbContext.SaveChanges();
        }
    }
}
