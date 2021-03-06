using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDIApp.Util.Calculos
{
    public class CalculosRandom
    {
        Random random;

        public CalculosRandom()
        {
            random = new Random();
        }

        public CalculosRandom(int semente)
        {
            random = new Random(semente);
        }

        public byte NovoByte()
        {
            byte[] b = new byte[1];
            random.NextBytes(b);

            return b[0];
        }

        public int NovoInt()
        {
            return random.Next();
        }
    }
}
