using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarritoProductoModel
    {
        public Guid CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
