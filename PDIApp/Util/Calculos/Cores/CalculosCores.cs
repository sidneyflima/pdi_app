using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PDIApp.Modelo;

namespace PDIApp.Util.Calculos.Cores
{
    public class CalculosCores
    {

        #region Atributos

        /// <summary>Matriz para calculo XYZ</summary>
        private double[][] matrizXYZ;
        /// <summary>Ponto branco referencia</summary>
        double[] refer;

        #endregion

        #region Construtores

        public CalculosCores()
        {
            CriarMatrixXYZ();
        }

        /// <summary>
        /// Cria matriz XYZ
        /// </summary>
        private void CriarMatrixXYZ()
        {
            matrizXYZ = new double[3][];

            matrizXYZ[0] = new double[3];
            matrizXYZ[1] = new double[3];
            matrizXYZ[2] = new double[3];

            matrizXYZ[0][0] = 0.412453;
            matrizXYZ[0][1] = 0.357580;
            matrizXYZ[0][2] = 0.180423;

            matrizXYZ[1][0] = 0.212671;
            matrizXYZ[1][1] = 0.715160;
            matrizXYZ[1][2] = 0.072169;

            matrizXYZ[2][0] = 0.019334;
            matrizXYZ[2][1] = 0.119193;
            matrizXYZ[2][2] = 0.950227;

            refer = new double[3];

            refer[0] = 95.047;
            refer[1] = 100.000;
            refer[2] = 108.883;

        }

        #endregion

        #region Metodos Conversao de cores

        #region Usando RGB

        /// <summary>
        /// Obtem o valor de uma cor para escala cinza
        /// </summary>
        /// <param name="cor"></param>
        /// <returns></returns>
        public int ValorEscalaCinza(Color cor)
        {
            double pesoR = 0.2989;
            double pesoG = 0.5870;
            double pesoB = 0.1140;


            return Convert.ToInt32(
                        Math.Ceiling(cor.R * pesoR +
                                     cor.G * pesoG +
                                     cor.B * pesoB));
        }


        /// <summary>
        /// Retorna se uma cor convertida para cinza esta acima do limiar (true)
        /// ou abaixo do limiar (false).
        /// </summary>
        /// <param name="cor"></param>
        /// <param name="limiar"></param>
        /// <returns></returns>
        public bool ValorBinario(Color cor, int limiar)
        {
            int valor = ValorEscalaCinza(cor);

            return valor >= limiar;
        }

        #endregion

        #region Normalização RGB

        /// <summary>
        /// Retorna valores do RGB normalizado
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public double[] RGBNormalizado(Color rgb)
        {
            double[] norm = new double[3];

            norm[0] = Convert.ToDouble(rgb.R) / 255;
            norm[1] = Convert.ToDouble(rgb.G) / 255;
            norm[2] = Convert.ToDouble(rgb.B) / 255;

            return norm;
        }

        /// <summary>
        /// Obtem RGB normalizado e retorne a cor
        /// </summary>
        /// <param name="alfa"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Color RGBNormalizadoParaCor(int alfa, double r, double g, double b)
        {
            if (alfa == 0)
                return Color.FromArgb(0, Color.Black);

            int R = Convert.ToInt32(Math.Ceiling(r * 255));
            int G = Convert.ToInt32(Math.Ceiling(g * 255));
            int B = Convert.ToInt32(Math.Ceiling(b * 255));

            if (R < 0)   R = 0;
            if (R > 255) R = 255;

            if (G < 0)   G = 0;
            if (G > 255) G = 255;

            if (B < 0)   B = 0;
            if (B > 255) B = 255;

            return Color.FromArgb(alfa, R, G, B);
        }

        #endregion

        #region RGB -> XYZ

        //fonte: http://easyrgb.com/index.php?X=MATH

        /// <summary>
        /// Converte uma cor RGB para coordenadas XYZ
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public double[] RGBParaXYZ(Color rgb)
        {
            double[] rgbNorm = RGBNormalizado(rgb);
            double[] xyz = new double[3];

            for (int i = 0; i < 3; i++)
            {
                if (rgbNorm[i] > 0.4045)
                    rgbNorm[i] = Math.Pow(((rgbNorm[i] + 0.055) / 1.055), 2.4);
                else
                    rgbNorm[i] = xyz[i] / 12.92;

                rgbNorm[i] *= 100;
            }

            xyz[0] = rgbNorm[0] * 0.4124 + rgbNorm[1] * 0.3576 + rgbNorm[2] * 0.1805;
            xyz[1] = rgbNorm[0] * 0.2126 + rgbNorm[1] * 0.7152 + rgbNorm[2] * 0.0722;
            xyz[2] = rgbNorm[0] * 0.0193 + rgbNorm[1] * 0.1192 + rgbNorm[2] * 0.9505;

            return xyz;
        }

        #endregion

        #region XYZ -> RGB

        /// <summary>
        /// Converte de XYZ para RGB
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Color XYZToRGB(double x, double y, double z)
        {
            return XYZParaRGB(255, x, y, z);
        }

        /// <summary>
        /// Converte de XYZ para RGB
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Color XYZParaRGB(int alfa, double x, double y, double z)
        {
            double[] rgb = new double[3];

            x = x / 100;
            y = y / 100;
            z = z / 100;

            rgb[0] = x * 3.2406  + y * -1.5372 + z * -0.4986;
            rgb[1] = x * -0.9689 + y * 1.8758  + z * 0.0415;
            rgb[2] = x * 0.0557  + y * -0.2040 + z * 1.0570;

            for (int i = 0; i < 3; i++)
            {
                if (rgb[i] > 0.0031308)
                    rgb[i] = 1.055 * Math.Pow(rgb[i], (1 / 2.4)) - 0.055;
                else
                    rgb[i] = 12.92 * rgb[i];

                rgb[i] *= 255;
            }

            return Color.FromArgb(alfa, Convert.ToByte(Math.Floor(rgb[0])),
                                        Convert.ToByte(Math.Floor(rgb[1])),
                                        Convert.ToByte(Math.Floor(rgb[2])));
        }


        #endregion

        #region RGB -> HSI

        /// <summary>
        /// Converte de RGB para HSI
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public double[] RGBParaHSI(Color rgb)
        {
            double[] norm = RGBNormalizado(rgb);
            double[] hsi = new double[3];

            if (rgb.A == 0)
                return hsi;

            hsi[0] = ObterH(norm[0], norm[1], norm[2]);
            hsi[1] = ObterS(norm[0], norm[1], norm[2]);
            hsi[2] = ObterI(norm[0], norm[1], norm[2]);

            return hsi;
        }


        /// <summary>
        /// Obtem valor de H dado RGB. RETORNA NAN SE H NAO PODE SER DEFINIDO
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double ObterH(double r, double g, double b)
        {
            if (r == g && g == b)
                return Double.NaN;

            double angulo = ObterTeta(r, g, b);

            if (b > g)
                angulo = 360 - angulo;

            return angulo / 360;
        }

        /// <summary>
        /// Obtem cosseno do H dado RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double ObterTeta(double r, double g, double b)
        {

            double num = (r - g) + (r - b);
            num = num / 2;

            double dem = Math.Pow((r - g), 2);
            dem += (r - b) * (g - b);
            dem = Math.Sqrt(dem);

            double cos = num / dem;
            return Math.Acos(cos);
        }

        /// <summary>
        /// Obtem valor de S dado RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double ObterS(double r, double g, double b)
        {
            if (r == g && g == b)
                return 0;

            double min = Math.Min(r, g);
            min = Math.Min(g, b);

            double sub = r + g + b;
            sub = (3 * min) / sub;

            return 1 - sub;
        }

        /// <summary>
        /// Obtem valor de I dado RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double ObterI(double r, double g, double b)
        {
            return (r + g + b) / 3;
        }

        #endregion 

        #region HSI -> RGB

        /// <summary>
        /// Converte cor de HSI para RGB
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public Color HSIParaRGB(int alfa, double h, double s, double i)
        {
            if(s == 0)
            {
                int I = Convert.ToInt32(i * 255);
                I = (I < 0) ? I = 0 : I;
                I = (I > 255) ? I = 255 : I;
                return Color.FromArgb(alfa, I, I, I);
            }


            //tira normalizacao de H
            h = h * 360;

            

            double[] norm;

            if (0 <= h && h < 120)
                norm = SetorRG(h, s, i);
            else if (120 <= h && h < 240)
                norm = SetorGB(h, s, i);
            else
                norm = SetorBR(h, s, i);

            return RGBNormalizadoParaCor(alfa, norm[0], norm[1], norm[2]);
        }

        /// <summary>
        /// Conversao HSI -> RGB quando 0 <= H < 120
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private double[] SetorRG(double h, double s, double i)
        {
            double[] rgb = new double[3];

            rgb[0] = EquacaoMaiorHSIRGB(h, s, i); //define R
            rgb[2] = EquacaoMenorHSIRGB(h, s, i); //define B
            rgb[1] = 1 - (rgb[0] + rgb[2]);       //define G

            return rgb;
        }

        /// <summary>
        /// Conversao HSI -> RGB quando 0 <= H < 120
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private double[] SetorGB(double h, double s, double i)
        {
            h = h - 120;
            double[] rgb = new double[3];

            rgb[1] = EquacaoMaiorHSIRGB(h, s, i); //define R
            rgb[0] = EquacaoMenorHSIRGB(h, s, i); //define B
            rgb[2] = 1 - (rgb[1] + rgb[0]);       //define G

            return rgb;
        }

        /// <summary>
        /// Conversao HSI -> RGB quando 0 <= H < 120
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private double[] SetorBR(double h, double s, double i)
        {
            h = h - 240;
            double[] rgb = new double[3];

            rgb[2] = EquacaoMaiorHSIRGB(h, s, i); //define R
            rgb[1] = EquacaoMenorHSIRGB(h, s, i); //define B
            rgb[0] = 1 - (rgb[2] + rgb[1]);       //define G

            return rgb;
        }

        /// <summary>
        /// Calculo da maior equacao da formula
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private double EquacaoMaiorHSIRGB(double h, double s, double i)
        {
            //numerador da conta
            double num = (s * Math.Cos(h));
            //denominador da conta
            double dem = Math.Cos(60 - h);
            //fracao delimitada por colchetes
            double fracao = 1 + (num / dem);

            return i * fracao;
        }

        /// <summary>
        /// Calculo da menor equacao da formula
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private double EquacaoMenorHSIRGB(double h, double s, double i)
        {
            return i * (1 - s);
        }

        #endregion

        #region RGB -> L*a*b 
        
        //fonte: http://easyrgb.com/index.php?X=MATH

        /// <summary>
        /// Converte cor RGB para CIE L*a*b*
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public double[] RBGParaCIELAB(Color rgb)
        {
            //converte para XYZ
            double[] xyz   = RGBParaXYZ(rgb);
            double[] lab   = new double[3];


            for (int i = 0; i < 3; i++)
            {
                if (xyz[i] > 0.008856)
                    xyz[i] = Math.Pow(xyz[i], (1.0 / 3.0));
                else
                    xyz[i] = (7.787 * xyz[i]) + (16.0 / 116.0);
            }

            lab[0] = (16 * xyz[1]) - 16;
            lab[1] = 500 * (xyz[0] - xyz[1]);
            lab[2] = 200 * (xyz[1] - xyz[2]);

            return lab;
        }


        #endregion

        #region L*a*b -> RGB

        /// <summary>
        /// Converte cor de CIE L*a*b* para RGB
        /// </summary>
        /// <param name="alfa"></param>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Color CIELabParaRGB(int alfa, double l, double a, double b)
        {
            double[] xyz = new double[3];

            xyz[1] = (l + 16) / 16.0;
            xyz[0] = (a / 500.0) + xyz[1];
            xyz[2] = xyz[1] - b / 200.0;

            for (int i = 0; i < 3; i++)
            {
                double pow = Math.Pow(xyz[i], 3.0);

                if (pow > 0.008856)
                    xyz[i] = pow;
                else
                    xyz[i] = (xyz[i] - 16.0 / 116.0) / 7.787;

                xyz[i] = refer[i] * xyz[i];
            }

            return XYZParaRGB(alfa, xyz[0], xyz[1], xyz[2]);
            
        }

        #endregion


        #endregion

        #region Exibicao de Cores

        /// <summary>
        /// Exibe string da cor formatada como tupla
        /// </summary>
        /// <param name="norm"></param>
        /// <returns></returns>
        public string CorParaString(double[] norm)
        {
            string[] s = new string[3];

            for(int i = 0; i < 3; i++)
                s[i] = (Double.IsNaN(norm[i])) ? "NaN" : norm[i].ToString("000.000");


            return String.Format("({0} , {1} , {2})", s[0], s[1], s[2]);
        }

        /// <summary>
        /// Exibe string da cor formatada como tupla
        /// </summary>
        /// <param name="norm"></param>
        /// <returns></returns>
        public string CorParaString(Color c)
        {
            return String.Format("({0} , {1} , {2} , {3})",
                                    c.A.ToString("D3"),
                                    c.R.ToString("D3"),
                                    c.G.ToString("D3"),
                                    c.B.ToString("D3"));
        }

        #endregion

        #region Criacao de cores

        public Color NovaCorAleatoria(byte alfa)
        {
            CalculosRandom r = CalculosFactory.Instance.CalculosRandom;
            return Color.FromArgb(alfa, r.NovoByte(), r.NovoByte(), r.NovoByte());
        }

        public Color NovaCorAleatoria()
        {
            CalculosRandom r = CalculosFactory.Instance.CalculosRandom;
            return Color.FromArgb(byte.MaxValue, r.NovoByte(), r.NovoByte(), r.NovoByte());
        }

        #endregion

        #region Ajuste de cores

        /// <summary>
        /// Ajusta intensidade, sendo esta definida por valores de 0 a 255
        /// </summary>
        /// <param name="c"></param>
        /// <param name="nivel"></param>
        /// <returns></returns>
        public Color AjusteIntensidade(Color c, byte nivel)
        {
            double taxa = ((double)nivel) / 255;

            return Color.FromArgb(c.A, Convert.ToByte(c.R * taxa),
                                       Convert.ToByte(c.G * taxa),
                                       Convert.ToByte(c.B * taxa));
        }

        #endregion
    }
}
