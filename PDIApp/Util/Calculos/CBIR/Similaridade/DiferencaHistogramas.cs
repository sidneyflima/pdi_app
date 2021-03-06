using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR.Similaridade
{
    class DiferencaHistogramas: IMedidaSimilaridade
    {
        #region IMedidaSimilaridade Members

        public double CalculaSimilaridade(IDescritor query, IDescritor imagem)
        {
            Modelo.Histograma histQuery = (Modelo.Histograma) query.GetDescritor();
            Modelo.Histograma histTeste = (Modelo.Histograma) imagem.GetDescritor();

            int soma = 0;

            for (int i = 0; i < 256; i++)
                soma += Math.Abs(histQuery[(byte) i] - histTeste[(byte) i]);

            return Convert.ToDouble(soma);
        }

        #endregion
    }
}
