using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IOrden
{
    public interface IOrdenCommand
    {
        Task InsertOrden(Orden orden);
        Task UpdateOrden(Orden orden);
        Task RemoveOrden(Orden orden);
    }
}
