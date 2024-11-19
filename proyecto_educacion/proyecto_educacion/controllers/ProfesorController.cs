using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_educacion.models;

namespace proyecto_educacion.controllers
{
    public class ProfesorController
    {
        // obtener id profesor
        public int ObtenerIdProfesor(string usuario, string contrasena)
        {
            return ProfesorModel.ObtenerIdProfesor(usuario, contrasena);
        }

        // obtener datos del profesor x id
        public ProfesorModel GetProfesorById(int idProfesor)
        {
            return ProfesorModel.GetProfesorById(idProfesor);
        }

        // actualizar datos profesor
        public bool UpdateProfesor(ProfesorModel profesor)
        {
            return ProfesorModel.UpdateProfesor(profesor);
        }
    }

}

