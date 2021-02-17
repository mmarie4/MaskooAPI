using DAL.Entities.User;
using DAL.Repositories.Users;
using Services.SecretService;
using Services.Users.Models;
using System;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        private readonly ISecretService _secretService;

        public UserService(IUserRepository userRepository, ISecretService tokenService)
        {
            _userRepository = userRepository;
            _secretService = tokenService;
        }

        public async Task<(User, string)> Login(LoginParameter loginParameter)
        {
            var user = await _userRepository.GetByEmailAsync(loginParameter.Email);

            if (user == null)
            {
                throw new Exception($"User not found with email {loginParameter.Email}");
            }
            var passwordHash = _secretService.HashUsingPbkdf2(loginParameter.Password, user.PasswordSalt);

            if (user.PasswordHash != passwordHash)
            {
                throw new Exception($"Incorrect password");
            }

            var token = await Task.Run(() => _secretService.GenerateToken(user));

            return (user, token);
        }

        public async Task<(User, string)> SignUpAsync(SignUpParameter signUpParameter)
        {
            var salt = _secretService.GenerateSalt();
            var user = new User()
            {
                Id = new Guid(),
                Email = signUpParameter.Email,
                FirstName = signUpParameter.FirstName,
                LastName = signUpParameter.LastName,
                PasswordSalt = salt.ToString(),
                PasswordHash = _secretService.HashUsingPbkdf2(signUpParameter.Password, salt.ToString()),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var token = await Task.Run(() => _secretService.GenerateToken(user));

            var result = await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return (result, token);
        }
    }
}
