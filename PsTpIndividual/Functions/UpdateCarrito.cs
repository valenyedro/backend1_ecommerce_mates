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
    public class UpdateCarrito
    {
        public static async Task UpdateCarritoDb(Carrito carrito)
        {
            using (var context = new AppDbContext())
            {
                CarritoCommand CommandCarrito = new CarritoCommand(context);
                CarritoQuery QueryCarrito = new CarritoQuery(context);
                CarritoServices ServicesCarrito = new CarritoServices(CommandCarrito, QueryCarrito);

                await ServicesCarrito.UpdateCarrito(carrito);
            }
        }
    }
}
