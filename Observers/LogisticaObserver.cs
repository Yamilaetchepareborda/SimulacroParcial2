using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public class LogisticaObserver : IPedidoObserver
    {
        public void OnPedidoConfirmado(Models.Pedido pedido)
        {
            Console.WriteLine($"Logistica || Preparando el envio para {pedido.ClienteNombre}");
            Console.WriteLine($"Metodo de envio: {pedido.EnvioNombre}");
        }
    }
}
