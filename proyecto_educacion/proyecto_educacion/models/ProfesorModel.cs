using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace proyecto_educacion.models
{
    public class ProfesorModel
    {
        public int Id { get; set; }
        public string Nom1 { get; set; }
        public string Nom2 { get; set; }
        public string Ape1 { get; set; }
        public string Ape2 { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        // Método para validar las credenciales de un profesor
        public static bool ValidarCredenciales(string usuario, string contrasena)
        {
            bool resultado = false;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Profesor WHERE Usuario = @usuario AND Password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", contrasena);

                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        resultado = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al validar las credenciales: " + ex.Message);
                }
            }
            return resultado;
        }

        // Método para obtener el ID del profesor por su usuario y contraseña
        public static int ObtenerIdProfesor(string usuario, string contrasena)
        {
            int idProfesor = 0;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "SELECT id_profesor FROM profesor WHERE usr_profesor = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        //cmd.Parameters.AddWithValue("@password", contrasena);

                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            idProfesor = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el ID del profesor: " + ex.Message);
                }
            }
            return idProfesor;
        }

        // Método para obtener los datos de un profesor por su ID
        public static ProfesorModel GetProfesorById(int idProfesor)
        {
            ProfesorModel profesor = null;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "SELECT * FROM profesor WHERE id_profesor = @Id;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idProfesor);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                profesor = new ProfesorModel
                                {
                                    Id = reader.GetInt32("id_profesor"),
                                    Nom1 = reader["nom1_profesor"].ToString(),
                                    Nom2 = reader["nom2_profesor"].ToString(),
                                    Ape1 = reader["ape1_profesor"].ToString(),
                                    Ape2 = reader["ape2_profesor"].ToString(),
                                    Documento = reader["doc_profesor"].ToString(),
                                    Email = reader["email_profesor"].ToString(),
                                    Usuario = reader["usr_profesor"].ToString(),
                                    Password = reader["pass_profesor"].ToString(),
                                    // Aquí puedes agregar la foto si la tienes
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los datos del profesor: " + ex.Message);
                }
            }
            return profesor;
        }

        // Método para actualizar la información de un profesor
        public static bool UpdateProfesor(ProfesorModel profesor)
        {
            bool resultado = false;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "UPDATE profesor SET nom1_profesor = @Nom1, nom2_profesor = @Nom2, ape1_profesor = @Ape1, ape2_profesor = @Ape2, doc_profesor = @Documento, email_profesor = @Email, usr_profesor = @Usuario, pass_profesor = @Password WHERE id_profesor = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom1", profesor.Nom1);
                        cmd.Parameters.AddWithValue("@Nom2", profesor.Nom2);
                        cmd.Parameters.AddWithValue("@Ape1", profesor.Ape1);
                        cmd.Parameters.AddWithValue("@Ape2", profesor.Ape2);
                        cmd.Parameters.AddWithValue("@Documento", profesor.Documento);
                        cmd.Parameters.AddWithValue("@Email", profesor.Email);
                        cmd.Parameters.AddWithValue("@Usuario", profesor.Usuario);
                        cmd.Parameters.AddWithValue("@Password", profesor.Password);
                        cmd.Parameters.AddWithValue("@Id", profesor.Id);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar los datos del profesor: " + ex.Message);
                }
            }
            return resultado;
        }
    }
}

