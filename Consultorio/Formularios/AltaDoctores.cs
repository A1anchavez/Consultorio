using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Common;
using Consultorio.Dtos;
using Infraestructura.Sqlite.Contextos;
using Infraestructura.Sqlite.Repositorios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

        #region Eventos controles
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            //string url = "https://localhost:7013/doctor";

            //DoctorDto doctor = new DoctorDto()
            //{
            //    Cedula = txt_cedula.Text,
            //    Nombre = txt_nombre.Text,
            //    Apellido = txt_apellidos.Text,
            //    NumeroDeTelefono = txt_apellidos.Text
            //};
            string url = "https://localhost:7013/doctor";
            Doctor doctor = new Doctor()
            {
                Nombre = txt_nombre.Text,
                Apellido = txt_apellidos.Text,
                Cedula = txt_cedula.Text,
                NumeroDeTelefono = txt_numtel.Text
            };
            Send<Doctor>(url, doctor);
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

        
        public string Send<T>(string url, T obj, string method = "POST")
        {
            string result;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj); 
            WebRequest request = WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json;charset=utf-8";
            request.PreAuthenticate = true; 
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
            }
            var response = ((HttpWebResponse)request.GetResponse());
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

        public List<Doctor> Get(string url, string method = "GET")
        {
            string result;
            WebRequest request = WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json;charset=utf-8";
            request.PreAuthenticate = true;
            var response = ((HttpWebResponse)request.GetResponse());
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            List<Doctor> lista = JsonConvert.DeserializeObject<List<Doctor>>(result);
            //dtg_ListaDoctores = result;
            return lista;

        }

        #endregion

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:7013/doctor?pageNumber=1&pageSize=4";
            dtg_ListaDoctores.DataSource = Get(url);
            dtg_ListaDoctores.Refresh();

        }
    }
}
