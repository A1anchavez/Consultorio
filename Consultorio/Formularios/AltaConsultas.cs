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
    public partial class AltaConsultas : Form
    {
        public List<Consulta> ListaConsultas = new List<Consulta>();
        public List<Cliente> ListaClientes = new List<Cliente>();
        public List<Doctor> ListaDoctores = new List<Doctor>();

        public AltaConsultas()
        {
            InitializeComponent();
        }
        #region Eventos Controles

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                IRepository<Consulta> repo = new ConsultaSQLiteRepository(new SQLiteContext());
                var consulta = new Consulta(repo,                            
                            txt_NomDoc.Text,
                            txt_NomClnt.Text,
                            dtp_fechaConsulta.Value,
                            txt_MotCon.Text);

                //Agrega un elemento a la lista de tareas List<ToDo>
                consulta.AgregarConsulta();

                ListaConsultas.Add(consulta);

                LimpiarFormulario();

                dts_listaConsultas.DataSource = null;
                dts_listaConsultas.DataSource = ListaConsultas;
                dts_listaConsultas.Refresh();
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


        private void ListaConsultas_Shown(object sender, EventArgs e)
        {
            try
            {
                //Consultas
                var consulta = new Consulta();
                ListaConsultas = consulta.CargarConsultas();
                dts_listaConsultas.DataSource = ListaConsultas;

                //Clientea
                var cliente = new Cliente();
                ListaClientes = cliente.CargarClientes();
                dts_ListaClientes.DataSource = ListaClientes;

                //Doctores
                var doctor = new Doctor();
                ListaDoctores = doctor.CargarDoctores();
                dts_ListaDoctores.DataSource = ListaDoctores;
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
                Consulta consulta = new();
                consulta.GuardarListaConsultas(ListaConsultas);
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
                txt_NomDoc.Text = string.Empty;
                txt_NomClnt.Text = string.Empty;
                dtp_fechaConsulta.Value = DateTime.Today;
                txt_MotCon.Text = string.Empty;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");
            }
            finally
            {
                txt_NomDoc.Text = string.Empty;
                txt_NomClnt.Text = string.Empty;
                dtp_fechaConsulta.Value = DateTime.Today;
                txt_MotCon.Text = string.Empty;
            }

        }






        #endregion

    }
}
