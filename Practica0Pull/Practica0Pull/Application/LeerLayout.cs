using Practica0Pull.Conexion;
using System;

namespace Practica0Pull.Application
{
    class LeerLayout
    {
        static void Main(string[] args)
        {
            ConnectionDB connec = new ConnectionDB();

            Console.WriteLine("Digite la Ruta del archivo: ");
            string ruta = Console.ReadLine();

            Console.WriteLine("Digite el nombre del archivo: ");
            string archivo = Console.ReadLine();

            connec.LeerArchivo(ruta, archivo);
            Console.ReadLine();
        }
    }
}
