using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Flyweight
{
    /// <summary>
    /// Criação de um pool para o padrao flyweight
    /// </summary>
    /// <typeparam name="K">Tipo de dados da chave</typeparam>
    /// <typeparam name="V">Tipo de dados do valor</typeparam>
    public abstract class FlyweightPool<K, V>
    {
        /// <summary>Pool com os objetos</summary>
        private Dictionary<K, V> pool;

        /// <summary>
        /// Cria um novo pool para padrao flyweight
        /// </summary>
        public FlyweightPool()
        {
            this.pool = new Dictionary<K, V>();
        }


        /// <summary>
        /// Obtem ou define um novo objeto com a chave. Caso ja foi 
        /// criado algum elemento para aquela chave, este não será adicionado
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        public V this[K chave]
        {
            get
            {
                V obj;
                if (!pool.TryGetValue(chave, out obj))
                    return default(V);

                return obj;
            }

            set
            {
                if (!pool.ContainsKey(chave))
                    pool.Add(chave, value);
            }

        }

    }
}
