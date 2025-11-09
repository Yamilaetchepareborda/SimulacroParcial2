using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategies;
namespace Builders
{
    public class PedidoBuilder : IPedidoBuilder
    {
        private Pedido _pedido = new Pedido();
        public void Reset() => _pedido = new Pedido();

        public void SetCliente(string nombre, string direccion)
        {
            _pedido.ClienteNombre = nombre?.Trim() ?? "";

            _pedido.Direccion = direccion?.Trim() ?? ""; 
        }

        public void AddProducto (string nombre, decimal precio, int cantidad)
        {
            _pedido.Items.Add(new Producto {
                Nombre = nombre?.Trim() ?? "",
                Precio = precio,
                Cantidad = cantidad
            });
            _pedido.SubTotal = _pedido.Items.Sum(i => i.Total);
        }

        public void SetEnvio (IEnvioStrategy envio)
        {
            _pedido.EnvioNombre = envio.Nombre;
            _pedido.CostoEnvio = envio.CalcularCosto(_pedido.SubTotal);
            _pedido.Total = _pedido.SubTotal + _pedido.CostoEnvio;
        }
        public Pedido Build() => _pedido;
    }
}
