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
    public class CreateCarritoModel
    {
        public static Carrito CreateCarrito(ref Cliente cliente)
        {
            using (var context = new AppDbContext())
            {
                CarritoCommand CommandCarrito = new CarritoCommand(context);
                CarritoQuery QueryCarrito = new CarritoQuery(context);
                CarritoServices ServicesCarrito = new CarritoServices(CommandCarrito, QueryCarrito);

                CarritoModel ModelCarrito = new CarritoModel
                {
                    CarritoId = Guid.NewGuid(),
                    CarritoEstado = true,
                    ClienteId = cliente.ClienteId,
                };
                Carrito carrito = ServicesCarrito.CreateCarrito(ModelCarrito).Result;
                cliente.Carritos.Add(carrito);
                return carrito;
            }
        }
    }
}
