using PruebaTecnica.Desarrollo.Users.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Infrastructure.Services
{
    public interface IExternalUserService
    {
        string RegisterAndLoginUser(NewUserModel model);
    }
}
