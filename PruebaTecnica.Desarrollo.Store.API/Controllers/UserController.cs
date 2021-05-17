using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Desarrollo.Store.API.Models;
using PruebaTecnica.Desarrollo.Store.API.Models.Request;
using PruebaTecnica.Desarrollo.Store.API.Models.Responses;
using PruebaTecnica.Desarrollo.Store.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Desarrollo.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            ApiResponse<LoginResponse> response = new ApiResponse<LoginResponse>();

            LoginResponse user = userService.Auth(model);
            if (user == null)
            {
                response.Codigo = Models.Common.CodigoRespuestaEnum.Error;
                response.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(response);
            }

            response.Codigo = Models.Common.CodigoRespuestaEnum.Ok;
            response.Data = user;
            return Ok(response);
        }

       
    }
}
