using DAL.Entities.User;

namespace Services.SecretService
{
    public interface ISecretService
    {
        string HashUsingPbkdf2(string password, string salt);
        string GenerateSalt();
        string GenerateSecureSecret();
        string GenerateToken(User user);
    }
}
