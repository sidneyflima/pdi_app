using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.Conversao
{
    class ConverteBinariaCommand : ParallelModuloCommand
    {
        #region Metodos ParallelModuloCommand

        protected override Color OperacaoPixel(int x, long y, Color c)
        {
            int limiar = (int)this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR];
            return ObterCorBinaria(c, limiar);
        }



        protected override string DefinirTituloBarraProgresso()
        {
            return "Converter para imagem binária...";
        }

        #endregion


        private Color ObterCorBinaria(Color cor, int limiar)
        {
            CalculosFactory factory = CalculosFactory.Instance;
            CalculosCores conversor = factory.CalculosCores;

            if(conversor.ValorBinario(cor, limiar))
                return Color.FromArgb(cor.A, 255, 255, 255);
            else
                return Color.FromArgb(cor.A, 0, 0, 0);
        }

    }
}
