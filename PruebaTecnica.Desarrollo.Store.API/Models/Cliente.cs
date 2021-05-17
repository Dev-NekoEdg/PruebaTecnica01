using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaTecnica.Desarrollo.Store.API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; }
        public byte Edad { get; set; }

        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
