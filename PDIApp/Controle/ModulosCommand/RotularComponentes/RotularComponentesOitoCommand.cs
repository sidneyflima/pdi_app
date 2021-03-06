using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle.ModulosCommand.RotularComponentes
{
    class RotularComponentesOitoCommand : RotularComponentesCommand
    {
        protected override int NumeroPixelsVizinhos()
        {
            return 4;
        }
    }
}
