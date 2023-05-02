using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Dtos;
using Infraestructura.SQLServer.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio.Formularios
{
    public partial class AltaConsultas : Form
    {
        public AltaConsultas()
        {
            InitializeComponent();
        }
        static HttpClient client = new HttpClient();
        #region Eventos Controles

        private void ListaConsultas_Shown(object sender, EventArgs e)
        {

        }

        private async void btn_registrar_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta()
            {
                //Cliente = txt_NomClnt.Text,
                //Doctor = txt_NomDoc.Text,
                //FechaConsulta = dtp_fechaConsulta.Value,
                //Motivo = txt_MotCon.Text

            };
            await Post(consulta);
            MessageBox.Show("Exito");
        }

        private async void btn_consultar_Click(object sender, EventArgs e)
        {
            dts_listaConsultas.DataSource = await GetAll();
        }

        private async void btn_put_Click(object sender, EventArgs e)
        {
            ConsultaDto consulta = new ConsultaDto()
            {
                Id = txt_put.Text,
                //Cliente = txt_NomClnt.Text,
                //Doctor = txt_NomDoc.Text,
                FechaConsulta = dtp_fechaConsulta.Value,
                Motivo = txt_MotCon.Text
            };
            await Put(txt_put.Text, consulta);
            MessageBox.Show("Exito");
        }

        private async void btn_consultar_id_Click(object sender, EventArgs e)
        {
            if (txt_consultar.Text == null)
            {
                MessageBox.Show("introduce un ID valido");
            }
            else
            {
                dts_listaConsultas.DataSource = await Get(txt_consultar.Text);
                dts_listaConsultas.Refresh();

            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {


                if (txt_delete.Text == null)
                {
                    MessageBox.Show("introduce un ID valido");
                }
                else
                {
                    await Delete(txt_delete.Text);
                    MessageBox.Show("Exito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Metodos Privados
        private void LimpiarFormulario()
        {
            try
            {
                txt_NomDoc.Text = string.Empty;
                //txt_NomClnt.Text = string.Empty;
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
                //txt_NomClnt.Text = string.Empty;
                dtp_fechaConsulta.Value = DateTime.Today;
                txt_MotCon.Text = string.Empty;
            }

        }






        #endregion

        //ToDo: revisar las rutas 
        #region Metodos Api
        public async Task Post(Consulta consulta)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7013/cliente/", consulta);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ConsultaDto>> Get(string id)
        {
            ConsultaDto consulta = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/cliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                consulta = await response.Content.ReadFromJsonAsync<ConsultaDto>();
            }
            List<ConsultaDto> lista = new List<ConsultaDto>();
            lista.Add(consulta);
            return lista;
        }
        public async Task<List<ConsultaDto>> GetAll()
        {
            ConsultaDto consulta = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/cliente");
            List<ConsultaDto> lista = new List<ConsultaDto>();
            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadFromJsonAsync<List<ConsultaDto>>();
            }
            return lista;
        }

        public async Task<ConsultaDto> Getobj(string id)
        {
            ConsultaDto consulta = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/cliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                consulta = await response.Content.ReadFromJsonAsync<ConsultaDto>();
            }
            return consulta;
        }
        public async Task<HttpStatusCode> Put(string id, ConsultaDto consulta2)
        {
            ConsultaDto consulta = await Getobj(id);
            //consulta.Cliente = consulta2.Cliente == "" ? consulta.Cliente : consulta2.Cliente;
            //consulta.Doctor = consulta2.Doctor == "" ? consulta.Doctor : consulta2.Doctor;
            //consulta.FechaConsulta = consulta2.FechaConsulta == "" ? consulta.FechaConsulta : consulta2.FechaConsulta;
            consulta.Motivo = consulta2.Motivo == "" ? consulta.Motivo : consulta2.Motivo;
            HttpResponseMessage response = await client.PutAsJsonAsync($"https://localhost:7013/cliente/{id}", consulta);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> Delete(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7013/cliente/{id}");
            return response.StatusCode;
        }
        #endregion
    }
}
