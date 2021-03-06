using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Flyweight
{
    /// <summary>
    /// Dado uma cor, retorna a cor equivalente na paleta de cores
    /// </summary>
    public class RGB322PalettePool : FlyweightPool<byte, Color>
    {
        #region Atributos

        byte[] RValues;
        byte[] GValues;
        byte[] BValues;

        #endregion

        #region Construtores

        public RGB322PalettePool()
        {
            RValues = new byte[] { 0, 36, 73, 109, 146, 182, 219, 255 };
            GValues = new byte[] { 0, 36, 73, 109, 146, 182, 219, 255 };
            BValues = new byte[] { 0, 85, 170, 255 };

            this[0] = GerarCorPaleta(0);
            for (byte i = 0; i < 255; i++)
                this[Convert.ToByte(i + 1)] = GerarCorPaleta(i + 1);
        }

        #endregion

        #region Indexadores

        /// <summary>
        /// Dado uma cor, obtem a cor da paleta correspondente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Color this[Color c]
        {
            get { return ObterCorPaleta(c); }
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Obtem a cor dado o valor da paleta de 0 a 255
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Color GerarCorPaleta(int i)
        {
            int resto = i;

            int r = resto / 32;
            resto = resto % 32;

            int g = resto / 4;
            resto = resto % 4;

            int b = resto;

            return Color.FromArgb(RValues[r], GValues[g], BValues[b]);
        }

        /// <summary>
        /// Obtem a cor da paleta referente a uma cor do ARGB
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Color ObterCorPaleta(Color c)
        {
            return this[ObterBytePaleta(c)];
        }

        /// <summary>
        /// Obtem a cor da paleta referente a uma cor do ARGB
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public byte ObterBytePaleta(Color c)
        {
            int r = ObterPosicaoValor(RValues, c.R);
            int g = ObterPosicaoValor(GValues, c.G);
            int b = ObterPosicaoValor(BValues, c.B);

            return Convert.ToByte(r * 32 + g * 4 + b);
        }

        private int ObterPosicaoValor(byte[] V, byte valor)
        {
            //inicia V com o valor da posicao para busca
            int i = V.Length - 2;
            //busca posicao onde o valor ultrapassa o valor do vetor V
            while (valor < V[i] && i >= 0) i--;

            //o valor esta agora no intervalo de [ V[i] , V[i+1] ]

            //calcula distancia do valor do parametro entre o menor valor do intervalo
            //e o maior valor do intervalo
            int menor = V[i]; int maior = V[i + 1];
            menor = Math.Abs(menor - valor);
            maior = Math.Abs(maior - valor);

            //se 'valor' mais proximo do maior, retorne o maior
            if (maior < menor) return i + 1;
            //do contrario retorne o menor
            else return i;

        }

        #endregion
    }
}
