using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builders;
using Models;
using Repositories;
using Services;

namespace Facade
{
    public class CheckoutFacade
    {
        private readonly IPedidoBuilder _builder;
        private readonly StrategyFactory _factory;
        private readonly PedidoService _service;
        private readonly IRepositorio<Pedido> _repo;


        public CheckoutFacade(IPedidoBuilder builder, StrategyFactory factory, PedidoService service, IRepositorio<Pedido> repo)
        {
            _builder = builder;
            _factory = factory;
            _service = service;
            _repo = repo;
            _builder.Reset();
        }

        public void AgregarProducto(string nombre, decimal precio, int cantidad)
        {
            _builder.AddProducto(nombre, precio, cantidad);
        }

        public void SetCliente(string nombre, string direccion)
        {
            _builder.SetCliente(nombre, direccion);
        }
        public void SeleccionarEnvio(string alias)
        {
            var envio = _factory.FromAlias(alias);
            _builder.SetEnvio(envio);
        }
        public void ConfirmarPedido()
        {
            var pedido = _builder.Build();
            _service.Confirmar(pedido);
            _repo.Guardar(pedido);
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pedido guardado correctamente!");
                Console.ResetColor();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR] Al guardar el pedido");
                Console.ResetColor();
            }
           
        }

        public void ListarPedidos()
        {
            var pedidos = _repo.ObtenerTodos();
            if (!pedidos.Any())
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }
            Console.WriteLine("Pedidos guardados: ");

            foreach (var p in pedidos)
                Console.WriteLine($"- {p.ClienteNombre} |{p.EnvioNombre} | Total: {p.Total:C} ");
        }
    }
}
