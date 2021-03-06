using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDIApp.Util.Calculos.CBIR.Descritores;
using PDIApp.Util.Flyweight;

namespace PDIApp.Util.Calculos.CBIR.Calculos
{
    class CalculoDescritorHistograma : CalculosDescritor
    {
        public override IDescritor CalculaDescritor(Modelo.Imagem imagem)
        {
            imagem.BloqueiaBits();

            //converter pool
            Flyweight.RGB322PalettePool pool = PoolFactory.Instance.PoolRGB322Palette;
            //aloca o descritor da imagem
            HistogramaDescritor descritor = new HistogramaDescritor();
            //itera cada pixel para manipular imagem
            for(int x = 0; x < imagem.Largura; x++)
            {
                for (int y = 0; y < imagem.Altura; y++)
                //Parallel.For(0, imagem.Altura, y =>
                {
                    byte b = pool.ObterBytePaleta(imagem.GetPixel(x, y));
                    descritor[b]++;
                }//);
            }

            imagem.DesbloqueiaBits();

            return descritor;
        }
    }
}
