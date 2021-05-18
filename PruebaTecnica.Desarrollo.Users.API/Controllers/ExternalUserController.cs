using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PruebaTecnica.Desarrollo.Users.API.Infrastructure.Services;
using PruebaTecnica.Desarrollo.Users.API.Models;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Controllers
{
    [Route("api/externaluser")]
    [ApiController]
    public class ExternalUserController : ControllerBase
    {

        private readonly IExternalUserRepository repository;

        private readonly IMapper mapper;

        private readonly ICustomAuthentication authentication;

        private readonly IExternalUserService externalUserService;

        public ExternalUserController(IExternalUserRepository repository, 
                                      IMapper mapper,
                                      ICustomAuthentication authentication,
                                      IExternalUserService externalUserService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.authentication = authentication;
            this.externalUserService = externalUserService;
        }

        [HttpPost("token")]
        public IActionResult Login(LoginModel model) 
        {
            var innerModel = mapper.Map<UserEntity>(model);
            
            var foundUser = repository.GetUserByUserName(innerModel.UserName);

            if (foundUser == null)
            {
                return BadRequest($"Usuario { innerModel.UserName } no existe.");
            }

            if (foundUser.Password != innerModel.Password)
            {
                return BadRequest("Password incorrecta.");
            }

            string rawResponse = authentication.GenerateToken(mapper.Map<UserModel>(foundUser));
            return Ok(new { token = rawResponse });
        }

        [HttpPost("register")]
        public IActionResult RegisterNewUser([FromBody]NewUserModel model) 
        {
            var rawResponse = externalUserService.RegisterAndLoginUser(model);

            return Ok(new { token = rawResponse });
        }
    }
}
