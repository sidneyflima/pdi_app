using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroRobertsSecundariaCommand : FiltrosRealceModulosCommand
    {
        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim)
        {
            mascara[0][0] = 0; mascara[0][1] = -1;
            mascara[1][0] = 1; mascara[1][1] =  0;
        }

        protected override System.Drawing.Point DimensaoMascara()
        {
            return new System.Drawing.Point(2, 2);
        }

        protected override int FatorDivisao(int[][] mascara, System.Drawing.Point dim)
        {
            return 1;
        }
    }
}
