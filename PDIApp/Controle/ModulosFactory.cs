using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDIApp.Controle.ModulosCommand;
using PDIApp.Controle.ModulosCommand.AjustesCor;
using PDIApp.Controle.ModulosCommand.Conversao;
using PDIApp.Controle.ModulosCommand.Filtros;
using PDIApp.Controle.ModulosCommand.Histograma;
using PDIApp.Controle.ModulosCommand.InverterCores;
using PDIApp.Controle.ModulosCommand.Operacoes;
using PDIApp.Controle.ModulosCommand.RotularComponentes;
using PDIApp.Controle.ModulosCommand.TransformacaoIntensidade;

namespace PDIApp.Controle
{
    class ModulosFactory
    {
        #region Singleton

        private static ModulosFactory instance;

        public static ModulosFactory Instance
        {
            get 
            {
                if (instance == null)
                    instance = new ModulosFactory();
                return instance; 
            }
        }

        #endregion

        #region Atributos

        private Dictionary<Modulo, ModuloCommand> modulos;
        private ModulosCommand.ModuloCommandNulo moduloNulo;

        #endregion

        #region Construtores

        public ModulosFactory()
        {
            modulos     = new Dictionary<Modulo, ModuloCommand>();
            moduloNulo  = new ModulosCommand.ModuloCommandNulo();

            modulos.Add(Modulo.CONVERTER_MONOCROMATICO, new ConverteMonocromaticoCommand());
            modulos.Add(Modulo.CONVERTER_BINARIO,       new ConverteBinariaCommand());
            modulos.Add(Modulo.CONVERTER_RGB_332,       new ConvertePaleta332Command());


            modulos.Add(Modulo.ROTULAR_COMPONENTES_4,   new RotularComponentesQuatroCommand());
            modulos.Add(Modulo.ROTULAR_COMPONENTES_8,   new RotularComponentesOitoCommand());
            modulos.Add(Modulo.FATIAMENTO_BINARIO,      new FatiamentoBinarioCommand());
            modulos.Add(Modulo.INVERTER_CORES_RGB,      new InverterCoresRGBCommand());
            modulos.Add(Modulo.INVERTER_CORES_HSI,      new InverterCoresHSICommand());
            modulos.Add(Modulo.EXIBE_POR_BANDA_COR_RGB, new ExibirApenasBandaCorCommand());
            modulos.Add(Modulo.CRIAR_HISTOGRAMA,        new CriarHistogramaCommand());
            modulos.Add(Modulo.EQUALIZAR_HISTOGRAMA,    new EqualizarHistogramaCommand());

            modulos.Add(Modulo.TRANSFORMACAO_INTENSIDADE_RGB,   new TransformacaoIntensidadeRGBCommand());
            modulos.Add(Modulo.AJUSTE_INTENSIDADE_RGB,          new AjusteIntensidadeCorCommand());
            modulos.Add(Modulo.AJUSTE_TONALIDADE_ESCURAS,       new CorrecaoTonalidadeEscurasCommand());
            //modulos.Add(Modulo.AJUSTE_TONALIDADE_CLARAS,        new CorrecaoTonalidadeClarasCommand());

            modulos.Add(Modulo.TESTE,                           new TestePartialModulosCommand());
            modulos.Add(Modulo.FILTRO_MEDIA,                    new FiltroMediaSimplesCommand());
            modulos.Add(Modulo.FILTRO_MEDIA_PONDERADA,          new FiltroMediaPonderadaCommand());
            modulos.Add(Modulo.FILTRO_GAUSSIANO,                new FiltroGaussianoCommand());
            modulos.Add(Modulo.FILTRO_MEDIANA,                  new FiltroMedianaCommand());
            modulos.Add(Modulo.FILTRO_MODA,                     new FiltroMedianaCommand());
            modulos.Add(Modulo.FILTRO_MAXIMO,                   new FiltroMedianaCommand());
            modulos.Add(Modulo.FILTRO_MINIMO,                   new FiltroMedianaCommand());

            modulos.Add(Modulo.FILTRO_LAPLACIANO_4,             new FiltroLaplaciano4Command());
            modulos.Add(Modulo.FILTRO_LAPLACIANO_8,             new FiltroLaplaciano8Command());

            modulos.Add(Modulo.FILTRO_ROBERTS_DIAGONAL_PRINCIPAL,   new FiltroRobertsPrincipalCommand());
            modulos.Add(Modulo.FILTRO_ROBERTS_DIAGONAL_SECUNDARIA,  new FiltroRobertsSecundariaCommand());

            modulos.Add(Modulo.FILTRO_SOBEL_HORIZONTAL,         new FiltroSobelHorizontalCommand());
            modulos.Add(Modulo.FILTRO_SOBEL_VERTICAL,           new FiltroSobelVerticalCommand());
        }

        #endregion

        #region Indexadores

        /// <summary>
        /// Obtem um command.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public ModuloCommand this[Modulo m]
        {
            get
            {
                ModuloCommand mc;

                if (!modulos.TryGetValue(m, out mc))
                    return moduloNulo;

                return mc;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Obtem o visitador para determinado módulo
        /// </summary>
        /// <param name="modulo">Retorna o visitor que será executado</param>
        /// <returns></returns>
        public ModuloCommand ObtemModuloVisitor(Modulo modulo)
        {
            ModuloCommand m;

            if (!modulos.TryGetValue(modulo, out m))
                return moduloNulo;

            return m;
        }

        /// <summary>
        /// Adiciona um módulo. Este método substitui o visitor caso exista
        /// </summary>
        /// <param name="modulo"></param>
        /// <param name="visitor"></param>
        public ModulosFactory AdicionaSubstitui(Modulo modulo, ModuloCommand visitor)
        {
            if (modulos.ContainsKey(modulo))
                modulos.Remove(modulo);

            modulos.Add(modulo, visitor);
            return this;
        }

        /// <summary>
        /// Adiciona um módulo de forma segura. Caso exista, nao adicione o modulo
        /// </summary>
        /// <param name="modulo"></param>
        /// <param name="visitor"></param>
        public ModulosFactory AdicionaSeNaoExiste(Modulo modulo, ModuloCommand visitor)
        {
            if (!modulos.ContainsKey(modulo))
                modulos.Add(modulo, visitor);

            return this;
        }

        #endregion
    }
}
