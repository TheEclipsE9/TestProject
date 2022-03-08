using Microsoft.AspNetCore.Mvc;
using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;
using TestProjectWeb.Models;

namespace TestProjectWeb.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _dbContext;
        private Repository _repository;

        public UserController(ApplicationDbContext dbContext, 
                              Repository repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var users = _repository.GetAll();
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
            _repository.AddUser(user);

            return View();
        }

        public IActionResult DeleteUser(int id)
        {
            var user = _repository.GetById(id);
            _repository.DeleteUser(user);
            
            return RedirectToAction("Index");
        }

    }
}
