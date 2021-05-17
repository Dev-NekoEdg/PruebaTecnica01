using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnica.Desarrollo.Users.API.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRepository repository;

        public RoleController(IRoleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var response = repository.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.Message : ex.InnerException?.Message),
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(resp);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var response = repository.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.Message : ex.InnerException?.Message),
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(resp);
            }

        }

    }
}
