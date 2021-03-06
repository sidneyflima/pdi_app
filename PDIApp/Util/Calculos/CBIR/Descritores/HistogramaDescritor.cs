using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR.Descritores
{
    /// <summary>
    /// Descritor de cor baseado no histograma
    /// </summary>
    public class HistogramaDescritor: IDescritor
    {
        #region Atributos

        Modelo.Histograma hist;
        object[] _syncRoot;

        #endregion

        #region Construtores

        public HistogramaDescritor()
        {
            hist = new Modelo.Histograma();
            _syncRoot = new object[256];
            for (int i = 0; i < 256; i++)
                _syncRoot[i] = new object();
        }

        #endregion

        #region Construtores

        public int this[byte b] 
        {
            get { lock (_syncRoot[b]) { return hist[b];  } }
            set { lock (_syncRoot[b]) { hist[b] = value; } }
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
