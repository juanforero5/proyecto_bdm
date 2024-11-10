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

        // Método para validar el login
        public bool ValidarLogin(string usuario, string contrasena, string rol)
        {
            return loginModel.ValidarUsuario(usuario, contrasena, rol);
        }

        // Método para obtener el id del profesor al validar las credenciales
        public int ObtenerIdProfesor(string usuario, string contrasena)
        {
            return ProfesorModel.ObtenerIdProfesor(usuario, contrasena); // Llamada al modelo para obtener el ID
        }

        // Método para obtener el id del estudiante al validar las credenciales
        public int ObtenerIdEstudiante(string usuario, string contrasena)
        {
            return EstudianteModel.ObtenerIdEstudiante(usuario, contrasena); // Llamada al modelo para obtener el ID
        }
    }
}
