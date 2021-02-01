using DAL.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
