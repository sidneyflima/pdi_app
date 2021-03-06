using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Util.Calculos.Histograma
{
    /// <summary>Metodos para calculos de histograma</summary>
    public class CalculosHistograma
    {
        #region Criar Histograma pela imagem

        /// <summary>
        /// Cria um vetor com 4 histogramas, cada um relacionado com R, G, B e em escala cinza
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <returns></returns>
        public Modelo.Histograma[] CriarHistograma(Modelo.Imagem auxImagem)
        {
            //bloqueia bits caso nao estiver bloqueado
            if (!auxImagem.Bloqueada)
                throw new InvalidOperationException("A imagem deve estar previamente bloqueada antes de chamar a funcao");

            Modelo.Histograma[] hist = new Modelo.Histograma[4];
            hist[0] = new Modelo.Histograma();
            hist[1] = new Modelo.Histograma();
            hist[2] = new Modelo.Histograma();
            hist[3] = new Modelo.Histograma();

            //itera sobre imagem
            //for (int x = 0; x < auxImagem.Largura; x++)
            Parallel.For(0, auxImagem.Largura, x =>
            {
                Parallel.For(0, auxImagem.Altura, y =>
                {
                    CalculosFactory factory = CalculosFactory.Instance;
                    CalculosCores conversor = factory.CalculosCores;

                    Color c = auxImagem.GetPixel(x, y);

                    //desconsidere alfa nulo
                    if (c.A != 0)
                    {
                        hist[0][c.R]++;
                        hist[1][c.G]++;
                        hist[2][c.B]++;

                        int valor = conversor.ValorEscalaCinza(c);
                        hist[3][Convert.ToByte(valor)]++;
                    }
                });
            });

            return hist;
        }

        #endregion

        #region Equalizacao de um histograma

        /// <summary>
        /// Dado um histograma, gera uma relacao de mapeamento.
        /// Cada posicao no vetor indica a escala em cinza do histograma original
        /// e o valor o novo valor cinza normalizado
        /// </summary>
        /// <param name="hist"></param>
        /// <returns></returns>
        public byte[] EqualizarHistograma(Modelo.Histograma hist)
        {
            //o mapa dos valores
            byte[] mapa = new byte[256];

            //obtem total de pixels
            int n;
            //armazenar o valor da funcao de probabilidade
            double fdp = 0;
            //armazena o valor da fda na i-ésima iteracao
            double fda;

            /***
             * PROCEDIMENTO:
             * 
             * PARA CADA FREQUENCIA NO HISTOGRAMA:
             * * CALCULE PROBABILIDADE P PARA CADA FREQUENCIA DE PIXELS
             * * CALCULE VALOR FDA COMO SENDO A SOMA DAS PROBABILIDADES ACUMULADAS ATE A 
             * I-ESIMA ITERACAO
             * * COM O VALOR DE FDA, MULTIPLIQUE PELO LIMITE E ARREDONDE O VALOR.
             * ESTE SERA O VALOR A SER COLOCADO NO MAPA NA IESIMA ITERACAO
             * 
             * */

            n = 0;

            //obtem quantos pixels tem a imagem
            for (int i = 0; i < 256; i++) 
                n += hist[Convert.ToByte(i)];

            //inicializa fda para a operacao
            fda = 0;

            //constroi o mapeamento
            for (int i = 0; i < 256; i++)
            {
                //obtem quantidade de pixels para bin histograma
                double nk = Convert.ToDouble(hist[Convert.ToByte(i)]);
                //obtem probabilidade naquele bin
                fdp    = nk / n;
                //obtem a fda ate esta iteracao
                fda += fdp;

                //encontra o novo valor daquele bin
                //multiplica pelo limite que é 256 - 1
                //obtendo o novo valor mapeado
                mapa[i] = Convert.ToByte(Math.Round(fda * 255));
            }

            return mapa;
        }

        #endregion

        #region Outros calculos
    
        /// <summary>
        /// Calcula a media dos valores de um histograma
        /// </summary>
        /// <param name="hist"></param>
        /// <returns></returns>
        public double MediaHistograma(Modelo.Histograma hist)
        {
            int soma = 0;

            for (int i = 0; i < 256; i++)
                soma += hist[(byte)i];

            return soma / 256.0;
        }

        #endregion
    }
}
