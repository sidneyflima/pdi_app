using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PDIApp.Modelo;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;
using PDIApp.Util.Flyweight;

namespace PDIApp.Controle.ModulosCommand.Conversao
{
    /// <summary>
    /// Execução para o módulo de conversao para monocromático
    /// </summary>
    class ConverteMonocromaticoCommand: ParallelModuloCommand
    {
        #region Metodos ParallelModuloCommand

        protected override Color OperacaoPixel(int x, long y, Color c)
        {
            return ObterCorMonocromatica(c);
        }

        protected override string DefinirTituloBarraProgresso()
        {
            return "Convertendo para imagem monocromatica";
        }

        #endregion


        /// <summary>
        /// Obtem cor monocromatica
        /// </summary>
        /// <param name="cor"></param>
        /// <returns></returns>
        private Color ObterCorMonocromatica(Color cor)
        {
            CalculosFactory factory = CalculosFactory.Instance;
            CalculosCores conversor = factory.CalculosCores;

            int valor = conversor.ValorEscalaCinza(cor);

            return Color.FromArgb(cor.A, valor, valor, valor);
        }

    }
}
