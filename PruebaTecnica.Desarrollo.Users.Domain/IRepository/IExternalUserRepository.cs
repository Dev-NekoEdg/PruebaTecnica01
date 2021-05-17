using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Desarrollo.Users.Domain.IRepository
{
    public interface IExternalUserRepository
    {
        UserEntity RegisterNewUser(UserEntity user);

        UserEntity GetUserByUserName(string userName);
    }
}
