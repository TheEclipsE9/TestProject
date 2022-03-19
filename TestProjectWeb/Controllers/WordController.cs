using Microsoft.AspNetCore.Mvc;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;
using TestProjectWeb.Services;

namespace TestProjectWeb.Controllers
{
    public class WordController : Controller
    {
        private WordRepository _wordRepository;
        private UserService _userService;

        public WordController(WordRepository wordRepository,
                              UserService userService)
        {
            _wordRepository = wordRepository;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult CreateWord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWord(WordViewModel wordViewModel)
        {

            var user = _userService.GetCurrentUser();

            var word = new Word();
            word.Value = wordViewModel.Value;
            word.Translation = wordViewModel.Translation;
            word.Creater = user;

            _wordRepository.CreateWord(word);

            return View();
        }
    }
}
