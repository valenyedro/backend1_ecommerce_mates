using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IProducto
{
    public interface IProductoCommand
    {
        Task InsertProducto(Producto producto);
        Task UpdateProducto(Producto producto);
        Task RemoveProducto(Producto producto);
    }
}
