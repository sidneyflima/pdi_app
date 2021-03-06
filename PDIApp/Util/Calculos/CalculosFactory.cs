using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos.Histograma;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Util.Calculos
{
    /// <summary>
    /// Fabrica para obter cálculos de distância
    /// </summary>
    public class CalculosFactory
    {
        #region Atributos

        Dictionary<TipoCalculoDistancia,  ICalculoDistancia> distancias;

        #endregion

        #region Propriedades

        public CalculosBinarios     CalculosBinarios    { get; private set; }
        public CalculosCores        CalculosCores       { get; private set; }
        public CalculosRandom       CalculosRandom      { get; private set; }
        public CalculosHistograma   CalculosHistograma  { get; private set; }
        //public CalculosDescritor    CalculosDescritor   { get; private set; } 
  
        #endregion

        #region Singleton

        private static CalculosFactory instance;

        public static CalculosFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new CalculosFactory();
                return instance;
            }
        }

        #endregion

        private CalculosFactory()
        {
            Random r = new Random();
            CalculosBinarios    = new CalculosBinarios();
            CalculosCores       = new CalculosCores();
            CalculosRandom      = new CalculosRandom(r.Next());
            CalculosHistograma  = new CalculosHistograma();


            distancias = new Dictionary<TipoCalculoDistancia, ICalculoDistancia>();
        }

        /// <summary>
        /// Obtem um calculo de distancia para o tipo
        /// </summary>
        /// <param name="tipo">Tipo de calculo de distância</param>
        /// <returns></returns>
        public ICalculoDistancia ObterCalculoDistancia(TipoCalculoDistancia tipo)
        {
            ICalculoDistancia c;

            if (!distancias.TryGetValue(tipo, out c))
                return null;

            return c;
        }
    }
}
