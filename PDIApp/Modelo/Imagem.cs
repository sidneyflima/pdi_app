using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PDIApp.Modelo
{
    /// <summary>
    /// Classe que representa uma imagem.
    /// </summary>
    public class Imagem
    {
        #region Atributos

        /// <summary>A imagem em Bitmap</summary>
        private Bitmap bitmap;
        /// <summary>Representacao da linha de uma imagem</summary>
        private ImagemLinha linha;
        /// <summary>Ponteiro para a primeiro pixel</summary>
        IntPtr ponteiroImagemPtr = IntPtr.Zero;
        /// <summary>Os dados da imagem</summary>
        BitmapData dados = null;
        /// <summary>Array de pixels</summary>
        byte[] pixels;
        /// <summary>Quantidade de bytes por pixel</summary>
        int bpp;
        /// <summary>Largura</summary>
        int largura;
        /// <summary>Altura</summary>
        int altura;


        #endregion

        #region Propriedades

        /// <summary>A largura da imagem</summary>
        public int Largura { get { return largura; } }
        /// <summary>A altura da imagem</summary>
        public int Altura  { get { return altura; } }
        /// <summary>Obtem a imagem bitmap</summary>
        public Bitmap ImagemBitmap 
        { 
            get { return bitmap; } 
            set 
            { 
                bitmap = value;
                this.linha.ImagemBitmap = value;
                this.largura = bitmap.Width;
                this.altura = bitmap.Height;
            }
        }
        /// <summary>Informa se a imagem está bloqueada ou não</summary>
        public bool Bloqueada { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria uma imagem através de um bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        public Imagem(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            this.linha = new ImagemLinha(this.bitmap, 0);
            this.largura = bitmap.Width;
            this.altura = bitmap.Height;
            this.Bloqueada = false;
        }

        /// <summary>
        /// Cria uma imagem através de um stream
        /// </summary>
        /// <param name="stream"></param>
        public Imagem(Stream stream)
            :this(new Bitmap(stream))
        {
            
        }

        #endregion

        #region Indexadores
        
        /*
        /// <summary>
        /// Obtem a linha de uma imagem.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <exception cref="Exception.ArgumentException">Caso o x ultrapasse os limites</exception>
        public ImagemLinha this[int x]
        {
            get
            {                
                this.linha.X = x;
                return this.linha;
            }
        }
        */

        #endregion 

        #region Metodos

        #region Definindo Bitmap

        /// <summary>
        /// Copia imagem bitmap para imagem passada por parametro.
        /// Apenas atribui o mesmo objeto sem criar um novo bitmap
        /// </summary>
        /// <param name="destino"></param>
        public void CopiarBitmapParaImagem(Imagem destino)
        {
            destino.bitmap = bitmap;
        }

        /// <summary>
        /// Copia nova imagem bitmap para imagem passada por parametro.
        /// Este procedimento aloca um novo objeto para a imagem de destino
        /// com os valores do anterior
        /// </summary>
        /// <param name="destino"></param>
        public void CopiarNovoBitmapParaImagem(Imagem destino)
        {
            destino.bitmap = bitmap;
        }

        #endregion

        #region Manipulacao Bits e Pixel

        /// <summary>
        /// Bloqueia imagem bitmap
        /// </summary>
        public void BloqueiaBits()
        {
            //obtem total de pixels bloqueados
            int quantidadePixels = Largura * Altura;

            // obtem a quantidade de bits por pixel
            bpp = Bitmap.GetPixelFormatSize(bitmap.PixelFormat);

            //verifica se é diferente de 8, 24 ou 32
            if (bpp != 8) if(bpp != 24) if(bpp != 32)
                throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");

            // cria retangulos para bloquear
            Rectangle rect = new Rectangle(0, 0, Largura, Altura);
            // bloqueia bitmap e obtem os dados
            dados = bitmap.LockBits(rect, ImageLockMode.ReadWrite,
                                            ImagemBitmap.PixelFormat);

            // obtem passo para x
            int passo = bpp / 8;
            //obtem array de pixels
            pixels = new byte[quantidadePixels * passo];
            //define posicao do primeiro pixel da imagem
            ponteiroImagemPtr = dados.Scan0;

            //Copia dados da imagem para o array
            Marshal.Copy(ponteiroImagemPtr, pixels, 0, pixels.Length);

            Bloqueada = true;
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void DesbloqueiaBits()
        {
            // Copia dados dos pixels para a imagem
            Marshal.Copy(pixels, 0, ponteiroImagemPtr, pixels.Length);
            //Desbloqueia dados do bitmap
            bitmap.UnlockBits(dados);

            Bloqueada = false;
        }


        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            if (!Bloqueada)
                throw new InvalidOperationException("A imagem deve estar bloqueada para obter pixels");

            int i = ObterIndicePixel(x, y);

            //se for monocromatico
            if (bpp == 8)
                return Color.FromArgb(pixels[i], pixels[i], pixels[i]);

            //se for RGB
            if (bpp == 24)
                return Color.FromArgb(pixels[i + 2], pixels[i + 1], pixels[i]);
                //R {i+2}; G {i+1}; B {i}
            

            //se for ARGB
            byte b = pixels[i];
            byte g = pixels[i + 1];
            byte r = pixels[i + 2];
            byte a = pixels[i + 3];
            
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            if (!Bloqueada)
                throw new InvalidOperationException("A imagem deve estar bloqueada para definir pixels");

            int i = ObterIndicePixel(x, y);

            //se for monocromatico
            if (bpp == 8)
                pixels[i] = color.B;
            //se for RGB
            if (bpp == 24)
            {
                pixels[i] = color.B;
                pixels[i + 1] = color.G;
                pixels[i + 2] = color.R;
            }
            //se for ARGB
            if (bpp == 32)
            {
                pixels[i] = color.B;
                pixels[i + 1] = color.G;
                pixels[i + 2] = color.R;
                pixels[i + 3] = color.A;
            }
        }

        /// <summary>
        /// Dado posicoes do pixel, retorna o indice inicial do vetor de pixels
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ObterIndicePixel(int x, int y)
        {
            //obter quantidade de bytes por pixel
            int bytes = bpp / 8;
            //retorna indice de inicio
            int i =  ((y * largura) + x) * bytes;

            if (i > pixels.Length - bytes)
                throw new IndexOutOfRangeException();

            return i;
        }

        #endregion

        #endregion
    }
}
