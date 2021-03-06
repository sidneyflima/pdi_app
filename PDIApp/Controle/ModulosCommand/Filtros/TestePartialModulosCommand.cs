using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    class TestePartialModulosCommand : PartialModulosCommand
    {
        protected override void OperacaoSubImagem(Modelo.Imagem auxImagem, int xini, int yini, int largura, int altura)
        {
            CalculosCores calc = CalculosFactory.Instance.CalculosCores;
            Color c = calc.NovaCorAleatoria();

            for (int i = 0; i < largura; i++)
                for (int j = 0; j < altura; j++)
                    auxImagem.SetPixel(i + xini, j + yini, c);
                    /*
                    auxImagem.SetPixel(i + x, j + y, Color.FromArgb(255, calc.ValorEscalaCinza(c),
                                                                         calc.ValorEscalaCinza(c),
                                                                         calc.ValorEscalaCinza(c)));
                     * */
        }
    }
}
