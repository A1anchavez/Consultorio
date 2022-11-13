﻿using Consultorio.Formularios;
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
            var frmAltaDoctor = new AltaDoctor();
            frmAltaDoctor.ShowDialog();
        }
    }
}