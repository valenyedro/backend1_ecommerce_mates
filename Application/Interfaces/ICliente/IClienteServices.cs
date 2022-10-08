using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICliente
{
    public interface IClienteServices
    {
        Task<Cliente> CreateCliente(ClienteModel request);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<Cliente> DeleteCliente(Cliente cliente);
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
    }
}
