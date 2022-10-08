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
    public class SelectCliente
    {
        public static async Task<Cliente> SelectExistingCliente()
        {
            using (var context = new AppDbContext())
            {
                ClienteCommand CommandCliente = new ClienteCommand(context);
                ClienteQuery QueryCliente = new ClienteQuery(context);
                ClienteServices ServicesCliente = new ClienteServices(CommandCliente, QueryCliente);
                int IdBuscada = 0;
                bool IdCorrecta = false;
                bool sigue = false;

                List<Cliente> Clientes = ServicesCliente.GetAllClientes().Result;

                foreach (Cliente cliente in Clientes)
                {
                    Console.WriteLine($"ID: {cliente.ClienteId}, nombre: {cliente.Nombre}, apellido: {cliente.Apellido}");
                }

                do
                {
                    try
                    {
                        do
                        {
                            IdCorrecta = false;
                            Console.Write("\nIngrese su ID de cliente: ");
                            IdBuscada = int.Parse(Console.ReadLine());
                            foreach (Cliente cliente in Clientes)
                            {
                                if (cliente.ClienteId == IdBuscada)
                                {
                                    IdCorrecta = true;
                                }
                            }
                            if (!IdCorrecta)
                            {
                                Console.WriteLine("\nID no válida. Por favor, reintente.");
                            }
                            sigue = false;
                        } while (!IdCorrecta);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nID no válida. Por favor, reintente.");
                        sigue = true;
                    }
                } while (sigue);

                Cliente ClienteBuscado = await ServicesCliente.GetClienteById(IdBuscada);
                return ClienteBuscado;
            }
        }
    }
}
