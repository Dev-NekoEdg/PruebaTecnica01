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
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            this.facturaService = facturaService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("dsfsdfsdfsd");
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] FacturaModel model)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (facturaService.Registrar(model))
            {
                response.Codigo = Models.Common.CodigoRespuestaEnum.Ok;
            }
            else
            {
                response.Codigo = Models.Common.CodigoRespuestaEnum.Error;
                response.Mensaje = "Error al registra la venta";
            }

            return Ok(response);
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
