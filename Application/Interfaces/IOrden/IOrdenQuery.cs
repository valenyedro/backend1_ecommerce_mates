using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IOrden
{
    public interface IOrdenQuery
    {
        Task<List<Orden>> GetListOrdenes();
        Task<Orden> GetOrden(Guid id);
    }
}
