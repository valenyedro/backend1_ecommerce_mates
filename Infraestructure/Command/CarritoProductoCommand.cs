using Application.Interfaces.ICarritoProducto;
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
    public class CarritoProductoCommand : ICarritoProductoCommand
    {
        private readonly AppDbContext _context;

        public CarritoProductoCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Add(carritoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Remove(carritoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Update(carritoProducto);
            await _context.SaveChangesAsync();
        }
    }
}
