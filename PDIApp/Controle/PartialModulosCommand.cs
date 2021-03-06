using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Util.Calculos;

namespace PDIApp.Controle
{
    /// <summary>
    /// Realiza operacoes em paralelo, porem particionando a imagem em grids 4x4 recursivas e operando cada
    /// subimagem particionada em paralelo, no lugar de operar cada pixel unicamente em paralelo.
    /// 
    /// É util para operações que requer dependencia entre os pixels, como por exemplo os filtros
    /// </summary>
    abstract class PartialModulosCommand: ModuloCommand
    {
        /// <summary>Quantidade mínima de pixels na imagem em largura para iniciar particionamento</summary>
        const int MinPixelAmountWidth = 50;
        /// <summary>Quantidade mínima de pixels na imagem em altura para iniciar particionamento</summary>
        const int MinPixelAmountHeight = 50;


        const int MaxDivisoes = 4;

        protected override object RealizaExecucaoRetorna(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            return null;
        }

        protected override void RealizaExecucao(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            //obtem a menor dimensao da imagem
            int menor = (auxImagem.Largura > auxImagem.Altura) ? auxImagem.Altura : auxImagem.Largura;

            //calcule log2 desta menor dimensao e indique no grau de particionamento p
            //e obtem o piso (para nao exceder quantidade de pixels da largura ou altura)

            int p = Convert.ToInt32(Math.Floor(Math.Log(menor, 2.0)));

            if (p > MaxDivisoes) p = MaxDivisoes;

            //calcula quantas divisoes em largura ou altura teremos
            int n = Convert.ToInt32(Math.Pow(2, p));

            //inicializa para encontrar a variacao de pixels (continua) entre uma particao e outra
            //obtendo o comprimento de uma particao
            double deltaL = auxImagem.Largura;
            double deltaA = auxImagem.Altura;

            //realiza p divisoes por 2 para obter o valor de comprimento e largura continua de cada particao
            for (int i = 0; i < p; i++)
            {
                deltaL = deltaL / 2;
                deltaA = deltaA / 2;
            }


            progresso.Minimo = 0;
            progresso.Maximo = n*n;

            //Parallel.For(0, n, j =>
            //realiza a operacao para cada particao
            for (int j = 0; j < n; j++)
            {
                int y = Convert.ToInt32(Math.Floor(j * deltaA));
                int y1 = Convert.ToInt32(Math.Floor((j + 1) * deltaA));
                //Parallel.For(0, n, i =>
                for (int i = 0; i < n; i++)
                {
                    int x = Convert.ToInt32(Math.Floor(i * deltaL));
                    int x1 = Convert.ToInt32(Math.Floor((i + 1) * deltaL));
                    OperacaoSubImagem(auxImagem, x, y, x1 - x, y1 - y);

                    progresso.IncrementaBarra(); 
                }//);

                //progresso.ValorBarra++;                   
                
            }//);
        }

        protected abstract void OperacaoSubImagem(Modelo.Imagem auxImagem, int xini, int yini, int largura, int altura);

    }
}
