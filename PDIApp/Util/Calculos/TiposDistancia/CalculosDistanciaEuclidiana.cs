using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.TiposDistancia
{
    class CalculosDistanciaEuclidiana : ICalculoDistancia
    {
        #region ICalculoDistancia Members

        public double CalculaDistancia(int px, int py, int qx, int qy)
        {
            double x2 = Math.Pow((px - qx), 2);
            double y2 = Math.Pow((py - qy), 2);

            return Math.Sqrt(x2 + y2);
        }

        #endregion
    }
}
