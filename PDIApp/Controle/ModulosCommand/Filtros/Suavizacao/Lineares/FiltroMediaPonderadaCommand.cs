using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroMediaPonderadaCommand: FiltrosModulosCommand
    {
        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim)
        {
            mascara[0][0] = 1; mascara[0][1] = 1; mascara[0][2] = 1;
            mascara[1][0] = 2; mascara[1][1] = 4; mascara[1][2] = 2;
            mascara[2][0] = 1; mascara[2][1] = 2; mascara[2][2] = 1;
        }

        protected override System.Drawing.Point DimensaoMascara()
        {
            //int n = Convert.ToInt32(this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR]);

            //if (n % 2 == 0) n++;
            //mascara de dimensao 3x3
            return new System.Drawing.Point(3, 3);
        }
    }
}
