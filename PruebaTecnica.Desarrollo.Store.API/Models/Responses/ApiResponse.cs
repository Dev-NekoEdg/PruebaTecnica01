using PruebaTecnica.Desarrollo.Store.API.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Models.Responses
{
    public class ApiResponse<T>
    {
        public CodigoRespuestaEnum Codigo { get; set; }

        public string Mensaje { get; set; }

        public T Data { get; set; }


        public ApiResponse()
        {
            this.Codigo = CodigoRespuestaEnum.Error;
        }

    }
}
