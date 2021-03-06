using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Modelo;

namespace PDIApp.Controle
{
    /// <summary>
    /// Define um modulo command para operações pixel a pixel.
    /// Tais operações apenas obtem a cor de uma imagem e convertem para outra cor.
    /// Desta forma este módulo implementa de forma paralela utilizando Threads, o que 
    /// torna tais operações mais rápidas
    /// </summary>
    abstract class ParallelModuloCommand : ModuloCommand
    {
        #region Metodos Command

        protected override object RealizaExecucaoRetorna(Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            return null;
        }

        protected override void RealizaExecucao(Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            //define titulo
            progresso.Titulo = DefinirTituloBarraProgresso();

            //nova definicao para o processo
            progresso.Maximo = auxImagem.Largura;

            //itera cada pixel para manipular imagem
            for (int x = 0; x < auxImagem.Largura; x++)
            {
                //for (int y = 0; y < auxImagem.Altura; y++)
                Parallel.For(0, auxImagem.Altura, y =>
                {
                    Color c = auxImagem.GetPixel(x, y);
                    Color novaCor = OperacaoPixel(x, y, c);
                    auxImagem.SetPixel(x, y, novaCor);
                    //progresso.ValorBarra++;
                });
                progresso.ValorBarra++;
            }
        }

        #endregion

        #region Metodos Template

        /// <summary>
        /// Realiza operação pixel a pixel, modificando uma cor em outra
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        protected abstract Color OperacaoPixel(int x, long y, Color c);

        /// <summary>
        /// Define o titulo da barra de progresso
        /// </summary>
        /// <returns></returns>
        protected abstract string DefinirTituloBarraProgresso();

        #endregion

    }
}
