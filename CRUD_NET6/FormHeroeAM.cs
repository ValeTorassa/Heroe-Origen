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
    public partial class FormHeroeAM : Form
    {
        private Heroe heroe;
        private bool modificar = false;

        public FormHeroeAM()
        {
            InitializeComponent();
        }

        public FormHeroeAM(Heroe heroeModificar)
        {
            InitializeComponent();
            heroe = heroeModificar;
            modificar = true;
        }

        private void LlenarCMBOrigen()
        {
            cmbOrigen.DataSource = ControladoraOrigen.Instancia.RecuperarOrigenes();
            cmbOrigen.DisplayMember = "NombreHistoria";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mensaje;

            if (ValidarCampos())
            {
                if (modificar)
                {
                    var nuevoHeroe = new Heroe()
                    {
                        Nombre = txtNombre.Text,
                        Clase = txtClase.Text,
                        Nivel = (int)numNivel.Value,
                        Origen = (Origen)cmbOrigen.SelectedItem
                    };

                    if (!ControladoraHeroe.Instancia.OrigenAsociadoOtroHeroe(nuevoHeroe.Origen, nuevoHeroe.Nombre))
                    {
                        mensaje = ControladoraHeroe.Instancia.ModificarHeroe(nuevoHeroe);
                        MessageBox.Show(mensaje, "Información");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El origen ya está asociado a otro héroe", "Información");
                    }
                }
                else
                {
                    var nuevoHeroe = new Heroe()
                    {
                        Nombre = txtNombre.Text,
                        Clase = txtClase.Text,
                        Nivel = (int)numNivel.Value,
                        Origen = (Origen)cmbOrigen.SelectedItem
                    };

                    if (!ControladoraHeroe.Instancia.OrigenAsociadoOtroHeroe(nuevoHeroe.Origen))
                    {
                        mensaje = ControladoraHeroe.Instancia.AgregarHeroe(nuevoHeroe);
                        MessageBox.Show(mensaje, "Información");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El origen ya está asociado a otro héroe", "Información");
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHeroeAM_Load(object sender, EventArgs e)
        {
            LlenarCMBOrigen();

            if (modificar)
            {
                lblAgregarModificar.Text = "Modificar";
                txtNombre.Enabled = false;
                txtNombre.Text = heroe.Nombre;
                txtClase.Text = heroe.Clase;
                numNivel.Value = heroe.Nivel;
                cmbOrigen.SelectedItem = heroe.Origen;
            }
            else
            {
                lblAgregarModificar.Text = "Agregar";
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre");
                return false;
            }
            if (string.IsNullOrEmpty(txtClase.Text))
            {
                MessageBox.Show("Debe ingresar una clase");
                return false;
            }
            if (numNivel.Value <= 0)
            {
                MessageBox.Show("El nivel debe ser mayor que cero");
                return false;
            }
            if (cmbOrigen.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un origen");
                return false;
            }
            return true;
        }
    }

}
