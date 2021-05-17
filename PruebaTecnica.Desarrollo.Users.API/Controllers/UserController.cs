using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Desarrollo.Users.API.Models;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository repository;
        private readonly IMapper mapper;


        public UserController(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("")]
        [Authorize]
        public IActionResult Get() 
        {
            try
            {
                var rawResponse  = repository.GetAll();
                var response = mapper.Map<IList<UserModel>>(rawResponse);

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
                var rawResponse = repository.GetById(id);
                var response = mapper.Map<UserModel>(rawResponse);

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

        [HttpPost("")]
        public IActionResult Create(UserModel user)
        {
            try
            {
                var newUser = mapper.Map<UserEntity>(user);

                var rawResponse = repository.Create(newUser);
                var algo = rawResponse.Role?.Name;
                var response = mapper.Map<UserModel>(rawResponse);

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

        [HttpPut("")]
        public IActionResult Update(UserModel user)
        {
            try
            {
                var rawResponse = repository.Update(mapper.Map<UserEntity>(user));
                var response = mapper.Map<UserModel>(rawResponse);

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

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var response = repository.Delete(id);
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
