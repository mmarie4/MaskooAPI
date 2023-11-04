using DAL.Entities.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.SecretService.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.SecretService
{
    public class SecretService : ISecretService
    {
        private readonly SecretConfiguration _config;

        public SecretService(IOptions<SecretConfiguration> config)
        {
            _config = config.Value;
        }

        /// <summary>
        /// Hash a password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string HashUsingPbkdf2(string password, string salt)
        {
            using var bytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
            var derivedRandomKey = bytes.GetBytes(32);
            var hash = Convert.ToBase64String(derivedRandomKey);
            return hash;
        }

        /// <summary>
        /// Generate a random base64 string for salt
        /// </summary>
        /// <returns></returns>
        public string GenerateSalt()
        {
            var randomBytes = new byte[64];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }





        // Important note***************
        // The secret is a base64-encoded string, always make sure to use a secure long string so no one can guess it. ever!.
        // a very recommended approach to use is through the HMACSHA256() class, to generate such a secure secret, you can refer to the below function
        // you can run a small test by calling the GenerateSecureSecret() function to generate a random secure secret once, grab it, and use it as the secret above 
        // or you can save it into appsettings.json file and then load it from them, the choice is yours

        public string GenerateSecureSecret()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));

            var permClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(_config.Issuer,
                                             _config.Audience,
                                             permClaims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
