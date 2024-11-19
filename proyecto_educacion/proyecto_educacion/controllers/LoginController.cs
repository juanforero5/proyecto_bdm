using System;
using System.Windows.Forms;
using proyecto_educacion.models;
using proyecto_educacion.views;
using System.Collections.Generic;

namespace proyecto_educacion.controllers
{
    public class LoginController
    {
        private readonly LoginModel loginModel;

        public LoginController()
        {
            loginModel = new LoginModel();
        }

        // valida usuario login
        public bool ValidarLogin(string usuario, string contrasena, string rol)
        {
            return loginModel.ValidarUsuario(usuario, contrasena, rol);
        }

        // obtener el id del profesor luego de validar
        public int ObtenerIdProfesor(string usuario, string contrasena)
        {
            return ProfesorModel.ObtenerIdProfesor(usuario, contrasena);
        }

        // obtener el id del estudiante luego de validar
        public int ObtenerIdEstudiante(string usuario, string contrasena)
        {
            return EstudianteModel.ObtenerIdEstudiante(usuario, contrasena);
        }
    }
}
