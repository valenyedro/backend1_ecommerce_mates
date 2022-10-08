using Application.Interfaces.ICliente;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly AppDbContext _context;

        public ClienteQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            var Cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.ClienteId == id);
            return Cliente;
        }

        public async Task<List<Cliente>> GetListClientes()
        {
            var Clientes = await _context.Cliente.ToListAsync();
            return Clientes;
        }
    }
}
