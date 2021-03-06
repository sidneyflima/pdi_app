﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class FiltroLaplaciano4Command : FiltrosRealceModulosCommand
    {
        protected override void PreencherMascara(int[][] mascara, System.Drawing.Point dim)
        {
            mascara[0][0] =  0; mascara[0][1] =  -1; mascara[0][2] =  0;
            mascara[1][0] = -1; mascara[1][1] =   4; mascara[1][2] = -1;
            mascara[2][0] =  0; mascara[2][1] =  -1; mascara[2][2] =  0;
        }

        protected override System.Drawing.Point DimensaoMascara()
        {
            return new System.Drawing.Point(3, 3);
        }

        protected override int FatorDivisao(int[][] mascara, System.Drawing.Point dim)
        {
            return mascara[1][1];
                
        }
    }
}
