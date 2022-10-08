using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoCommand
    {
        Task InsertCarritoProducto(CarritoProducto carritoProducto);
        Task UpdateCarritoProducto(CarritoProducto carritoProducto);
        Task RemoveCarritoProducto(CarritoProducto carritoProducto);
    }
}
