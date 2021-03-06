using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDIApp.Visao
{
    public partial class SplashInicial : Form
    {
        public SplashInicial()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void SplashInicial_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
