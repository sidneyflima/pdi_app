using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PDIApp.Modelo
{
    /// <summary>
    /// Representa uma linha da imagem. Ou seja, os pixels dado um valor x fixo
    /// </summary>
    public class ImagemLinha
    {
        #region Atributos
        
        /// <summary>Imagem em bitmap</summary>
        private Bitmap bitmap;
        /// <summary>Posicao da linha</summary>
        private int x;

        #endregion

        #region Propriedades

        /// <summary>
        /// Recupera e define a posicao da linha a ser avaliada
        /// </summary>
        public int X
        {
            get { return x; }
            set
            {
                VerificaArgumentoLinha(bitmap.Width, value);
                this.x = value;
            }
        }

        /// <summary>
        /// Recupera e define a imagem bitmap
        /// </summary>
        public Bitmap ImagemBitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria uma nova linha para a imagem
        /// </summary>
        /// <param name="bitmap">A imagem em bitmap</param>
        /// <param name="x">A posicao da linha</param>
        public ImagemLinha(Bitmap bitmap, int x)
        {
            VerificaArgumentoLinha(bitmap.Width, x);

            this.bitmap = bitmap;
            this.x  = x;
        }

        #endregion

        #region Indexadores

        /// <summary>
        /// Recupera uma cor da imagem
        /// </summary>
        /// <param name="y">A posicao y da imagem (coluna)</param>
        /// <returns>A cor na posicao (x,y)</returns>
        public Color this[int y]
        {
            get 
            {
                VerificaArgumentoColuna(bitmap.Height, y);
                return bitmap.GetPixel(this.x, y);
            }
            set
            {
                VerificaArgumentoColuna(bitmap.Height, y);
                bitmap.SetPixel(this.x, y, value);
            }
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Verifica os argumentos da linha da imagem (valor para x)
        /// </summary>
        /// <param name="largura">O valor da largura da imagem</param>
        /// <param name="x">O valor da linha da imagem</param>
        private void VerificaArgumentoLinha(int largura, int x)
        {
            if (x < 0)
                throw new ArgumentException("O argumento 'linha' é menor que 0");
            if (x >= largura)
                throw new ArgumentException("O argumento 'linha' deve ser menor que a largura = " + largura + " da imagem");
        }

        /// <summary>
        /// Verifica os argumentos da coluna da imagem (valor de y)
        /// </summary>
        /// <param name="altura">O valor da altura da imagem</param>
        /// <param name="linha">O valor da linha da imagem</param>
        private void VerificaArgumentoColuna(int altura, int y)
        {
            if (y < 0)
                throw new ArgumentException("O argumento 'linha' é menor que 0");
            if (y >= altura)
                throw new ArgumentException("O argumento 'linha' deve ser menor que a altura = " + altura + " da imagem");
        }

        #endregion
    }
}
