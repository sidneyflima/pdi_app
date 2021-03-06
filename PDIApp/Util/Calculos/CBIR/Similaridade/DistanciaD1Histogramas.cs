using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos.Histograma;

namespace PDIApp.Util.Calculos.CBIR.Similaridade
{
    class DistanciaD1Histogramas:IMedidaSimilaridade
    {
        #region IMedidaSimilaridade Members

        public double CalculaSimilaridade(IDescritor query, IDescritor imagem)
        {
            Modelo.Histograma histQuery = (Modelo.Histograma) query .GetDescritor();
            Modelo.Histograma histTeste = (Modelo.Histograma) imagem.GetDescritor();

            double soma = 0;

            for (int i = 0; i < 256; i++)
            {
                int q = histQuery[(byte)i];
                int t = histTeste[(byte)i];

                double num = Math.Abs(q - t);
                int    dem = 1 + q + t;

                soma += num / dem;
            }

            return soma;
        }


        #endregion
    }
}
