using BLL.Contracts.Repository;
using BLL.Contracts.Services;
using BLL.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(string userName)
            => (await _userRepository.FilterAsync(u => u.UserName == userName)).FirstOrDefault();
    }
}
