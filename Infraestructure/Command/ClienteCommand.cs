using Application.Interfaces.ICliente;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly AppDbContext _context;

        public ClienteCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCliente(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
