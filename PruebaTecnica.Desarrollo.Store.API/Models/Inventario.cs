using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaTecnica.Desarrollo.Store.API.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
