using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Movie_Ticketing.Models
{
    public class JwtService
    {
        public String SecretKey { get; set; }
        public int TokenDuration { get; set; }
        public readonly IConfiguration config;

        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.SecretKey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);
        }
        public String GenerateTokane (String UserID, String FirstName, String LastName, String Email, String Mobile) 
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                new Claim("UserID", UserID),
                new Claim("Firstname", FirstName),
                new Claim("LastName", LastName),
                new Claim("Email", Email),
                new Claim ("Mobile", Mobile)
            };
            var jwtToken = new JwtSecurityToken(
                 issuer: "localhost",
                 audience: "localhost",
                 claims: payload,
                 expires: DateTime.Now.AddMinutes(TokenDuration),
                 signingCredentials: signature
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

           }
    }
}
