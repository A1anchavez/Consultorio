using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Infraestructura.Sqlite.Contextos;
using Infraestructura.Sqlite.Repositorios;
using Infraestructura.SQLServer.Repositorios;
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
        public AltaCliente()
        {
            InitializeComponent();
        }



        #region Eventos Controles

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
        }


        private void ListaClientes_Shown(object sender, EventArgs e)
        {

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {

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
