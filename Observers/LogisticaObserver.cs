using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Observers
{
    public class LogisticaObserver : IPedidoObserver
    {
        public void OnPedidoConfirmado(Pedido pedido)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Logistica || Preparando el envio para {pedido.ClienteNombre}");
            Console.WriteLine($"Metodo de envio: {pedido.EnvioNombre}");
            Console.ResetColor();
        }
    }
}
