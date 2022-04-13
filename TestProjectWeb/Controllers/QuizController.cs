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

        public QuizController(WordRepository wordRepository, UserService userService)
        {
            _wordRepository = wordRepository;
            _userService = userService;
        }

        public IActionResult myQuizzes()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateQuiz()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQuiz(QuizViewModel quizViewModel)
        {
            var user = _userService.GetCurrentUser();
            var questions = new List<Question>();
            foreach (var questionViewModel in quizViewModel.QuestionViewModels)
            {
                var variants = new List<Variant>();
                variants.Add(questionViewModel.Answer);
                for
                var question = new Question
                {
                    Ask = questionViewModel.Ask,
                    Answer = questionViewModel.Answer,
                    Variants = variants,
                };
            }

            var quiz = new Quiz
            {
                Title = quizViewModel.Title,
                Creater = user,
                Questions = questions,
            };

            return View();
        }
    }
}
