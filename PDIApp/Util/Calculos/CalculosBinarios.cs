using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos
{
    public class CalculosBinarios
    {

        /// <summary>
        /// Retorna se o bit informado é 1 no byte b. Tal bit deve estar em [0,7]
        /// </summary>
        /// <param name="b"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public bool PossuiBitUm(byte b, byte bit)
        {
            //obtem mascara, definida pelo byte b com o bit indicado setado um
            byte mascara = DefinirBitUm(b, bit);
            //se b for igual a mascara, entao o valor de xor é 0 e aquele bit é um
            byte xor = Convert.ToByte(b ^ mascara);

            return xor == 0;
        }

        /// <summary>
        /// Define o bit descrito para 1, caso seja 0 na posicao indicada por 'bit'
        /// </summary>
        /// <param name="b"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public byte DefinirBitUm(byte b, byte bit)
        {
            byte shift = ObterBitDeslocamento(bit);
            return Convert.ToByte(b | shift);
        }

        /// <summary>
        /// Retorna um byte com todos os bits com zero exceto bit a ser definido.
        /// A contagem dos bits é dada de 0 a 7.
        /// Ex: int bit = 3 => 00003000
        /// </summary>
        /// <param name="shift"></param>
        /// <returns></returns>
        public byte ObterBitDeslocamento(byte bit)
        {
            if (bit < 0)
                if (bit > 7)
                    throw new ArgumentException("Shift deve estar entre 0 a 7");

            return Convert.ToByte(1 << bit);
        }
    }
}
