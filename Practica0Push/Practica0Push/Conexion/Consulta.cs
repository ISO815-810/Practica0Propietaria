﻿using System;
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
        static string SELECT_SUMARIO = @"SELECT  COUNT(d.Id) AS Total_Empleados, SUM(d.Sueldo_Bruto) AS Total_Nomina FROM Detalles AS d INNER JOIN EncabezadoDetalle AS ed ON ed.DetalleId = d.Id INNER JOIN Encabezados        AS e  ON e.Id = ed.EncabezadoId WHERE e.Periodo_Nomina = '02/12/2012';";


        public static List<string> getEncabezado(string strPeriodoNomina)
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
                    string Periodo_Nomina = dataReader.GetString(1);
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


    }
}