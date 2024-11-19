using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace proyecto_educacion.models
{
    public class ComentarioModel
    {
        public int IdComentario { get; set; }
        public string TxtComentario { get; set; }
        public DateTime FechaComentario { get; set; }
        public int IdEstudianteCom { get; set; }
        public int IdMaterialCom { get; set; }

        public static bool InsertComentario(ComentarioModel comentario)
        {
            bool resultado = false;
            ConnectionBD dbConnection = new ConnectionBD();
            using (MySqlConnection conn = dbConnection.DataSource())
            {
                try
                {
                    dbConnection.ConnectOpened(conn);

                    string query = "INSERT INTO comentario (txt_comentario, fecha_comentario, id_estudianteCom, id_materialCom) " +
                                   "VALUES (@TxtComentario, @FechaComentario, @IdEstudianteCom, @IdMaterialCom)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TxtComentario", comentario.TxtComentario);
                        cmd.Parameters.AddWithValue("@FechaComentario", comentario.FechaComentario.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@IdEstudianteCom", comentario.IdEstudianteCom);
                        cmd.Parameters.AddWithValue("@IdMaterialCom", comentario.IdMaterialCom);

                        cmd.ExecuteNonQuery();
                        resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar el comentario: " + ex.Message);
                }
                finally
                {
                    dbConnection.ConnectClosed(conn);
                }
            }
            return resultado;
        }

        public static List<ComentarioModel> GetComentariosByMaterial(int idMaterial)
        {
            List<ComentarioModel> comentarios = new List<ComentarioModel>();
            ConnectionBD dbConnection = new ConnectionBD();
            using (MySqlConnection conn = dbConnection.DataSource())
            {
                try
                {
                    dbConnection.ConnectOpened(conn);

                    string query = "SELECT * FROM comentario WHERE id_materialCom = @IdMaterialCom";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdMaterialCom", idMaterial);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ComentarioModel comentario = new ComentarioModel
                                {
                                    IdComentario = reader.GetInt32("id_comentario"),
                                    TxtComentario = reader.GetString("txt_comentario"),
                                    FechaComentario = reader.GetDateTime("fecha_comentario"),
                                    IdEstudianteCom = reader.GetInt32("id_estudianteCom"),
                                    IdMaterialCom = reader.GetInt32("id_materialCom")
                                };
                                comentarios.Add(comentario);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los comentarios: " + ex.Message);
                }
                finally
                {
                    dbConnection.ConnectClosed(conn);
                }
            }
            return comentarios;
        }
    }
}

