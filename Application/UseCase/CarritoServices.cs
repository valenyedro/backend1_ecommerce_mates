using Application.Interfaces.ICarrito;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CarritoServices : ICarritoServices
    {
        private readonly ICarritoCommand _command;
        private readonly ICarritoQuery _query;

        public CarritoServices(ICarritoCommand command, ICarritoQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Carrito> CreateCarrito(CarritoModel request)
        {
            var Carrito = new Carrito
            {
                CarritoId = request.CarritoId,
                Estado = request.CarritoEstado,
                ClienteId = request.ClienteId,
        };
            await _command.InsertCarrito(Carrito);
            return Carrito;
        }

        public async Task<Carrito> UpdateCarrito(Carrito carrito)
        {
            await _command.UpdateCarrito(carrito);
            return carrito;
        }

        public async Task<Carrito> DeleteCarrito(Carrito carrito)
        {
            await _command.RemoveCarrito(carrito);
            return carrito;
        }

        public async Task<List<Carrito>> GetAllCarritos()
        {
            var Carritos = await _query.GetListCarritos();
            return Carritos;
        }

        public async Task<Carrito> GetCarritoById(Guid id)
        {
            var Carrito = await _query.GetCarrito(id);
            return Carrito;
        }
    }
}
