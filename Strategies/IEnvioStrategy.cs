using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Threading.Tasks;

namespace Strategies
{
    public interface IEnvioStrategy
    {
        string Nombre { get; }
        decimal CalcularCosto(Pedido pedido);
    }
}
