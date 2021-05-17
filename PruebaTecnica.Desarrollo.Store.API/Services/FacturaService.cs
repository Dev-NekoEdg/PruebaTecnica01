using PruebaTecnica.Desarrollo.Store.API.Models;
using PruebaTecnica.Desarrollo.Store.API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API.Services
{
    public class FacturaService : IFacturaService
    {
        public bool Registrar(FacturaModel model)
        {
            bool result = false;
            using (TiendaJuegosContext context = new TiendaJuegosContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Factura factura = new Factura();

                        factura.ClienteId = model.ClienteId;
                        factura.Total = (double)model.Detalles.Sum(d => d.Valor);

                        context.Factura.Add(factura);
                        context.SaveChanges();

                        foreach (DetalleFacturaModel detalle in model.Detalles)
                        {
                            DetalleFactura detalleFactura = new DetalleFactura();

                            detalleFactura.FacturaId = factura.IdFactura;
                            detalleFactura.ProductoId = detalle.ProductoId;
                            detalleFactura.Cantidad = (byte)detalle.Cantidad;
                            detalleFactura.Valor = (double)detalle.Valor;

                            context.DetalleFactura.Add(detalleFactura);
                            context.SaveChanges();
                        }

                        transaction.Commit();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return result;
        }

    }
}
