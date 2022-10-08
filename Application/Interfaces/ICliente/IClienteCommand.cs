using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICliente
{
    public interface IClienteCommand
    {
        Task InsertCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task RemoveCliente(Cliente cliente);
    }
}
