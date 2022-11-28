using Consultorio.Business.Entidades;
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
    public partial class AltaDoctor : Form
    {
        public List<Doctor> ListaDoctores = new List<Doctor>();

        public AltaDoctor()
        {
            InitializeComponent();
        }

        #region Eventos controles
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var doctor = new Doctor(
                    txt_cedula.Text,
                    txt_nombre.Text,
                    txt_apellidos.Text,
                    txt_numtel.Text);

                //Agrega un elemento a la lista de doctores List<Doctor>
                doctor.AgregarDoctor();

                ListaDoctores.Add(doctor);

                LimpiarFormulario();

                dtg_ListaDoctores.DataSource = null;
                dtg_ListaDoctores.DataSource = ListaDoctores;
                dtg_ListaDoctores.Refresh();
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

        private void ListaDoctores_Shown(object sender, EventArgs e)
        {
            try
            {

                var doctor = new Doctor();
                ListaDoctores = doctor.CargarDoctores();
                dtg_ListaDoctores.DataSource = ListaDoctores;
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
                Doctor doctor = new();
                doctor.GuardarListaDoctores(ListaDoctores);
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
                txt_cedula.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_apellidos.Text = string.Empty;
                txt_numtel.Text = string.Empty;


            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");
            }
            finally
            {
                txt_cedula.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_apellidos.Text = string.Empty;
                txt_numtel.Text = string.Empty;
            }

        }






        #endregion
    }
}
