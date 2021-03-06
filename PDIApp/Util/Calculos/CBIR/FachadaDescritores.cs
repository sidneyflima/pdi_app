using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR
{
    public class FachadaDescritores
    {
        #region Singleton

        private static FachadaDescritores instance;

        public static FachadaDescritores Instance
        {
            get
            {
                if (instance == null)
                    instance = new FachadaDescritores();
                return instance;
            }
        }

        #endregion

        private FachadaDescritores() { }


    }
}
