
namespace proyecto_educacion.views
{
    partial class profesorCalificarForm
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvMaterialC = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTituloM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvComentariosMaterial = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialC)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentariosMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(658, 19);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(98, 31);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvMaterialC
            // 
            this.dgvMaterialC.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMaterialC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterialC.Location = new System.Drawing.Point(6, 35);
            this.dgvMaterialC.Name = "dgvMaterialC";
            this.dgvMaterialC.RowHeadersWidth = 62;
            this.dgvMaterialC.RowTemplate.Height = 28;
            this.dgvMaterialC.Size = new System.Drawing.Size(722, 193);
            this.dgvMaterialC.TabIndex = 19;
            this.dgvMaterialC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterialC_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 37);
            this.label1.TabIndex = 20;
            this.label1.Text = "Calificar materiales de estudiantes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCalificar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNota);
            this.groupBox1.Controls.Add(this.txtDescM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTituloM);
            this.groupBox1.Location = new System.Drawing.Point(19, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 257);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calificar materiales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMaterialC);
            this.groupBox2.Location = new System.Drawing.Point(19, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 245);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Materiales cargados";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtDescM
            // 
            this.txtDescM.AccessibleDescription = "";
            this.txtDescM.Enabled = false;
            this.txtDescM.Location = new System.Drawing.Point(159, 80);
            this.txtDescM.Name = "txtDescM";
            this.txtDescM.Size = new System.Drawing.Size(569, 26);
            this.txtDescM.TabIndex = 26;
            this.txtDescM.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Titulo material";
            // 
            // txtTituloM
            // 
            this.txtTituloM.AccessibleDescription = "";
            this.txtTituloM.Enabled = false;
            this.txtTituloM.Location = new System.Drawing.Point(159, 41);
            this.txtTituloM.Name = "txtTituloM";
            this.txtTituloM.Size = new System.Drawing.Size(181, 26);
            this.txtTituloM.TabIndex = 23;
            this.txtTituloM.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Calificación";
            // 
            // txtNota
            // 
            this.txtNota.AccessibleDescription = "";
            this.txtNota.Location = new System.Drawing.Point(159, 205);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(181, 26);
            this.txtNota.TabIndex = 27;
            this.txtNota.Tag = "";
            // 
            // btnDescargar
            // 
            this.btnDescargar.Location = new System.Drawing.Point(475, 608);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(281, 31);
            this.btnDescargar.TabIndex = 23;
            this.btnDescargar.Text = "Descargar material para calificar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click_1);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(362, 203);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(98, 31);
            this.btnCalificar.TabIndex = 24;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click_1);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.AccessibleDescription = "";
            this.txtObservaciones.Location = new System.Drawing.Point(159, 158);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(569, 26);
            this.txtObservaciones.TabIndex = 30;
            this.txtObservaciones.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Descripción";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvComentariosMaterial);
            this.groupBox3.Location = new System.Drawing.Point(19, 656);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(737, 216);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comentarios del material";
            // 
            // dgvComentariosMaterial
            // 
            this.dgvComentariosMaterial.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvComentariosMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComentariosMaterial.Location = new System.Drawing.Point(6, 34);
            this.dgvComentariosMaterial.Name = "dgvComentariosMaterial";
            this.dgvComentariosMaterial.RowHeadersWidth = 62;
            this.dgvComentariosMaterial.RowTemplate.Height = 28;
            this.dgvComentariosMaterial.Size = new System.Drawing.Size(722, 176);
            this.dgvComentariosMaterial.TabIndex = 20;
            // 
            // profesorCalificarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(774, 884);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Name = "profesorCalificarForm";
            this.Text = "Calificar materiales";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentariosMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvMaterialC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTituloM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvComentariosMaterial;
    }
}