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
    }
}
