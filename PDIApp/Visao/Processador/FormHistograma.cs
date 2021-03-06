using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PDIApp.Visao
{
    public partial class FormHistograma : Form
    {
        public FormHistograma(Modelo.Histograma[] h)
        {
            InitializeComponent();
            
            if(h.Length != 4)
            {
                throw new ArgumentException("Deve ser informado os 4 histogramas relacionados à cor " +
                                            "R, B, G e imagem em escala cinza");
                                        
            }

            for (byte i = 0; i < 255; i++)
            {
                AdicionaPontoR(i+1, h[0][i]);
                AdicionaPontoG(i + 1, h[1][i]);
                AdicionaPontoB(i + 1, h[2][i]);
                AdicionaPontoGray(i + 1, h[3][i]);
            }
            
        }

        const string NOME_SERIE = "Histograma";

        #region Eventos

        private void linhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Bar);
        }

        private void colunasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Column);
        }

        private void areaSplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.SplineArea);
        }

        private void linhasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.FastLine);
        }

        private void splineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Spline);
        }

        private void pontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Point);
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Area);
        }

        private void radarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Radar);
        }

        private void polarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineTipoGrafico(SeriesChartType.Polar);
        }

        private void exibirHistograma3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isChecked = exibirHistograma3DToolStripMenuItem.Checked;
            DefineGrafico3D(isChecked);
        }

        #endregion

        #region Configuracoes do Grafico

        private void DefineGrafico3D(bool enabled)
        {
            graficoR.ChartAreas["ChartArea"].Area3DStyle.Enable3D = enabled;
            graficoG.ChartAreas["ChartArea"].Area3DStyle.Enable3D = enabled;
            graficoB.ChartAreas["ChartArea"].Area3DStyle.Enable3D = enabled;
            graficoGray.ChartAreas["ChartArea"].Area3DStyle.Enable3D = enabled;
        }

        private void DefineTipoGrafico(SeriesChartType type)
        {
            graficoR.Series[NOME_SERIE].ChartType = type;
            graficoG.Series[NOME_SERIE].ChartType = type;
            graficoB.Series[NOME_SERIE].ChartType = type;
            graficoGray.Series[NOME_SERIE].ChartType = type;
        }

        #endregion

        #region Adiciona pontos

        /// <summary>Adiciona ponto no grafico do histograma para R</summary>
        private void AdicionaPontoR(double x, double y)
        {
            graficoR.Series[NOME_SERIE].Points.AddXY(x, y);
        }
        /// <summary>Adiciona ponto no grafico do histograma para R</summary>
        private void AdicionaPontoR(byte x, int y)
        {
            double x1 = Convert.ToDouble(x);
            double y1 = Convert.ToDouble(y);
            graficoR.Series[NOME_SERIE].Points.AddXY(x1, y1);
        }
        /// <summary>Adiciona ponto no grafico do histograma para G</summary>
        private void AdicionaPontoG(double x, double y)
        {
            graficoG.Series[NOME_SERIE].Points.AddXY(x, y);
        }
        /// <summary>Adiciona ponto no grafico do histograma para G</summary>
        private void AdicionaPontoG(byte x, int y)
        {
            double x1 = Convert.ToDouble(x);
            double y1 = Convert.ToDouble(y);
            graficoG.Series[NOME_SERIE].Points.AddXY(x1, y1);
        }
        /// <summary>Adiciona ponto no grafico do histograma para B</summary>
        private void AdicionaPontoB(double x, double y)
        {
            graficoB.Series[NOME_SERIE].Points.AddXY(x, y);
        }
        /// <summary>Adiciona ponto no grafico do histograma para B</summary>
        private void AdicionaPontoB(byte x, int y)
        {
            double x1 = Convert.ToDouble(x);
            double y1 = Convert.ToDouble(y);
            graficoB.Series[NOME_SERIE].Points.AddXY(x1, y1);
        }
        /// <summary>Adiciona ponto no grafico do histograma para Escala Cinza</summary>
        private void AdicionaPontoGray(double x, double y)
        {
            graficoGray.Series[NOME_SERIE].Points.AddXY(x, y);
        }
        /// <summary>Adiciona ponto no grafico do histograma para Escala Cinza</summary>
        private void AdicionaPontoGray(byte x, int y)
        {
            double x1 = Convert.ToDouble(x);
            double y1 = Convert.ToDouble(y);
            graficoGray.Series[NOME_SERIE].Points.AddXY(x1, y1);
        }

        #endregion
    }
}
