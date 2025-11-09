using Builders;
using Facade;
using Models;
using Repositories;
using Services;
using Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Observers;

namespace SimulacroYam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new PedidoBuilder();
            var factory = new StrategyFactory(new EnvioMoto(), new EnvioRetiro(), new EnvioCorreo());
            var service = new PedidoService();
            service.Suscribir(new ClienteObserver());
            service.Suscribir(new LogisticaObserver());
            var repo = new RepositorioJson<Pedido>("pedidos.json");

            var facade = new CheckoutFacade(builder, factory, service, repo);
            var view = new ConsolaView(facade);

            view.MostrarMenu();
        }
    }
}
