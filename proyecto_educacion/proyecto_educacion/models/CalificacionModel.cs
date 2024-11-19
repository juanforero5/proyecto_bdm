using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using proyecto_educacion.models;


namespace proyecto_educacion.models
{
    public class CalificacionModel
    {

        private readonly ConnectionBD dbConnection = new ConnectionBD();
        public int IdCalificacion { get; set; }
        public int NotaCalificacion { get; set; }
        public string DescripcionCalificacion { get; set; }
        public byte[] FileCalificacion { get; set; }
        public DateTime FechaCalificacion { get; set; }
        public int IdMaterialC { get; set; }
        public int IdProfesorP { get; set; }

        public void InsertarCalificacion(int nota, string descripcion, int idMaterial, int idProfesor)
        {
            try
            {
                // upsert nota calificación
                string query = @"
            INSERT INTO calificacion (nota_calificacion, descripcion_calificacion, id_materialC, id_profesorP, fecha_calificacion)
            VALUES (@nota, @descripcion, @idMaterial, @idProfesor, @fecha)
            ON DUPLICATE KEY UPDATE 
                nota_calificacion = VALUES(nota_calificacion),
                descripcion_calificacion = VALUES(descripcion_calificacion),
                fecha_calificacion = VALUES(fecha_calificacion);
        ";

                // crear conexión a la bd
                using (MySqlConnection conn = dbConnection.DataSource())
                {
                    dbConnection.ConnectOpened(conn);  // Abrir la conexión

                    // crear comando sql con los parametros
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nota", nota);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                        cmd.Parameters.AddWithValue("@idProfesor", idProfesor);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar o actualizar la calificación: " + ex.Message);
            }
        }

    }

}
