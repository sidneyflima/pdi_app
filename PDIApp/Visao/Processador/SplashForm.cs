using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PDIApp.Controle;
using PDIApp.Util.Calculos;
using PDIApp.Controle.ModulosCommand;
using PDIApp.Util.Flyweight;

namespace PDIApp.Visao
{
    public partial class SplashForm : Form
    {
        #region Atributos

        /// <summary>Contador para o timer</summary>
        private int count = 0;

        #endregion

        #region Construtores

        public SplashForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (count == 50)
            {
                timer.Stop();
                //CarregaModulos();
                DialogResult = DialogResult.OK;
                Close();
            }
            count++;
            barraProgresso.Value++;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Carrega os módulos
        /// </summary>
        private void CarregaModulos()
        {
            //define total de módulos
            //int totalModulos = Enum.GetNames(typeof(Modulo)).Length;
            int totalModulos = 1;
            barraProgresso.Minimum = 0;
            barraProgresso.Maximum = totalModulos;

            infoLabel.Text = "Carregando módulos...";
            
            //força desta forma a criar os módulos
            ModulosFactory  c1  = ModulosFactory.Instance;
            //força desta forma a criar os calculos
            CalculosFactory c2  = CalculosFactory.Instance;
            //força desta forma a criar os pools de objetos
            PoolFactory     c3  = PoolFactory.Instance;
            barraProgresso.Value++; //incrementa
            

        }

        #endregion

    }
}
