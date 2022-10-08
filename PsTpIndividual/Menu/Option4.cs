using Application.Interfaces.ICarrito;
using Application.UseCase;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using PsTpIndividual.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PsTpIndividual.Menu
{
    public class Option4
    {
        public static void ShowOption()
        {
            using (var context = new AppDbContext())
            {
                OrdenCommand CommandOrden = new OrdenCommand(context);
                OrdenQuery QueryOrden = new OrdenQuery(context);
                OrdenServices ServicesOrden = new OrdenServices(CommandOrden, QueryOrden);

                CarritoCommand CommandCarrito = new CarritoCommand(context);
                CarritoQuery QueryCarrito = new CarritoQuery(context);
                CarritoServices ServicesCarrito = new CarritoServices(CommandCarrito, QueryCarrito);

                CarritoProductoCommand CommandCarritoProducto = new CarritoProductoCommand(context);
                CarritoProductoQuery QueryCarritoProducto = new CarritoProductoQuery(context);
                CarritoProductoServices ServicesCarritoProducto = new CarritoProductoServices(CommandCarritoProducto, QueryCarritoProducto);

                ClienteCommand CommandCliente = new ClienteCommand(context);
                ClienteQuery QueryCliente = new ClienteQuery(context);
                ClienteServices ServicesCliente = new ClienteServices(CommandCliente, QueryCliente);

                List<Producto> Productos = PrintProductos.PrintProducts();
                int IdBuscada = 0;
                bool IdCorrecta = true;
                do
                {
                    try
                    {

                        Console.Write("\nIngrese el ID de producto que desea ver en detalle en lista de ventas: ");
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
                        IdCorrecta = false;
                    }
                } while (!IdCorrecta);


                List<Orden> Ordenes = ServicesOrden.GetAllOrdenes().Result;
                List<Orden> OrdenesConProducto = new List<Orden>();
                List<CarritoProducto> CarritoProds = QueryCarritoProducto.GetListCarritoProductos().Result;
                foreach (Orden orden in Ordenes)
                {
                    
                    Carrito carrito = QueryCarrito.GetCarrito(orden.CarritoId).Result;
                    foreach (CarritoProducto carritoProducto in carrito.CarritoProductos)
                    {
                        OrdenesConProducto.Add(orden);
                        break;
                    }
                }

                if (OrdenesConProducto.Count == 0)
                {
                    Console.WriteLine("\nNo existen ventas que incluyan el producto solicitado.");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

                

                foreach (Orden orden in OrdenesConProducto)
                {
                    Cliente Cliente = ServicesCliente.GetClienteById(orden.Carrito.ClienteId).Result;
                    Console.WriteLine($"\nORDEN: {orden.OrdenId}\n");
                    Console.WriteLine($"FECHA: {orden.Fecha.ToString()}\n");
                    Console.WriteLine("CLIENTE:\n");
                    Console.WriteLine($"ID: {Cliente.ClienteId}, nombre: {Cliente.Nombre}, apellido: {Cliente.Apellido}, DNI: {Cliente.DNI}, dirección: {Cliente.Direccion}, teléfono: {Cliente.Telefono}. ");
                    Console.WriteLine("----------------------------------------------------------------");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
