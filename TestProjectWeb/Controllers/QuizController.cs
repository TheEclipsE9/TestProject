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

        public IActionResult MyQuizzes()
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
        public IActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuiz(CreateQuizViewModel createQuizViewModel)
        {
            var user = _userService.GetCurrentUser();
            var maxQuantity = _wordRepository.GetAllByCreaterId(user.Id).Count;
            if (maxQuantity < createQuizViewModel.QuestionsQuantity)
            {
                ModelState.AddModelError("QuestionsQuantity", $"Max word quantity is {maxQuantity}");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var quiz = _quizService.CreateQuiz(createQuizViewModel.Title, createQuizViewModel.QuestionsQuantity);

            _quizRepository.Create(quiz);

            return RedirectToAction("myQuizzes");
        }

        public IActionResult PlayQuiz(int id)
        {
            var quiz = _quizRepository.GetById(id);

            var questionViewModels = new List<QuestionViewModel>();

            foreach (var question in quiz.Questions)
            {
                var variantViewModels = new List<VariantViewModel>();
                foreach (var variant in question.Variants)
                {
                    var variantViewModel = new VariantViewModel
                    {
                        Value = variant.Value,
                    };
                    variantViewModels.Add(variantViewModel);
                }

                var questionViewModel = new QuestionViewModel
                {
                    Ask = question.Ask,
                    Answer = question.Answer,
                    VariantViewModels = variantViewModels,
                };
                questionViewModels.Add(questionViewModel);
            }

            var quizViewModel = new QuizViewModel
            {
                Id = quiz.Id,
                Title = quiz.Title,
                QuestionViewModels = questionViewModels,
            };

            return View(quizViewModel);
        }

        public IActionResult DeleteQuiz(int id)
        {
            var quiz = _quizRepository.GetById(id);
            _quizRepository.Delete(quiz);

            return RedirectToAction("myQuizzes");
        }
    }
}
