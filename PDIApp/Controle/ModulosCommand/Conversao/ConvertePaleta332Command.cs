using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Flyweight;

namespace PDIApp.Controle.ModulosCommand.Conversao
{
    class ConvertePaleta332Command: ParallelModuloCommand
    {
        protected override System.Drawing.Color OperacaoPixel(int x, long y, System.Drawing.Color c)
        {
            return PoolFactory.Instance.PoolRGB322Palette[c];
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Convertendo para paleta RGB 3-3-2 bit...";
        }
    }
}
