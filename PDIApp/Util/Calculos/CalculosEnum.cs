using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos
{
    /// <summary>
    /// Sobre qual sistema de cores a conversão está baseada
    /// </summary>
    public enum TipoCorConversao
    {
        /// <summary>Informa que o conversor é para cores RGB</summary>
        CONVERSOR_RGB
    }

    /// <summary>
    /// Tipo de cálculos de distância
    /// </summary>
    public enum TipoCalculoDistancia
    {
        /// <summary>Informa que será o cálculo da distancia euclidiana</summary>
        EUCLIDIANA,
        /// <summary>Informa que será o cálculo da distancia cityblock</summary>
        CITY_BLOCK,
        /// <summary>Informa que será o cálculo da distancia chessboard</summary>
        CHESSBOARD
    }
}
