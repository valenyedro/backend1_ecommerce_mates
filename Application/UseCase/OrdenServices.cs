using Application.Interfaces.ICliente;
using Application.Interfaces.IOrden;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class OrdenServices : IOrdenServices
    {
        private readonly IOrdenCommand _command;
        private readonly IOrdenQuery _query;

        public OrdenServices(IOrdenCommand command, IOrdenQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Orden> CreateOrden(OrdenModel request)
        {
            var Orden = new Orden
            {
                OrdenId = Guid.NewGuid(),
                CarritoId = request.CarritoId,
                Fecha = request.OrdenFecha,
                Total = request.OrdenTotal,
            };
            await _command.InsertOrden(Orden);
            return Orden;
        }

        public async Task<Orden> UpdateOrden(Orden orden)
        {
            await _command.UpdateOrden(orden);
            return orden;
        }

        public async Task<Orden> DeleteOrden(Orden orden)
        {
            await _command.RemoveOrden(orden);
            return orden;
        }

        public async Task<List<Orden>> GetAllOrdenes()
        {
            var Ordenes = await _query.GetListOrdenes();
            return Ordenes;
        }

        public async Task<Orden> GetOrdenById(Guid id)
        {
            var Orden = await _query.GetOrden(id);
            return Orden;
        }
    }
}
