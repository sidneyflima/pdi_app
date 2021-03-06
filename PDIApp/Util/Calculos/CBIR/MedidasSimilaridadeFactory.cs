using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos.CBIR.Similaridade;
using PDIApp.Util.Flyweight;

namespace PDIApp.Util.Calculos.CBIR
{
    public enum TiposMedidaSimilaridade
    {
        DIFERENCA_DE_HISTOGRAMAS    = 0,
        DISTANCIA_D1                = 1,
        INTERSECCAO_HISTOGRAMAS     = 2,
        CORRELACAO_HISTOGRAMAS      = 3,
        DISTANCIA_DLOG               = 4
    }

    public class MedidasSimilaridadeFactory : FlyweightPool<TiposMedidaSimilaridade,
                                                            IMedidaSimilaridade>
    {
        #region Singleton

        private static MedidasSimilaridadeFactory instance;

        public static MedidasSimilaridadeFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new MedidasSimilaridadeFactory();
                return instance;
            }
        }

        #endregion

        private MedidasSimilaridadeFactory()
        {
            this[TiposMedidaSimilaridade.CORRELACAO_HISTOGRAMAS]    = new CorrelacaoHistogramas();
            this[TiposMedidaSimilaridade.DIFERENCA_DE_HISTOGRAMAS]  = new DiferencaHistogramas();
            this[TiposMedidaSimilaridade.DISTANCIA_D1]              = new DistanciaD1Histogramas();
            this[TiposMedidaSimilaridade.DISTANCIA_DLOG]            = new DistanciaDLOGHistogramas();
            this[TiposMedidaSimilaridade.INTERSECCAO_HISTOGRAMAS]   = new InterseccaoHistogramas();
        }
    }
}
