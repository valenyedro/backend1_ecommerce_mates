using Application.Interfaces.IOrden;
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
    public class OrdenQuery : IOrdenQuery
    {
        private readonly AppDbContext _context;

        public OrdenQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Orden> GetOrden(Guid id)
        {
            var Orden = await _context.Orden.FirstOrDefaultAsync(o => o.OrdenId == id);
            return Orden;
        }
        public async Task<List<Orden>> GetListOrdenes()
        {
            var Ordenes = await _context.Orden.ToListAsync();
            return Ordenes;
        }
    }
}
