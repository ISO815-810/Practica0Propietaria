using Practica0Pull.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica0Pull.Application
{
    class LeerLayout
    {
        static void Main(string[] args)
        {
            ConnectionDB connec = new ConnectionDB();

            Console.WriteLine("Ruta: ");
            string ruta = Console.ReadLine();

            Console.WriteLine("archivo: ");
            string archivo = Console.ReadLine();

            connec.LeerArchivo(ruta, archivo);
            Console.ReadLine();
        }
    }
}
