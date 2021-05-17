using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Desarrollo.Store.API.Models;
using PruebaTecnica.Desarrollo.Store.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PruebaTecnica.Desarrollo.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        // GET: api/<TipoDocumentoController>
        [HttpGet]
        public IActionResult Get()
        {
            ApiResponse<ICollection<TipoIdentificacion>> result = new ApiResponse<ICollection<TipoIdentificacion>>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = Models.Common.CodigoRespuestaEnum.Ok;
                    result.Data = context.TipoIdentificacion.OrderBy(c => c.IdTipoIdentificacion).ToList();
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

        // GET api/<TipoDocumentoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ApiResponse<TipoIdentificacion> result = new ApiResponse<TipoIdentificacion>();
            try
            {
                using (TiendaJuegosContext context = new TiendaJuegosContext())
                {
                    result.Codigo = Models.Common.CodigoRespuestaEnum.Ok;
                    result.Data = context.TipoIdentificacion.Find(id);
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

        
    }
}
