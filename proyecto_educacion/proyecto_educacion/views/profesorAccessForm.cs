using System;
using System.Windows.Forms;
using proyecto_educacion.controllers;
using proyecto_educacion.models;
namespace proyecto_educacion.views
{
    public partial class profesorAccessForm : Form
    {
        private readonly ProfesorController profesorController;
        private int profesorId; 

        // inicializar y recibir id profesor
        public profesorAccessForm(int idProfesor)
        {
            InitializeComponent();
            profesorController = new ProfesorController();
            profesorId = idProfesor;  // id del profesor logueado
        }

        // cargar datos del profesor
        private void CargarDatosProfesor()
        {
            ProfesorModel profesor = profesorController.GetProfesorById(profesorId);

            if (profesor != null)
            {
                txtNom1.Text = profesor.Nom1;
                txtNom2.Text = profesor.Nom2;
                txtApe1.Text = profesor.Ape1;
                txtApe2.Text = profesor.Ape2;
                txtDocumento.Text = profesor.Documento;
                txtEmail.Text = profesor.Email;
                txtUsuario.Text = profesor.Usuario;
                txtPassword.Text = profesor.Password;
            }
            else
            {
                MessageBox.Show("No se encontraron datos del profesor.");
            }
        }

        private void ProfesorAccessForm_Load(object sender, EventArgs e)
        {
            CargarDatosProfesor(); 
        }

        private void btnUpdateP_Click(object sender, EventArgs e)
        {
            // objeto profesor
            var profesorEditado = new ProfesorModel
            {
                Id = profesorId,  // profesor logueado
                Nom1 = txtNom1.Text,
                Nom2 = txtNom2.Text,
                Ape1 = txtApe1.Text,
                Ape2 = txtApe2.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                Usuario = txtUsuario.Text,
                Password = txtPassword.Text,
            };

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

        private void btnGestionEst_Click(object sender, EventArgs e)
        {
            var estudianteForm = new EstudianteForm(this);
            this.Hide();
            estudianteForm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idProfesor = profesorId;

            var formularioCalificar = new profesorCalificarForm(idProfesor);

            formularioCalificar.ShowDialog();
        }

    }
}

