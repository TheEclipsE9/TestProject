using Microsoft.AspNetCore.Mvc;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Data.Enums;
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
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _userService.GetCurrentUser();

            var word = new Word();
            word.Value = wordViewModel.Value.ToLower();
            word.Translation = wordViewModel.Translation.ToLower();
            word.Category = wordViewModel.Category.ToLower();
            word.PartOfSpeech = wordViewModel.PartOfSpeech;
            word.Creater = user;

            _wordRepository.CreateWord(word);
            return RedirectToAction("Profile", "Profile");
        }

        [HttpGet]
        public IActionResult EditWord(int id)
        {
            var word = _wordRepository.GetById(id);

            var wordViewModel = new WordViewModel();
            wordViewModel.Value = word.Value;
            wordViewModel.Translation = word.Translation;
            wordViewModel.Category = word.Category;
            wordViewModel.PartOfSpeech = word.PartOfSpeech;


            return View(wordViewModel);
        }
        [HttpPost]
        public IActionResult EditWord(WordViewModel wordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _userService.GetCurrentUser();

            var word = new Word();
            word.Id = wordViewModel.Id;
            word.Value = wordViewModel.Value.ToLower();
            word.Translation = wordViewModel.Translation.ToLower();
            word.Category = wordViewModel.Category.ToLower();
            word.PartOfSpeech = wordViewModel.PartOfSpeech;
            word.Creater = user;

            _wordRepository.EditWord(word);

            return RedirectToAction("Profile", "Profile");
        }

        public IActionResult DeleteWord(int id)
        {
            var word = _wordRepository.GetById(id);
            _wordRepository.DeleteWord(word);

            return RedirectToAction("Profile", "Profile");
        }

        public IActionResult CopyWord(int createrId, string value, string translation, string category, PartsOfSpeech partOfSpeech)
        {
            var user = _userService.GetCurrentUser();

            var word = new Word();
            word.Value = value;
            word.Translation = translation;
            word.Category = category;
            word.PartOfSpeech = partOfSpeech;
            word.Creater = user;

            _wordRepository.CreateWord(word);

            return RedirectToAction("UserProfile", "User", new {@id = createrId});
        }
    }
}
