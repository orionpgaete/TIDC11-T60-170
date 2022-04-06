using AdminPersonas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPersonasModel.DAL
{
    public class PersonasDALArchivos : IPersonasDAL
    {
        private static string archivo = "personas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;
        // C:/users/sistema/visual...../personas.txt
        public void AgregarPersona(Persona persona)
        {
            //1. crear el stremwriter
            //2. agregar un linea al archivo
            //3. cerrar el stremwriter

            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    string texto = persona.Nombre + ";" + persona.Estatura + ";" 
                                   + persona.Telefono + ";" + persona.Peso + ";";
                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error al escribir en archivo" + ex.Message);
            }finally
            {

            }
        }  

        public List<Persona> FiltrarPersonas(string nombre)
        {
            return ObtenerPersonas().FindAll(p => p.Nombre == nombre);
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();
            using(StreamReader reader = new StreamReader(ruta))
            {
                //leer desde el archivo hasta qe no haya nada
                string texto;
                do
                {
                    texto = reader.ReadLine();
                    if (texto != null)
                    {
                        string[] textoArr = texto.Trim().Split(';');
                        string nombre = textoArr[0];
                        double estatura = Convert.ToDouble(textoArr[1]);
                        uint telefono = Convert.ToUInt32(textoArr[2]);
                        double peso = Convert.ToDouble(textoArr[3]);
                        //crear una persona
                        Persona p = new Persona()
                        {
                            Nombre = nombre,
                            Estatura = estatura,
                            Telefono = telefono,
                            Peso = peso
                        };
                        //calcular IMC
                        p.calcularIMC();
                        //agregar a la lista
                        personas.Add(p);

                    }

                } while (texto != null);
            }
            return personas;
        }
    }
}
