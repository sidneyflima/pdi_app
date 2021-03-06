using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR.Descritores
{
    /// <summary>
    /// Trata-se de um descritor
    /// </summary>
    public class LocalBinaryPatternDescritor : IDescritor
    {
        #region Atributos

        private Modelo.Histograma hist;

        #endregion

        #region Construtores

        public LocalBinaryPatternDescritor()
        {
            hist = new Modelo.Histograma();
        }

        #endregion

        #region Indexadores

        public int this[byte b] 
        { 
            get { return hist[b];   }
            set { hist[b] = value;  }
        }

        #endregion

        #region IDescritor Members

        public Object GetDescritor()
        {
            return hist;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < 256; i++)
                builder.Append("{").Append(i).Append("}").Append(" - ").Append(hist[(byte)i]).AppendLine();

            return builder.ToString();
        }

        #endregion
    }
}
