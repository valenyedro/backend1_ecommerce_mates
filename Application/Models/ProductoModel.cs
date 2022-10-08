using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductoModel
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; }
        public string ProductoMarca { get; set; }
        public string ProductoCodigo { get; set; }
        public decimal ProductoPrecio { get; set; }
        public string ProductoImage { get; set; }
    }
}
