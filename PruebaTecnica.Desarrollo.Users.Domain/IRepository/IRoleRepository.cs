using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.Domain.IRepository
{
    public interface IRoleRepository
    {
        IList<RoleEntity> GetAll();

        RoleEntity GetById(string id);
    }
}
