using AutoMapper;
using Microsoft.Extensions.Options;
using PruebaTecnica.Desarrollo.Users.API.Models;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Infrastructure.Services
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly IExternalUserRepository repository;

        private readonly IMapper mapper;

        private readonly GlobalConfig globalConfig;

        private readonly ICustomAuthentication authentication;

        public ExternalUserService(
            IExternalUserRepository repository,
            IMapper mapper,
            IOptions<GlobalConfig> options,
            ICustomAuthentication authentication
            )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.globalConfig = options.Value;
            this.authentication = authentication;
        }

        public string RegisterAndLoginUser(NewUserModel model)
        {
            model.RoleId = globalConfig.IdRoleDefault;
            UserEntity modelEntity = this.mapper.Map<UserEntity>(model);

            UserEntity newUser = repository.RegisterNewUser(modelEntity);

            UserModel tokenModel = mapper.Map<UserModel>(newUser);

            string token = authentication.GenerateToken(tokenModel);


            return token;
        }
    }
}
