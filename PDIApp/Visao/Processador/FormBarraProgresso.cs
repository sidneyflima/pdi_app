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
    public partial class FormBarraProgresso : Form
    {
        private object lockObj;


        public FormBarraProgresso()
        {
            InitializeComponent();
            lockObj = new object();
        }

        /// <summary>
        /// Define o valor maximo da barra de progresso
        /// </summary>
        public int Maximo
        {
            get { return progressBar.Maximum; }
            set { progressBar.Maximum = value; }
        }

        /// <summary>
        /// Define o valor maximo da barra de progresso
        /// </summary>
        public int Minimo
        {
            get { return progressBar.Minimum; }
            set { progressBar.Minimum = value; }
        }

        /// <summary>
        /// Valor atual da barra de progresso
        /// </summary>
        public int ValorBarra
        {
            get{ return progressBar.Value;  }
            set{ progressBar.Value = value; }
        }

        /// <summary>
        /// O titulo da janela.
        /// </summary>
        public string Titulo
        {
            get { return this.Text; }
            set { this.Text = value; }
        }


        public void IncrementaBarra()
        {
            //lock (lockObj)
            //{
                this.progressBar.Value++;
            //}
        }
    }
}
