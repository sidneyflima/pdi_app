using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos.CBIR
{
    public interface IMedidaSimilaridade
    {
        /// <summary>
        /// Calcula a similaridade entre duas imagens baseado no descritor
        /// </summary>
        /// <param name="query"></param>
        /// <param name="imagem"></param>
        /// <returns></returns>
        double CalculaSimilaridade(IDescritor query, IDescritor imagem);
    }
}
