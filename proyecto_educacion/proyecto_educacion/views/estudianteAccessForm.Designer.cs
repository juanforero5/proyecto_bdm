
namespace proyecto_educacion.views
{
    partial class estudianteAccessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMateriales = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteM = new System.Windows.Forms.Button();
            this.btnEditarM = new System.Windows.Forms.Button();
            this.btnCreateM = new System.Windows.Forms.Button();
            this.lblTituloFile = new System.Windows.Forms.Label();
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTituloM = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMateriales)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Acceso estudiantes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewMateriales);
            this.groupBox1.Location = new System.Drawing.Point(19, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 264);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mis materiales cargados";
            // 
            // dataGridViewMateriales
            // 
            this.dataGridViewMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMateriales.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewMateriales.Name = "dataGridViewMateriales";
            this.dataGridViewMateriales.RowHeadersWidth = 62;
            this.dataGridViewMateriales.RowTemplate.Height = 28;
            this.dataGridViewMateriales.Size = new System.Drawing.Size(746, 220);
            this.dataGridViewMateriales.TabIndex = 0;
            this.dataGridViewMateriales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMateriales_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteM);
            this.groupBox2.Controls.Add(this.btnEditarM);
            this.groupBox2.Controls.Add(this.btnCreateM);
            this.groupBox2.Controls.Add(this.lblTituloFile);
            this.groupBox2.Controls.Add(this.btnSeleccionarArchivo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDescM);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTituloM);
            this.groupBox2.Location = new System.Drawing.Point(19, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 258);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestionar materiales";
            // 
            // btnDeleteM
            // 
            this.btnDeleteM.Location = new System.Drawing.Point(423, 212);
            this.btnDeleteM.Name = "btnDeleteM";
            this.btnDeleteM.Size = new System.Drawing.Size(98, 31);
            this.btnDeleteM.TabIndex = 21;
            this.btnDeleteM.Text = "Eliminar";
            this.btnDeleteM.UseVisualStyleBackColor = true;
            this.btnDeleteM.Click += new System.EventHandler(this.btnDeleteM_Click);
            // 
            // btnEditarM
            // 
            this.btnEditarM.Location = new System.Drawing.Point(128, 212);
            this.btnEditarM.Name = "btnEditarM";
            this.btnEditarM.Size = new System.Drawing.Size(98, 31);
            this.btnEditarM.TabIndex = 20;
            this.btnEditarM.Text = "Editar";
            this.btnEditarM.UseVisualStyleBackColor = true;
            this.btnEditarM.Click += new System.EventHandler(this.btnEditarM_Click);
            // 
            // btnCreateM
            // 
            this.btnCreateM.Location = new System.Drawing.Point(10, 212);
            this.btnCreateM.Name = "btnCreateM";
            this.btnCreateM.Size = new System.Drawing.Size(98, 31);
            this.btnCreateM.TabIndex = 19;
            this.btnCreateM.Text = "Crear";
            this.btnCreateM.UseVisualStyleBackColor = true;
            this.btnCreateM.Click += new System.EventHandler(this.btnCreateM_Click);
            // 
            // lblTituloFile
            // 
            this.lblTituloFile.AutoSize = true;
            this.lblTituloFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFile.Location = new System.Drawing.Point(310, 123);
            this.lblTituloFile.Name = "lblTituloFile";
            this.lblTituloFile.Size = new System.Drawing.Size(117, 20);
            this.lblTituloFile.TabIndex = 18;
            this.lblTituloFile.Text = "Cargar material";
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(159, 118);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(130, 31);
            this.btnSeleccionarArchivo.TabIndex = 17;
            this.btnSeleccionarArchivo.Text = "Seleccionar";
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fichero material";
            // 
            // txtDescM
            // 
            this.txtDescM.AccessibleDescription = "";
            this.txtDescM.Location = new System.Drawing.Point(159, 80);
            this.txtDescM.Name = "txtDescM";
            this.txtDescM.Size = new System.Drawing.Size(362, 26);
            this.txtDescM.TabIndex = 7;
            this.txtDescM.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Titulo material";
            // 
            // txtTituloM
            // 
            this.txtTituloM.AccessibleDescription = "";
            this.txtTituloM.Location = new System.Drawing.Point(159, 41);
            this.txtTituloM.Name = "txtTituloM";
            this.txtTituloM.Size = new System.Drawing.Size(181, 26);
            this.txtTituloM.TabIndex = 4;
            this.txtTituloM.Tag = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // estudianteAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 640);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "estudianteAccessForm";
            this.Text = "Acceso estudiantes";
            this.Load += new System.EventHandler(this.estudianteAccessForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMateriales)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewMateriales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTituloM;
        private System.Windows.Forms.Label lblTituloFile;
        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateM;
        private System.Windows.Forms.Button btnEditarM;
        private System.Windows.Forms.Button btnDeleteM;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}