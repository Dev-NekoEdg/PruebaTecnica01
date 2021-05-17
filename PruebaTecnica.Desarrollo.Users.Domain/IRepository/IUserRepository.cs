using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Desarrollo.Users.Domain.IRepository
{
    public interface IUserRepository
    {
        IList<UserEntity> GetAll();

        UserEntity GetById(string id);

        UserEntity Create(UserEntity user);

        UserEntity Update(UserEntity user);

        bool Delete(string id);

    }
}
