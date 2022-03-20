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
    public class AccountController : Controller
    {
        private WordRepository _wordRepository;
        private UserRepository _userRepository;
        private UserService _userService;

        public AccountController(ApplicationDbContext dbContext,
                              UserRepository userRepository,
                              UserService userService,
                              WordRepository wordRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _wordRepository = wordRepository;
        }
        public IActionResult AllAccounts()
        {
            var users = _userRepository.GetAll();
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel();
                userViewModel.Id = user.Id;
                userViewModel.Name = user.Name;
                userViewModels.Add(userViewModel);
            }
            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registrationViewModel)
        {
            var newUser = new User
            {
                Name = registrationViewModel.Name,
                Password = registrationViewModel.Password,
            };
            _userRepository.CreateUser(newUser);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = _userRepository.GetByLogin(loginViewModel.Name, loginViewModel.Password);

            if (user == null)
            {
                return RedirectToAction("Register", "Account");
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim("Name", user.Name));
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "AuthCookie"));

            var claimsIdentity = new ClaimsIdentity(claims, "AuthCookie");

            var principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteAccount(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.DeleteUser(user);

            return RedirectToAction("AllAccounts");
        }
    }
}
