using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Desarrollo.Store.API.Models;
using PruebaTecnica.Desarrollo.Store.API.Models.Common;
using PruebaTecnica.Desarrollo.Store.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Desarrollo.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            ApiResponse<ICollection<Cliente>> result = new ApiResponse<ICollection<Cliente>>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = Models.Common.CodigoRespuestaEnum.Ok;
                    result.Data = context.Cliente.OrderByDescending(c => c.IdCliente).ToList();
                }
            }
            catch (Exception ex)
            {
                result.Codigo = Models.Common.CodigoRespuestaEnum.Error;
                result.Mensaje = ex.Message;
                result.Data = null;
            }

            return Ok(result);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ApiResponse<Cliente> result = new ApiResponse<Cliente>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = CodigoRespuestaEnum.Ok;
                    result.Data = context.Cliente.Find(id);
                }
            }
            catch (Exception ex)
            {
                result.Codigo = CodigoRespuestaEnum.Error;
                result.Mensaje = ex.Message;
                result.Data = null;
            }

            return Ok(result);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            ApiResponse<Cliente> result = new ApiResponse<Cliente>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = CodigoRespuestaEnum.Ok;

                    context.Cliente.Add(cliente);
                    context.SaveChanges();

                    result.Data = cliente;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = CodigoRespuestaEnum.Error;
                result.Mensaje = ex.Message;
                result.Data = null;
            }

            return Ok(result);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            ApiResponse<Cliente> result = new ApiResponse<Cliente>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = CodigoRespuestaEnum.Ok;

                    var oldCliente = context.Cliente.Find(id);
                    oldCliente.Nombre = cliente.Nombre;
                    oldCliente.TipoIdentificacionId = cliente.TipoIdentificacionId;
                    oldCliente.NumeroIdentificacion = cliente.NumeroIdentificacion;
                    oldCliente.Edad = cliente.Edad;

                    context.Entry(oldCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                    result.Data = cliente;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = CodigoRespuestaEnum.Error;
                result.Mensaje = ex.Message;
                result.Data = null;
            }

            return Ok(result);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ApiResponse<bool> result = new ApiResponse<bool>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = CodigoRespuestaEnum.Ok;

                    var oldCliente = context.Cliente.Find(id);


                    context.Cliente.Remove(oldCliente);
                    context.SaveChanges();

                    result.Data = true;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = CodigoRespuestaEnum.Error;
                result.Mensaje = ex.Message;
                result.Data = false;
            }

            return Ok(result);
        }
    }
}
