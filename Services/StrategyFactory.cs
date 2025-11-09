using Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StrategyFactory
    {
        private readonly EnvioMoto _moto;
        private readonly EnvioRetiro _retiro;
        private readonly EnvioCorreo _correo;

        public StrategyFactory(EnvioMoto moto, EnvioRetiro retiro, EnvioCorreo correo)
        {
            _moto = moto;
            _retiro = retiro;
            _correo = correo;
        }

        public IEnvioStrategy FromAlias(string alias)
        {
            switch (alias)
            {
                case "moto":
                    return _moto;
                case "retiro":
                    return _retiro;
                case "correo":
                    return _correo;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException($"Tipo de envio no reconocido. Usa: moto | correo | retiro");
            }
        }
    }
}
