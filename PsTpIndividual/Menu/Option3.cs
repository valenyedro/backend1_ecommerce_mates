using PsTpIndividual.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsTpIndividual.Functions;

namespace PsTpIndividual.Menu
{
    public class Option3
    {
        public static void showOption()
        {
            Console.WriteLine("\n");
            PrintOrdenes.PrintOrden();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
