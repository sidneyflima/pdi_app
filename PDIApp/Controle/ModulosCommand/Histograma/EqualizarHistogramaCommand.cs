using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Histograma;

namespace PDIApp.Controle.ModulosCommand.Histograma
{
    /// <summary>
    /// Comanda para equalizar histograma
    /// </summary>
    public class EqualizarHistogramaCommand : ModuloCommand
    {
        protected override object RealizaExecucaoRetorna(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            return null;
        }

        protected override void RealizaExecucao(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            progresso.Titulo = "Equalizando Histograma...";

            CalculosHistograma calc = CalculosFactory.Instance.CalculosHistograma;
            //cria histograma
            Modelo.Histograma[] hist = calc.CriarHistograma(auxImagem);
            //obtem mapas para modificacoes
            byte[] mapaR    = calc.EqualizarHistograma(hist[0]);
            byte[] mapaG    = calc.EqualizarHistograma(hist[1]);
            byte[] mapaB    = calc.EqualizarHistograma(hist[2]);
            //byte[] mapaGray = calc.EqualizarHistograma(hist[3]);

            //modifica a imagem auxiliar de acordo com os valores mapeados
            //for (int x = 0; x < auxImagem.Largura; x++)
            Parallel.For(0, auxImagem.Largura, x =>
            {
                Parallel.For(0, auxImagem.Altura, y =>
                {
                    Color c = auxImagem.GetPixel(x, y);
                    Color novaCor = Color.FromArgb(c.A, mapaR[c.R], mapaG[c.G], mapaB[c.B]);
                    auxImagem.SetPixel(x, y, novaCor);
                });
            });
        }
    }
}
