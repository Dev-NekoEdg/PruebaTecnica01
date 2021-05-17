
namespace PruebaTecnica.Desarrollo.Users.Infrastructure.Repository
{
    using PruebaTecnica.Desarrollo.Users.Domain.Entities;
    using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RoleRepository : IRoleRepository
    {

        private readonly UsersContext context;

        public RoleRepository(UsersContext context)
        {
            this.context = context;
        }

        public IList<RoleEntity> GetAll()
        {
            return context.Role.ToList();
        }

        public RoleEntity GetById(string id)
        {
            return context.Role.Find(id);
        }
    }
}
