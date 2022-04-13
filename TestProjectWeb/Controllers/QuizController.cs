using Microsoft.AspNetCore.Mvc;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;
using TestProjectWeb.Services;

namespace TestProjectWeb.Controllers
{
    public class QuizController : Controller
    {
        private WordRepository _wordRepository;
        private UserService _userService;
        private QuizService _quizService;
        private QuizRepository _quizRepository;

        public QuizController(WordRepository wordRepository, UserService userService, QuizService quizService, QuizRepository quizRepository)
        {
            _wordRepository = wordRepository;
            _userService = userService;
            _quizService = quizService;
            _quizRepository = quizRepository;
        }

        public IActionResult myQuizzes()
        {
            var user = _userService.GetCurrentUser();
            var myQuizzes = _quizRepository.GetByCreaterId(user.Id);
            var quizViewModels = new List<QuizViewModel>();
            foreach (var quiz in myQuizzes)
            {
                var quizViewModel = new QuizViewModel
                {
                    Id = quiz.Id,
                    Title = quiz.Title
                };
                quizViewModels.Add(quizViewModel);
            }
            return View(quizViewModels);
        }

        [HttpGet]
        public IActionResult CreateQuiz( )
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuiz(CreateQuizViewModel createQuizViewModel)
        {
            var quiz = _quizService.CreateQuiz(createQuizViewModel.Title, createQuizViewModel.QuestionsQuantity);

            _quizRepository.CreateQuiz(quiz);

            return RedirectToAction("myQuizzes");
        }
    }
}
