using System;
using System.Collections.Generic;
using proyecto_educacion.models;

namespace proyecto_educacion.controllers
{
    public class estudianteAccessController
    {
        public List<MaterialModel> ObtenerMaterialesEstudiante(int idEstudiante)
        {
            return MaterialModel.GetMaterialesByEstudianteId(idEstudiante);
        }

        public bool CreateMaterial(MaterialModel material)
        {
            try
            {
                return MaterialModel.InsertMaterial(material);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el material: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarMaterial(int idMaterial, string titulo, string descripcion, byte[] archivo, DateTime fechaMaterial)
        {
            return MaterialModel.UpdateMaterial(idMaterial, titulo, descripcion, archivo, fechaMaterial);
        }

        public bool EliminarMaterial(int idMaterial)
        {
            return MaterialModel.DeleteMaterial(idMaterial);
        }

        public bool CrearComentario(ComentarioModel comentario)
        {
            try
            {
                return ComentarioModel.InsertComentario(comentario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el comentario: " + ex.Message);
                return false;
            }
        }
    }
}

