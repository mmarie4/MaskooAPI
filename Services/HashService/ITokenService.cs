using DAL.Entities.User;

namespace Services.HashService
{
    public interface ITokenService
    {
        string HashUsingPbkdf2(string password, string salt);
        string GenerateSecureSecret();
        string GenerateToken(User user);
    }
}
