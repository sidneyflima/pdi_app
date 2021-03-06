using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Modelo
{
    /// <summary>
    /// Especifica os parametros de cor
    /// </summary>
    public enum BandaCorARGB
    {
        /// <summary>Alfa</summary>
        ALFA,
        /// <summary>Vermelho em RGB</summary>
        RED,
        /// <summary>Verde em RGB</summary>
        GREEN,
        /// <summary>Azul em RGB</summary>
        BLUE
    }

    public enum ModeloCor
    {
        /// <summary>Modelo de cor RGB</summary>
        RGB,
        /// <summary>Modelo de cor HSI</summary>
        HSI,
        /// <summary>Modelo de cor L*a*b*</summary>
        LAB
    }
}
