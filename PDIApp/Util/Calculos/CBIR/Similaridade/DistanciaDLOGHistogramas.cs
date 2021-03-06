using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR.Similaridade
{
    class DistanciaDLOGHistogramas: IMedidaSimilaridade
    {
        #region IMedidaSimilaridade Members

        public double CalculaSimilaridade(IDescritor query, IDescritor imagem)
        {
            Modelo.Histograma histQuery = (Modelo.Histograma)query.GetDescritor();
            Modelo.Histograma histTeste = (Modelo.Histograma)imagem.GetDescritor();

            int soma = 0;

            for (int i = 0; i < 256; i++)
            {
                int q = histQuery[(byte)i];
                int t = histTeste[(byte)i];
                soma += Math.Abs(DLog(q) - DLog(t));
            }

            return soma;
        }

        private int DLog(double value)
        {
            if (value <= 0) return 0;
            if (value <= 1) return 1;
            return (int) Math.Round(Math.Log(value, 2.0)) + 1;
        }

        #endregion
    }
}
