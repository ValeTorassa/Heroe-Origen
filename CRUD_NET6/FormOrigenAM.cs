using Controladora;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FormOrigenAM : Form
    {
        private Origen origen;
        private bool modificar = false;

        public FormOrigenAM()
        {
            InitializeComponent();
        }

        public FormOrigenAM(Origen origenModificar)
        {
            InitializeComponent();
            origen = origenModificar;
            modificar = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    origen.NombreHistoria = txtNombre.Text;
                    origen.Lugar = txtLugar.Text;
                    origen.Historia = txtHistoria.Text;

                    var mensaje = ControladoraOrigen.Instancia.ModificarOrigen(origen);
                    MessageBox.Show(mensaje, "Información");
                }
                else
                {
                    var nuevoOrigen = new Origen()
                    {
                        NombreHistoria = txtNombre.Text,
                        Lugar = txtLugar.Text,
                        Historia = txtHistoria.Text
                    };

                    var mensaje = ControladoraOrigen.Instancia.AgregarOrigen(nuevoOrigen);
                    MessageBox.Show(mensaje, "Información");
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de historia");
                return false;
            }
            if (string.IsNullOrEmpty(txtLugar.Text))
            {
                MessageBox.Show("Debe ingresar un lugar");
                return false;
            }
            if (string.IsNullOrEmpty(txtHistoria.Text))
            {
                MessageBox.Show("Debe ingresar una historia");
                return false;
            }
            return true;
        }

        private void FormOrigenAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregarModificar.Text = "Modificar";
                txtNombre.Enabled = false;
                txtNombre.Text = origen.NombreHistoria;
                txtLugar.Text = origen.Lugar;
                txtHistoria.Text = origen.Historia;
            }
            else
            {
                lblAgregarModificar.Text = "Agregar";
            }
        }
    }

}
