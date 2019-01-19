using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Practica0Push.Conexion
{
    class Consulta
    {

        static string connectionString = @"Data Source=DELL-PC\MSSQLSERVER2016;Initial Catalog=FerreteriaAmericana;Integrated Security=True";

        static string SELECT_ENCABEZADO = @"SELECT Tipo_Registro, RNC, Periodo_Nomina FROM Encabezados WHERE Periodo_Nomina = @periodoNomina;";
        static string SELECT_DETALLE = @"SELECT d.Tipo_Registro, d.Cedula, d.Sueldo_Bruto, d.Numero_TSS FROM Detalles AS d INNER JOIN EncabezadoDetalle AS ed ON ed.DetalleId = d.Id INNER JOIN Encabezados AS e  ON e.Id = ed.EncabezadoId WHERE e.Periodo_Nomina = @periodoNomina;";
        static string SELECT_SUMARIO = @"SELECT COUNT(d.Id), SUM(d.Sueldo_Bruto) FROM Detalles AS d INNER JOIN EncabezadoDetalle AS ed ON ed.DetalleId = d.Id INNER JOIN Encabezados AS e  ON e.Id = ed.EncabezadoId WHERE e.Periodo_Nomina = @periodoNomina;";


        public List<string> GetEncabezado(string strPeriodoNomina)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(SELECT_ENCABEZADO, conn);
            List<string> encabezadosList = new List<string>();

            command.Parameters.AddWithValue("@periodoNomina", strPeriodoNomina);
            conn.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    string Tipo_Registro = dataReader.GetString(0);
                    string RNC = dataReader.GetString(1);
                    string Periodo_Nomina = dataReader.GetString(2);
                    //Console.WriteLine(Tipo_Registro + "," + RNC + "," + Periodo_Nomina);
                    encabezadosList.Add(Tipo_Registro + "," + RNC + "," + Periodo_Nomina);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Ha fallado la cosa viejo" + e.StackTrace);
            }
            finally
            {
                dataReader.Close();
                conn.Close();
            }


            return encabezadosList;
        }




        public List<string> GetDetalle(string strPeriodoNomina)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(SELECT_DETALLE, conn);
            List<string> detallesList = new List<string>();

            command.Parameters.AddWithValue("@periodoNomina", strPeriodoNomina);
            conn.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    string Tipo_Registro = dataReader.GetString(0);
                    string Cedula = dataReader.GetString(1);
                    Int64 Sueldo_Bruto = dataReader.GetInt64(2);
                    string Numero_TSS = dataReader.GetString(3);

                    //Console.WriteLine(Tipo_Registro + "," + RNC + "," + Periodo_Nomina);
                    detallesList.Add(Tipo_Registro + "," + Cedula + "," + Sueldo_Bruto + "," + Numero_TSS);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Ha fallado la cosa viejo" + e.StackTrace);
            }
            finally
            {
                dataReader.Close();
                conn.Close();
            }


            return detallesList;
        }




        public List<string> GetSumario(string strPeriodoNomina)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(SELECT_SUMARIO, conn);
            List<string> sumarioList = new List<string>();

            command.Parameters.AddWithValue("@periodoNomina", strPeriodoNomina);
            conn.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {

                    Int32 Total_Empleados = dataReader.GetInt32(0);
                    Int64 Monto_Total = dataReader.GetInt64(1);

                    sumarioList.Add("S," + Total_Empleados + "," + Monto_Total);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Ha fallado la cosa viejo" + e.StackTrace);
            }
            finally
            {
                dataReader.Close();
                conn.Close();
            }


            return sumarioList;
        }

        //static void Main(string[] args)
        //{
        //    Consulta consulta = new Consulta();
        //    Console.WriteLine("Periodo de nomina: ");
        //    string strPeriodoNomina = Console.ReadLine();

        //    List<string> encabezado = consulta.GetSumario(strPeriodoNomina);

        //    for (int i = 0; i < encabezado.Count; i++)
        //    {
        //        Console.WriteLine(encabezado[i]);
        //    }

        //    Console.ReadLine();
        //}

    }
}
