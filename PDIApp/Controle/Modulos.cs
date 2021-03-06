using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Controle
{
    #region Enumerations

    /// <summary>
    /// Define quais são os módulos que serão executados 
    /// </summary>
    enum Modulo
    {
        TESTE,
        /// <summary>Converte a imagem para imagem binaria</summary>
        CONVERTER_BINARIO,
        /// <summary>Obtem imagem realizanco fatiamento bit a bit</summary>
        FATIAMENTO_BINARIO,
        /// <summary>Converte a imagem para monocromatica</summary>
        CONVERTER_MONOCROMATICO,
        /// <summary>Converte a imagem para paleta RGB 3-3-2</summary>
        CONVERTER_RGB_332,
        /// <summary>Rotula componentes 4-conexas</summary>
        ROTULAR_COMPONENTES_4,
        /// <summary>Rotula componentes 8-conexas</summary>
        ROTULAR_COMPONENTES_8,
        /// <summary>Cria histograma</summary>
        CRIAR_HISTOGRAMA,
        /// <summary>Equaliza histograma</summary>
        EQUALIZAR_HISTOGRAMA,
        /// <summary>Operacao inverter cores rgb</summary>
        INVERTER_CORES_RGB,
        /// <summary>Operacao inverter cores hsi</summary>
        INVERTER_CORES_HSI,
        /// <summary>Operacao inverter cores l*a*b*</summary>
        INVERTER_CORES_LAB,
        /// <summary>Mudar intensidade cores rgb</summary>
        TRANSFORMACAO_INTENSIDADE_RGB,
        /// <summary>Mudar intensidade cores hsi</summary>
        INTENSIDADE_CORES_HSI,
        /// <summary>Mudar intensidade cores l*a*b*</summary>
        INTENSIDADE_CORES_LAB,
        /// <summary>Exibe imagem pela banda de cor</summary>
        EXIBE_POR_BANDA_COR_RGB,
        /// <summary>Realiza ajuste de intensidade de cores para RGB</summary>
        AJUSTE_INTENSIDADE_RGB,
        /// <summary>Tonalidade de imagens claras</summary>
        AJUSTE_TONALIDADE_CLARAS,
        /// <summary>Tonalidade de imagens claras</summary>
        AJUSTE_TONALIDADE_ESCURAS,
        /// <summary>Filtros de media</summary>
        FILTRO_MEDIA,
        /// <summary>Filtros de media</summary>
        FILTRO_MEDIA_PONDERADA,
        /// <summary>Filtros de media</summary>
        FILTRO_GAUSSIANO,
        /// <summary>Filtros de mediana</summary>
        FILTRO_MEDIANA,
        /// <summary>Filtros de moda</summary>
        FILTRO_MODA,
        /// <summary>Filtros de maximo</summary>
        FILTRO_MAXIMO,
        /// <summary>Filtros de minimo</summary>
        FILTRO_MINIMO,

        /// <summary>Filtros de laplace para vizinhanca 4</summary>
        FILTRO_LAPLACIANO_4,
        /// <summary>Filtros de minimo para vizinhanca 8</summary>
        FILTRO_LAPLACIANO_8,
        /// <summary>Filtros de roberts</summary>
        FILTRO_ROBERTS_DIAGONAL_PRINCIPAL,
        /// <summary>Filtros de roberts</summary>
        FILTRO_ROBERTS_DIAGONAL_SECUNDARIA,
        /// <summary>Filtros de roberts</summary>
        FILTRO_SOBEL_HORIZONTAL,
        /// <summary>Filtros de roberts</summary>
        FILTRO_SOBEL_VERTICAL,
    }

    #endregion

    #region Structs
    
    /// <summary>
    /// Informações necessárias sobre um módulo.
    /// O nome do programa é o arquivo *.exe escrito em C.
    /// O verificador é um código no qual requer para que
    /// o arquivo em C seja executado.
    /// </summary>
    struct ModuloInfo
    {
        private string nome;
        private string verificador;

        /// <summary>Nome do programa</summary>
        public string NomePrograma { get { return nome; } }
        /// <summary>Verificador do programa</summary>
        public string VerificadorPrograma { get { return verificador;} }

        public ModuloInfo(string nome, string verificador)
        {
            this.nome = nome;
            this.verificador = verificador;
        }
    }
    
    #endregion
}
