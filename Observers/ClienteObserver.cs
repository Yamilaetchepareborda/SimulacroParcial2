using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public class ClienteObserver : IPedidoObserver
    {
        public void OnPedidoConfirmado(Pedido pedido)
        {
            Console.WriteLine($"Cliente || Pedido confirmado para {pedido.ClienteNombre}");
            Console.WriteLine($"Total a pagar: {pedido.Total}");
            Console.WriteLine($"Envio: {pedido.EnvioNombre}");
        }
    }
}
