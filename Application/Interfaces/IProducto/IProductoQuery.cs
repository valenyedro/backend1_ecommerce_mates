using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IProducto
{
    public interface IProductoQuery
    {
        Task<List<Producto>> GetListProductos();
        Task<Producto> GetProducto(int id);
    }
}
