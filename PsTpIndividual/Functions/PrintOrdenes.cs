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
    public class PrintOrdenes
    {
        public static async Task PrintOrden()
        {
            using (var context = new AppDbContext())
            {
                OrdenCommand CommandOrden = new OrdenCommand(context);
                OrdenQuery QueryOrden = new OrdenQuery(context);
                OrdenServices ServicesOrden = new OrdenServices(CommandOrden, QueryOrden);

                ProductoCommand CommandProducto = new ProductoCommand(context);
                ProductoQuery QueryProducto = new ProductoQuery(context);
                ProductoServices ServicesProducto = new ProductoServices(CommandProducto, QueryProducto);

                CarritoProductoCommand CommandCarritoProducto = new CarritoProductoCommand(context);
                CarritoProductoQuery QueryCarritoProducto = new CarritoProductoQuery(context);
                CarritoProductoServices ServicesCarritoProducto = new CarritoProductoServices(CommandCarritoProducto, QueryCarritoProducto);

                ClienteCommand CommandCliente = new ClienteCommand(context);
                ClienteQuery QueryCliente = new ClienteQuery(context);
                ClienteServices ServicesCliente = new ClienteServices(CommandCliente, QueryCliente);

                CarritoCommand CommandCarrito = new CarritoCommand(context);
                CarritoQuery QueryCarrito = new CarritoQuery(context);
                CarritoServices ServicesCarrito = new CarritoServices(CommandCarrito, QueryCarrito);

                List<Orden> Ordenes = ServicesOrden.GetAllOrdenes().Result;

                if (Ordenes.Count() == 0)
                {
                    Console.WriteLine("No se registraron ventas en el día.");
                }

                List<CarritoProducto> CarritoProds = await QueryCarritoProducto.GetListCarritoProductos();

                foreach (Orden orden in Ordenes)
                {
                    Carrito Carrito = ServicesCarrito.GetCarritoById(orden.CarritoId).Result;
                    Cliente Cliente = ServicesCliente.GetClienteById(Carrito.ClienteId).Result;
                    Console.WriteLine($"\nORDEN: {orden.OrdenId}\n");
                    Console.WriteLine($"FECHA: {orden.Fecha.ToString()}\n");

                    Console.WriteLine("CLIENTE:");
                    Console.WriteLine($"ID: {Cliente.ClienteId}, nombre: {Cliente.Nombre}, apellido: {Cliente.Apellido}, DNI: {Cliente.DNI}, dirección: {Cliente.Direccion}, teléfono: {Cliente.Telefono}. ");
                    Console.WriteLine("\nPRODUCTOS:");
                    
                    foreach (CarritoProducto carritoProducto in Carrito.CarritoProductos)
                    {
                        Producto Producto = ServicesProducto.GetProductoById(carritoProducto.ProductoId).Result;
                        Console.WriteLine($"ID: {Producto.ProductoId}, nombre: {Producto.Nombre}, marca: {Producto.Marca}, precio: ${Producto.Precio}, imagen: {Producto.Image}");
                    }
                    Console.WriteLine($"\nTOTAL: {orden.Total}");
                    Console.WriteLine("----------------------------------------------------------------");
                }
            }
        }
    }
}
