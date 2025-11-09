using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class Pedido
    {
        public string ClienteNombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public List<Producto> Items { get; set; } = new List<Producto>();
        public string EnvioNombre { get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public decimal CostoEnvio { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;

    }
}
