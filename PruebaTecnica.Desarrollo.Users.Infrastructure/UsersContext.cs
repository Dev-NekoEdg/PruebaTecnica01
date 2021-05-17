using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Desarrollo.Users.Infrastructure
{
    public class UsersContext: DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> User { get; set; }

        public DbSet<RoleEntity> Role { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity(Guid.NewGuid().ToString(), "Usuario") ,
                new RoleEntity(Guid.NewGuid().ToString(), "Administrador") );
           
        }

    }
}
