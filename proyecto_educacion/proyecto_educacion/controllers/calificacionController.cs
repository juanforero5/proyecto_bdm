using System;
using System.Collections.Generic;
using proyecto_educacion.models;

namespace proyecto_educacion.controllers
{
    public class calificacionController
    {
        private CalificacionModel calificacionModel = new CalificacionModel();

        public List<MaterialModel> ObtenerTodosMaterialesEstudiante()
        {
            return MaterialModel.GetAllMaterialesByEstudiante();
        }

        public byte[] ObtenerArchivoMaterial(int idMaterial)
        {
            return MaterialModel.GetArchivoById(idMaterial);
        }

        public void InsertarCalificacion(int nota, string descripcion, int idMaterial, int idProfesor)
        {
            try
            {
                calificacionModel.InsertarCalificacion(nota, descripcion, idMaterial, idProfesor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el controlador: " + ex.Message);
            }
        }

        public List<ComentarioModel> ObtenerComentariosPorMaterial(int idMaterial)
        {
            try
            {
                return ComentarioModel.GetComentariosByMaterial(idMaterial);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener comentarios: " + ex.Message);
            }
        }
    }
}

