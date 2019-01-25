using System;
using System.Data.SqlClient;
using System.IO;

namespace Practica0Pull.Conexion
{
    class ConnectionDB
    {

        private static string connectionString = @"Data Source=DELL-PC\MSSQLSERVER2016;Initial Catalog=TSS;Integrated Security=True";

        private static string INSERT_NOMINA = @"INSERT INTO Nomina VALUES(@TipoRegistro,@Rnc,@PeriodoNomina);";
        private static string INSERT_DETALLE_NOMINA = @"INSERT INTO Detalle_Nomina VALUES(@TipoRegistro,@Cedula,@Sueldo,@Numero_TSS);";


        public void LeerArchivo(string vRuta, string vArchivo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            //   string cadena = "a";

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"" + vRuta + vArchivo + ".txt"))
                {
                    Console.WriteLine("Leyendo Archivo...");
                    string[] partes = sr.ReadToEnd().Split(',');

                    try
                    {
                        SqlCommand command = new SqlCommand(INSERT_NOMINA, conn);

                        command.Parameters.AddWithValue("@TipoRegistro", partes[0]);
                        command.Parameters.AddWithValue("@Rnc", partes[1]);
                        command.Parameters.AddWithValue("@PeriodoNomina", partes[2]);
                        conn.Open();

                        //Console.WriteLine($"{partes[0]},{partes[1]},{partes[2]}");

                        int result = command.ExecuteNonQuery();
                        //conn.Close();
                        //Check Error
                        if (result < 0)
                            Console.WriteLine("Error insertando el encabezado en la BD!");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Error en Encabezado >>> \n" + e.StackTrace + "\n");
                    }


                    for (int i = 3; i <= partes.Length; i += 4)
                    {

                        Console.Write($"{partes[i]},{partes[i + 1]},{partes[i + 2]},{partes[i + 3]}");

                        try
                        {

                            SqlCommand command1 = new SqlCommand(INSERT_DETALLE_NOMINA, conn);
                            command1.Parameters.AddWithValue("@TipoRegistro", partes[i]);
                            command1.Parameters.AddWithValue("@Cedula", partes[i + 1]);
                            command1.Parameters.AddWithValue("@Sueldo", Int64.Parse(partes[i + 2]));
                            command1.Parameters.AddWithValue("@Numero_TSS", partes[i + 3]);

                            //SqlCommand command1 = new SqlCommand(INSERT_DETALLE_NOMINA, conn);
                            //command1.Parameters.AddWithValue("@TipoRegistro", "D");
                            //command1.Parameters.AddWithValue("@Cedula", "15995147852");
                            //command1.Parameters.AddWithValue("@Sueldo", 2);
                            //command1.Parameters.AddWithValue("@Numero_TSS", "369852147");


                            int result1 = command1.ExecuteNonQuery();

                            conn.Close();
                            // Check Error
                            if (result1 < 0)
                                Console.WriteLine("Error insertando los detalles en la BD!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nError en Detalle >>> \n" + e.StackTrace + "\n");
                        }


                    }

                    sr.Close();

                    //Console.WriteLine(partes[0].ToString());

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
