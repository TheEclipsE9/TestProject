using Microsoft.AspNetCore.Mvc;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;
using TestProjectWeb.Services;

namespace TestProjectWeb.Controllers
{
    public class VocabularyController : Controller
    {
        private WordRepository _wordRepository;
        private UserService _userService;

        public VocabularyController(WordRepository wordRepository,
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
            word.Value = wordViewModel.Value.ToLower();
            word.Translation = wordViewModel.Translation.ToLower();
            word.Category = wordViewModel.Category.ToLower();
            word.PartOfSpeech = wordViewModel.PartOfSpeech;
            word.Creater = user;

            _wordRepository.CreateWord(word);

            return View();
        }
    }
}
