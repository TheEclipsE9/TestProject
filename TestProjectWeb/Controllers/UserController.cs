using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestProjectWeb.Data;
using TestProjectWeb.Models;
using TestProjectWeb.Services;

namespace TestProjectWeb.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private UserService _userService;
        private WordRepository _wordRepository;

        public UserController(UserRepository userRepository, WordRepository wordRepository, UserService userService)
        {
            _userRepository = userRepository;
            _wordRepository = wordRepository;
            _userService = userService;
        }

        public IActionResult AllUsers()
        {
            var users = _userRepository.GetAll();
            var usersViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel 
                { 
                    Id = user.Id,
                    Name = user.Name,
                    Country = user.Country,
                    City = user.City,
                    LearningLanguage = user.LearningLanguage,
                    LanguageLevel = user.LanguageLevel,
                };
                usersViewModels.Add(userViewModel);
            }
            return View(usersViewModels);
        }

        public IActionResult UserProfile(int id)
        {
            if (id == _userService.GetCurrentUser()?.Id)
            {
                return RedirectToAction("Profile", "Profile");
            }

            var profileViewModel = new ProfileViewModel();
            var userViewModel = new UserViewModel();
            var wordViewModels = new List<WordViewModel>();

            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return RedirectToAction("AllUsers");
            }
            userViewModel.Id = user.Id;
            userViewModel.Name = user.Name;
            userViewModel.Country = user.Country;
            userViewModel.City = user.City;
            userViewModel.LearningLanguage = user.LearningLanguage;
            userViewModel.LanguageLevel = user.LanguageLevel;


            var words = _wordRepository.GetAllByCreaterId(id);
            foreach (var word in words)
            {
                var wordViewModel = new WordViewModel();
                wordViewModel.Id = word.Id;
                wordViewModel.Value = word.Value;
                wordViewModel.Translation = word.Translation;
                wordViewModel.Category = word.Category;
                wordViewModel.PartOfSpeech = word.PartOfSpeech;
                wordViewModel.CreaterId = word.Creater.Id;

                wordViewModels.Add(wordViewModel);
            }

            profileViewModel.UserViewModel = userViewModel;
            profileViewModel.WordViewModels = wordViewModels;
            return View(profileViewModel);
        }
    }
}