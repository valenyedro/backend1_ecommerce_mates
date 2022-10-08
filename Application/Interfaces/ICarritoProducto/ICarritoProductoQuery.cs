using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoQuery
    {
        Task<List<CarritoProducto>> GetListCarritoProductos();
        Task<CarritoProducto> GetCarritoProducto(Guid carritoId);
    }
}
