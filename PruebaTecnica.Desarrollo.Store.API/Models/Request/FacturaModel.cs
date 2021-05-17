using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Models.Request
{
    public class FacturaModel
    {
        [Required]
        [ExisteCliente(ErrorMessage = "Cliente no existe.")]
        public int ClienteId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "detalle factura debe tener un producto.")]
        public DetalleFacturaModel[] Detalles { get; set; }

    }

    #region Validator Attributes

    public class ExisteClienteAttribute : ValidationAttribute 
    {

        public override bool IsValid(object value)
        {
            int idCliente = (int)value;

            using (TiendaJuegosContext context = new TiendaJuegosContext())
            {
                if (context.Cliente.Find(idCliente) == null)
                {
                    return false;
                }
            }

            return true;
        }
    }

    #endregion

}
