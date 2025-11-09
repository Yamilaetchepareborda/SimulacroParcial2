using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public interface IPedidoObserver
    {
        void OnPedidoConfirmado(Pedido pedido);
    }
}
