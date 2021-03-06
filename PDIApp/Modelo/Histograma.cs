using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos.CBIR;

namespace PDIApp.Modelo
{
    /// <summary>
    /// Esta classe define os dados para um histograma
    /// </summary>
    public class Histograma
    {
        /// <summary>Dados para o histograma</summary>
        private int[] dados;
        /// <summary>Para realizacao de lock</summary>
        private object[] lockobj;

        /// <summary>
        /// Obtem a frequencia de pixels para determinado valor na escala cinza
        /// </summary>
        /// <param name="v">Valor da escala cinza</param>
        /// <returns></returns>
        public int this[byte v]
        {
            get
            {
                lock(lockobj[v])
                {
                    return dados[v];
                }
            }

            set
            {
                lock (lockobj[v])
                {
                    dados[v] = value;
                }
            }
        }

        /// <summary>
        /// Aloca um novo histograma
        /// </summary>
        public Histograma()
        {
            dados = new int[256];
            lockobj = new object[256];
            for (int i = 0; i < 256; i++)
                lockobj[i] = new object();
        }
    }
}
