using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroMediaSimplesCommand : FiltrosModulosCommand
    {
        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim)
        {
            for (int i = 0; i < mascara.Length; i++)
                for (int j = 0; j < mascara[i].Length; j++)
                    mascara[i][j] = 1;

        }

        protected override System.Drawing.Point DimensaoMascara()
        {
            int n = Convert.ToInt32(this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR]);

            if (n % 2 == 0) n++;
            //mascara de dimensao 3x3
            return new System.Drawing.Point(n, n);
        }
    }
}
