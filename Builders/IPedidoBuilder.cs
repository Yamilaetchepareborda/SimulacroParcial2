using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategies;


namespace Builders
{
    public interface IPedidoBuilder
    {
        void Reset();
        void SetCliente(string nombre, string direccion);   
        void AddProducto(string nombre, decimal precio, int cantidad);
        void SetEnvio(IEnvioStrategy envio);
        Pedido Build();
    }
}
