using Application.Interfaces.ICarrito;
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
    public class CarritoQuery : ICarritoQuery
    {
        private readonly AppDbContext _context;

        public CarritoQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Carrito> GetCarrito(Guid id)
        {
            var Carrito = await _context.Carrito.FirstOrDefaultAsync(c => c.CarritoId == id);
            return Carrito;
        }

        public async Task<List<Carrito>> GetListCarritos()
        {
            var Carritos = await _context.Carrito.ToListAsync();
            return Carritos;
        }
    }
}
