using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaTecnica.Desarrollo.Store.API.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
            Inventario = new HashSet<Inventario>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int ConsolaId { get; set; }
        public double Precio { get; set; }

        public virtual Consola Consola { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
