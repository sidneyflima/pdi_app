using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Flyweight;

namespace PDIApp.Util.Calculos.CBIR
{
    public enum TiposDescritores
    {
        HISTOGRAMA_COR = 0,
        COLOR_COHERENCE_VETOR = 1,
        LOCAL_BINARY_PATTERN = 2
    }

    public class DescritoresFactory: FlyweightPool<TiposDescritores, CalculosDescritor>
    {
        #region Singleton

        private static DescritoresFactory instance;

        public static DescritoresFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new DescritoresFactory();
                return instance;
            }
        }

        #endregion

        private DescritoresFactory()
        {
            this[TiposDescritores.HISTOGRAMA_COR]           = new Calculos.CalculoDescritorHistograma();
            this[TiposDescritores.COLOR_COHERENCE_VETOR]    = new Calculos.CalculoDescritorCCV();
            this[TiposDescritores.LOCAL_BINARY_PATTERN]     = new Calculos.CalculoDescritorLBP();
        }
    }
}
