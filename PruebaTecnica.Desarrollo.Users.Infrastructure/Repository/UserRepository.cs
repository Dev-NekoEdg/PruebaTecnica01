using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaTecnica.Desarrollo.Users.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext context;

        public UserRepository(UsersContext context)
        {
            this.context = context;
        }

        public UserEntity Create(UserEntity user)
        {
            context.User.Add(user);
            context.SaveChanges();
            user.Role = context.Role.Find(user.RoleId);

            return user;
        }

        public bool Delete(string id)
        {
            context.User.Remove(context.User.Find(id));
            return context.SaveChanges() > default(int);
        }

        public IList<UserEntity> GetAll()
        {
            return context.User.Include("Role").ToList();
        }

        public UserEntity GetById(string id)
        {
            return context.User.Include("Role").Single(u=> u.UserId == id);
        }

        public UserEntity Update(UserEntity user)
        {
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            user.Role = context.Role.Find(user.RoleId);

            return user;
        }
    }
}
