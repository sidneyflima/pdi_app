using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos.Histograma;

namespace PDIApp.Util.Calculos.CBIR.Similaridade
{
    class CorrelacaoHistogramas:IMedidaSimilaridade
    {
        #region IMedidaSimilaridade Members

        public double CalculaSimilaridade(IDescritor query, IDescritor imagem)
        {
            Modelo.Histograma histQuery = (Modelo.Histograma)query.GetDescritor();
            Modelo.Histograma histTeste = (Modelo.Histograma)imagem.GetDescritor();
            CalculosHistograma calc = CalculosFactory.Instance.CalculosHistograma;

            double mediaQuery = calc.MediaHistograma(histQuery);
            double mediaTeste = calc.MediaHistograma(histQuery);

            double num = 0;
            double dem = 0;

            for (int i = 0; i < 256; i++)
            {
                double diffQuery = (histQuery[(byte)i] - mediaQuery);
                double diffTeste = (histTeste[(byte)i] - mediaTeste);

                num += diffQuery * diffTeste;
                dem += Math.Pow(diffQuery, 2) * Math.Pow(diffTeste, 2);
            }

            return num / dem;
        }

        #endregion
    }
}
