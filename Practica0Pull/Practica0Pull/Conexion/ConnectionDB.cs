using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica0Pull.Conexion
{
    class ConnectionDB
    {

        private static string connectionString = @"Data Source=DELL-PC\MSSQLSERVER2016;Initial Catalog=TSS;Integrated Security=True";

        //static string SELECT_NOMINA = @"SELECT * FROM Nomina;";
        //static string SELECT_DETALLE_NOMINA = @"SELECT * FROM Detalle_Nomina;";

        private static string INSERT_NOMINA = @"INSERT INTO Nomina VALUES(@TipoRegistro,@Rnc,@PeriodoNomina);";
        private static string INSERT_DETALLE_NOMINA = @"INSERT INTO Detalle_Nomina VALUES(@TipoRegistro,@Cedula,@Sueldo,@Numero_TSS);";


        public void LeerArchivo(string vRuta, string vArchivo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string cadena = "a";

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"" + vRuta + vArchivo + ".txt"))
                {
                    Console.WriteLine("Archivo Leido....");
                    string[] partes = new string[] { sr.ReadToEnd() };

                    foreach (var partess in partes)
                    {
                        Console.WriteLine("aqui estan: " + partess);
                    }

                    while ((cadena = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("Probandoa ver si entra en el while.....");
                        switch (partes[0])
                        {
                            case "E":

                                partes = cadena.Split(',');
                                string Tipo_Registro = partes[0];
                                string RNC = partes[1];
                                string Periodo_Nomina = partes[2];

                                Console.WriteLine(Tipo_Registro + "," + RNC + "," + Periodo_Nomina);

                                try
                                {

                                    SqlCommand command = new SqlCommand(INSERT_NOMINA, conn);
                                    command.Parameters.AddWithValue("@TipoRegistro", Tipo_Registro);
                                    command.Parameters.AddWithValue("@Rnc", RNC);
                                    command.Parameters.AddWithValue("@PeriodoNomina", Periodo_Nomina);
                                    conn.Open();

                                    int result = command.ExecuteNonQuery();

                                    // Check Error
                                    if (result < 0)
                                        Console.WriteLine("Error insertando el encabezado en la BD!");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error Aqui viejo >>> " + e.StackTrace);
                                }

                                break;

                            case "D":

                                partes = cadena.Split(',');
                                string TipoRegistro = partes[0];
                                string Cedula = partes[1];
                                Int64 Sueldo = Int64.Parse(partes[2]);
                                string Numero_TSS = partes[3];

                                Console.WriteLine(TipoRegistro + "," + Cedula + "," + Sueldo + "," + Numero_TSS);

                                try
                                {

                                    SqlCommand command = new SqlCommand(INSERT_DETALLE_NOMINA, conn);
                                    command.Parameters.AddWithValue("@TipoRegistro", TipoRegistro);
                                    command.Parameters.AddWithValue("@Cedula", Cedula);
                                    command.Parameters.AddWithValue("@Sueldo", Sueldo);
                                    command.Parameters.AddWithValue("@Numero_TSS", Numero_TSS);
                                    conn.Open();

                                    int result = command.ExecuteNonQuery();

                                    // Check Error
                                    if (result < 0)
                                        Console.WriteLine("Error insertando los detalles en la BD!");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error Aqui viejo >>> " + e.StackTrace);
                                }
                                break;

                            default:
                                Console.WriteLine("Problemas");
                                break;
                        }
                    }

                    sr.Close();
                    Console.WriteLine("Archivo finalizado...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("El Archivo no pudo ser leido>>> ");
                Console.WriteLine(e.Message);
            }
        }


    }
}
