using Models;
using Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategies
{
    public class EnvioCorreo : IEnvioStrategy
    {
        public string Nombre => "correo";
        public decimal CalcularCosto(Pedido pedido)
        {
            var baseCost = 5000m;
            var varible = 150m * pedido.Items.Count;
            return pedido.CostoEnvio = baseCost + varible;
        }
    }
}
