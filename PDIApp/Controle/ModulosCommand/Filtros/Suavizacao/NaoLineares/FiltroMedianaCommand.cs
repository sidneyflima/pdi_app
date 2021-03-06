using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroMedianaCommand: FiltrosModulosCommand
    {
        #region Funcoes nao utilizadas

        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim){ }

        #endregion

        protected override System.Drawing.Point DimensaoMascara()
        {
            int n = Convert.ToInt32(this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR]);
            return new System.Drawing.Point(n, n);
        }

        protected override System.Drawing.Color ComputarFiltro(Modelo.Imagem auxImagem, int x, int y, int[][] mascara, System.Drawing.Point dim)
        {
            int n = dim.X * dim.Y;

            //obtem dimensao da mascara em X e Y
            int x1 = x - (dim.X / 2);
            int y1 = y - (dim.Y / 2);

            //array do tamanho das dimensoes
            List<byte> listaR = new List<byte>();
            List<byte> listaG = new List<byte>();
            List<byte> listaB = new List<byte>();

            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    Color c = base.ObterCorPixel(auxImagem, x1 + i, y1 + j);
                    listaR.Add(c.R);
                    listaG.Add(c.G);
                    listaB.Add(c.B);
                }
            }

            listaR.Sort(); listaG.Sort(); listaB.Sort();

            return Color.FromArgb(base.ObterCorPixel(auxImagem, x, y).A,
                                  listaR[n / 2], listaG[n / 2], listaB[n / 2]); 
            
        }
    
    }
}
