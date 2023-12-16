using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWebAppPracting.Models.ModelsUser;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebAppPracting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration config;



        public List<User> users { get; set; } = new()
        {
            new User() { Id=1,Username = "Isa",Password ="1234"},
            new User() { Id=2,Username = "Ali",Password ="1111"},
        };
        public UserController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost("Login")]

        public Task<ActionResult<ModelUserLoginSuccsess>> Login(ModelUserLogin userModel)
        {
            var data = users.FirstOrDefault(u => u.Username == userModel.Username && u.Password == userModel.Password);

            var token = GenereateToken(data);
            return Task.FromResult<ActionResult<ModelUserLoginSuccsess>>(Ok(new ModelUserLoginSuccsess()
            {
                Id = data.Id,
                Token = token
            }));

        }

        private string GenereateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:SignInKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) ,
                    new Claim(ClaimTypes.Name,user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "example",
                Audience = "example",
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
