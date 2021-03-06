using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Util.Calculos;
using PDIApp.Util.Flyweight;

namespace PDIApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] v = {false,false,true,false,
                        true,true,false,true};

            byte b = 0;
            CalculosBinarios c = CalculosFactory.Instance.CalculosBinarios;

            v = v.Reverse<bool>().ToArray<bool>();

            for (byte i = 0; i < 8; i++)            
                if (v[i]) 
                    b = c.DefinirBitUm(b, i);

            Console.WriteLine(b);
            Console.Read();

        }

    }
}
