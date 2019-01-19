using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica0Push.Conexion
{
    class ConnectionDB
    {
        static string connectionString = @"Data Source=DELL-PC\MSSQLSERVER2016;Initial Catalog=FerreteriaAmericana;Integrated Security=True";
        static SqlConnection conn = new SqlConnection(connectionString);
        
        public static void EstablecerConexion()
        {
            
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             
        }

  
        public void CerrarConexion()
        {
            conn.Close();
        }

      
    }
}
