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
    class FatiamentoBinarioCommand : ParallelModuloCommand
    {
        #region Metodos ParallelModuloCommand

        protected override Color OperacaoPixel(int x, long y, Color c)
        {
            int bit = (int)this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR];
            return ObterCorFatiamento(c, bit);
        }


        protected override string DefinirTituloBarraProgresso()
        {
            return "Realizar fatiamento da imagem bit a bit...";
        }

        #endregion

        private Color ObterCorFatiamento(Color cor, int bit)
        {
            CalculosFactory factory = CalculosFactory.Instance;
            CalculosCores conversor = factory.CalculosCores;

            //obtem o valor em escala cinza
            int valor = conversor.ValorEscalaCinza(cor);

            //obter valor de 2 ^ bit (2 elevado a bit)
            int potencia = Convert.ToInt32(Math.Pow(2, bit));

            //obtem qual salto o valor pertence
            int salto = valor / potencia;

            //se for impar, logo aquele bit possui 1 e é a cor branca
            if (salto % 2 != 0) 
                return Color.FromArgb(cor.A, 255, 255, 255);
            else //senao possui 0 e é a cor preta
                return Color.FromArgb(cor.A, 0, 0, 0);
        }

    }
}
