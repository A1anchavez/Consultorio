using Consultorio.Business.Entidades;
using Consultorio.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio.Formularios
{
    public partial class InicioSesion : Form
    {
        static HttpClient client = new HttpClient();
        public InicioSesion()
        {
            InitializeComponent();
        }

        private async void btn_confirmar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                NombreUsuario = txt_usuario.Text,
                Contraseña = txt_contraseña.Text
            
            };
            await iniciarSesion(usuario);

        }
        private async Task iniciarSesion(Usuario usuario)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7013/cliente/inicioSesion", usuario);
            if (response.IsSuccessStatusCode)
            {
                var frmAltaCliente = new AltaConsultas();
                frmAltaCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
    }
}
