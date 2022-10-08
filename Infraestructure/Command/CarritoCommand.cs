using Application.Interfaces.ICarrito;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class CarritoCommand : ICarritoCommand
    {
        private readonly AppDbContext _context;

        public CarritoCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertCarrito(Carrito carrito)
        {
            _context.Add(carrito);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveCarrito(Carrito carrito)
        {
            _context.Remove(carrito);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarrito(Carrito carrito)
        {
            _context.Update(carrito);
            await _context.SaveChangesAsync();
        }
    }
}
