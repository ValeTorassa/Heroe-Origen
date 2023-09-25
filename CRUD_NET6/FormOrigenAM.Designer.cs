namespace CRUD
{
    partial class FormOrigenAM
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblAgregarModificar = new Label();
            lblHistoria = new Label();
            label1 = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            txtLugar = new TextBox();
            txtHistoria = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(18, 141);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(191, 141);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblAgregarModificar
            // 
            lblAgregarModificar.AutoSize = true;
            lblAgregarModificar.Location = new Point(76, 9);
            lblAgregarModificar.Name = "lblAgregarModificar";
            lblAgregarModificar.Size = new Size(113, 15);
            lblAgregarModificar.TabIndex = 4;
            lblAgregarModificar.Text = "Agregar o Modificar";
            // 
            // lblHistoria
            // 
            lblHistoria.AutoSize = true;
            lblHistoria.Location = new Point(42, 106);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Size = new Size(51, 15);
            lblHistoria.TabIndex = 5;
            lblHistoria.Text = "Historia:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 74);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 6;
            label1.Text = "Lugar:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 41);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(93, 15);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre Origen:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(111, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(109, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtLugar
            // 
            txtLugar.Location = new Point(111, 74);
            txtLugar.Name = "txtLugar";
            txtLugar.Size = new Size(109, 23);
            txtLugar.TabIndex = 9;
            // 
            // txtHistoria
            // 
            txtHistoria.Location = new Point(111, 103);
            txtHistoria.Name = "txtHistoria";
            txtHistoria.Size = new Size(212, 23);
            txtHistoria.TabIndex = 10;
            // 
            // FormOrigenAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 175);
            Controls.Add(txtHistoria);
            Controls.Add(txtLugar);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(label1);
            Controls.Add(lblHistoria);
            Controls.Add(lblAgregarModificar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Name = "FormOrigenAM";
            Text = "FormOrigenAM";
            Load += FormOrigenAM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblAgregarModificar;
        private Label lblHistoria;
        private Label label1;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtLugar;
        private TextBox txtHistoria;
    }
}