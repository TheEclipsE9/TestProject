using TestProjectWeb.Data;
using TestProjectWeb.Data.DbModels;

namespace TestProjectWeb.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private WordRepository _wordRepository;

        public UserService(UserRepository userRepository,
                           IHttpContextAccessor httpContextAccessor, WordRepository wordRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _wordRepository = wordRepository;
        }

        public User GetCurrentUser()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id");
            if (claim == null)
            {
                return null;
            }
            var idClaim = claim?.Value;
            var id = int.Parse(idClaim);

            return _userRepository.GetById(id);
        }

        public List<string> GetAllUserCategories()
        {
            var user = GetCurrentUser();
            var userWords = _wordRepository.GetAllByCreaterId(user.Id);
            var categories = userWords.Select(x => x.Category).Distinct().ToList();

            return categories;
        }
    }
}
