using DAL.Entities.User;
using System.Threading.Tasks;

namespace DAL.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
    }
}
