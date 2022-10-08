using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using PsTpIndividual.Functions;

namespace PsTpIndividual.Menu
{
    public class Option1
    {
        public static void ShowOption()
        {
            Console.WriteLine("\n");
            CreateClienteInput.CreateCliente();
            Console.WriteLine("\nCliente registrado con éxito.\n" +
                "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
