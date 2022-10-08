using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICliente
{
    public interface IClienteQuery
    {
        Task<List<Cliente>> GetListClientes();
        Task<Cliente> GetCliente(int id);
    }
}
