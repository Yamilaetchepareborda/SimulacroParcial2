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
        public string Nombre => "Envío por correo";
        public decimal CalcularCosto(decimal subtotal) => subtotal * 0.1m;
    }
}
