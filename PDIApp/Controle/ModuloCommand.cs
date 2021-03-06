using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Modelo;
using PDIApp.Util;
using PDIApp.Util.Flyweight;
using PDIApp.Visao;

namespace PDIApp.Controle
{
    /// <summary>
    /// Interface para módulos implementando o padrão Visitor
    /// </summary>
    public abstract class ModuloCommand
    {
        #region Atributos

        /// <summary>Armazenará quais argumentos serão utilizados pelas funcoes</summary>
        private Dictionary<string, object> argumentos;

        #endregion

        #region Construtores

        public ModuloCommand()
        {
            argumentos = new Dictionary<string, object>();
        }

        #endregion

        #region Indexadores

        /// <summary>
        /// Recupera um argumento
        /// </summary>
        /// <param name="chave">A chave do argumento</param>
        /// <returns>O valor do argumento correspondente a esta chave</returns>
        public object this[string chave]
        {
            get
            {
                object o;
                if (!argumentos.TryGetValue(chave, out o))
                    o = null;
                return o;
            }
            set
            {
                if (!argumentos.ContainsKey(chave))
                    argumentos.Add(chave, value);
            }
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Executa um módulo, modificando a imagem e 
        /// retorna respostas auxiliares
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progresso"></param>
        /// <returns></returns>
        public T ExecutarRetorna<T>(FormBarraProgresso progresso)
        {
            ImagemPool pool = PoolFactory.Instance.PoolImagem;

            CriaImagemAuxiliar(pool);
            ConfiguraBarraProgressoImagem(pool, progresso);

            //bloqueia bits
            pool[TipoImagemPool.AUXILIAR].BloqueiaBits();

            Cast cast = new Cast();
            cast.Objeto = RealizaExecucaoRetorna(pool[TipoImagemPool.AUXILIAR], progresso);

            //desbloqueia bits
            pool[TipoImagemPool.AUXILIAR].DesbloqueiaBits();

            ModificarImagemAtual(pool);
            LimparArgumentos();

            return cast.RealizaCast<T>();
        }

        /// <summary>
        /// Executa um módulo, modificando uma imagem
        /// </summary>
        /// <param name="progresso"></param>
        public void Executar(FormBarraProgresso progresso)
        {
            ImagemPool pool = PoolFactory.Instance.PoolImagem;
            
            CriaImagemAuxiliar(pool);
            ConfiguraBarraProgressoImagem(pool, progresso);
            //bloqueia bits
            pool[TipoImagemPool.AUXILIAR].BloqueiaBits();
            
            RealizaExecucao(pool[TipoImagemPool.AUXILIAR], progresso);

            //bloqueia bits
            pool[TipoImagemPool.AUXILIAR].DesbloqueiaBits();

            ModificarImagemAtual(pool);
            LimparArgumentos();
        }

        /// <summary>
        /// Adiciona um argumento passando uma chave
        /// </summary>
        /// <param name="chave"></param>
        /// <param name="argumento"></param>
        public void AdicionaArgumentos(string chave, object argumento)
        {
            argumentos.Add(chave, argumento);
        }

        #endregion

        #region Metodos Template

        /// <summary>
        /// Realiza a execução de um módulo e retorna o valor
        /// </summary>
        /// <param name="progresso"></param>
        /// <returns></returns>
        protected abstract Object RealizaExecucaoRetorna(Imagem auxImagem, FormBarraProgresso progresso);

        /// <summary>
        /// Realiza a execucao de um módulo sem retorno de valores
        /// </summary>
        /// <param name="progresso"></param>
        protected abstract void RealizaExecucao(Imagem auxImagem, FormBarraProgresso progresso);

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Aloca um novo bitmap como copia da imagem atual e coloca na imagem auxiliar
        /// </summary>
        /// <param name="pool"></param>
        private void CriaImagemAuxiliar(ImagemPool pool)
        {
            Imagem atual     = pool[TipoImagemPool.ATUAL];
            Imagem auxImagem = pool[TipoImagemPool.AUXILIAR];

            Bitmap bitmap = new Bitmap(atual.ImagemBitmap);
            auxImagem.ImagemBitmap = bitmap;
        }


        /// <summary>
        /// Configura a barra de progresso
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="progresso"></param>
        private void ConfiguraBarraProgressoImagem(ImagemPool pool, FormBarraProgresso progresso)
        {
            Imagem auxImagem = pool[TipoImagemPool.AUXILIAR];

            //define mínimo como 0
            progresso.Minimo = 0;
            //define maximo como a largura e altura da imagem
            progresso.Maximo = auxImagem.Largura * auxImagem.Altura;
        }


        /// <summary>
        /// Define bitmap modificado pela imagem auxiliar para imagem atual
        /// </summary>
        /// <param name="pool"></param>
        private void ModificarImagemAtual(ImagemPool pool)
        {
            Imagem atual = pool[TipoImagemPool.ATUAL];
            Imagem auxImagem = pool[TipoImagemPool.AUXILIAR];

            atual.ImagemBitmap = auxImagem.ImagemBitmap;
        }

        /// <summary>
        /// Limpa os argumentos após uma operação
        /// </summary>
        private void LimparArgumentos()
        {
            argumentos.Clear();
        }

        #endregion
    }
}
