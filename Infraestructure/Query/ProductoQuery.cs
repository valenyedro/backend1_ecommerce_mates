using Application.Interfaces.IProducto;
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
    public class ProductoQuery : IProductoQuery
    {
        private readonly AppDbContext _context;

        public ProductoQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> GetProducto(int id)
        {
            var Producto = await _context.Producto.FirstOrDefaultAsync(c => c.ProductoId == id);
            return Producto;
        }

        public async Task<List<Producto>> GetListProductos()
        {
            var Productos = await _context.Producto.ToListAsync();
            return Productos;
        }
    }
}
