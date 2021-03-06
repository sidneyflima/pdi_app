using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos.CBIR.Descritores;

namespace PDIApp.Util.Calculos.CBIR.Calculos
{
    class CalculoDescritorCCV : CalculosDescritor
    {
        public override IDescritor CalculaDescritor(Modelo.Imagem imagem)
        {
            throw new NotImplementedException("O calculo para o descritor CCV não foi implementado");
        }

    }
}
