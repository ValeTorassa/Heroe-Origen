namespace CRUD
{
    partial class FormHeroeAM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHeroeAM));
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblAgregarModificar = new Label();
            lblNivel = new Label();
            lblClase = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            txtClase = new TextBox();
            numNivel = new NumericUpDown();
            cmbOrigen = new ComboBox();
            lblOrigen = new Label();
            ((System.ComponentModel.ISupportInitialize)numNivel).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(5, 218);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(146, 218);
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
            lblAgregarModificar.Location = new Point(58, 9);
            lblAgregarModificar.Name = "lblAgregarModificar";
            lblAgregarModificar.Size = new Size(113, 15);
            lblAgregarModificar.TabIndex = 4;
            lblAgregarModificar.Text = "Agregar o Modificar";
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(24, 123);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(37, 15);
            lblNivel.TabIndex = 5;
            lblNivel.Text = "Nivel:";
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Location = new Point(24, 82);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(38, 15);
            lblClase.TabIndex = 6;
            lblClase.Text = "Clase:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(10, 41);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(93, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(109, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtClase
            // 
            txtClase.Location = new Point(93, 82);
            txtClase.Name = "txtClase";
            txtClase.Size = new Size(109, 23);
            txtClase.TabIndex = 9;
            // 
            // numNivel
            // 
            numNivel.Location = new Point(93, 121);
            numNivel.Name = "numNivel";
            numNivel.Size = new Size(109, 23);
            numNivel.TabIndex = 10;
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(93, 163);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(109, 23);
            cmbOrigen.TabIndex = 11;
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(27, 166);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(46, 15);
            lblOrigen.TabIndex = 12;
            lblOrigen.Text = "Origen:";
            // 
            // FormHeroeAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(480, 268);
            Controls.Add(lblOrigen);
            Controls.Add(cmbOrigen);
            Controls.Add(numNivel);
            Controls.Add(txtClase);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblClase);
            Controls.Add(lblNivel);
            Controls.Add(lblAgregarModificar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Name = "FormHeroeAM";
            Text = "FormHeroeAM";
            Load += FormHeroeAM_Load;
            ((System.ComponentModel.ISupportInitialize)numNivel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblAgregarModificar;
        private Label lblNivel;
        private Label lblClase;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtClase;
        private NumericUpDown numNivel;
        private ComboBox cmbOrigen;
        private Label lblOrigen;
    }
}