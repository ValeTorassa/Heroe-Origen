using Controladora;
using Modelo;
using System;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FormDGVs : Form
    {
        public FormDGVs()
        {
            InitializeComponent();
        }

        private void btnAgregarHeroe_Click(object sender, EventArgs e)
        {
            FormHeroeAM formHeroeAM = new FormHeroeAM();
            formHeroeAM.ShowDialog();
            ActualizarGrillaHeroes();
        }

        private void btnModificarHeroe_Click(object sender, EventArgs e)
        {
            if (dgvHeroes.Rows.Count > 0)
            {
                var heroe = (Heroe)dgvHeroes.CurrentRow.DataBoundItem;
                FormHeroeAM formHeroeAM = new FormHeroeAM(heroe);
                formHeroeAM.ShowDialog();
                ActualizarGrillaHeroes();
            }
        }

        private void btnEliminarHeroe_Click(object sender, EventArgs e)
        {
            if (dgvHeroes.Rows.Count > 0)
            {
                var heroe = (Heroe)dgvHeroes.CurrentRow.DataBoundItem;

                var mensaje = ControladoraHeroe.Instancia.EliminarHeroe(heroe);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrillaHeroes();
            }
        }

        private void btnAgregarOrigen_Click(object sender, EventArgs e)
        {
            FormOrigenAM formOrigenAM = new FormOrigenAM();
            formOrigenAM.ShowDialog();
            ActualizarGrillaOrigenes();
        }

        private void btnModificarOrigen_Click(object sender, EventArgs e)
        {
            if (dgvOrigenes.Rows.Count > 0)
            {
                var origen = (Origen)dgvOrigenes.CurrentRow.DataBoundItem;
                FormOrigenAM formOrigenAM = new FormOrigenAM(origen);
                formOrigenAM.ShowDialog();
                ActualizarGrillaOrigenes();
            }
        }

        private void btnEliminarOrigen_Click(object sender, EventArgs e)
        {
            if (dgvOrigenes.Rows.Count > 0)
            {
                var origen = (Origen)dgvOrigenes.CurrentRow.DataBoundItem;

                var mensaje = ControladoraOrigen.Instancia.EliminarOrigen(origen);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrillaOrigenes();
            }
        }

        private void ActualizarGrillaHeroes()
        {
            dgvHeroes.DataSource = null;
            dgvHeroes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHeroes.DataSource = ControladoraHeroe.Instancia.RecuperarHeroes();
        }

        private void ActualizarGrillaOrigenes()
        {
            dgvOrigenes.DataSource = null;
            dgvOrigenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrigenes.DataSource = ControladoraOrigen.Instancia.RecuperarOrigenes();
        }

        private void FormDGVs_Load(object sender, EventArgs e)
        {
            // Por defecto, muestra la lista de héroes al cargar el formulario.
            ActualizarGrillaHeroes();
            ActualizarGrillaOrigenes();
        }
    }
}
