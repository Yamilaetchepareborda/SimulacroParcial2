using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategies
{
    public class EnvioMoto : IEnvioStrategy
    {
        public string Nombre => "Moto";
        public decimal CalcularCosto(Pedido pedido)
        {
            var baseCosto = 1500m;
            var variable = 200m * pedido.Items.Count;
            if(variable > 2000m)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Excede el limite de moto, se enviara por correo");
                Console.ResetColor();
                return new EnvioCorreo().CalcularCosto(pedido);

            }
            return pedido.CostoEnvio = baseCosto + variable;
        }
    }
}
