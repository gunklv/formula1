using BLL.Domain;
using System.Threading.Tasks;

namespace BLL.Contracts.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string userName);
    }
}
