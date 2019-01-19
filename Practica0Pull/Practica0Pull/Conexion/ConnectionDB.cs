using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica0Pull.Conexion
{
    class ConnectionDB
    {

        static string connectionString = @"Data Source=DELL-PC\MSSQLSERVER2016;Initial Catalog=TSS;Integrated Security=True";

        static string SELECT_NOMINA = @"SELECT * FROM Nomina;";
        static string SELECT_DETALLE_NOMINA = @"SELECT * FROM Detalle_Nomina;";

        static string INSERT_NOMINA = @"INSERT INTO Nomina VALUES(@TipoRegistro,@Rnc,@PeriodoNomina);";
        static string INSERT_DETALLE_NOMINA = @"INSERT INTO Detalle_Nomina VALUES(@TipoRegistro,@Cedula,@Sueldo,@Numero_TSS);";



    }
}
