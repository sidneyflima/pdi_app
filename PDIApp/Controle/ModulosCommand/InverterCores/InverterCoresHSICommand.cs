using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.InverterCores
{
    class InverterCoresHSICommand : ParallelModuloCommand
    {
        protected override System.Drawing.Color OperacaoPixel(int x, long y, System.Drawing.Color c)
        {
            CalculosCores conversor = CalculosFactory.Instance.CalculosCores;
            double[] hsi = conversor.RGBParaHSI(c);

            hsi[2] = ValorInversoI(hsi[2]);

            //calcula H e S se s != 0
            if (hsi[1] != 0)
            {
                hsi[0] = ValorInversoH(hsi[0]);
                hsi[1] = ValorInversoS(hsi[1]);
            }

            return conversor.HSIParaRGB(c.A, hsi[0], hsi[1], hsi[2]);
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Invertendo as cores da imagem por RGB...";
        }

        private double ValorInversoH(double h)
        {
            if (h < 0.5) return h + 0.5;
            if (h > 0.5) return h - 0.5;

            return 0.5;
        }

        private double ValorInversoS(double s)
        {
            return s;
        }

        private double ValorInversoI(double i)
        {
            return 1 - i;
        }
    }
}
