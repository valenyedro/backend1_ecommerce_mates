using Application.Interfaces.IProducto;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class ProductoCommand : IProductoCommand
    {
        private readonly AppDbContext _context;

        public ProductoCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertProducto(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProducto(Producto producto)
        {
            _context.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
