using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PDIApp.Modelo;

namespace PDIApp.Visao
{
    public partial class FormParametrosSlideCores : Form
    {
        public FormParametrosSlideCores(ModeloCor cor,
                                        int min1, int max1,
                                        int min2, int max2,
                                        int min3, int max3,
                                        string titulo)
        {
            InitializeComponent();
            Text = titulo;

            barraSlide1.Minimum = min1;
            barraSlide1.Maximum = max1;

            barraSlide2.Minimum = min2;
            barraSlide2.Maximum = max2;

            barraSlide3.Minimum = min3;
            barraSlide3.Maximum = max3;

            min1Label.Text = min1.ToString();
            max1Label.Text = max1.ToString();

            min2Label.Text = min2.ToString();
            max2Label.Text = max2.ToString();

            min3Label.Text = min3.ToString();
            max3Label.Text = max3.ToString();

            valor1TextBox.Text = "0";
            valor2TextBox.Text = "0";
            valor3TextBox.Text = "0";

            switch (cor)
            {
                case ModeloCor.RGB:
                    param1Label.Text = "R";
                    param2Label.Text = "G";
                    param3Label.Text = "B";
                    break;
                case ModeloCor.HSI:
                    param1Label.Text = "H";
                    param2Label.Text = "S";
                    param3Label.Text = "I";
                    break;
                case ModeloCor.LAB:
                    param1Label.Text = "L*";
                    param2Label.Text = "a*";
                    param3Label.Text = "b*";
                    break;
            }

        }

        public int ValorParametro1 { get { return barraSlide1.Value; } }
        public int ValorParametro2 { get { return barraSlide2.Value; } }
        public int ValorParametro3 { get { return barraSlide3.Value; } }

        private void botaoConcluir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void barraSlide1_ValueChanged(object sender, EventArgs e)
        {
            valor1TextBox.Text = Convert.ToString(barraSlide1.Value);
        }

        private void barraSlide2_ValueChanged(object sender, EventArgs e)
        {
            valor2TextBox.Text = Convert.ToString(barraSlide2.Value);
        }

        private void barraSlide3_ValueChanged(object sender, EventArgs e)
        {
            valor3TextBox.Text = Convert.ToString(barraSlide3.Value);

        }
    }
}
