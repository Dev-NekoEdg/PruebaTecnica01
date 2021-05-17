using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaTecnica.Desarrollo.Store.API.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int IdFactura { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
