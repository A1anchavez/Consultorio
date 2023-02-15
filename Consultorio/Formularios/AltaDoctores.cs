using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio.Formularios
{
    public partial class AltaDoctores : Form
    {

        public AltaDoctores()
        {
            InitializeComponent();
        }
        static HttpClient client = new HttpClient();
        #region Eventos controles
        private async void btn_registrar_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor()
            {
                Nombre = txt_nombre.Text,
                Apellido = txt_apellidos.Text,
                Cedula = txt_cedula.Text,
                NumeroDeTelefono = txt_numtel.Text
            };
            await Post(doctor);
            MessageBox.Show("Exito");

        }

        private async void btn_consultar_Click(object sender, EventArgs e)
        {
            dtg_ListaDoctores.DataSource = await GetAll();
        }

        private async void btn_put_Click(object sender, EventArgs e)
        {
            DoctorDto doctor = new DoctorDto()
            {
                Id = txt_put.Text,
                Nombre = txt_nombre.Text,
                Apellido = txt_apellidos.Text,
                Cedula = txt_cedula.Text,
                NumeroDeTelefono = txt_numtel.Text
            };
            await Put(txt_put.Text, doctor);
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
                dtg_ListaDoctores.DataSource =  await Get(txt_consultar.Text);
                dtg_ListaDoctores.Refresh();

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

        private void ListaDoctores_Shown(object sender, EventArgs e)
        {

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

        #region Metodos Api

        public async Task Post(Doctor doctor)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7013/doctor", doctor);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<DoctorDto>> Get(string id)
        {
            DoctorDto doctor = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/doctor/{id}");
            if (response.IsSuccessStatusCode)
            {
                doctor =  await response.Content.ReadFromJsonAsync<DoctorDto>();
            }
            List<DoctorDto> lista = new List<DoctorDto>();
            lista.Add(doctor);
            return lista;
        }
        public async Task<List<DoctorDto>> GetAll()
        {
            DoctorDto doctor = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/doctor");
            List<DoctorDto> lista = new List<DoctorDto>();
            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadFromJsonAsync<List<DoctorDto>>();
            }
            return lista;
        }

        public async Task<DoctorDto> Getobj(string id)
        {
            DoctorDto doctor = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/doctor/{id}");
            if (response.IsSuccessStatusCode)
            {
                doctor = await response.Content.ReadFromJsonAsync<DoctorDto>();
            }
            return doctor;
        }
        public async Task<HttpStatusCode> Put(string id, DoctorDto doctor2)
        {
            DoctorDto doctor = await Getobj(id);
            doctor.Cedula = doctor2.Cedula == "" ? doctor.Cedula : doctor2.Cedula;
            doctor.Nombre = doctor2.Nombre == "" ? doctor.Nombre : doctor2.Nombre;
            doctor.Apellido = doctor2.Apellido == "" ? doctor.Apellido : doctor2.Apellido;
            doctor.NumeroDeTelefono = doctor2.NumeroDeTelefono == "" ? doctor.NumeroDeTelefono : doctor2.NumeroDeTelefono;
            HttpResponseMessage response = await client.PutAsJsonAsync($"https://localhost:7013/doctor/{id}",doctor);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> Delete(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7013/doctor/{id}");
            return response.StatusCode;
        }
        #endregion


    }
}
