using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR.Similaridade
{
    class InterseccaoHistogramas: IMedidaSimilaridade
    {
        #region IMedidaSimilaridade Members

        public double CalculaSimilaridade(IDescritor query, IDescritor imagem)
        {
            Modelo.Histograma histQuery = (Modelo.Histograma)query.GetDescritor();
            Modelo.Histograma histTeste = (Modelo.Histograma)imagem.GetDescritor();

            double soma = 0;

            for (int i = 0; i < 256; i++)
            {
                int q = histQuery[(byte)i];
                int t = histTeste[(byte)i];

                soma += Math.Min(q, t) / Math.Max(q, t);
            }

            return soma;
        }

        #endregion
    }
}
