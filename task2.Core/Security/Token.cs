using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task2.Core.Models;

namespace task2.API.Security
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public DateTime Expiration { get; set; }

    }
}
