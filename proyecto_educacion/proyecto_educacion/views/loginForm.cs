using System;
using System.Windows.Forms;
using proyecto_educacion.controllers;
using proyecto_educacion.views;
using proyecto_educacion.models;
using System.Collections.Generic;

namespace proyecto_educacion.views
{
    public partial class LoginForm : Form
    {
        private readonly LoginController loginController;

        public LoginForm()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtPassword.Text;
            string rol = rbEstudiante.Checked ? "Estudiante" : (rbProfesor.Checked ? "Profesor" : "");

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Por favor ingrese todos los datos.");
                return;
            }

            bool loginExitoso = loginController.ValidarLogin(usuario, contrasena, rol);

            if (loginExitoso)
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                // Obtener el ID del profesor
                int idProfesor = 0;
                if (rol == "Profesor")
                {
                    idProfesor = loginController.ObtenerIdProfesor(usuario, contrasena); // Obtener el ID del profesor
                    if (idProfesor == 0)
                    {
                        MessageBox.Show("No se encontró un profesor con esas credenciales.");
                        return; // Si no se encuentra el ID, detén el flujo
                    }
                    else
                    {
                        // Ocultar el formulario de login
                        this.Hide();
                    }
                }

                // Obtener el ID del estudiante
                int idEstudiante = 0;
                if (rol == "Estudiante")
                {
                    idEstudiante = loginController.ObtenerIdEstudiante(usuario, contrasena); // Obtener el ID del estudiante
                    if (idEstudiante == 0)
                    {
                        MessageBox.Show("No se encontró un estudiante con esas credenciales.");
                        return; // Si no se encuentra el ID, detén el flujo
                    }
                    else
                    {
                        // Ocultar el formulario de login
                        this.Hide();
                    }
                }

                

                // Abrir el formulario correspondiente según el rol
                if (rol == "Estudiante")
                {
                    estudianteAccessForm estudianteForm = new estudianteAccessForm(idEstudiante); // Pasar el idEstudiante al formulario de estudiante
                    estudianteForm.FormClosed += new FormClosedEventHandler(Form_FormClosed); // Cerrar el login cuando se cierre el formulario Estudiante
                    estudianteForm.Show();
                }
                else if (rol == "Profesor")
                {
                    profesorAccessForm profesorForm = new profesorAccessForm(idProfesor); // Pasar el idProfesor al formulario de profesor
                    profesorForm.FormClosed += new FormClosedEventHandler(Form_FormClosed); // Cerrar el login cuando se cierre el formulario Profesor
                    profesorForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cerrar el formulario de login cuando el formulario de Estudiante o Profesor se cierre
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}


