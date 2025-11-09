using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategies
{
    public class EnvioMoto : IEnvioStrategy
    {
        public string Nombre => "Envío por Moto";
        public decimal CalcularCosto(decimal subtotal) => 1500m;
    }
}
