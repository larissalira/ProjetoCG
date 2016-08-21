using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ComputacaoGraficaProject.View;

namespace ComputacaoGraficaProject.Sintese
{
    class Circunferencia
    {
        private Bitmap imagem;
        private Ponto ponto;

        public Circunferencia()
        {
            ponto = new Ponto();
            imagem = new Bitmap(Referencias.sizeImageX, Referencias.sizeImageY);
            
        }

        /** 
         * Algoritmo para desenhar o Círculo com algoritmo do Ponto Médio:
         * 
         * IncE = (2 * x) + 3
         * IncSE = (2 * (x - y)) + 5
         * d = (1 - raio)
         * d += IncE || d += IncSE
         * */

        public void methodPontoMedio(int raio)
        {
            int x = 0;
            int y = raio;
            double d = ((double)1 - (double)raio);

            simetriade8(x, y);

            while (y > x)
            {
                if (d < 0)
                {
                    double IncE = (2 * x) + 3;
                    d += IncE;
                }
                else
                {
                    double IncSE = (2 * (x - y)) + 5;
                    d += IncSE;
                    y--;
                }
                x++;
                simetriade8(x, y);
            }
            Referencias.functions.atualizarImagem(imagem);
        }

        private void simetriade8(int x, int y)
        {
            ponto.plotarPixel(x, y, Color.Blue, imagem);
            ponto.plotarPixel(y, x, Color.Blue, imagem);
            ponto.plotarPixel(y, -x, Color.Blue, imagem);
            ponto.plotarPixel(x, -y, Color.Blue, imagem);
            ponto.plotarPixel(-x, -y, Color.Blue, imagem);
            ponto.plotarPixel(-y, -x, Color.Blue, imagem);
            ponto.plotarPixel(-y, x, Color.Blue, imagem);
            ponto.plotarPixel(-x, y, Color.Blue, imagem);
        }


        public void methodEquacaoExplicita (int raio)
        {
            int y;
            for (int x= -raio; x <= raio; x++)
            {
                y = Convert.ToInt32(Math.Sqrt((raio * raio) - (x * x)));
                imagem.SetPixel(ponto.X_MundoParaDispositivo(x), ponto.Y_MundoParaDispositivo(y), Color.Blue);
                imagem.SetPixel(ponto.X_MundoParaDispositivo(x), ponto.Y_MundoParaDispositivo(-y), Color.Blue);
                
            }
            Referencias.functions.atualizarImagem(imagem);
        }


        public void methodTrigonometrico (int raio)
        {
            double teta1 = Math.PI / 4;
            double teta0 = 0;
            int x, y;

            while (teta0 <= teta1)
            {
                if (teta0 > teta1) { break; }

                x = Convert.ToInt32(raio * Math.Cos(teta0));
                y = Convert.ToInt32(raio * Math.Sin(teta0));
                simetriade8(x, y);
                teta0 += Math.PI / 180;
            }

            Referencias.functions.atualizarImagem(imagem);
        }



    }
}
