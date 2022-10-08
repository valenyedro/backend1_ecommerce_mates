using Application.UseCase;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using PsTpIndividual.Menu;
using System.Security.Cryptography.X509Certificates;

var option = "";
while (option != "0")
{
    Console.WriteLine("*******************************");
    Console.WriteLine("*¡Bienvenido a la YedroTienda!*");
    Console.WriteLine("*******************************");
    Console.WriteLine("¿Qué desea hacer?\n\n" +
        "-Registrar cliente (1)\n" +
        "-Registrar venta (2)\n" +
        "-Reporte de ventas (3)\n" +
        "-Filtrar por producto en reporte de ventas (4)\n" +
        "-Salir (0)\n");

    Console.Write("Ingrese la opción deseada: ");
    option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Option1.ShowOption();
            break;
        case "2":
            Option2.ShowOption();
            break;
        case "3":
            Option3.showOption();
            break;
        case "4":
            Option4.ShowOption();
            break;
        case "0":
            Console.WriteLine("¡Hasta luego!");
            break;
        default:
            Console.WriteLine("\nOpción no válida. Por favor, presione cualquier tecla para reintentar.\n");
            Console.ReadKey();
            Console.Clear();
            break;
    }


}