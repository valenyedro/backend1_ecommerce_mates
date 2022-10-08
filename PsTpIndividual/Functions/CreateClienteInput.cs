using Application.Models;
using Application.UseCase;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PsTpIndividual.Functions
{
    public class CreateClienteInput
    {
        public static async Task<Cliente> CreateCliente() {
            using (var context = new AppDbContext()) {
                ClienteCommand CommandCliente = new ClienteCommand(context);
                ClienteQuery QueryCliente = new ClienteQuery(context);
                ClienteServices ServicesCliente = new ClienteServices(CommandCliente, QueryCliente);

                List<Cliente> Clientes = ServicesCliente.GetAllClientes().Result;
                bool Duplicated = false;

                string ClienteDNI;
                string ClienteNombre;
                string ClienteApellido;
                string ClienteDireccion;
                string ClienteTelefono;

                do
                {
                    Duplicated = false;   
                    Console.Write("Ingrese el DNI del cliente a registrar: \n");
                    ClienteDNI = Console.ReadLine();
                    if (ClienteDNI.Length > 10)
                        Console.WriteLine("Máximo de caracteres excedido (10). Por favor, reintente.\n");
                    else if (ClienteDNI.Length < 2)
                        Console.WriteLine("Mínimo de caracteres no alcanzado (2). Por favor, reintente.\n");
                    foreach (Cliente Client in Clientes)
                    {
                        if (Client.DNI == ClienteDNI)
                        {
                            Duplicated = true;
                            Console.WriteLine("El DNI ingresado ya está registrado. Ingrese uno diferente.\n");
                        }
                    }
                } while (ClienteDNI.Length > 10 || ClienteDNI.Length < 2 || Duplicated == true);

                do
                {
                    Console.Write("Ingrese el nombre del cliente a registrar: \n");
                    ClienteNombre = Console.ReadLine();
                    if (ClienteNombre.Length > 25)
                        Console.WriteLine("Máximo de caracteres excedido (25). Por favor, reintente.\n");
                    else if (ClienteNombre.Length < 2)
                        Console.WriteLine("Mínimo de caracteres no alcanzado (2). Por favor, reintente.\n");
                } while (ClienteNombre.Length > 25 || ClienteNombre.Length < 2);

                do
                {
                    Console.Write("Ingrese el apellido del cliente a registrar: \n");
                    ClienteApellido = Console.ReadLine();
                    if (ClienteApellido.Length > 25)
                        Console.WriteLine("Máximo de caracteres excedido (25). Por favor, reintente.\n");
                    else if (ClienteApellido.Length < 2)
                        Console.WriteLine("Mínimo de caracteres no alcanzado (2). Por favor, reintente.\n");
                } while (ClienteApellido.Length > 25 || ClienteApellido.Length < 2);

                do
                {
                    Console.Write("Ingrese la dirección del cliente a registrar: \n");
                    ClienteDireccion = Console.ReadLine();
                    if (ClienteDireccion.Length > 200)
                        Console.WriteLine("Máximo de caracteres excedido (200). Por favor, reintente.\n");
                    else if (ClienteDireccion.Length < 2)
                        Console.WriteLine("Mínimo de caracteres no alcanzado (2). Por favor, reintente.\n");
                } while (ClienteDireccion.Length > 200 || ClienteDireccion.Length < 2);
                
                do
                {
                    Console.Write("Ingrese el teléfono del cliente a registrar: \n");
                    ClienteTelefono = Console.ReadLine();
                    if (ClienteTelefono.Length > 13)
                        Console.WriteLine("Máximo de caracteres excedido (13). Por favor, reintente.\n");
                    else if (ClienteTelefono.Length < 2)
                        Console.WriteLine("Mínimo de caracteres no alcanzado (2). Por favor, reintente.\n");
                } while (ClienteTelefono.Length > 13 || ClienteTelefono.Length < 2);

                ClienteModel ModelCliente = new ClienteModel
                {
                    ClienteDNI = ClienteDNI,
                    ClienteNombre = ClienteNombre,
                    ClienteApellido = ClienteApellido,
                    ClienteDireccion = ClienteDireccion,
                    ClienteTelefono = ClienteTelefono,
                };

                return await ServicesCliente.CreateCliente(ModelCliente);
            }
        }
    }
}
