#define de_bug
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AjusteDeCurvas.Helper
{
    public static class SistemasLineares
    {
        public static double[] SS(double[][] a, double[] b)
        {
            double[] x = new double[a.Length];

            ///x[n] = b[n]/a[n][n]
            x[x.Length - 1] = b[x.Length - 1] / a[x.Length - 1][x.Length - 1];

            ///x[i] = (b[i] - sum(a[i][j] * x[j], ))
            for (int i = x.Length - 2; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i+1; j < x.Length; j++)
                {
                    sum += a[i][j] * x[j];
                }

                x[i] = (b[i] - sum) / a[i][i];
            }

            return x;
        }

        public static double[] SI(double[][] a, double[] b)
        {
            double[] x = new double[a.Length];

            ///x[1] = b[1]/a[1][1];
            x[0] = b[0] / a[0][0];

            for (int i = 0; i < x.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += a[i][j] * x[j];
                }
                x[i] = (b[i] - sum) / a[i][i];
            }

            return x;
        }

        public static double[] LU(double[][] a, double[] b)
        {
            double[][] u, l;
            u = new double[a.Length][];
            l = new double[a.Length][];

            for (int i = 0; i < u.Length; i++)
            {
                u[i] = new double[u.Length];
                l[i] = new double[l.Length];
            }

            ///Separa em L e U
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    double sumu = 0;
                    double suml = 0;

                    ///Linha de U
                    for (int k = 0; k < i; k++)
                    {
                        sumu += l[i][k] * u[k][j];
                    }
                    u[i][j] = a[i][j] - sumu;
                    ///Coluna de L
                    for (int k = 0; k < j; k++)
                    {
                        suml += l[i][k] * u[k][j];
                    }
                    l[i][j] = (a[i][j] - suml) / u[j][j];
                }
            }

            double[] y = SI(l, b);
            double[] x = SS(u, y);
            return x;
        }
    }
    public static class SistemasLinearesIterativos
    {
        public static double[] Jacobi(double[][] A, double[] B, int ordem)
        {

            double[] _B = new double[ordem];
            double[][] _A = new double[ordem][];

            for (int i = 0; i < _A.Length; i++)
            {
                _A[i] = new double[ordem];
            }

            ///Matriz simplificada
            for (int i = 0; i < _A.Length; i++)
            {
                for (int j = 0; j < _A.Length; j++)
                {
                    _A[i][j] = A[i][j] / A[i][i];
                }
                _B[i] = B[i] / A[i][i];
            }

#if de_bug
            for (int i = 0; i < _A.Length; i++)
            {
                for (int j = 0; j < _A.Length; j++)
                {
                    Console.WriteLine(_A[i][j]);
                }
            }
#endif
            double[] x = new double[ordem];
            double[] newx = new double[ordem];
            bool keepDoin = true;
            while (keepDoin)
            {
                ///Novo vetor X
                for (int i = 0; i < _A.Length; i++)
                {
                    double summatory = 0;
                    for (int j = 0; j < _A.Length; j++)
                    {
                        if (j != i)
                        {
                            summatory += _A[i][j] * x[i];
                        }
                    }

                    newx[i] = _B[i] - summatory;
                }
                double maior = 0;
                double menosmaior = 0;
                ///Maior X
                for (int i = 0; i < ordem; i++)
                {
                    if (Math.Abs(newx[i]) > maior)
                        maior = Math.Abs(newx[i]);

                    if (Math.Abs(newx[i] - x[i]) > menosmaior)
                        menosmaior = Math.Abs(newx[i] - x[i]);
                }

                if (menosmaior / maior < 0.0001)
                    keepDoin = false;
                else
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] = newx[i];
                    }
            }
            return x;
        }
    }
}
