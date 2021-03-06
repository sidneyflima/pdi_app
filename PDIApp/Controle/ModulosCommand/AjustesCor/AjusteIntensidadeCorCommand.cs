using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.AjustesCor
{
    /// <summary>
    /// Comando para ajustes de intensidade
    /// </summary>
    class AjusteIntensidadeCorCommand: ParallelModuloCommand
    {
        protected override System.Drawing.Color OperacaoPixel(int x, long y, System.Drawing.Color c)
        {
            CalculosCores calc = CalculosFactory.Instance.CalculosCores;            
            return calc.AjusteIntensidade(c, Convert.ToByte(this[Constantes.CHAVE_ARGUMENTO_TRACK_BAR]));
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Ajustando intensiidade";
        }
    }
}
