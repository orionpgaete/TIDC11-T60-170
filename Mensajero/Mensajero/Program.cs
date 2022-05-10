﻿using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            mensajesDAL.AgregarMensaje(mensaje);
        }

        static void Mostrar()
        {
            List<Mensaje> mensajes = mensajesDAL.ObtenerMensajes();
            foreach(Mensaje mensaje in mensajes)
            {
                Console.WriteLine(mensaje);
            }
        }

    }
}
