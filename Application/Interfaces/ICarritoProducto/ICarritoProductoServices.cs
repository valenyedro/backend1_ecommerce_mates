using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoServices
    {
        Task<CarritoProducto> CreateCarritoProducto(CarritoProductoModel request);
        Task<CarritoProducto> UpdateCarritoProducto(CarritoProducto carritoProducto);
        Task<CarritoProducto> DeleteCarritoProducto(CarritoProducto carritoProducto);
        Task<List<CarritoProducto>> GetAllCarritoProductos();
        Task<CarritoProducto> GetCarritoProductoById(Guid carritoId);
    }
}
