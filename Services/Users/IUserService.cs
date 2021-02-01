using DAL.Entities.User;
using Services.Users.Models;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUserService
    {
        Task<(User, string)> Login(LoginParameter loginParameter);
        Task<(User, string)> SignUpAsync(SignUpParameter signUpParameter);
    }
}
