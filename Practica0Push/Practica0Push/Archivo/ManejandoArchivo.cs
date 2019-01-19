using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica0Push.Archivo
{
    class ManejandoArchivo
    {
        public StreamWriter GenerarArchivo(string vRuta, string vArchivo)
        {
            string vPath = @"" + vRuta + vArchivo;

            StreamWriter vFile;
            return vFile = File.AppendText(vPath);

        }

        static void Main(string[] args)
        {
            ManejandoArchivo manejandoArchivo = new ManejandoArchivo();
            Console.WriteLine("Sr. Usuario introduzca la ruta: ");
            string ruta = Console.ReadLine();

            Console.WriteLine("Sr. Usuario introduzca el nombre del archivo: ");
            string archivo = Console.ReadLine();

            Console.WriteLine("Generando archivo...");
            manejandoArchivo.GenerarArchivo(ruta, archivo);

            Console.WriteLine("\narchivo generado...");
            Console.ReadLine();
        }
    }
}
