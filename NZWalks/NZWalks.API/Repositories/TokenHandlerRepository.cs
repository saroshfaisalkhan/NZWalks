using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories
{
    public class TokenHandlerRepository : ITokenHandlerRepository
    {
        private readonly IConfiguration configuration;

        public TokenHandlerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateTokenAsync(User user)
        {
            // 1. Adding Claims

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.EmailAddress));

            // 1.1 Fetching Role

            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            });


            //2. Create Key

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //3. Create Credential and Pass key to the credential

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4. Create JWT Token

            var token = new JwtSecurityToken(
                //4.1 Issuer
                configuration["Jwt:Issuer"],
                //4.2 Audience
                configuration["Jwt:Audience"],
                //4.3 Claims
                claims,
                //4.4 expiry time
                expires:DateTime.Now.AddMinutes(15),
                //4.5 signing credential
                signingCredentials: credential
                );

            //5. Write token into JWT Securirty Token Handler and return back to to caller

           return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
