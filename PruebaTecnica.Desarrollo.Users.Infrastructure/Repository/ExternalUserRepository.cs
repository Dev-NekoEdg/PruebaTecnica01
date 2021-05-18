using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Desarrollo.Users.Infrastructure.Repository
{
    public class ExternalUserRepository : IExternalUserRepository
    {
        private readonly UsersContext context;

        public ExternalUserRepository(UsersContext context)
        {
            this.context = context;
        }

        public string Login(UserEntity user)
        {
            var userFound = context.User.Include(r=> r.Role).Single(u => u.UserName == user.UserName);
            //var userFound = context.User.Single(u => u.UserName == user.UserName);

            if (userFound != null)
            {
                if (!userFound.Active)
                {
                    throw new Exception("Usuario Inactivo.");
                }

                if (user.Password.Contains(userFound.Password))
                {
                    return GenerateToken(userFound,"");
                }
            }

            throw new Exception($"El usuario { user.UserName } no existe.");
        }

        private string GenerateToken(UserEntity user, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
           
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.UserId),
                    new Claim("name", user.Name),
                    new Claim("lastName", user.LastName),
                    new Claim("roleId", user.Name),
                    new Claim("role", user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public UserEntity RegisterNewUser(UserEntity user)
        {
            context.User.Add(user);
            context.SaveChanges();

            return user;
        }

        public UserEntity GetUserByUserName(string userName)
        {
            return context.User.Include(r => r.Role).Single(u => u.UserName.ToLower() == userName.ToLower());
        }
    }
}
