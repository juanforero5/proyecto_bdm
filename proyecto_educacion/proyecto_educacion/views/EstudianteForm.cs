using proyecto_educacion.controllers;
using proyecto_educacion.models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;



namespace proyecto_educacion.views
{
    public partial class EstudianteForm : Form
    {
        private EstudianteController estudianteController = new EstudianteController();
        private Form formularioPrevio;

        public EstudianteForm(Form formularioAnterior)
        {
            InitializeComponent();
            dgvEstudiantes.CellClick += dgvEstudiantes_CellClick;
            CargarEstudiantes();
            formularioPrevio = formularioAnterior;
        }

        private void CargarEstudiantes()
        {
            List<EstudianteModel> estudiantes = estudianteController.GetAllEstudiantes();
            dgvEstudiantes.DataSource = estudiantes;

            dgvEstudiantes.Columns["Id"].Visible = false; 
            dgvEstudiantes.Columns["Nom1"].HeaderText = "Primer Nombre";
            dgvEstudiantes.Columns["Nom2"].HeaderText = "Segundo Nombre";
            dgvEstudiantes.Columns["Ape1"].HeaderText = "Primer Apellido";
            dgvEstudiantes.Columns["Ape2"].HeaderText = "Segundo Apellido";
            dgvEstudiantes.Columns["Documento"].HeaderText = "Documento";
            dgvEstudiantes.Columns["Email"].HeaderText = "Email";
            dgvEstudiantes.Columns["Usuario"].HeaderText = "Usuario";
            dgvEstudiantes.Columns["Password"].HeaderText = "Contraseña";
            dgvEstudiantes.Columns["FechaCreacion"].HeaderText = "Fecha creacion";
        }

        private void LimpiarCampos()
        {
            txtNom1.Clear();
            txtNom2.Clear();
            txtApe1.Clear();
            txtApe2.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            pictureBoxFoto.Image = null;
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Error al guardar la imagen: {ex.Message}");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("La imagen es nula.");
                return null;
            }
        }


        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            var estudiante = new EstudianteModel
            {
                Nom1 = txtNom1.Text,
                Nom2 = txtNom2.Text,
                Ape1 = txtApe1.Text,
                Ape2 = txtApe2.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                Usuario = txtUsuario.Text,
                Password = txtPassword.Text,
                FechaCreacion = DateTime.Now // Fecha actual
            };

            byte[] foto = ConvertImageToByteArray(pictureBoxFoto.Image);

            if (estudianteController.CreateEstudiante(estudiante, foto))
            {
                MessageBox.Show("Estudiante creado exitosamente.");
                CargarEstudiantes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al crear el estudiante.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var estudiante = new EstudianteModel
            {
                Nom1 = txtNom1.Text,
                Nom2 = txtNom2.Text,
                Ape1 = txtApe1.Text,
                Ape2 = txtApe2.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                Usuario = txtUsuario.Text,
                Password = txtPassword.Text
            };

            byte[] foto = ConvertImageToByteArray(pictureBoxFoto.Image);

            if (estudianteController.UpdateEstudiante(estudiante, foto))
            {
                MessageBox.Show("Estudiante actualizado exitosamente.");
                CargarEstudiantes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el estudiante.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Obtener el valor del documento de identidad (doc_estudiante) del campo de texto.
            string documento = txtDocumento.Text;

            // Verificar que el documento no esté vacío.
            if (!string.IsNullOrEmpty(documento))
            {
                // Llamar al método DeleteEstudiante pasando el documento de identidad.
                if (estudianteController.DeleteEstudianteByDocumento(documento))
                {
                    // Si la eliminación fue exitosa, mostrar un mensaje de éxito.
                    MessageBox.Show("Estudiante eliminado exitosamente.");

                    // Recargar la lista de estudiantes para reflejar los cambios.
                    CargarEstudiantes();

                    // Limpiar los campos del formulario.
                    LimpiarCampos();
                }
                else
                {
                    // Si no se pudo eliminar el estudiante, mostrar un mensaje de error.
                    MessageBox.Show("Error al eliminar el estudiante.");
                }
            }
            else
            {
                // Si el documento no es válido (vacío), mostrar un mensaje.
                MessageBox.Show("Selecciona un estudiante válido para eliminar.");
            }
        }


        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFoto.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEstudiantes.Rows[e.RowIndex];
                txtNom1.Text = row.Cells["Nom1"].Value.ToString();
                txtNom2.Text = row.Cells["Nom2"].Value.ToString();
                txtApe1.Text = row.Cells["Ape1"].Value.ToString();
                txtApe2.Text = row.Cells["Ape2"].Value.ToString();
                txtDocumento.Text = row.Cells["Documento"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();


                if (row.Cells["Foto"].Value != DBNull.Value && row.Cells["Foto"].Value != null)
                {
                    byte[] fotoBytes = (byte[])row.Cells["Foto"].Value;

                    // Verificar que el arreglo de bytes no esté vacío
                    if (fotoBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(fotoBytes))
                        {
                            pictureBoxFoto.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxFoto.Image = null; // Si el arreglo está vacío, no mostramos ninguna imagen
                    }
                }
                else
                {
                    pictureBoxFoto.Image = null; // Si el valor de la celda es nulo, eliminamos la imagen
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra EstudianteForm
            formularioPrevio.Show(); // Muestra el formulario previo
        }
    }
}

