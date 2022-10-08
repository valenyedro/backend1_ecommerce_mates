using Application.Interfaces.ICarrito;
using Application.Interfaces.ICliente;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteCommand _command;
        private readonly IClienteQuery _query;

        public ClienteServices(IClienteCommand command, IClienteQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Cliente> CreateCliente(ClienteModel request)
        {
            var Cliente = new Cliente
            {
                DNI = request.ClienteDNI,
                Nombre = request.ClienteNombre,
                Apellido = request.ClienteApellido,
                Direccion = request.ClienteDireccion,
                Telefono = request.ClienteTelefono
            };
            await _command.InsertCliente(Cliente);
            return Cliente;
        }
        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            await _command.UpdateCliente(cliente);
            return cliente;
        }

        public async Task<Cliente> DeleteCliente(Cliente cliente)
        {
            await _command.RemoveCliente(cliente);
            return cliente;
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            var Clientes = await _query.GetListClientes();
            return Clientes;
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            var Cliente = await _query.GetCliente(id);
            return Cliente;
        }

    }
}
