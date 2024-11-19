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
            LimpiarCamposMaterial();
            txtComentario.Enabled = false;
            btnComentar.Enabled = false;
        }

        private void CargarMateriales()
        {
            // obtener los materiales del estudiante
            List<MaterialModel> materiales = EstudianteAccessController.ObtenerMaterialesEstudiante(idEstudiante);


            dataGridViewMateriales.AutoGenerateColumns = false;
            dataGridViewMateriales.Columns.Clear();


            dataGridViewMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TituloMaterial",
                HeaderText = "Título",
                Name = "TituloMaterial"
            });


            dataGridViewMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescMaterial",
                HeaderText = "Descripción",
                Name = "DescMaterial"
            });


            dataGridViewMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaMaterial",
                HeaderText = "Fecha publicación",
                Name = "FechaMaterial"
            });


            dataGridViewMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdCalificacion",
                HeaderText = "Calificación",
                Name = "IdCalificacion"
            });


            dataGridViewMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescripcionCalificacion",
                HeaderText = "Observaciones",
                Name = "DescripcionCalificacion"
            });

            dataGridViewMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdMaterial",
                HeaderText = "Id Material",
                Name = "IdMaterial",
                Visible = false
            });

            dataGridViewMateriales.DataSource = materiales;
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
            openFileDialog1.Filter = "Archivos PDF|*.pdf|Archivos Word|*.docx|Archivos Excel|*.xlsx|Imágenes PNG|*.png|Archivos TXT|*.txt";
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

                txtComentario.Enabled = true;
                btnComentar.Enabled = true;
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
            // limpiar campos
            txtTituloM.Clear();
            txtDescM.Clear();
            lblTituloFile.Text = "Cargar material";

            // limpiar file seleccionado
            openFileDialog1.FileName = string.Empty;

            // restaurar id material seleccionado
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

        private void btnComentar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComentario.Text))
            {
                MessageBox.Show("Por favor, escriba un comentario antes de enviarlo.");
                return;
            }

            var comentario = new ComentarioModel
            {
                TxtComentario = txtComentario.Text,
                FechaComentario = DateTime.Now,
                IdEstudianteCom = idEstudiante,
                IdMaterialCom = idMaterialSeleccionado
            };

            bool resultado = EstudianteAccessController.CrearComentario(comentario);

            if (resultado)
            {
                MessageBox.Show("Comentario agregado exitosamente.");
                txtComentario.Clear();
                txtComentario.Enabled = false;
                btnComentar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al agregar el comentario.");
            }
        }
    }
}

