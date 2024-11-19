using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using proyecto_educacion.models;

namespace proyecto_educacion.models
{
    public class EstudianteModel
    {
        private readonly ConnectionBD dbConnection = new ConnectionBD();

        // get y set
        public int Id { get; set; }
        public string Nom1 { get; set; }
        public string Nom2 { get; set; }
        public string Ape1 { get; set; }
        public string Ape2 { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaCreacion { get; set; }

        // obtener todos los estudiantes
        public List<EstudianteModel> GetAll()
        {
            List<EstudianteModel> estudiantes = new List<EstudianteModel>();
            string sql = "SELECT * FROM estudiante";

            using (MySqlConnection conn = dbConnection.DataSource())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EstudianteModel estudiante = new EstudianteModel
                            {
                                Id = reader.GetInt32("id_estudiante"),
                                Nom1 = reader.GetString("nom1_estudiante"),
                                Nom2 = reader["nom2_estudiante"] as string,
                                Ape1 = reader.GetString("ape1_estudiante"),
                                Ape2 = reader["ape2_estudiante"] as string,
                                Documento = reader.GetString("doc_estudiante"),
                                Email = reader.GetString("email_estudiante"),
                                Usuario = reader.GetString("usr_estudiante"),
                                Password = reader.GetString("pass_estudiante"),
                                Foto = reader["foto_estudiante"] as byte[],
                                FechaCreacion = reader.GetDateTime("fechacrea_estudiante")
                            };
                            estudiantes.Add(estudiante);
                        }
                    }
                }
            }
            return estudiantes;
        }

        // crear un estudiante
        public bool Create()
        {
            string sql = "INSERT INTO estudiante (nom1_estudiante, nom2_estudiante, ape1_estudiante, ape2_estudiante, doc_estudiante, email_estudiante, usr_estudiante, pass_estudiante, foto_estudiante, fechacrea_estudiante) VALUES (@Nom1, @Nom2, @Ape1, @Ape2, @Documento, @Email, @Usuario, @Password, @Foto, @FechaCreacion)";

            using (MySqlConnection conn = dbConnection.DataSource())  // Crear una nueva conexión
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nom1", Nom1);
                cmd.Parameters.AddWithValue("@Nom2", Nom2);
                cmd.Parameters.AddWithValue("@Ape1", Ape1);
                cmd.Parameters.AddWithValue("@Ape2", Ape2);
                cmd.Parameters.AddWithValue("@Documento", Documento);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Foto", Foto);
                cmd.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // actualizar un estudiante
        public bool Update()
        {
            string sql = "UPDATE estudiante SET nom1_estudiante = @Nom1, nom2_estudiante = @Nom2, ape1_estudiante = @Ape1, ape2_estudiante = @Ape2, doc_estudiante = @Documento, email_estudiante = @Email, usr_estudiante = @Usuario, pass_estudiante = @Password, foto_estudiante = @Foto WHERE doc_estudiante = @Documento";

            using (MySqlConnection conn = dbConnection.DataSource())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Nom1", Nom1);
                cmd.Parameters.AddWithValue("@Nom2", Nom2);
                cmd.Parameters.AddWithValue("@Ape1", Ape1);
                cmd.Parameters.AddWithValue("@Ape2", Ape2);
                cmd.Parameters.AddWithValue("@Documento", Documento);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Foto", Foto);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // eliminar un estudiante
        public bool Delete(string documento)
        {
            bool result = false;
            string sql = "DELETE FROM estudiante WHERE doc_estudiante = @Documento";

            using (MySqlConnection conn = dbConnection.DataSource())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Documento", documento);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public static int ObtenerIdEstudiante(string usuario, string contrasena)
        {
            int idEstudiante = 0;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "SELECT id_estudiante FROM estudiante WHERE usr_estudiante = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        //cmd.Parameters.AddWithValue("@password", contrasena);

                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            idEstudiante = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el ID del estudiante: " + ex.Message);
                }
            }
            return idEstudiante;
        }
    }
}


