using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Data
{
    public class QuizRepository
    {
        private ApplicationDbContext _dbContext;

        public QuizRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Quiz> GetAll()
        {
            return _dbContext.Quizzes.ToList();
        }
        public List<Quiz> GetAllByCreaterId(int id)
        {
            return _dbContext.Quizzes.Where(x => x.Creater.Id == id).ToList();
        }
        public Quiz GetById(int id)
        {
            return _dbContext.Quizzes.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Quiz> GetByCreaterId(int id)
        {
            return _dbContext.Quizzes.Where(x => x.Creater.Id == id).ToList();
        }

        public void CreateQuiz(Quiz quiz)
        {
            _dbContext.Quizzes.Add(quiz);
            _dbContext.SaveChanges();
        }
        public void DeleteQuiz(Quiz quiz)
        {
            _dbContext.Quizzes.Remove(quiz);
            _dbContext.SaveChanges();
        }
    }
}
