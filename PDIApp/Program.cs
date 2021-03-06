using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PDIApp.Modelo;

namespace PDIApp
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IniciarAplicacao();
        }

        private static void IniciarAplicacao()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form splash = new Visao.SplashInicial();
            DialogResult result = splash.ShowDialog();

            switch(result)
            {
                case DialogResult.Yes:
                    Application.Run(new Visao.SplashForm());
                    Application.Run(new Visao.FormPrincipal());
                    break;

                case DialogResult.No:
                    if (new Visao.CBIR.SplashCBIR().ShowDialog() == DialogResult.OK)
                        new Visao.CBIR.FormCBIRTeste().ShowDialog();
                    break;

                default:
                    break;
            }

        }
    }
}
