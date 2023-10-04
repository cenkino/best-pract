using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace task2.API.Security
{
    public static class TokenHandler
    {
        public static Token CreateToken(IConfiguration configuration)
        {
            Token token = new Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:Expiration"]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            token.RefreshToken=Convert.ToBase64String(number);


            return token;
        }
    }
}
