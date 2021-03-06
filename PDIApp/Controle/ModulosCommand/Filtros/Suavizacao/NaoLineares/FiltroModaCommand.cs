using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroModaCommand : FiltrosModulosCommand
    {
        #region Funcoes nao utilizadas

        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim) { }

        #endregion

        protected override System.Drawing.Point DimensaoMascara()
        {
            int n = Convert.ToInt32(this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR]);
            return new System.Drawing.Point(n, n);
        }



        protected override System.Drawing.Color ComputarFiltro(Modelo.Imagem auxImagem, int x, int y, int[][] mascara, System.Drawing.Point dim)
        {
            //obtem dimensao da mascara em X e Y
            int x1 = x - (dim.X / 2);
            int y1 = y - (dim.Y / 2);

            Modelo.Histograma histR = new Modelo.Histograma();
            Modelo.Histograma histG = new Modelo.Histograma();
            Modelo.Histograma histB = new Modelo.Histograma();

            int valorR = 0;
            int valorG = 0;
            int valorB = 0;

            byte corR = 0, corG = 0, corB = 0;

            //conta frequencia das cores
            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    Color c = base.ObterCorPixel(auxImagem, x1 + i, y1 + j);
                    histR[c.R]++;
                    histG[c.G]++;
                    histB[c.B]++;
                }
            }

            //busca pela cor que ocorre com maior frequencia
            for (byte i = 0; i < 255; i++)
            {
                if (valorR < histR[i])
                {
                    valorR = histR[i];
                    corR = i;
                }

                if (valorG < histG[i])
                {
                    valorG = histG[i];
                    corG = i;
                }

                if (valorB < histB[i])
                {
                    valorB = histB[i];
                    corB = i;
                }
            }

            return Color.FromArgb(base.ObterCorPixel(auxImagem, x, y).A,
                                  corR, corG, corB);

        }

    }
}
