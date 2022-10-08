using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            this.Carritos = new List<Carrito>();
        }

        public int ClienteId { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }


        public ICollection<Carrito> Carritos { get; set; }

    }
}
