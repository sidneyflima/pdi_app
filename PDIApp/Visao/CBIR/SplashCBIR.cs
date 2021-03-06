using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDIApp.Visao.CBIR
{
    public partial class SplashCBIR : Form
    {
        public SplashCBIR()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar.Value++;
            if (progressBar.Value == progressBar.Maximum)
            {
                DialogResult = DialogResult.OK;
                timer.Stop();
                Close();
            }
            
        }

        private void SplashCBIR_Load(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            timer.Start();
        }
    }
}
