using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR.Descritores
{
    public enum CCVHistograma
    {
        COERENCIA = 0, INCOERENCIA = 1
    }

    public class ColorCoherenceVectorDescritor : IDescritor
    {
        #region Atributos

        private Modelo.Histograma[] hists;

        #endregion

        #region Construtores

        public ColorCoherenceVectorDescritor()
        {
            int tamanho = Enum.GetValues(typeof(CCVHistograma)).Length;

            hists = new Modelo.Histograma[tamanho];
            for(int i = 0; i < tamanho; i++)
                hists[i] = new Modelo.Histograma();
        }

        #endregion

        #region Indexadores

        public Modelo.Histograma this[CCVHistograma c] 
        { 
            get 
            { 
                return hists[c.GetHashCode()]; 
            } 
        }

        #endregion

        #region IDescritor Members

        public Object GetDescritor()
        {
            return hists;
        }        

        #endregion

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Coerencia") ;
            for (int i = 0; i < 256; i++)
                builder.Append(hists[CCVHistograma.COERENCIA.GetHashCode()]
                                    [(byte) i]).Append(" ");

            builder.AppendLine().AppendLine("Incoerencia");
            for (int i = 0; i < 256; i++)
                builder.Append(hists[CCVHistograma.COERENCIA.GetHashCode()]
                                    [(byte)i]).Append(" ");

            return builder.ToString();
        }
    }
}
