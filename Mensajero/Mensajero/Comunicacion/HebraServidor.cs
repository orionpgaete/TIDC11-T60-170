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

namespace Mensajero.Comunicacion
{
    public class HebraServidor
    {
       
        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);
            Console.WriteLine("S: Iniciando servidor en puerto {0}", puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("S: Esperando Cliente...");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("S: Cliente recibido");

                    //esto era lo de generar comunicacion
                    ClienteCom clienteCom = new ClienteCom(cliente);

                    HebraCliente clienteHebra = new HebraCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteHebra.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                   
                }
            }
            else
            {
                Console.WriteLine("Fail, no se puede conextar al server en {0}", puerto);
            }
        }
    }
}
