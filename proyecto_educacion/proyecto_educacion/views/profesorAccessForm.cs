using System;
using System.Windows.Forms;
using proyecto_educacion.controllers;
using proyecto_educacion.models;
namespace proyecto_educacion.views
{
    public partial class profesorAccessForm : Form
    {
        private readonly ProfesorController profesorController;
        private int profesorId;  // ID del profesor logueado

        // Constructor: recibe el ID del profesor y lo inicializa
        public profesorAccessForm(int idProfesor)
        {
            InitializeComponent();
            profesorController = new ProfesorController();
            profesorId = idProfesor;  // Guardamos el id del profesor logueado
        }

        // Método para cargar los datos del profesor al iniciar el formulario
        private void CargarDatosProfesor()
        {
            ProfesorModel profesor = profesorController.GetProfesorById(profesorId);  // Obtener los datos del profesor desde la base de datos

            if (profesor != null)
            {
                // Llenar los campos del formulario con los datos obtenidos
                txtNom1.Text = profesor.Nom1;
                txtNom2.Text = profesor.Nom2;
                txtApe1.Text = profesor.Ape1;
                txtApe2.Text = profesor.Ape2;
                txtDocumento.Text = profesor.Documento;
                txtEmail.Text = profesor.Email;
                txtUsuario.Text = profesor.Usuario;
                txtPassword.Text = profesor.Password;
                // Aquí podrías también cargar la foto si fuera necesario
            }
            else
            {
                MessageBox.Show("No se encontraron datos del profesor.");
            }
        }

        // Evento de carga del formulario
        private void ProfesorAccessForm_Load(object sender, EventArgs e)
        {
            CargarDatosProfesor();  // Llamar al método para cargar los datos del profesor al cargar el formulario
        }

        // Evento del botón "Guardar"
        private void btnUpdateP_Click(object sender, EventArgs e)
        {
            // Crear un objeto de tipo ProfesorModel con los datos editados
            var profesorEditado = new ProfesorModel
            {
                Id = profesorId,  // Usamos el Id del profesor logueado
                Nom1 = txtNom1.Text,
                Nom2 = txtNom2.Text,
                Ape1 = txtApe1.Text,
                Ape2 = txtApe2.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                Usuario = txtUsuario.Text,
                Password = txtPassword.Text,
                // Aquí puedes incluir la foto si la estás editando
            };

            // Llamamos al método del controlador para actualizar la información
            if (profesorController.UpdateProfesor(profesorEditado))
            {
                MessageBox.Show("Información actualizada exitosamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar la información.");
            }
        }

        private void profesorAccessForm_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // En el formulario donde abres EstudianteForm
        private void btnGestionEst_Click(object sender, EventArgs e)
        {
            var estudianteForm = new EstudianteForm(this); // Pasamos el formulario actual como referencia
            this.Hide(); // Oculta el formulario actual
            estudianteForm.ShowDialog(); // Abre EstudianteForm de forma modal
            this.Show(); // Vuelve a mostrar el formulario actual al cerrar EstudianteForm
        }

    }
}

