using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util
{
    /// <summary>
    /// Realiza cast de um objeto
    /// </summary>
    public class Cast
    {
        Object o;
        //Type tipo;

        /// <summary>
        /// Define o objeto que será realizado o cast
        /// </summary>
        public Object Objeto
        {
            set
            {
                o = value;
            }
        }

        /*
        /// <summary>
        /// Define o tipo do objeto a realizar cast
        /// </summary>
        public Type Tipo
        {
            get { return tipo;  }
            set { tipo = value; }
        }
        */

        /// <summary>
        /// Realiza o cast do objeto
        /// </summary>
        /// <returns>Um objeto da classe T com o cast</returns>
        public T RealizaCast<T>()
        {
            return (T) o;
        }

    }
}
