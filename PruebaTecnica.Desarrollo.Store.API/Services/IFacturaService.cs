using PruebaTecnica.Desarrollo.Store.API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Services
{
    public interface IFacturaService
    {
        bool Registrar(FacturaModel model);
    }
}
