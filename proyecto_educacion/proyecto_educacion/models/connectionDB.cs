using MySql.Data.MySqlClient;
using System;

namespace proyecto_educacion.models
{
    public class ConnectionBD
    {
        private readonly string connectionString = "server=127.0.0.1;database=proyecto_bdm;Uid=root;password=root;";

        // Método para obtener una nueva conexión
        public MySqlConnection DataSource()
        {
            return new MySqlConnection(connectionString);
        }

        public void ConnectOpened(MySqlConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void ConnectClosed(MySqlConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public bool ExecuteQuery(string sql)
        {
            bool result = false;
            MySqlConnection conn = null;
            try
            {
                conn = DataSource();  // Se crea una nueva conexión
                ConnectOpened(conn);
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hay un ERROR: " + ex.Message);
            }
            finally
            {
                if (conn != null) ConnectClosed(conn);  // Se cierra la conexión si está abierta
            }
            return result;
        }
    }
}

