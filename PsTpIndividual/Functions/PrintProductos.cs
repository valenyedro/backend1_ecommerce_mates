using Application.UseCase;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsTpIndividual.Functions
{
    public class PrintProductos
    {
        public static List<Producto> PrintProducts()
        {
            using (var context = new AppDbContext())
            {
                ProductoCommand CommandProducto = new ProductoCommand(context);
                ProductoQuery QueryProducto = new ProductoQuery(context);
                ProductoServices ServicesProducto = new ProductoServices(CommandProducto, QueryProducto);
                List<Producto> Productos = ServicesProducto.GetAllProductos().Result;

                foreach (Producto producto in Productos)
                {
                    Console.WriteLine($"ID: {producto.ProductoId}\nNombre: {producto.Nombre}\nDescripción: {producto.Descripcion}\nMarca: {producto.Marca}\nPrecio: {producto.Precio}\n");
                }

                return Productos;
            }
        }
    }
}
