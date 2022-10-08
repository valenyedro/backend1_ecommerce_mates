using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICarrito
{
    public interface ICarritoQuery
    {
        Task<List<Carrito>> GetListCarritos();
        Task<Carrito> GetCarrito(Guid id);
    }
}
