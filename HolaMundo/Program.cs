using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //uso de la consola
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("Hola Mundo");
            Console.WriteLine("Ingrese Nombre:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("INACAP");
            Console.ReadKey();
        }
    }
}
