using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;
using TestProjectWeb.Services;

namespace TestProjectWeb.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private WordRepository _wordRepository;
        private UserRepository _userRepository;
        private UserService _userService;

        public ProfileController(ApplicationDbContext dbContext,
                              UserRepository userRepository,
                              UserService userService, 
                              WordRepository wordRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _wordRepository = wordRepository;
        }
        
        public IActionResult Profile()
        {
            var profileViewModel = new ProfileViewModel();

            var user = _userService.GetCurrentUser();
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Country = user.Country,
                City = user.City,
                LearningLanguage = user.LearningLanguage,
                LanguageLevel = user.LanguageLevel,
            };


            var wordViewModels = new List<WordViewModel>();

            var words = _wordRepository.GetAllByCreaterId(user.Id);
            foreach (var word in words)
            {
                var wordViewModel = new WordViewModel();
                wordViewModel.Id = word.Id;
                wordViewModel.Value = word.Value;
                wordViewModel.Translation = word.Translation;
                wordViewModel.Category = word.Category;
                wordViewModel.PartOfSpeech = word.PartOfSpeech;

                wordViewModels.Add(wordViewModel);
            }

            profileViewModel.UserViewModel = userViewModel;
            profileViewModel.WordViewModels = wordViewModels;
            
            return View(profileViewModel);
        }              
    }
}
