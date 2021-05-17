using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Desarrollo.Store.API.Models;
using PruebaTecnica.Desarrollo.Store.API.Models.Common;
using PruebaTecnica.Desarrollo.Store.API.Models.Request;
using PruebaTecnica.Desarrollo.Store.API.Models.Responses;
using PruebaTecnica.Desarrollo.Store.API.Tools;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Services
{
    public class UserService : IUserService
    {

        private readonly GlobalValues globalConfig;

        public UserService(IOptions<GlobalValues> options)
        {
            this.globalConfig = options.Value;
        }

        public LoginResponse Auth(LoginModel model)
        {
            LoginResponse result = new LoginResponse();

            using (TiendaJuegosContext context = new TiendaJuegosContext())
            {
                string passwordSHA256 = CustomEncryptation.EncryptarSHA256(model.Password);

                Usuarios user = context.Usuarios.Include(r=> r.Rol).
                                                 FirstOrDefault(u => u.UserName.ToLower() == model.UserName && 
                                                                u.Password == passwordSHA256);
                if (user == null)
                {
                    result = null;
                }
                else
                {
                    result.Email = user.Email;
                    result.UserName = user.UserName;
                    result.Token = GenerateToken(user);
                }
            }

            return result;
        }

        private string GenerateToken(Usuarios user) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(globalConfig.SecretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Rol?.Nombre)
                }),
                Expires = DateTime.UtcNow.AddMinutes(globalConfig.MinutesToExpire),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
