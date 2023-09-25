namespace CRUD
{
    partial class FormDGVs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDGVs));
            dgvHeroes = new DataGridView();
            dgvOrigenes = new DataGridView();
            lblHeroes = new Label();
            lblOrigen = new Label();
            btnAgregarHeroe = new Button();
            btnAgregarOrigen = new Button();
            btnModificarOrigen = new Button();
            btnEliminarOrigen = new Button();
            btnEliminarHeroe = new Button();
            btnModificarHeroe = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHeroes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrigenes).BeginInit();
            SuspendLayout();
            // 
            // dgvHeroes
            // 
            dgvHeroes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHeroes.Location = new Point(46, 57);
            dgvHeroes.Name = "dgvHeroes";
            dgvHeroes.RowTemplate.Height = 25;
            dgvHeroes.Size = new Size(317, 150);
            dgvHeroes.TabIndex = 0;
            // 
            // dgvOrigenes
            // 
            dgvOrigenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrigenes.Location = new Point(442, 57);
            dgvOrigenes.Name = "dgvOrigenes";
            dgvOrigenes.RowTemplate.Height = 25;
            dgvOrigenes.Size = new Size(310, 150);
            dgvOrigenes.TabIndex = 1;
            // 
            // lblHeroes
            // 
            lblHeroes.AutoSize = true;
            lblHeroes.Location = new Point(170, 27);
            lblHeroes.Name = "lblHeroes";
            lblHeroes.Size = new Size(44, 15);
            lblHeroes.TabIndex = 2;
            lblHeroes.Text = "Heroes";
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(574, 27);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(43, 15);
            lblOrigen.TabIndex = 3;
            lblOrigen.Text = "Origen";
            // 
            // btnAgregarHeroe
            // 
            btnAgregarHeroe.Location = new Point(46, 236);
            btnAgregarHeroe.Name = "btnAgregarHeroe";
            btnAgregarHeroe.Size = new Size(75, 23);
            btnAgregarHeroe.TabIndex = 4;
            btnAgregarHeroe.Text = "Agregar";
            btnAgregarHeroe.UseVisualStyleBackColor = true;
            btnAgregarHeroe.Click += btnAgregarHeroe_Click;
            // 
            // btnAgregarOrigen
            // 
            btnAgregarOrigen.Location = new Point(442, 236);
            btnAgregarOrigen.Name = "btnAgregarOrigen";
            btnAgregarOrigen.Size = new Size(75, 23);
            btnAgregarOrigen.TabIndex = 5;
            btnAgregarOrigen.Text = "Agregar";
            btnAgregarOrigen.UseVisualStyleBackColor = true;
            btnAgregarOrigen.Click += btnAgregarOrigen_Click;
            // 
            // btnModificarOrigen
            // 
            btnModificarOrigen.Location = new Point(574, 236);
            btnModificarOrigen.Name = "btnModificarOrigen";
            btnModificarOrigen.Size = new Size(75, 23);
            btnModificarOrigen.TabIndex = 6;
            btnModificarOrigen.Text = "Modificar";
            btnModificarOrigen.UseVisualStyleBackColor = true;
            btnModificarOrigen.Click += btnModificarOrigen_Click;
            // 
            // btnEliminarOrigen
            // 
            btnEliminarOrigen.Location = new Point(677, 236);
            btnEliminarOrigen.Name = "btnEliminarOrigen";
            btnEliminarOrigen.Size = new Size(75, 23);
            btnEliminarOrigen.TabIndex = 7;
            btnEliminarOrigen.Text = "Eliminar";
            btnEliminarOrigen.UseVisualStyleBackColor = true;
            btnEliminarOrigen.Click += btnEliminarOrigen_Click;
            // 
            // btnEliminarHeroe
            // 
            btnEliminarHeroe.Location = new Point(288, 236);
            btnEliminarHeroe.Name = "btnEliminarHeroe";
            btnEliminarHeroe.Size = new Size(75, 23);
            btnEliminarHeroe.TabIndex = 8;
            btnEliminarHeroe.Text = "Eliminar";
            btnEliminarHeroe.UseVisualStyleBackColor = true;
            btnEliminarHeroe.Click += btnEliminarHeroe_Click;
            // 
            // btnModificarHeroe
            // 
            btnModificarHeroe.Location = new Point(159, 236);
            btnModificarHeroe.Name = "btnModificarHeroe";
            btnModificarHeroe.Size = new Size(75, 23);
            btnModificarHeroe.TabIndex = 9;
            btnModificarHeroe.Text = "Modificar";
            btnModificarHeroe.UseVisualStyleBackColor = true;
            btnModificarHeroe.Click += btnModificarHeroe_Click;
            // 
            // FormDGVs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 283);
            Controls.Add(btnModificarHeroe);
            Controls.Add(btnEliminarHeroe);
            Controls.Add(btnEliminarOrigen);
            Controls.Add(btnModificarOrigen);
            Controls.Add(btnAgregarOrigen);
            Controls.Add(btnAgregarHeroe);
            Controls.Add(lblOrigen);
            Controls.Add(lblHeroes);
            Controls.Add(dgvOrigenes);
            Controls.Add(dgvHeroes);
            Name = "FormDGVs";
            Text = "Heroes y Origenes";
            Load += FormDGVs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHeroes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrigenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHeroes;
        private DataGridView dgvOrigenes;
        private Label lblHeroes;
        private Label lblOrigen;
        private Button btnAgregarHeroe;
        private Button btnAgregarOrigen;
        private Button btnModificarOrigen;
        private Button btnEliminarOrigen;
        private Button btnEliminarHeroe;
        private Button btnModificarHeroe;
    }
}