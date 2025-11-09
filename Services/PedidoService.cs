using Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observers;

namespace Services
{
    public class PedidoService
    {
        private readonly List<IPedidoObserver> _observers = new List<IPedidoObserver>();

        public void Suscribir(IPedidoObserver observer)
        {
            _observers.Add(observer);
        }
        public void Desuscribir(IPedidoObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Confirmar(Pedido pedido)
        {
            foreach(var obs in _observers)
            {
                try { obs.OnPedidoConfirmado(pedido);  }
                catch 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("no se pudo notificar");
                }
            }
        }
    }
}
