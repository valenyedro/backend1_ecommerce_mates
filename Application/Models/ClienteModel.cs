using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ClienteModel
    {
        public string ClienteDNI { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteTelefono { get; set; }
        public ICollection<Carrito> Carritos { get; set; }
    }
}
