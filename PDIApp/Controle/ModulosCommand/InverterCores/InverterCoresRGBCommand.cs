using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.InverterCores
{
    class InverterCoresRGBCommand: ParallelModuloCommand
    {
        protected override Color OperacaoPixel(int x, long y, System.Drawing.Color c)
        {
            return InverterCor(c);
        }

        private Color InverterCor(System.Drawing.Color c)
        {
            return Color.FromArgb(c.A,  ValorCorInversa(c.R),
                                        ValorCorInversa(c.G),
                                        ValorCorInversa(c.B));
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Invertendo as cores da imagem por RGB...";
        }


        /// <summary>
        /// Calcula cor inversa de uma banda RGB dado um valor
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public byte ValorCorInversa(byte valor)
        {
            return Convert.ToByte(255 - valor);
        }

    }
}
