using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace proyecto_educacion.models
{
    public class MaterialModel
    {
        public int IdMaterial { get; set; }
        public string TituloMaterial { get; set; }
        public string DescMaterial { get; set; }
        public byte[] FicheroMaterial { get; set; }
        public DateTime FechaMaterial { get; set; }
        public int? IdCalificacion { get; set; }
        public int IdEstudiante { get; set; }

        public static List<MaterialModel> GetMaterialesByEstudianteId(int idEstudiante)
        {
            var materiales = new List<MaterialModel>();

            using (var conn = new ConnectionBD().DataSource())
            {
                string query = "SELECT * FROM material WHERE id_estudianteE = @IdEstudiante";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            materiales.Add(new MaterialModel
                            {
                                IdMaterial = reader.GetInt32("id_material"),
                                TituloMaterial = reader["titulo_material"].ToString(),
                                DescMaterial = reader["desc_material"].ToString(),
                                FechaMaterial = reader.GetDateTime("fecha_material"),
                                IdCalificacion = reader.IsDBNull(reader.GetOrdinal("id_calificacionC")) ? (int?)null : reader.GetInt32("id_calificacionC"),
                                IdEstudiante = reader.GetInt32("id_estudianteE")
                            });
                        }
                    }
                }
            }
            return materiales;
        }

        public static bool InsertMaterial(MaterialModel material)
        {
            bool resultado = false;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "INSERT INTO material (titulo_material, desc_material, fichero_material, fecha_material, id_estudianteE) " +
                                   "VALUES (@Titulo, @Descripcion, @Fichero, @Fecha, @EstudianteId)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", material.TituloMaterial);
                        cmd.Parameters.AddWithValue("@Descripcion", material.DescMaterial);
                        cmd.Parameters.AddWithValue("@Fichero", material.FicheroMaterial);
                        cmd.Parameters.AddWithValue("@Fecha", material.FechaMaterial);
                        cmd.Parameters.AddWithValue("@EstudianteId", material.IdEstudiante);

                        conn.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar el material: " + ex.Message);
                }
            }
            return resultado;
        }

        public static bool UpdateMaterial(int idMaterial, string titulo, string descripcion, byte[] archivo, DateTime fechaMaterial)
        {
            bool resultado = false;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "UPDATE material SET titulo_material = @Titulo, desc_material = @Descripcion, fichero_material = @Archivo, fecha_material = @Fecha " +
                                   "WHERE id_material = @IdMaterial";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", titulo);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Archivo", archivo);
                        cmd.Parameters.AddWithValue("@Fecha", fechaMaterial);
                        cmd.Parameters.AddWithValue("@IdMaterial", idMaterial);

                        conn.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el material: " + ex.Message);
                }
            }
            return resultado;
        }


        public static bool DeleteMaterial(int idMaterial)
        {
            bool resultado = false;
            using (var conn = new ConnectionBD().DataSource())
            {
                try
                {
                    string query = "DELETE FROM material WHERE id_material = @IdMaterial";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdMaterial", idMaterial);

                        conn.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el material: " + ex.Message);
                }
            }
            return resultado;
        }
    }
}

