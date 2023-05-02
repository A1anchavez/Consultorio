using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Infraestructura.SQLServer.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consultorio.Dtos;
using System.Net.Http.Json;
using System.Numerics;

namespace Consultorio.Formularios
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }
        static HttpClient client = new HttpClient();

        #region Eventos Controles
        private void ListaClientes_Shown(object sender, EventArgs e)
        {

        }

        private async void btn_registrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nombre = txt_nombre.Text,
                Apellido = txt_nombre.Text,
                FechaDeNacimiento = dtp_fechaNacimiento.Value,
                Direccion = txt_direccion.Text
            };
            await Post(cliente);
            MessageBox.Show("Exito");
        }

        private async void btn_consultar_Click(object sender, EventArgs e)
        {
            dtg_ListaClientes.DataSource = await GetAll();

        }

        private async void btn_put_Click(object sender, EventArgs e)
        {
            ClienteDto cliente = new ClienteDto()
            {
                Id = txt_put.Text,
                Nombre = txt_nombre.Text,
                Apellido = txt_nombre.Text,
                FechaDeNacimiento = dtp_fechaNacimiento.Value,
                Direccion = txt_direccion.Text
            };
            await Put(txt_put.Text, cliente);
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
                dtg_ListaClientes.DataSource = await Get(txt_consultar.Text);
                dtg_ListaClientes.Refresh();

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

        #region Metodos Api

        public async Task Post(Cliente cliente)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7013/doctor", cliente);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ClienteDto>> Get(string id)
        {
            ClienteDto cliente = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/doctor/{id}");
            if (response.IsSuccessStatusCode)
            {
                cliente = await response.Content.ReadFromJsonAsync<ClienteDto>();
            }
            List<ClienteDto> lista = new List<ClienteDto>();
            lista.Add(cliente);
            return lista;
        }
        public async Task<List<ClienteDto>> GetAll()
        {
            ClienteDto cliente = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/cliente");
            List<ClienteDto> lista = new List<ClienteDto>();
            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadFromJsonAsync<List<ClienteDto>>();
            }
            return lista;
        }

        public async Task<ClienteDto> Getobj(string id)
        {
            ClienteDto cliente = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/cliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                cliente = await response.Content.ReadFromJsonAsync<ClienteDto>();
            }
            return cliente;
        }
        public async Task<HttpStatusCode> Put(string id, ClienteDto cliente2)
        {
            ClienteDto cliente = await Getobj(id);

            cliente.Nombre = cliente2.Nombre == ""? cliente.Nombre: cliente2.Nombre;
            cliente.Apellido = cliente2.Apellido == ""? cliente.Apellido: cliente2.Apellido;
            cliente.Direccion = cliente2.Direccion ==""? cliente.Direccion: cliente2.Direccion;
            //FechaDeNacimiento es obligatorio de poner

            HttpResponseMessage response = await client.PutAsJsonAsync($"https://localhost:7013/cliente/{id}", cliente);

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
