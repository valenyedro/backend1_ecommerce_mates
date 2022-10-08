using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito
    {
        public Carrito()
        {
            this.CarritoProductos = new List<CarritoProducto>();
        }

        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }
        public IList<CarritoProducto> CarritoProductos { get; set; }

        public Orden Orden { get; set; }
        public Cliente Cliente { get; set; }
    }
}
