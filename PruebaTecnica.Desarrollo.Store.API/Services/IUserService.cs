using PruebaTecnica.Desarrollo.Store.API.Models.Request;
using PruebaTecnica.Desarrollo.Store.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Services
{
    public interface IUserService
    {
        LoginResponse Auth(LoginModel model);

    }
}
