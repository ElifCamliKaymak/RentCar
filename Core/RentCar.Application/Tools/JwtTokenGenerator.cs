using Microsoft.IdentityModel.Tokens;
using RentCar.Application.Dtos;
using RentCar.Application.Features.Mediator.Results.AppUserResults;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentCar.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static object JwtSecurityToken { get; private set; }

        public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result)
        {
            var claims = new List<Claim>();
            if(!string.IsNullOrEmpty(result.Role))
                claims.Add(new Claim(ClaimTypes.Role, result.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

            if (!string.IsNullOrEmpty(result.UserName))
                claims.Add(new Claim("Username" ,result.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signinCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer, 
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore:DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signinCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);       
        }
    }
}
