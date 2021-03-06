using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.AjustesCor
{
    class CorrecaoTonalidadeEscurasCommand : ParallelModuloCommand
    {
        protected override System.Drawing.Color OperacaoPixel(int x, long y, System.Drawing.Color c)
        {
            int v = (int)this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR];
            return System.Drawing.Color.FromArgb(c.A, ObtemTonalidade(c.R, v),
                                                      ObtemTonalidade(c.G, v),
                                                      ObtemTonalidade(c.B, v));
        }

        private int ObtemTonalidade(int x, int v)
        {
            return (int)Math.Round(v * Math.Log(x + 1, 255));
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Corrigindo tons claros";
        }
    }
}
