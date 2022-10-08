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
    public class CreateOrdenModel
    {
        public static async Task<Orden> CreateOrden(Guid carritoId, decimal total)
        {
            using (var context = new AppDbContext())
            {
                OrdenCommand CommandOrden = new OrdenCommand(context);
                OrdenQuery QueryOrden = new OrdenQuery(context);
                OrdenServices ServicesOrden = new OrdenServices(CommandOrden, QueryOrden);

                OrdenModel ModelOrden = new OrdenModel
                {
                    OrdenId = Guid.NewGuid(),
                    CarritoId = carritoId,
                    OrdenFecha = DateTime.Now,
                    OrdenTotal = total,

                };
                Orden Orden = await ServicesOrden.CreateOrden(ModelOrden);
                return Orden;
            }
        }
    }
}
