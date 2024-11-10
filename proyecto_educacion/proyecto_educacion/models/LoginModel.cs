using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using proyecto_educacion.models;

namespace proyecto_educacion.models
{
    public class LoginModel
    {
        private readonly ConnectionBD dbConnection;

        public LoginModel()
        {
            dbConnection = new ConnectionBD();
        }

        public bool ValidarUsuario(string usuario, string contrasena, string rol)
        {
            bool loginExitoso = false;

            string sql = rol == "Estudiante" ?
                "SELECT * FROM estudiante WHERE usr_estudiante = @Usuario AND pass_estudiante = @Contrasena" :
                "SELECT * FROM profesor WHERE usr_profesor = @Usuario AND pass_profesor = @Contrasena";

            using (MySqlConnection conn = dbConnection.DataSource())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            loginExitoso = true;
                        }
                    }
                }
            }

            return loginExitoso;
        }
    }
}
