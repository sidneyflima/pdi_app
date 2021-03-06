using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR
{
    /// <summary>
    /// Classe abstrata para definir calculos de descritores de imagens
    /// </summary>
    public abstract class CalculosDescritor
    {
        protected IMedidaSimilaridade MedidaSimilaridade { get; set; }

        #region Metodos Calculos de Descritores

        /// <summary>
        /// Calcula o descritor de uma imagem
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        public abstract IDescritor CalculaDescritor(Modelo.Imagem imagem);

        /// <summary>
        /// Calcula a similaridade entre duas imagens baseado no descritor
        /// </summary>
        /// <param name="query"></param>
        /// <param name="imagem"></param>
        /// <returns></returns>
        public double CalculaSimilaridade(IDescritor query, IDescritor imagem)
        {
            return MedidaSimilaridade.CalculaSimilaridade(query, imagem);
        }

        #endregion
    }
}
