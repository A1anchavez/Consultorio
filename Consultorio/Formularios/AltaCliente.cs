using Consultorio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio.Formularios
{
    public partial class AltaCliente : Form
    {
        public List<Cliente> ListaClientes = new List<Cliente>();
        public AltaCliente()
        {
            InitializeComponent();
        }
        #region Eventos Controles

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente(txt_nombre.Text,
                            txt_apellidos.Text,
                            dtp_fechaNacimiento.Value,
                            txt_direccion.Text);

                //Agrega un elemento a la lista de tareas List<Cliente>
                cliente.AgregarCliente();

                ListaClientes.Add(cliente);

                LimpiarFormulario();

                dtg_ListaClientes.DataSource = null;
                dtg_ListaClientes.DataSource = ListaClientes;
                dtg_ListaClientes.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");

            }

        }


        private void ListaClientes_Shown(object sender, EventArgs e)
        {
            try
            {
                //Context context = new();

                var cliente = new Cliente();
                ListaClientes = cliente.CargarCliente();
                dtg_ListaClientes.DataSource = ListaClientes;
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error.", "Informativo");

            }

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new();
                cliente.GuardarListaClientes(ListaClientes);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");

            }

        }

        #endregion

        #region Metodos Privados
        private void LimpiarFormulario()
        {
            try
            {
                txt_nombre.Text = string.Empty;
                txt_apellidos.Text = string.Empty;
                dtp_fechaNacimiento.Value = DateTime.Today;
                txt_direccion.Text = String.Empty;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");
            }
            finally
            {
                txt_nombre.Text = string.Empty;
                txt_apellidos.Text = string.Empty;
                dtp_fechaNacimiento.Value = DateTime.Today;
                txt_direccion.Text = String.Empty;
            }

        }






        #endregion
    }
}
