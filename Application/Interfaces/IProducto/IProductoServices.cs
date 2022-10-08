using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IProducto
{
    public interface IProductoServices
    {
        Task<Producto> CreateProducto(ProductoModel request);
        Task<Producto> UpdateProducto(Producto cliente);
        Task<Producto> DeleteProducto(Producto cliente);
        Task<List<Producto>> GetAllProductos();
        Task<Producto> GetProductoById(int id);
    }
}
