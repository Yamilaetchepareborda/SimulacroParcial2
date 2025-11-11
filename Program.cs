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
            //instancias base
            var builder = new PedidoBuilder();
            var factory = new StrategyFactory(new EnvioMoto(), new EnvioRetiro(), new EnvioCorreo());
            var service = new PedidoService();

            //obsservadires (cliente + logistica)
            service.Suscribir(new ClienteObserver());
            service.Suscribir(new LogisticaObserver());

            //repositrio Json (persistencia local )
            var repo = new RepositorioJson<Pedido>("pedidos.json");

            //fachada principal
            var facade = new CheckoutFacade(builder, factory, service, repo);

            //vista consola
            var view = new ConsolaView(facade);

            view.MostrarMenu();
        }
    }
}
