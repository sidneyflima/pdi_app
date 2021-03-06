using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.Histograma
{
    class CriarHistogramaCommand: ModuloCommand
    {
        
        protected override object RealizaExecucaoRetorna(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            //definir titulo
            progresso.Titulo = "Criando histograma...";

            //criar novo histograma
            return CalculosFactory.Instance.CalculosHistograma.CriarHistograma(auxImagem);  

        }

        protected override void RealizaExecucao(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso) { }
        
        
    }
}
