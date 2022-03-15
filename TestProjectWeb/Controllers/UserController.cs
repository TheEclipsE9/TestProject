using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;
using TestProjectWeb.Services;

namespace TestProjectWeb.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private UserService _userService;

        public UserController(ApplicationDbContext dbContext,
                              UserRepository userRepository, 
                              UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public IActionResult Index()
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

        public IActionResult Profile()
        {
            var user = _userService.GetCurrentUser();
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
            };
            
            return View(userViewModel);
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

            var claims = new List<Claim>();

            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim("Name", user.Name));
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "AuthCookie"));

            var claimsIdentity = new ClaimsIdentity(claims, "AuthCookie");

            var principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(principal);

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel userViewModel)
        {
            User user = new User
            {
                Name = userViewModel.Name,
            };
            _userRepository.CreateUser(user);

            return View();
        }

        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.DeleteUser(user);
            
            return RedirectToAction("Index");
        }

    }
}
