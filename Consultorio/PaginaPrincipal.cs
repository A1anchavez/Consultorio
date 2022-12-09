using Consultorio.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio
{
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void btn_altaDoctor_Click(object sender, EventArgs e)
        {
            var frmAltaDoctor = new AltaDoctores();
            frmAltaDoctor.ShowDialog();
        }

        private void btn_altaCliente_Click(object sender, EventArgs e)
        {
            var frmAltaCliente = new AltaCliente();
            frmAltaCliente.ShowDialog();
        }

        private void btn_altaConsulta_Click(object sender, EventArgs e)
        {
            var frmAltaConsulta = new AltaConsultas();
            frmAltaConsulta.ShowDialog();
        }

        private void btn_sqlRepository_Click(object sender, EventArgs e)
        {

        }

        private void btn_sqlite_Click(object sender, EventArgs e)
        {

        }
        
        //Referencia a estos eventos tal vez den error a futuro, esperemos y no

        private void btn_txtRepository_Click(object sender, EventArgs e)
        {

        }

        private void btn_memoryRepository_Click(object sender, EventArgs e)
        {

        }
    }
}
