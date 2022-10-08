using Application.UseCase;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using PsTpIndividual.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsTpIndividual.Menu
{
    public class Option2
    {
        public static void ShowOption()
        {
            decimal Total = 0;
            List<int> ListaIds= new List<int>();
            string Option = "";
            bool IdElegida = false;
            Cliente Cliente = new Cliente();
            Console.WriteLine("¿Quiere registrar la venta con un cliente existente o con uno nuevo?\n\n" +
                "-Existente (1)\n" +
                "-Nuevo (2)\n");
            while (Option != "0") {
                Console.Write("Ingrese la opción deseada: ");
                Option = Console.ReadLine();
                if(Option == "1")
                {
                    Cliente = SelectCliente.SelectExistingCliente().Result;
                    Console.WriteLine($"\n¡Bienvenido {Cliente.Nombre} {Cliente.Apellido}!\n\n" +
                        "Seleccione el producto que desea agregar al carrito.");
                    Option = "0";
                } else if(Option == "2")
                {
                    Cliente = CreateClienteInput.CreateCliente().Result;
                    Console.WriteLine("\nCliente registrado con éxito.\n\n" +
                        "Seleccione el producto que desea agregar al carrito.");
                    Option = "0";
                } else
                {
                    Console.WriteLine("\nOpción no válida. Por favor, presione cualquier tecla para reintentar.\n");
                    Console.ReadKey();
                }
            }
            Carrito CarritoCliente = CreateCarritoModel.CreateCarrito(ref Cliente);

            bool sigueAgregando = true;

            while (sigueAgregando)
            {
                Producto ProductoElegido;
                do
                {
                    IdElegida = false;
                    ProductoElegido = SelectProducto.SelectProductById().Result;
                    if (ListaIds.Contains(ProductoElegido.ProductoId))
                    {
                        Console.WriteLine("\nProducto ya agregado en esta venta. Para comprarlo de nuevo se debe registrar otra venta\n\nPresione cualquier tecla para ingresar uno distinto.");
                        Console.ReadKey();
                        IdElegida = true;
                    }
                } while (IdElegida);
                ListaIds.Add(ProductoElegido.ProductoId);
                bool Valido = true;
                int Cantidad = 0;
                do
                {
                    try
                    {
                        Console.Write("\nIngrese la cantidad deseada del producto: ");
                        Valido = true;
                        Cantidad = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato inválido. Por favor, reintente.");
                        Valido = false;
                    }
                } while (!Valido);
                Total += Cantidad * ProductoElegido.Precio;
                CarritoProducto CarritoProductoCreado = CreateCarritoProductoModel.CreateCarritoProducto(CarritoCliente.CarritoId, ProductoElegido.ProductoId, Cantidad).Result;
                CarritoCliente.CarritoProductos.Add(CarritoProductoCreado);
                ProductoElegido.CarritoProductos.Add(CarritoProductoCreado);

                string sigue;
                do
                {
                    Console.Write("\n¿Quieres seguir agregando productos? S/N ");
                    sigue = Console.ReadLine();
                    if (sigue.ToUpper() == "S")
                        sigueAgregando = true;
                    else if (sigue.ToUpper() == "N")
                        sigueAgregando = false;
                    else
                        Console.WriteLine("Formato inválido. Por favor, reintentar");
                } while (sigue.ToUpper() != "S" && sigue.ToUpper() != "N");
            }

            CreateOrdenModel.CreateOrden(CarritoCliente.CarritoId, Total);
            CarritoCliente.Estado = false;
            UpdateCarrito.UpdateCarritoDb(CarritoCliente);

            Console.WriteLine($"\n¡Venta registrada con exito! El total ha sido de ${Total}.\n" +
                "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
