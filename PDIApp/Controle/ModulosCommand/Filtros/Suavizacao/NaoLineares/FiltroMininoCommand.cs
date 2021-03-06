using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroMininoCommand : FiltrosModulosCommand
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

            byte minR = byte.MaxValue;
            byte minG = byte.MaxValue;
            byte minB = byte.MaxValue;

            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    Color c = base.ObterCorPixel(auxImagem, x1 + i, y1 + j);
                    if (minR > c.R) minR = c.R;
                    if (minG > c.G) minG = c.G;
                    if (minR > c.B) minB = c.B;
                }
            }

            return Color.FromArgb(base.ObterCorPixel(auxImagem, x, y).A,
                                  minR, minG, minB);

        }

    }
}
