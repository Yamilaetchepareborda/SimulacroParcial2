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
            
            bool opcionValida = false;
            do
            {
                Console.WriteLine("Seleccion que tipo de envio quiere (moto | retiro | correo)");
                string opcion =Console.ReadLine()?.ToLower() ?? "";
                switch (opcion) {
                    case "moto":
                        opcionValida = true;
                        return _moto;
                    case "retiro":
                        opcionValida = true;
                        return _retiro;
                    case "correo":
                        opcionValida = true;
                        return _correo;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tipo de envio invalido, debe seleccionar: MOTO | RETIRO | CORREO:");
                        Console.ResetColor();
                        opcionValida = false;
                        break;
                }

            } while (!opcionValida);
            
            return _correo; // nunca retorna esto, es para que el compilador no se queje
          
        }
    }
}
