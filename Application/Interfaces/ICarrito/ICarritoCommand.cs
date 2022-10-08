using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICarrito
{
    public interface ICarritoCommand
    {
        Task InsertCarrito(Carrito carrito);
        Task UpdateCarrito(Carrito carrito);
        Task RemoveCarrito(Carrito carrito);
    }
}
