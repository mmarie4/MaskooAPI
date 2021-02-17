using DAL.Entities.User;
using System.Threading.Tasks;

namespace DAL.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
