using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using proyecto_educacion.controllers;
using proyecto_educacion.models;

namespace proyecto_educacion.views
{
    public partial class estudianteAccessForm : Form
    {
        private readonly estudianteAccessController EstudianteAccessController;
        private int idEstudiante;
        private int idMaterialSeleccionado;

        public estudianteAccessForm(int EstudianteId)
        {
            InitializeComponent();
            EstudianteAccessController = new estudianteAccessController();
            idEstudiante = EstudianteId;
        }

        private void estudianteAccessForm_Load(object sender, EventArgs e)
        {
            CargarMateriales();
        }

        private void CargarMateriales()
        {
            List<MaterialModel> materiales = EstudianteAccessController.ObtenerMaterialesEstudiante(idEstudiante);
            dataGridViewMateriales.DataSource = materiales;

            // Configuración de las columnas del DataGridView
            dataGridViewMateriales.Columns["IdMaterial"].Visible = false;
            dataGridViewMateriales.Columns["TituloMaterial"].HeaderText = "Titulo";
            dataGridViewMateriales.Columns["DescMaterial"].HeaderText = "Descripción";
            dataGridViewMateriales.Columns["FechaMaterial"].HeaderText = "Fecha publicación";
            dataGridViewMateriales.Columns["IdCalificacion"].HeaderText = "id_calificación";
            dataGridViewMateriales.Columns["IdEstudiante"].HeaderText = "id_estudiante";
        }

        private void btnCreateM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTituloM.Text) || string.IsNullOrEmpty(txtDescM.Text) || string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var material = new MaterialModel
            {
                TituloMaterial = txtTituloM.Text,
                DescMaterial = txtDescM.Text,
                FechaMaterial = DateTime.Now,
                IdEstudiante = idEstudiante,
                FicheroMaterial = ConvertFileToByteArray(openFileDialog1.FileName)
            };

            bool resultado = EstudianteAccessController.CreateMaterial(material);
            if (resultado)
            {
                MessageBox.Show("Material creado exitosamente.");
                CargarMateriales();
                LimpiarCamposMaterial();
            }
            else
            {
                MessageBox.Show("Error al crear el material.");
            }
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos PDF|*.pdf|Archivos Word|*.docx|Archivos Excel|*.xlsx|Imágenes PNG|*.png";
            openFileDialog1.Title = "Seleccione un archivo";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblTituloFile.Text = openFileDialog1.FileName;
            }
        }

        private void dataGridViewMateriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMateriales.Rows[e.RowIndex];
                txtTituloM.Text = row.Cells["TituloMaterial"].Value.ToString();
                txtDescM.Text = row.Cells["DescMaterial"].Value.ToString();
                idMaterialSeleccionado = Convert.ToInt32(row.Cells["IdMaterial"].Value);
            }
        }

        private void btnEditarM_Click(object sender, EventArgs e)
        {
            if (idMaterialSeleccionado > 0)
            {
                string titulo = txtTituloM.Text;
                string descripcion = txtDescM.Text;
                byte[] archivo = ConvertFileToByteArray(openFileDialog1.FileName);
                DateTime fechaMaterial = DateTime.Now.Date;
                //MessageBox.Show(fechaMaterial.ToString());

                bool actualizado = EstudianteAccessController.ActualizarMaterial(idMaterialSeleccionado, titulo, descripcion, archivo, fechaMaterial);
                if (actualizado)
                {
                    MessageBox.Show("Material actualizado exitosamente.");
                    CargarMateriales();
                    LimpiarCamposMaterial();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el material.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un material para actualizar.");
            }
        }

        private void LimpiarCamposMaterial()
        {
            // Limpiar los campos de texto
            txtTituloM.Clear();
            txtDescM.Clear();

            // Limpiar el archivo seleccionado
            openFileDialog1.FileName = string.Empty;

            // Resetear el id del material seleccionado
            idMaterialSeleccionado = 0;
        }

        private byte[] ConvertFileToByteArray(string filePath)
        {
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir el archivo: " + ex.Message);
                return null;
            }
        }


        private void btnDeleteM_Click(object sender, EventArgs e)
        {
            if (idMaterialSeleccionado > 0)
            {
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este material?",
                                                            "Confirmar Eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    estudianteAccessController controlador = new estudianteAccessController();

                    bool eliminado = controlador.EliminarMaterial(idMaterialSeleccionado);
                    if (eliminado)
                    {
                        MessageBox.Show("Material eliminado exitosamente.");
                        CargarMateriales();
                        LimpiarCamposMaterial();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el material.");
                    }
                }
            }
        }
    }
}

