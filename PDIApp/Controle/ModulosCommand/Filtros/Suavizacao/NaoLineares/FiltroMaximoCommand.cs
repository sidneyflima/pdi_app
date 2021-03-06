using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroMaximoCommand : FiltrosModulosCommand
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

            byte maxR = byte.MinValue;
            byte maxG = byte.MinValue;
            byte maxB = byte.MinValue;

            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    Color c = base.ObterCorPixel(auxImagem, x1 + i, y1 + j);
                    if (maxR < c.R) maxR = c.R;
                    if (maxG < c.G) maxG = c.G;
                    if (maxR < c.B) maxB = c.B;
                }
            }

            return Color.FromArgb(base.ObterCorPixel(auxImagem, x, y).A,
                                  maxR, maxG, maxB);

        }

    }
}
