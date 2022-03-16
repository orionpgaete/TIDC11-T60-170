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
            string nombre = Console.ReadLine();
            Console.WriteLine("Su nombre es {0} ", nombre);
            Console.ReadKey();
        }
    }
}
