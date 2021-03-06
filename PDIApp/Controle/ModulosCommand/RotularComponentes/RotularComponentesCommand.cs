using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Modelo;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Controle.ModulosCommand.RotularComponentes
{
    abstract class RotularComponentesCommand : ModuloCommand
    {
        #region Atributos

        /// <summary>Define o rotulo atual</summary>
        private int rotulo;
        /// <summary>Matriz com os rotulos de cada pixel</summary>
        private int[][] rotulos;

        /// <summary>Controle sobre rotulo dos vizinhos de cada pixel</summary>
        private int[] rotuloVizinhos;
        /// <summary>Define posicao dos vizinhos</summary>
        private Point[] vizinhos;
        
        /// <summary>Número de pixels a ser avaliado</summary>
        private int numeroPixels;

        /// <summary>Define relacao de equivalencia entre rotulos</summary>
        private Dictionary<int, int> equivalencias;
        private List<Color> cores;

        #endregion

        #region Construtores

        public RotularComponentesCommand()
        {
            numeroPixels   = NumeroPixelsVizinhos();
            vizinhos       = new Point[numeroPixels];

            for (int i = 0; i < numeroPixels; i++)
                vizinhos[i] = new Point();

            rotuloVizinhos = new int[numeroPixels];

            equivalencias = new Dictionary<int, int>();
            cores         = new List<Color>();
        }

        #endregion

        #region Metodos Command

        protected override void RealizaExecucao(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso) { }

        protected override object RealizaExecucaoRetorna(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            //define titulo
            progresso.Titulo = "Rotulando componentes conexas...";
            //define maximo por varrer a imagem duas vezes
            progresso.Maximo = auxImagem.Largura * auxImagem.Altura * 2;
            //define rotulo atual como zero
            rotulo = 0;
            //rotula componentes conexas
            RotularComponentes(auxImagem, progresso);
            //calcula componentes
            Tuple<int, int> t = CalculaComponentesConexas();
            int componentes = t.Item1;
            //cria cores aleatorias
            AlocaCoresAleatorias(auxImagem, t.Item2);


            //atribui cores
            AtribuiCoresComponentes(auxImagem, progresso);
            //limpa relacao de equivalencia
            equivalencias.Clear();

            return componentes;
        }

        /// <summary>
        /// Aloca lista de cores aleatorias de tamanho p
        /// </summary>
        /// <param name="p"></param>
        private void AlocaCoresAleatorias(Imagem auxImagem, int p)
        {
            cores.Clear();
            CalculosCores c = CalculosFactory.Instance.CalculosCores;
            for (int i = 0; i < p; i++)
            {
                Color cor = c.NovaCorAleatoria();
                cores.Add(cor);
            }
        }


        #endregion

        #region Metodos Rotular Componentes

        /// <summary>
        /// Rotula componentes conexas de uma imagem
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="progresso"></param>
        private void RotularComponentes(Modelo.Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            //aloca matriz para rotulos
            NovaMatrizRotulos(auxImagem.Largura, auxImagem.Altura);
            //realiza iteração
            for (int y = 0; y < auxImagem.Altura; y++)
            {
                for (int x = 0; x < auxImagem.Largura; x++)
                {
                    //rotula componente daquele pixel
                    RotularComponente(auxImagem, x, y);
                    //incrementa a barra
                    progresso.ValorBarra++;
                }
            }
        }

        /// <summary>
        /// Calcula quantidade de componentes conexas e obtem maior valor na lista
        /// </summary>
        /// <returns></returns>
        private Tuple<int, int> CalculaComponentesConexas()
        {
            int[] values = equivalencias.Values.ToArray<int>();
            Array.Sort(values);

            int componentes = 0;
            int maior = 0;
            int v = 0;

            foreach (int i in values)
            {
                if (v != i)
                {
                    componentes++;
                    v = i;
                }

                if(maior < i)
                    maior = i;
            }

            return new Tuple<int,int>(componentes, maior);
        }

        /// <summary>
        /// Define as cores das componentes
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <param name="progresso"></param>
        private void AtribuiCoresComponentes(Imagem auxImagem, Visao.FormBarraProgresso progresso)
        {
            //realiza iteração
            for (int y = 0; y < auxImagem.Altura; y++)
            {
                for (int x = 0; x < auxImagem.Largura; x++)
                {
                    //rotula componente daquele pixel
                    DefineCor(auxImagem, x, y);
                    //incrementa a barra
                    progresso.ValorBarra++;
                }
            }
        }

        #endregion

        #region Definindo Rotulo de um Pixel

        /// <summary>
        /// Rotula Componente de um pixel
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void RotularComponente(Imagem auxImagem, int x, int y)
        {
            Color corPixel = auxImagem.GetPixel(x, y);
            
            //se for alfa, o pixel é background e ignora
            if (corPixel.A != 255)
            {
                DefineRotulo(x, y, 0);
                return;
            }

            //lanca excecao se cor nao for binaria
            AsseguraSeCorBinaria(auxImagem, x, y);
            
            //se for primeiro pixel, define
            if(DefineSePrimeiroPixel(auxImagem, x, y)) 
                return;

            //NAO É PRIMEIRO PIXEL
            
            //se for cor background, retorne
            if (CorBackground(auxImagem, x, y))
            {
                DefineRotulo(x, y, 0);
                return;
            }

            //A PARTIR DE AGORA, O PIXEL PERTENCE A ALGUMA COMPONENTE

            ConstroiPontosVizinhos(x, y);
            //define rotulos em vetor rotulosVizinho se existir
            DefineRotulosPontosVizinhos(auxImagem);

            //procura no vetor de rotulos vizinhos qual deles possui menor rotulo
            int rotuloMinimo = ProcuraMenorRotuloNaoNulo();

            //caso não possui vizinhos foreground
            if (rotuloMinimo == int.MaxValue)
            {
                DefineRotulo(x, y, NovoRotulo());
                return;
            }

            AdicionaEquivalenciasRotulos(rotuloMinimo);
            DefineRotulo(x, y, rotuloMinimo);

        }


        #endregion

        #region Metodos Uteis para Rotular Componentes

        /// <summary>
        /// Define rotulo se for primerio pixel
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool DefineSePrimeiroPixel(Imagem auxImagem, int x, int y)
        {
            //se for primeiro pixel, define 0 ou 1 se for foreground ou nao
            if (x == 0 && y == 0)
            {
                if (CorForeground(auxImagem, x, y))
                    DefineRotulo(x, y, NovoRotulo());
                else
                    DefineRotulo(x, y, 0);

                return true;
            }

            return false;
        }


        /// <summary>
        /// Lanca excecao se cor do pixel nao for binaria
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void AsseguraSeCorBinaria(Imagem auxImagem, int x, int y)
        {
            if (!CorBinaria(auxImagem, x, y))
                throw new InvalidOperationException
                         ("A cor em (" + x + "," + y + ") não é binária (preto ou branco)");
        }

        /// <summary>
        /// Constroi os pontos vizinhos
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ConstroiPontosVizinhos(int x, int y)
        {
            //definir vizinhos
            vizinhos[0].X = x - 1; vizinhos[0].Y = y;     //define pixel à esquerda
            vizinhos[1].X = x; vizinhos[1].Y = y - 1; //define pixel do topo

            if (numeroPixels == 4)
            {
                vizinhos[2].X = x - 1; vizinhos[2].Y = y - 1; //define pixel diagomal esquerda
                vizinhos[3].X = x + 1; vizinhos[3].Y = y - 1; //define pixel diagonal direita
            }
        }

        /// <summary>
        /// Define rotulos dos pontos vizinhos
        /// </summary>
        /// <param name="auxImagem"></param>
        private void DefineRotulosPontosVizinhos(Imagem auxImagem)
        {
            for (int i = 0; i < numeroPixels; i++)
            {
                //supoe que nao exista
                bool existe = false;

                //se o ponto esta dentro dos limites da imagem, ele existe
                if (vizinhos[i].X >= 0)
                    if (vizinhos[i].X < auxImagem.Largura)
                        if (vizinhos[i].Y >= 0)
                            if (vizinhos[i].Y < auxImagem.Altura)
                                existe = true;

                //se existe, obtem seu rotulo
                if (existe)
                    rotuloVizinhos[i] = ObtemRotulo(vizinhos[i].X,
                                                    vizinhos[i].Y);
                else
                    rotuloVizinhos[i] = 0;
            }
        }

        /// <summary>
        /// Procura menor rotulo nao nulo. Se não existir rotulo nao nulo,
        /// não há pixels ao redor e retorna o maior inteiro existente
        /// </summary>
        /// <returns></returns>
        private int ProcuraMenorRotuloNaoNulo()
        {
            int minimo = int.MaxValue;

            for (int i = 0; i < numeroPixels; i++)
            {
                if (rotuloVizinhos[i] != 0)
                    if (minimo > rotuloVizinhos[i])
                        minimo = rotuloVizinhos[i];
            }

            return minimo;
        }


        /// <summary>
        /// Todos os rotulos vizinhos indicarão o rotulo minimo
        /// </summary>
        /// <param name="rotuloMinimo"></param>
        private void AdicionaEquivalenciasRotulos(int rotuloMinimo)
        {
            for (int i = 0; i < numeroPixels; i++)
            {
                if (rotuloVizinhos[i] != 0)
                {
                    if (rotuloVizinhos[i] != rotuloMinimo)
                    {
                        int r;
                        //se nao foi definido o minimo
                        if(equivalencias.TryGetValue(rotuloMinimo, out r))
                            AdicionaEquivalencia(rotuloVizinhos[i], r);
                        else
                            AdicionaEquivalencia(rotuloVizinhos[i], rotuloMinimo);
                    }
                }
            }
        }

        #endregion

        #region Metodos Template

        /// <summary>
        /// Numero de pixels vizinhos a serem verificados a cada pixel por iteracao
        /// </summary>
        /// <returns></returns>
        protected abstract int NumeroPixelsVizinhos();

        #endregion

        #region Metodos Uteis

        /// <summary>
        /// Adiciona equivalencia. Caso exista chave, remove e adiciona o valor para tal chave
        /// </summary>
        /// <param name="chave"></param>
        /// <param name="valor"></param>
        private void AdicionaEquivalencia(int chave, int valor)
        {
            if (equivalencias.ContainsKey(chave))
                equivalencias.Remove(chave);

            equivalencias.Add(chave, valor);
        }

        /// <summary>
        /// Dado o último
        /// </summary>
        /// <returns></returns>
        private int NovoRotulo()
        {
            this.rotulo++;

            //adiciona como relacao de equivalencia
            equivalencias.Add(rotulo, rotulo);

            return this.rotulo;
        }

        /// <summary>
        /// Obtem o rotulo de um pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ObtemRotulo(int x, int y)
        {
            return rotulos[x][y];
        }


        /// <summary>
        /// Define a cor de um pixel de acordo com o valor do rotulo
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DefineCor(Modelo.Imagem auxImagem, int x, int y)
        {
            int r;
            
            //captura qual o rotulo para aquele componente
            if(!equivalencias.TryGetValue(rotulos[x][y], out r))
                return;

            Color c = Color.FromArgb(auxImagem.GetPixel(x, y).A, cores[r - 1]);
            auxImagem.SetPixel(x, y, c);

        }

        /// <summary>
        /// Define um rotulo
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rotulo"></param>
        private void DefineRotulo(int x, int y, int rotulo)
        {
            rotulos[x][y] = rotulo;
        }

        /// <summary>
        /// Se a cor é branca ou nao
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool CorForeground(Imagem auxImagem, int x, int y)
        {
            //obtem a cor
            Color c = auxImagem.GetPixel(x, y);

            //nao é cor foreground
            if (c.A == 0)
                return false;

            //retorna true caso for cor branca
            if (c.R == 255)
                if (c.G == 255)
                    if (c.B == 255)
                        return true;

            return false;
        }

        /// <summary>
        /// Se a cor é branca ou nao
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool CorBackground(Imagem auxImagem, int x, int y)
        {
            //obtem a cor
            Color c = auxImagem.GetPixel(x, y);

            //é cor background
            if (c.A == 0)
                return true;

            //retorna true caso for cor preto
            if (c.R == 0)
                if (c.G == 0)
                    if (c.B == 0)
                        return true;

            return false;
        }

        /// <summary>
        /// Retorna se uma cor é binaria
        /// </summary>
        /// <param name="auxImagem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool CorBinaria(Imagem auxImagem, int x, int y)
        {
            if (CorForeground(auxImagem, x, y))
                return true;

            if (CorBackground(auxImagem, x, y))
                return true;

            return false;
        }

        /// <summary>
        /// Aloca uma nova matriz
        /// </summary>
        /// <param name="x">Largura da matriz (linhas)</param>
        /// <param name="y">Altura da matriz (colunas)</param>
        private void NovaMatrizRotulos(int x, int y)
        {
            rotulos = new int[x][];
            for (int i = 0; i < x; i++)
            {
                rotulos[i] = new int[y];
            }
        }

        #endregion
    }
}
