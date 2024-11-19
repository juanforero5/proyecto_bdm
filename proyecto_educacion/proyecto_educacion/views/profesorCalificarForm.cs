using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using proyecto_educacion.controllers;
using proyecto_educacion.models;

namespace proyecto_educacion.views
{
    public partial class profesorCalificarForm : Form
    {
        private readonly calificacionController CalificacionController;
        private int profesorId;
        private int? selectedMaterialId = null;

        public profesorCalificarForm(int idProfesor)
        {
            InitializeComponent();
            dgvMaterialC.SelectionChanged += dgvMaterialC_SelectionChanged;
            profesorId = idProfesor;
            CalificacionController = new calificacionController();
            CargarMateriales();
            btnDescargar.Enabled = false; // inactivar boton de descarga
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            //MessageBox.Show(selectedMaterialId.ToString());
        }

        private void CargarMateriales()
        {
            dgvMaterialC.AutoGenerateColumns = false;
            dgvMaterialC.Columns.Clear();

            // columna oculta para id material
            dgvMaterialC.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdMaterial",
                Name = "IdMaterial",
                Visible = false 
            });

            dgvMaterialC.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreEstudiante",
                HeaderText = "Estudiante"
            });
            dgvMaterialC.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TituloMaterial",
                Name = "TituloMaterial",
                HeaderText = "Título"
            });
            dgvMaterialC.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescMaterial",
                Name = "DescMaterial",
                HeaderText = "Descripción"
            });
            dgvMaterialC.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaMaterial",
                HeaderText = "Fecha publicación"
            });

            List<MaterialModel> materiales = CalificacionController.ObtenerTodosMaterialesEstudiante();
            dgvMaterialC.DataSource = materiales;
        }



        private void dgvMaterialC_SelectionChanged(object sender, EventArgs e)
        {
  
            if (dgvMaterialC.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMaterialC.SelectedRows[0]; // obtener fila seleccionada

                // obtener idmaterial
                selectedMaterialId = Convert.ToInt32(selectedRow.Cells["IdMaterial"].Value);

                // titulo y descripcion en txtbox
                txtTituloM.Text = selectedRow.Cells["TituloMaterial"].Value.ToString();
                txtDescM.Text = selectedRow.Cells["DescMaterial"].Value.ToString();

                btnDescargar.Enabled = true;
                CargarComentariosMaterial(selectedMaterialId.Value);
            }
            else
            {
                txtTituloM.Clear();
                txtDescM.Clear();
                btnDescargar.Enabled = false;
                dgvComentariosMaterial.DataSource = null;
            }
        }

        private void CargarComentariosMaterial(int idMaterial)
        {
            List<ComentarioModel> comentarios = CalificacionController.ObtenerComentariosPorMaterial(idMaterial);

            dgvComentariosMaterial.AutoGenerateColumns = false;
            dgvComentariosMaterial.Columns.Clear();

            dgvComentariosMaterial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TxtComentario",
                HeaderText = "Comentario"
            });
            dgvComentariosMaterial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaComentario",
                HeaderText = "Fecha"
            });

            dgvComentariosMaterial.DataSource = comentarios;
        }

        private void btnCalificar_Click_1(object sender, EventArgs e)
        {
            if (selectedMaterialId.HasValue)
            {
                int nota = Convert.ToInt32(txtNota.Text);  // obtener nota de txtNota
                string observaciones = txtObservaciones.Text;  // obtener observaciones de txtObservaciones

                try
                {
                    // insertar calificacion
                    CalificacionController.InsertarCalificacion(nota, observaciones, selectedMaterialId.Value, profesorId);

                    MessageBox.Show("Calificación guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // limpiar formulario
                    txtNota.Clear();
                    txtObservaciones.Clear();
                    txtTituloM.Clear();
                    txtDescM.Clear();

                    btnCalificar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la calificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnDescargar_Click_1(object sender, EventArgs e)
        {
            if (selectedMaterialId.HasValue)
            {
                byte[] archivo = CalificacionController.ObtenerArchivoMaterial(selectedMaterialId.Value);
                if (archivo != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = "archivo_material",
                        Filter = "Todos los archivos (*.*)|*.*"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, archivo);
                        MessageBox.Show("Archivo descargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo para este material.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMaterialC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

