using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroGaussianoCommand : FiltrosModulosCommand
    {
        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim)
        {
            mascara[0][0] = 1; mascara[0][1] = 4;  mascara[0][2] = 7;  mascara[0][3] = 4;  mascara[0][4] = 1;
            mascara[1][0] = 4; mascara[1][1] = 16; mascara[1][2] = 26; mascara[1][3] = 16; mascara[1][4] = 4;
            mascara[2][0] = 7; mascara[2][1] = 26; mascara[2][2] = 41; mascara[2][3] = 26; mascara[2][4] = 7;
            mascara[3][0] = 4; mascara[3][1] = 16; mascara[3][2] = 26; mascara[3][3] = 16; mascara[3][4] = 4;
            mascara[4][0] = 1; mascara[4][1] = 4;  mascara[4][2] = 7;  mascara[4][3] = 4;  mascara[4][4] = 1;
        }

        protected override System.Drawing.Point DimensaoMascara()
        {
            return new System.Drawing.Point(5, 5);
        }
    }
}
