using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos
{
    /// <summary>
    /// Para calculos de distancia entre dois pixels
    /// </summary>
    public interface ICalculoDistancia
    {
        /// <summary>
        /// Calcula a distancia entre dois pixels
        /// </summary>
        /// <param name="px">Posicao x do pixel p</param>
        /// <param name="py">Posicao y do pixel p</param>
        /// <param name="qx">Posicao x do pixel q</param>
        /// <param name="qy">Posicao y do pixel q</param>
        /// <returns></returns>
        double CalculaDistancia(int px, int py, int qx, int qy);
    }
}
