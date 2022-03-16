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
            Console.WriteLine("Hola Mundo");
            Console.WriteLine("Ingrese Nombre:");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese edad:");
            string edadTx = Console.ReadLine().Trim();
            // Trim()  = elimina espacios todos
            // TrimStart() = elimina espacios inicio
            // TrimEnd() = elimina espacios final 
            Console.WriteLine("su nombre es {0} y su edad {1}", nombre, edadTx);
            Console.ReadKey();
        }
    }
}
