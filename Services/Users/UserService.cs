using DAL.Entities.User;
using DAL.Repositories.Users;
using Services.HashService;
using Services.Users.Models;
using System;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<(User, string)> Login(LoginParameter loginParameter)
        {
            var user = await _userRepository.GetByEmailAsync(loginParameter.Email);

            if (user == null)
            {
                throw new Exception($"User not found with email {loginParameter.Email}");
            }
            var passwordHash = _tokenService.HashUsingPbkdf2(loginParameter.Password, user.PasswordSalt);

            if (user.PasswordHash != passwordHash)
            {
                throw new Exception($"Incorrect password");
            }

            var token = await Task.Run(() => _tokenService.GenerateToken(user));

            return (user, token);
        }

        public async Task<(User, string)> SignUpAsync(SignUpParameter signUpParameter)
        {
            var random = new Random();
            var salt = random.Next();

            var user = new User()
            {
                Id = new Guid(),
                Email = signUpParameter.Email,
                FirstName = signUpParameter.FirstName,
                LastName = signUpParameter.LastName,
                PasswordSalt = salt.ToString(),
                PasswordHash = _tokenService.HashUsingPbkdf2(signUpParameter.Password, salt.ToString()),
                CreatedAt = DateTime.UtcNow
            };

            var token = await Task.Run(() => _tokenService.GenerateToken(user));

            return (user, token);
        }
    }
}
