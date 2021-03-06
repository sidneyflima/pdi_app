using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Flyweight
{

    /// <summary>Tipo de imagem a ser retornada pelo pool</summary>
    public enum TipoImagemPool
    {
        /// <summary>Indica a imagem original</summary>
        ORIGINAL,
        /// <summary>Indica a imagem atual</summary>
        ATUAL,
        /// <summary>Indica a imagem para processamento</summary>
        AUXILIAR,
        /// <summary>Indica a imagem de busca para CBIR</summary>
        QUERY,
        /// <summary>Indica a imagem no banco para CBIR</summary>
        BANCO,
        /// <summary>Outra imagem para operacao ponto a ponto</summary>
        OPERACAO
    }

    /// <summary>
    /// Define um pool de imagens
    /// </summary>
    public class ImagemPool: FlyweightPool<TipoImagemPool, Modelo.Imagem>
    {
        #region Construtores

        public ImagemPool()
            : base()
        {
            this[TipoImagemPool.ORIGINAL]   = new Modelo.Imagem(new Bitmap(1,1));
            this[TipoImagemPool.ATUAL]      = new Modelo.Imagem(new Bitmap(1, 1));
            this[TipoImagemPool.AUXILIAR]    = new Modelo.Imagem(new Bitmap(1, 1));
            this[TipoImagemPool.QUERY]      = new Modelo.Imagem(new Bitmap(1, 1));
            this[TipoImagemPool.BANCO]      = new Modelo.Imagem(new Bitmap(1, 1));
        }

        #endregion
    }
}
