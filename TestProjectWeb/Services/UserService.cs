using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(UserRepository userRepository, 
                           IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public User GetCurrentUser()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id");
            var idClaim = claim.Value;
            var id = int.Parse(idClaim);

            return _userRepository.GetById(id);
        }
    }
}
