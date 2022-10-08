using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICarrito
{
    public interface ICarritoServices
    {
        Task<Carrito> CreateCarrito(CarritoModel request);
        Task<Carrito> UpdateCarrito(Carrito carrito);
        Task<Carrito> DeleteCarrito(Carrito carrito);
        Task<List<Carrito>> GetAllCarritos();
        Task<Carrito> GetCarritoById(Guid id);
    }
}
