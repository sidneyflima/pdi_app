using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.TransformacaoIntensidade
{
    class TransformacaoIntensidadeRGBCommand : ParallelModuloCommand
    {
        protected override Color OperacaoPixel(int x, long y, Color c)
        {
            int paramR = (int)this[Constantes.CHAVE_PARAMETRO_1];
            int paramG = (int)this[Constantes.CHAVE_PARAMETRO_2];
            int paramB = (int)this[Constantes.CHAVE_PARAMETRO_3];

            byte r = Convert.ToByte(Math.Ceiling(c.R * (paramR / 100.0)));
            byte g = Convert.ToByte(Math.Ceiling(c.G * (paramG / 100.0)));
            byte b = Convert.ToByte(Math.Ceiling(c.B * (paramB / 100.0)));

            return Color.FromArgb(c.A, r, g, b);
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Transformação de intensidade RGB...";
        }
    }
}
