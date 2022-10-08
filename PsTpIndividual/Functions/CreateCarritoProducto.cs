using Application.Models;
using Application.UseCase;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsTpIndividual.Functions
{
    public class CreateCarritoProductoModel
    {
        public static async Task<CarritoProducto> CreateCarritoProducto(Guid carritoId, int productoId, int cantidad)
        {
            using (var context = new AppDbContext())
            {
                CarritoProductoCommand CommandCarritoProducto = new CarritoProductoCommand(context);
                CarritoProductoQuery QueryCarritoProducto = new CarritoProductoQuery(context);
                CarritoProductoServices ServicesCarritoProducto = new CarritoProductoServices(CommandCarritoProducto, QueryCarritoProducto);

                CarritoProductoModel ModelCarritoProducto = new CarritoProductoModel
                {
                    CarritoId = carritoId,
                    ProductoId = productoId,
                    Cantidad = cantidad,

                };
                CarritoProducto CarritoProducto = await ServicesCarritoProducto.CreateCarritoProducto(ModelCarritoProducto);
                return CarritoProducto;
            }
        }
    }
}
