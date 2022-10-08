using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarritoModel
    {
        public Guid CarritoId { get; set; }
        public bool CarritoEstado { get; set; }
        public int ClienteId { get; set; }
    }
}
