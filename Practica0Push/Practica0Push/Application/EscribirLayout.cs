using Practica0Push.Archivo;
using Practica0Push.Conexion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica0Push.Application
{
    class EscribirLayout
    {
        public static ManejandoArchivo manejandoArchivo = new ManejandoArchivo();
        public static Consulta consulta = new Consulta();

        static void Main(string[] args)
        {

            Console.WriteLine("Sr. Usuario introduzca la ruta: ");
            string vRuta = Console.ReadLine();

            Console.WriteLine("Sr. Usuario introduzca el nombre del archivo: ");
            string vArchivo = Console.ReadLine();

            Console.WriteLine("Sr. Usuario introduzca el periodo de nomina que requiere: ");
            string periodoNomina = Console.ReadLine();

            Console.WriteLine("Generando archivo...");

            try
            {
                string vPath = @"" + vRuta + vArchivo + ".txt";
                FileStream strm = File.Create(vPath);

                List<string> encabezado = consulta.GetEncabezado(periodoNomina);
                List<string> detalles = consulta.GetDetalle(periodoNomina);
                List<string> sumarios = consulta.GetSumario(periodoNomina);

                TextWriter writer = new StreamWriter(strm);
                foreach (var encabezadoLista in encabezado)
                {
                    writer.WriteLine(encabezadoLista);
                }


                foreach (var detalleList in detalles)
                {
                    writer.WriteLine(detalleList);
                }


                foreach (var sumarioList in sumarios)
                {
                    writer.WriteLine(sumarioList);
                }

                writer.Close();
                Console.WriteLine("\nArchivo generado con exito...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hay un error aqui >>> " + e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
