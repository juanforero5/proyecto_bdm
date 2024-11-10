using proyecto_educacion.models;
using proyecto_educacion.controllers;
using System.Collections.Generic;

namespace proyecto_educacion.controllers
{
    public class EstudianteController
    {
        private EstudianteModel estudianteModel = new EstudianteModel();

        public List<EstudianteModel> GetAllEstudiantes()
        {
            return estudianteModel.GetAll();
        }

        public bool CreateEstudiante(EstudianteModel estudiante, byte[] foto)
        {
            estudiante.Foto = foto;
            return estudiante.Create();
        }

        public bool UpdateEstudiante(EstudianteModel estudiante, byte[] foto)
        {
            estudiante.Foto = foto;
            return estudiante.Update();
        }

        public bool DeleteEstudianteByDocumento(string documento)
        {
            return estudianteModel.Delete(documento);
        }
    }
}

