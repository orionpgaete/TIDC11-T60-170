using MensajeroModel.DAL;
using MensajeroModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mensajero.Comunicacion
{
    public class HebraServidor
    {
        private static IMensajesDAL mensajesDAL = MensajesDALArchivos.GetInstacia();
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
                    clienteCom.Escribir("Ingrese nombre");
                    string nombre = clienteCom.Leer();
                    clienteCom.Escribir("Ingrese texto: ");
                    string texto = clienteCom.Leer();
                    Mensaje mensaje = new Mensaje()
                    {
                        Nombre = nombre,
                        Texto = texto,
                        Tipo = "TCP"
                    };
                    mensajesDAL.AgregarMensaje(mensaje);
                    clienteCom.Desconectar();
                }
            }
            else
            {
                Console.WriteLine("Fail, no se puede conextar al server en {0}", puerto);
            }
        }
    }
}
