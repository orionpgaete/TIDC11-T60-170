using HolaMunditoSocket.Comunicaciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HolaMunditoSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                //OK puede iniciar
                Console.WriteLine("Servidor Iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Cliente");
                    Socket socketCliente = servidor.ObtenerCliente();
                    //construir el mecanismo para escrile y leerle
                    ClienteCom cliente = new ClienteCom(socketCliente);
                    //aqui esta el protocolo de comunicacion, que ambos saben
                    cliente.Escribir("Hola Mundo cliente, dame tu nombre:");
                    string respuesta = cliente.Leer();
                    Console.WriteLine("El cliente dice: {0}", respuesta);
                    cliente.Escribir("Hasta la vista bei bei " + respuesta);
                    cliente.Desconectar();

                    //<CR><LF>
                }
            }
            else
            {
                Console.WriteLine("Error, el puerto {0} esta en uso", puerto);
            }

        }
    }
}
