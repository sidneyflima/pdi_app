using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Flyweight
{
    public class PoolFactory
    {
        #region Singleton

        private static PoolFactory instance;
        private static object _syncRoot = new object();

        public static PoolFactory Instance
        {
            get
            {
                lock (_syncRoot)
                {
                    if (instance == null)
                        instance = new PoolFactory();
                    return instance;
                }
            }
        }

        #endregion

        ImagemPool imagemPool;
        RGB322PalettePool palette;

        public ImagemPool PoolImagem
        {
            get { return imagemPool; }
        }

        public RGB322PalettePool PoolRGB322Palette
        {
            get { return palette; }
        }

        private PoolFactory()
        {
            imagemPool = new ImagemPool();
            palette = new RGB322PalettePool();
        }

    }
}
