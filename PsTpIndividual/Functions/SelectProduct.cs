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
    public class SelectProducto
    {
        public static async Task<Producto> SelectProductById()
        {
            using (var context = new AppDbContext())
            {
                ProductoCommand CommandProducto = new ProductoCommand(context);
                ProductoQuery QueryProducto = new ProductoQuery(context);
                ProductoServices ServicesProducto = new ProductoServices(CommandProducto, QueryProducto);
                int IdBuscada = 0;
                bool IdCorrecta = true;

                List<Producto> Productos = ServicesProducto.GetAllProductos().Result;

                foreach (Producto producto in Productos)
                {
                    Console.WriteLine($"ID: {producto.ProductoId}\nNombre: {producto.Nombre}\nDescripción: {producto.Descripcion}\nMarca: {producto.Marca}\nPrecio: {producto.Precio}\n");
                }

                do
                {
                    try
                    {

                        Console.Write("\nIngrese su ID de producto para agregar al carrito: ");
                        IdCorrecta = true;
                        IdBuscada = int.Parse(Console.ReadLine());
                        if (IdBuscada > Productos.Count || IdBuscada < 1)
                        {
                            Console.WriteLine("\nID no válida. Por favor, reintente.");
                            IdCorrecta = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nID no válida. Por favor, reintente.");
                        IdCorrecta=false;
                    }
                } while (!IdCorrecta);

                Producto ProductoBuscado = await ServicesProducto.GetProductoById(IdBuscada);
                return ProductoBuscado;
            }
        }
    }
}
