using Mensajero.Comunicacion;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mensajero
{
    class Program
    {
        private static IMensajesDAL mensajesDAL = MensajesDALArchivos.GetInstacia();

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("¿Que quiere hacer");
            Console.WriteLine(" 1. Ingresar \n 2. Mostrar \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1": Ingresar();
                    break;
                case "2": Mostrar();
                    break;
                case "0": continuar = false;
                    break;
                default: Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }

   
        static void Main(string[] args)
        {
            //1. iniciar el servidor socket en el puerto 3000
            //2. el puerto tiene que ser configurable app.config
            //3. cuando reciba un cliente, tiene que solicitar a ese cliente el nombre y texto,
            //   y agregar un nuevo mensaje con el tipo TCP
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (Menu()) ;
        }

        static void Ingresar()
        {
            Console.WriteLine("Ingrese nombre: ");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese texto :");
            string texto = Console.ReadLine().Trim();
            Mensaje mensaje = new Mensaje()
            {
                Nombre = nombre,
                Texto = texto,
                Tipo = "Aplicacion"
            };
            lock (mensajesDAL)
            {
                mensajesDAL.AgregarMensaje(mensaje);
            }
            
        }

        //ThreadSafe

        static void Mostrar()
        {
            List<Mensaje> mensajes = null;
            lock (mensajesDAL)
            {
                mensajes = mensajesDAL.ObtenerMensajes();
            }

            foreach(Mensaje mensaje in mensajes)
            {
                Console.WriteLine(mensaje);
            }
        }

    }
}
