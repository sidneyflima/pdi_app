using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.Filtros
{
    /// <summary>
    /// Abstracao para filtros de realce. A unica diferenca é como os valores iniciais sao definidos
    /// </summary>
    abstract class FiltrosRealceModulosCommand : FiltrosModulosCommand
    {
        protected override void DefinirPontoInicial(int x, int y, System.Drawing.Point dim, out int x1, out int y1)
        {
            //base.DefinirPontoInicial(x, y, dim, out x1, out y1);
            x1 = x; y1 = y;
        }
    }
}
