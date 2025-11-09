using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Views
{
    public class InputHelper
    {
        public static string GetValidInput(bool isNumeric = false, bool isDecimal =false )
        {
            string input;
            bool isValid = false;
            do
            {
                input = Console.ReadLine()?.Trim() ?? "";
                if (isNumeric && int.TryParse(input, out _))
                {
                    isValid = true;
                }
                else if (isDecimal && decimal.TryParse(input, out _))
                {
                    isValid = true;
                }
                else if (!string.IsNullOrEmpty(input) && (!isNumeric && !isDecimal))
                {
                    isValid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (isNumeric)
                    {
                        Console.WriteLine("Ingrese un numero entero valido");
                    }
                    else if (isDecimal)
                    {
                        Console.WriteLine("Error. Debe ingresar un numero decimal valido");
                    }
                    else
                    {
                        Console.WriteLine("Error, el campo no puede estar vacio");
                    }
                    
                    Console.ResetColor();
                    
                }

            } while (!isValid);
            return input;


        }
    }
}
