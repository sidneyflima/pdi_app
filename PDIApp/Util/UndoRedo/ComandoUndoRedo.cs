using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.UndoRedo
{
    class ComandoUndoRedo<T>
    {
        /// <summary>Lista de arquivos temporarios</summary>
        List<T> elems;
        int posicao;
        int limite;

        /// <summary>Habilita desfazer</summary>
        public bool PodeDesfazer { get { return posicao != 0; } }
        /// <summary>Habilita refazer</summary>
        public bool PodeRefazer { get { return posicao != limite; } }

        /// <summary>
        /// Novo comando de UndoRedo
        /// </summary>
        /// <param name="temp">Primeiro arquivo a ser criado</param>
        public ComandoUndoRedo(T inicio)
        {
            elems = new List<T>();
            AdicionaPrimeiro(inicio);
        }


        /// <summary>Desfaz</summary>
        public T Desfazer()
        {
            if (PodeDesfazer)
            {
                posicao--;
                return elems[posicao];
            }

            throw new InvalidOperationException("NAO PODE DESFAZER");
        }

        /// <summary>Desfaz</summary>
        public T Refazer()
        {
            if (PodeRefazer)
            {
                posicao++;
                return elems[posicao];
            }

            throw new InvalidOperationException("NAO PODE REFAZER");
        }

        /// <summary>Adiciona arquivo temporario</summary>
        public void Adicionar(T elem)
        {
            posicao++;
            limite = posicao;
            if (limite == elems.Count)
                elems.Add(elem);
            else
                elems[posicao] = elem;
        }

        /// <summary>
        /// Limpa undo redo mas adiciona um primeiro elemento na lista
        /// </summary>
        /// <param name="first"></param>
        public void Limpar(T inicio)
        {
            elems.Clear();
            AdicionaPrimeiro(inicio);
        }

        /// <summary>
        /// Adiciona primeiro elemento a uma lista vazia
        /// configurando 'posicao' e 'limite'
        /// </summary>
        /// <param name="inicio"></param>
        private void AdicionaPrimeiro(T inicio)
        {
            elems.Add(inicio);
            posicao = 0;
            limite = 0;
        }
    }
}
