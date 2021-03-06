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
    public partial class FormParametroSlide : Form
    {
        /// <summary>
        /// Cria uma janela para parametro slide. O valor definido como 
        /// padrão é a media entre minimo e maximo
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public FormParametroSlide(int min, int max)
            : this(min, max, (min + max) / 2, "Parâmetro")
        {
        }

        public FormParametroSlide(int min, int max, int valor)
            :this(min,max,valor,"Parâmetro")
        { 
        
        }

        /// <summary>
        /// Cria uma janela para parametro slide, definindo o valor inicial do 
        /// slide
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="valor"></param>
        public FormParametroSlide(int min, int max, int valor, string titulo)
        {
            InitializeComponent();
            this.Text = titulo;
            barraSlide.Minimum = min;
            barraSlide.Maximum = max;

            minLabel.Text = Convert.ToString(min);
            maxLabel.Text = Convert.ToString(max);

            if (valor >= min)
            {
                if (valor <= max)
                {
                    barraSlide.Value = valor;
                    valorTextBox.Text = Convert.ToString(valor);
                }
            }
        }

        /// <summary>
        /// Obtem o valor retornado pelo slide
        /// </summary>
        public int ValorSlide { get { return barraSlide.Value; } }

        private void botaoConcluir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void FormParametroSlide_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void barraSlide_ValueChanged(object sender, EventArgs e)
        {
            valorTextBox.Text = Convert.ToString(barraSlide.Value);
        }


    }
}
