using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Modelo;
using PDIApp.Util.Flyweight;

namespace PDIApp.Controle.ModulosCommand
{
    /// <summary>
    /// Será executado caso algum módulo nao tenha sido implementado ainda
    /// </summary>
    class ModuloCommandNulo : ModuloCommand
    {

        protected override object RealizaExecucaoRetorna(Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            return null;
        }

        protected override void RealizaExecucao(Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            
        }
    }
}
