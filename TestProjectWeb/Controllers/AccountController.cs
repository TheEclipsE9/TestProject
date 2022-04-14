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
        private UserRepository _userRepository;
        private UserService _userService;

        public AccountController(ApplicationDbContext dbContext,
                              UserRepository userRepository,
                              UserService userService,
                              WordRepository wordRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registrationViewModel)
        {
            if(_userRepository.GetAll().Any(x=> x.Login == registrationViewModel.Login))
            {
                ModelState.AddModelError("Login", "Login is already taken");
            }
            if (registrationViewModel.Login == registrationViewModel.Password)
            {
                ModelState.AddModelError("Login", "Login cannot be the same as password");
                ModelState.AddModelError("Password", "Password cannot be the same as login");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            var newUser = new User
            {
                Name = registrationViewModel.Name,
                Country = registrationViewModel.Country,
                City = registrationViewModel.City,
                LearningLanguage = registrationViewModel.LearningLanguage,
                LanguageLevel = registrationViewModel.LanguageLevel,

                Login = registrationViewModel.Login,
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
            if (_userRepository.GetAll().Any(x => x.Login == loginViewModel.Login) is false)
            {
                ModelState.AddModelError("Login", "Login is not correct or Account is not created");
            }
            if (_userRepository.GetAll().Any(x => x.Login == loginViewModel.Login && x.Password != loginViewModel.Password))
            {
                ModelState.AddModelError("Password", "Password is not correct");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _userRepository.GetByLogin(loginViewModel.Login, loginViewModel.Password);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim("Name", user.Name));
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "AuthCookie"));

            var claimsIdentity = new ClaimsIdentity(claims, "AuthCookie");

            var principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Profile", "Profile");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteAccount(int id)
        {
            await HttpContext.SignOutAsync();
            var user = _userRepository.GetById(id);
            _userRepository.DeleteUser(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
