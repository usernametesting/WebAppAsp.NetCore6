using Microsoft.IdentityModel.Tokens;
using MyWebAppPracting.Models.ModelsUser;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

using System.Text;

namespace MyWebAppPracting.MiddleWares
{
    public class JwtMiddleWare
    {
        private readonly RequestDelegate _next;

        public IConfiguration Configuration { get; }
        public JwtMiddleWare(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            Configuration = configuration;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                var result = context.Request.Headers["Authorization"].FirstOrDefault();
                if (result != null)
                {
                    var token = result!.Split(" ").Last();

                    if (token != null)
                    {
                        AttactUserToContext(context, token);
                    };
                }
            }
            catch (Exception)
            {

            }
            await _next(context);
        }

        private void AttactUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["Jwt:SignInKey"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var identity = new ClaimsIdentity(jwtToken.Claims);
                var principal = new ClaimsPrincipal(identity);
              

                context.User = principal;
            }
            catch { }

        }

    
    }
}
