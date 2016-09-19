//#define de_bug
using AjusteDeCurvas.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AjusteDeCurvas.Ajustes;

namespace AjusteDeCurvas
{
    public static class Ajustes
    {
        public struct Ponto
        {
            public double x;
            public double y;
        }

        public enum Tipos
        {
            Reta,
            Polinomial,
            Exponencial1,
            Exponencial2
        }

        public class DadosAjuste
        {
            Ponto[] pontosTabelados;
            int qtdePontos;
            public int Erro;

            public Ponto[] PontosTabelados
            {
                get
                {
                    return pontosTabelados;
                }
                set
                {
                    pontosTabelados = value;
                }
            }

            public int QtdePontos
            {
                get
                {
                    return qtdePontos;
                }

                set
                {
                    qtdePontos = value;
                    pontosTabelados = new Ponto[value];
                }
            }
        }

        public class DadosRetaExpAjustada : DadosAjuste
        {
            public double A;
            public double B;
            public double[] Y;
        }

        public class DadosPoliAjustada : DadosAjuste
        {
            public int GrauPoli;
            public double[] CoefAjust;
            public double[] Y;
        }

        private static void AjustarPoli(int qtdePontos, Ponto[] tabela, int GrauPoli, out double[] Coef, out double[] Y, out int erro)
        {
            double somy = 0;
            double[][] matriz  = new double[GrauPoli + 1][];
            for (int i = 0; i < matriz.Length; i++)
            {
                matriz[i] = new double[GrauPoli + 1];
            }
            double[] somxn = new double[GrauPoli*GrauPoli];
            double[] somxny = new double[GrauPoli+1];
            for (int i = 0; i < qtdePontos; i++)
            {
                for (int j = 0; j < GrauPoli * 2; j++)
                {
                    somxn[j] += Math.Pow(tabela[i].x, j+1);
                }
                for (int j = 0; j <= GrauPoli; j++)
                {
                    somxny[j] += Math.Pow(tabela[i].x, j) * tabela[i].y;
                }
                somy += tabela[i].y;
            }

            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz.Length; j++)
                {
                    if (j == 0 && i == 0)
                        matriz[i][j] = qtdePontos;
                    else
                        matriz[i][j] = somxn[j - 1 + i];
                }
            }

            double[] A = new double[GrauPoli+1];
            
            Coef = SistemasLineares.LU(matriz, somxny);
            Y = new double[qtdePontos];
            for (int i = 0; i < qtdePontos; i++)
            {
                for (int j = 0; j < GrauPoli; j++)
                {
                    Y[i] += Math.Pow(tabela[i].x, j) * Coef[j];
                }
            }
            erro = 0;
        }

        private static void AjustarReta(int qtdePontos, Ponto[] tabela, out double A, out double B, out double[] Y, out int erro)
        {
            double xy = 0, y = 0, x = 0, x2 = 0;
            for (int i = 0; i < tabela.Length; i++)
            {
                xy += tabela[i].x * tabela[i].y;
                x += tabela[i].x;
                y += tabela[i].y;
                x2 += tabela[i].x * tabela[i].x;
            }
            A = ((qtdePontos * xy) - (x * y)) / ((qtdePontos * x2) - (x * x));
            B = (y - (A * x)) / qtdePontos;

            Y = new double[qtdePontos];
            for (int i = 0; i < tabela.Length; i++)
            {
                Y[i] = (A * tabela[i].x) + B;
            }
            erro = 0;
        }

        private static void AjustarExp1(int qtdePontos, Ponto[] tabela, out double A, out double B, out double[] Y, out int erro)
        {
            double somx = 0, somxquad = 0, somlny = 0, somxlny = 0, a = 0, b = 0;
            for (int i = 0; i < tabela.Length; i++)
            {
                somx += tabela[i].x;
                somxquad += Math.Pow(tabela[i].x, 2);
                somlny += Math.Log(tabela[i].y);
                somxlny += (tabela[i].x * Math.Log(tabela[i].y));
            }
            a = (((qtdePontos * somxlny) - (somx * somlny)) / (qtdePontos * somxquad - (Math.Pow(somx, 2))));
            b = ((somlny - a * somx) / qtdePontos);
            A = Math.Exp(a);
            B = Math.Exp(b);
            
            Y = new double[qtdePontos];

            for (int i = 0; i < tabela.Length; i++)
            {
                Y[i] = B * (Math.Pow(A, (tabela[i].x)));
            }

            erro = 0;
            //valor = b*(math.exp(a*(vetor[i].x)));
        }

        private static void AjustarExp2(int qtdePontos, Ponto[] tabela, out double A, out double B, out double[] Y, out int erro)
        {
            double somx = 0, somxquad = 0, somlny = 0, somxlny = 0, a = 0, b = 0;
            for (int i = 0; i < tabela.Length; i++)
            {
                somx += tabela[i].x;
                somxquad += Math.Pow(tabela[i].x, 2);
                somlny += Math.Log(tabela[i].y);
                somxlny += (tabela[i].x * Math.Log(tabela[i].y));
            }
            a = (((qtdePontos * somxlny) - (somx * somlny)) / (qtdePontos * somxquad - (Math.Pow(somx, 2))));
            b = ((somlny - a * somx) / qtdePontos);
            A = a;
            B = Math.Exp(b);

            Y = new double[qtdePontos];

            for (int i = 0; i < tabela.Length; i++)
            {
                Y[i] = B * (Math.Exp(A * (tabela[i].x)));
            }

            erro = 0;
            //valor = b*(math.exp(a*(vetor[i].x)));
        }

        public static void AjustarReta(this DadosAjuste o, Tipos tipo)
        {
            switch (tipo)
            {
                case Tipos.Reta:
                    DadosRetaExpAjustada entrada = o as DadosRetaExpAjustada;
                    AjustarReta(entrada.QtdePontos, entrada.PontosTabelados, out entrada.A, out entrada.B, out entrada.Y, out entrada.Erro);
                    break;
                case Tipos.Polinomial:
                    DadosPoliAjustada entrada1 = o as DadosPoliAjustada;
                    AjustarPoli(entrada1.QtdePontos, entrada1.PontosTabelados, entrada1.GrauPoli, out entrada1.CoefAjust, out entrada1.Y, out entrada1.Erro);
                    break;
                case Tipos.Exponencial1:
                    DadosRetaExpAjustada entrada2 = o as DadosRetaExpAjustada;
                    AjustarExp1(entrada2.QtdePontos, entrada2.PontosTabelados, out entrada2.A, out entrada2.B, out entrada2.Y, out entrada2.Erro);
                    break;
                case Tipos.Exponencial2:
                    DadosRetaExpAjustada entrada3 = o as DadosRetaExpAjustada;
                    AjustarExp2(entrada3.QtdePontos, entrada3.PontosTabelados, out entrada3.A, out entrada3.B, out entrada3.Y, out entrada3.Erro);
                    break;
            }
        }
    }
}
