using JobHubWebAPI.DataLayer.AuthModel;
using JobHubWebAPI.DataLayer.DataBaseConnection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobHubWebAPI.ApplicationLayer.Token
{
    public class GenJWT
    {
        private readonly IConfiguration configuration;

        public GenJWT(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateAccesToken(AppUser  user)
        {
            var item = configuration.GetSection("JwtTokenSettings");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration[item["JwtKey"]]));
            var claims = new List<Claim>
            {
                new Claim("UserId",user.Id),
                new Claim(ClaimTypes.Role,"Cmp"), // instead of adding user to role after creating account of user, I add their role to claim and will user authorization Filter For Authorization :)
                new Claim(ClaimTypes.Email, user.Email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Issuer = configuration["JwtTokenSettings:ValidIssuer"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
