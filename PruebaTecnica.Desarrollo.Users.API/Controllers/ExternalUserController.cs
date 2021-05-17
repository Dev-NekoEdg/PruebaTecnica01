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

        public ExternalUserController(IExternalUserRepository repository, 
                                      IMapper mapper,
                                      ICustomAuthentication authentication)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.authentication = authentication;
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
    }
}
