using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    /// <summary>
    /// Abstracao para aplicacao de filtros 
    /// </summary>
    abstract class FiltrosModulosCommand: PartialModulosCommand
    {
        protected override void OperacaoSubImagem(Modelo.Imagem auxImagem, int xini, int yini, int largura, int altura)
        {
            //recupera dimensao da mascara
            Point dim = DimensaoMascara();

            int[][] mascara = new int[dim.Y][];
            for (int i = 0; i < dim.Y; i++)
                mascara[i] = new int[dim.X];

            //preenche mascara
            PreencherMascara(mascara, dim);

            //aplica filtro na sub imagem
            for (int i = 0; i < largura; i++)
            {
                for (int j = 0; j < altura; j++)
                {
                    //obtem x e y
                    int x = i + xini; 
                    int y = j + yini;

                    //calcule filtro detornando o valor para x e y
                    Color c = ComputarFiltro(auxImagem, x, y, mascara, dim);

                    //define o pixel na imagem
                    auxImagem.SetPixel(i + xini, j + yini, c);
                }
            }                   
        }
        /// <summary>
        /// Calcule o filtro, retornando a nova cor para aquele pixel
        /// </summary>
        /// <param name="auxImagem">Imagem auxiliar</param>
        /// <param name="x">Posicao x na imagem original a ser tratado pela mascara</param>
        /// <param name="y">Posicao y na imagem original a ser tratado pela mascara</param>
        /// <returns>A nova cor daquele pixel</returns>
        
        protected virtual Color ComputarFiltro(Modelo.Imagem auxImagem, int x, int y, int[][] mascara, Point dim)
        {
            //obtem dimensao da mascara em X e Y
            int x1, y1;

            DefinirPontoInicial(x, y, dim, out x1, out y1);

            int somaR = 0;
            int somaG = 0;
            int somaB = 0;

            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    Color c = ObterCorPixel(auxImagem, x1 + i, y1 + j);
                    //calcular mascara para R, G e B
                    somaR += c.R * mascara[i][j];
                    somaG += c.G * mascara[i][j];
                    somaB += c.B * mascara[i][j];
                }
            }

            int somaMascara = FatorDivisao(mascara, dim);

            somaR = somaR / somaMascara;
            somaG = somaG / somaMascara;
            somaB = somaB / somaMascara;

            if (somaR < 0) somaR = 0;
            if (somaG < 0) somaG = 0;
            if (somaB < 0) somaB = 0;

            if (somaR > 255) somaR = 255;
            if (somaG > 255) somaG = 255;
            if (somaB > 255) somaB = 255;

            //retorna nova cor
            return Color.FromArgb(auxImagem.GetPixel(x, y).A,
                                 somaR, somaG, somaB); 
        }

        /// <summary>
        /// Define ponto inicial para a mascara. Por padrao o ponto inicial depende da dimensao, tornando
        /// x e y como o centro.
        /// </summary>
        protected virtual void DefinirPontoInicial(int x, int y, Point dim, out int x1, out int y1)
        {
            //obtem dimensao da mascara em X e Y
            x1 = x - (dim.X / 2);
            y1 = y - (dim.Y / 2);
        }

        /// <summary>
        /// Obtem a cor do pixel na posicao x e y. Caso algum destas coordenadas forem negativas,
        /// obtem a cor do mais proximo, realizando tratamento das bordas.
        /// 
        /// Por exemplo se (-2,3), obtem cor (0,3).
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected Color ObterCorPixel(Modelo.Imagem auxImagem, int x, int y)
        {
            //busca pelo pixel mais proximo na imagem, duplicando a borda
            if (x < 0)  return ObterCorPixel(auxImagem, x + 1, y);
            if (y < 0)  return ObterCorPixel(auxImagem, x, y + 1);
            if (x >= auxImagem.Largura)  return ObterCorPixel(auxImagem, x - 1, y);
            if (y >= auxImagem.Altura )  return ObterCorPixel(auxImagem, x, y - 1);

            return auxImagem.GetPixel(x, y);
        }

        /// <summary>
        /// Retorna qual o valor a ser dividido para cada cor.
        /// Ex.: em filtros lineares como a media, o fator de divisao é a soma de todos
        /// os elementos da mascara
        /// </summary>
        /// <param name="mascara"></param>
        /// <param name="dim"></param>
        /// <returns></returns>
        protected virtual int FatorDivisao(int[][] mascara, Point dim)
        {
            int somaMascara = 0;

            for (int i = 0; i < dim.X; i++)
                for (int j = 0; j < dim.Y; j++)
                    somaMascara += mascara[i][j];

            return somaMascara;
        }

        #region Metodos Template

        /// <summary>Preenche a mascara pré-alocada</summary>
        /// <param name="mascara">A mascara pré-alocada</param>
        /// <param name="dim">Dimensao da mascara</param>
        protected abstract void  PreencherMascara(int[][] mascara, Point dim);
        
        /// <summary>Recupera dimensao da mascara</summary>
        protected abstract Point DimensaoMascara();

        

        #endregion

    }
}
