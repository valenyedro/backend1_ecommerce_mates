using Application.Interfaces.IOrden;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class OrdenCommand : IOrdenCommand
    {
        private readonly AppDbContext _context;

        public OrdenCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertOrden(Orden orden)
        {
            _context.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveOrden(Orden orden)
        {
            _context.Remove(orden);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrden(Orden orden)
        {
            _context.Update(orden);
            await _context.SaveChangesAsync();
        }
    }
}
