using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Modelo;

namespace PDIApp.Controle.ModulosCommand.Operacoes
{
    class ExibirApenasBandaCorCommand: ParallelModuloCommand
    {
        protected override System.Drawing.Color OperacaoPixel(int x, long y, Color c)
        {
            BandaCorARGB banda = (BandaCorARGB) this[Constantes.CHAVE_ARGUMENTO_BANDA_COR];
            return ObterCorPelaBanda(c, banda);
        }

        protected override string DefinirTituloBarraProgresso()
        {
            BandaCorARGB banda = (BandaCorARGB) this[Constantes.CHAVE_ARGUMENTO_BANDA_COR];
            return "Exibindo imagem pela banda " + banda.ToString();
        }

        /// <summary>
        /// Obtem a cor pela banda de cor. Se for RED, por exemplo, somente o valor da 
        /// banda vermelha da cor será exibida.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private Color ObterCorPelaBanda(Color c, BandaCorARGB banda)
        {
            Color cor = Color.FromArgb(c.A, c);
            switch (banda)
            {
                case BandaCorARGB.RED:
                    cor = Color.FromArgb(c.A, c.R, 0, 0);
                    break;
                case BandaCorARGB.GREEN:
                    cor = Color.FromArgb(c.A, 0, c.G, 0);
                    break;
                case BandaCorARGB.BLUE:
                    cor = Color.FromArgb(c.A, 0, 0, c.B);
                    break;
            }

            return cor;
        }
    }
}
