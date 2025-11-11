using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Facade;

namespace Views
{
    public class ConsolaView
    {
        private readonly CheckoutFacade _facade;
        public ConsolaView(CheckoutFacade facade)
        {
            _facade = facade;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PEDIDOS ===");
                Console.WriteLine("1) Agregar producto");
                Console.WriteLine("2) Cargar cliente");
                Console.WriteLine("3) Seleccionar envío");
                Console.WriteLine("4) Confirmar pedido");
                Console.WriteLine("5) Listar pedidos guardados");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":

                        AgregarProducto();
                       
                        break;
                    case "2":
                       AgregarCliente();
                        break;
                    case "3":
                       SeleccionarEnvio();
                        break;
                    case "4":
                        _facade.ConfirmarPedido();
                        break;
                    case "5":
                        _facade.ListarPedidos();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;

                }
                Console.WriteLine("nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void AgregarProducto()
        {
            Console.WriteLine("Nombre del producto: ");
            var nombre = InputHelper.GetValidInput();
            Console.WriteLine("Precio: ");
            var precio = decimal.Parse(InputHelper.GetValidInput(isDecimal: true));
            Console.WriteLine("Cantidad:");
            var cantidad = int.Parse(InputHelper.GetValidInput(isNumeric: true));
            _facade.AgregarProducto(nombre, precio, cantidad);
        }

        public void AgregarCliente()
        {
            Console.WriteLine("Ingrese el nombre del Cliente:");
            var nombreCliente = InputHelper.GetValidInput();
            Console.WriteLine("Ingrese la direccion:");
            var direccion = InputHelper.GetValidInput();
            _facade.SetCliente(nombreCliente, direccion);
        }

        public void SeleccionarEnvio()
        {
            Console.WriteLine("Ingrese tipo de envío (moto / correo / retiro): ");
            var alias = Console.ReadLine()?.Trim().ToLower() ?? "retiro";
            _facade.SeleccionarEnvio(alias);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Envio Seleccionado con exito");
            Console.ResetColor();
        }
    }
}
