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
        // Método para obtener el ID del profesor por usuario y contraseña
        public int ObtenerIdProfesor(string usuario, string contrasena)
        {
            return ProfesorModel.ObtenerIdProfesor(usuario, contrasena); // Delegar la consulta al modelo
        }

        // Método para obtener los datos de un profesor por su id
        public ProfesorModel GetProfesorById(int idProfesor)
        {
            return ProfesorModel.GetProfesorById(idProfesor);
        }

        // Método para actualizar los datos del profesor
        public bool UpdateProfesor(ProfesorModel profesor)
        {
            return ProfesorModel.UpdateProfesor(profesor);
        }
    }

}

