using Application.Interfaces.ICarritoProducto;
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
    public class CarritoProductoQuery : ICarritoProductoQuery
    {
        private readonly AppDbContext _context;

        public CarritoProductoQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CarritoProducto> GetCarritoProducto(Guid carritoId)
        {
            var CarritoProducto = await _context.CarritoProducto.FirstOrDefaultAsync(c => c.CarritoId == carritoId);
            return CarritoProducto;
        }

        public async Task<List<CarritoProducto>> GetListCarritoProductos()
        {
            var CarritoProductos = await _context.CarritoProducto.ToListAsync();
            return CarritoProductos;
        }
    }
}
