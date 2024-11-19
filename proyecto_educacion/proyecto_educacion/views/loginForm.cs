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

                // obtener ID profesor
                int idProfesor = 0;
                if (rol == "Profesor")
                {
                    idProfesor = loginController.ObtenerIdProfesor(usuario, contrasena);
                    if (idProfesor == 0)
                    {
                        MessageBox.Show("No se encontró un profesor con esas credenciales.");
                        return;
                    }
                    else
                    {

                        this.Hide();
                    }
                }

                // obtener ID estudiante
                int idEstudiante = 0;
                if (rol == "Estudiante")
                {
                    idEstudiante = loginController.ObtenerIdEstudiante(usuario, contrasena); // Obtener el ID del estudiante
                    if (idEstudiante == 0)
                    {
                        MessageBox.Show("No se encontró un estudiante con esas credenciales.");
                        return;
                    }
                    else
                    {
                        this.Hide();
                    }
                }

                

                // segun el rol abrir form
                if (rol == "Estudiante")
                {
                    estudianteAccessForm estudianteForm = new estudianteAccessForm(idEstudiante); // pasar id al form estudiantes
                    estudianteForm.FormClosed += new FormClosedEventHandler(Form_FormClosed); // cerrar el login
                    estudianteForm.Show();
                }
                else if (rol == "Profesor")
                {
                    profesorAccessForm profesorForm = new profesorAccessForm(idProfesor); // pasar id al form profesores
                    profesorForm.FormClosed += new FormClosedEventHandler(Form_FormClosed); // cerrar el login
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
            // cerrar el login cuando el form profesor o estudiante se cierra
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}


