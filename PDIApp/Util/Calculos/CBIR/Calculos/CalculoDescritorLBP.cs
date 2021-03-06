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
    class CalculoDescritorLBP : CalculosDescritor
    {
        /// <summary>guarda a posicao na imagem do bit 0, 1, 2 ... 7</summary>
        Point [] _posicaoRelativa;
        object[] _syncRoot;
        bool[]   _valores;

        public CalculoDescritorLBP()
        {
            /* 
             *   |0(-1, -1)||1( 0, -1)||2( 1, -1)| 
             *   |7(-1,  0)|| ( 0,  0)||3( 1,  0)|
             *   |6(-1,  1)||5( 0,  1)||4( 1,  1)|
             */

            _posicaoRelativa    = new Point[8];

            _posicaoRelativa[0] = new Point(-1, -1);
            _posicaoRelativa[1] = new Point( 0, -1);
            _posicaoRelativa[2] = new Point( 1, -1);
            _posicaoRelativa[3] = new Point( 1,  0);
            _posicaoRelativa[4] = new Point( 1,  1);
            _posicaoRelativa[5] = new Point( 0,  1);
            _posicaoRelativa[6] = new Point(-1,  1);
            _posicaoRelativa[7] = new Point(-1,  0);

            _syncRoot   = new object[8];
            _valores    = new bool[8];

            for (int i = 0; i < 8; i++)
                _syncRoot[i] = new object();
             

            
        }


        public override IDescritor CalculaDescritor(Modelo.Imagem imagem)
        {
            imagem.BloqueiaBits();

            //converter pool
            Flyweight.RGB322PalettePool pool = PoolFactory.Instance.PoolRGB322Palette;
            //aloca o descritor da imagem
            LocalBinaryPatternDescritor descritor = new LocalBinaryPatternDescritor();
            //itera cada pixel para manipular imagem
            for (int x = 0; x < imagem.Largura; x++)
            //Parallel.For(0, imagem.Largura, x =>
            {
                for (int y = 0; y < imagem.Altura; y++)
                //Parallel.For(0, imagem.Altura, y =>
                {
                    AtualizaDescritor(descritor, imagem, x, y, pool);
                }//);
            }//);

            imagem.DesbloqueiaBits();

            return descritor;
        }

        private void AtualizaDescritor(LocalBinaryPatternDescritor descritor, Modelo.Imagem imagem, long x, long y, RGB322PalettePool pool)
        {
            //obtem cor do pixel
            byte p = pool.ObterBytePaleta(imagem.GetPixel((int) x, (int) y));

            for (int i = 0; i < 8; i++)
            {
                //lock (_syncRoot[i])
                //{
                    //posicao relativa daquele pixel
                    Point rel = _posicaoRelativa[i];
                    //obtem cor do pixel relativo
                    byte prel = pool.ObterBytePaleta(ObterCorPixel(imagem, (int) x + rel.X, (int) y + rel.Y));
                    //seta um se valor do pixel for maior que o relativo
                    _valores[i] = (p > prel);
                //}
            }

            byte b = ObterValorLBP();
            descritor[b]++;
        }

        /// <summary>
        /// Dado os valores do vetor binario, converte para o valor byte correspondente
        /// </summary>
        /// <returns></returns>
        private byte ObterValorLBP()
        {
            CalculosBinarios c = CalculosFactory.Instance.CalculosBinarios;

            _valores = _valores.Reverse<bool>().ToArray<bool>();
            byte b = 0;
            for (byte i = 0; i < 8; i++)
                if (_valores[i])
                    b = c.DefinirBitUm(b, i);

            return b;
        }

        /// <summary>
        /// Obtem a cor do pixel na posicao x e y. Caso algum destas coordenadas forem negativas,
        /// obtem a cor do mais proximo, realizando tratamento das bordas.
        /// 
        /// Por exemplo se (-2,3), obtem cor (0,3).
        /// </summary>
        /// <param name="imagem"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Color ObterCorPixel(Modelo.Imagem imagem, int x, int y)
        {
            //busca pelo pixel mais proximo na imagem, duplicando a borda
            if (x < 0) return ObterCorPixel(imagem, x + 1, y);
            if (y < 0) return ObterCorPixel(imagem, x, y + 1);
            if (x >= imagem.Largura)    return ObterCorPixel(imagem, x - 1, y);
            if (y >= imagem.Altura)     return ObterCorPixel(imagem, x, y - 1);

            return imagem.GetPixel(x, y);
        }

    }
}
