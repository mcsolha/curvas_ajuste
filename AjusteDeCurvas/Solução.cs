using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AjusteDeCurvas.Ajustes;

namespace AjusteDeCurvas
{
    public partial class Solução : Form
    {
        public Action<object,Tipos> ShowSolution;

        private event EventHandler OpenForm;

        public void OnOpenForm(object sender)
        {
            OpenForm?.Invoke(sender, EventArgs.Empty);
        }

        public Solução()
        {
            InitializeComponent();
            OpenForm += Solução_OpenForm;
            ShowSolution = (o,t) =>
            {
                Ponto[] pontosajust = new Ponto[(o as DadosAjuste).QtdePontos];
                switch (t)
                {
                    case Tipos.Reta:
                        var dados = o is DadosRetaExpAjustada ? o as DadosRetaExpAjustada : null;
                        funcao.Text = "f(x) = " + dados.A.ToString("N4") + "x + " + dados.B.ToString("N4");
                        for (int i = 0; i < dados.Y.Length; i++)
                        {
                            pontosajust[i].y = dados.Y[i];
                            pontosajust[i].x = dados.PontosTabelados[i].x;
                        }
                        break;
                    case Tipos.Polinomial:
                        var dados1 = o is DadosPoliAjustada ? o as DadosPoliAjustada : null;
                        funcao.Text = "f(x) = ";
                        for (int i = 0; i < dados1.CoefAjust.Length; i++)
                        {
                            if (i == 0)
                                funcao.Text += dados1.CoefAjust[i] + " + ";
                            else if (i == (i - dados1.CoefAjust.Length))
                                funcao.Text += " " + dados1.CoefAjust[i] + " * x^" + i;
                            else
                                funcao.Text += " " + dados1.CoefAjust[i] + " * x^" + i + " ";
                        }
                        for (int i = 0; i < dados1.Y.Length; i++)
                        {
                            pontosajust[i].y = dados1.Y[i];
                            pontosajust[i].x = dados1.PontosTabelados[i].x;
                        }
                        break;
                    case Tipos.Exponencial1:
                        var dados2 = o is DadosRetaExpAjustada ? o as DadosRetaExpAjustada : null;
                        funcao.Text = "f(x) = " + dados2.B.ToString("N4") + " * " + dados2.A.ToString("N4") + "^x";
                        for (int i = 0; i < dados2.Y.Length; i++)
                        {
                            pontosajust[i].y = dados2.Y[i];
                            pontosajust[i].x = dados2.PontosTabelados[i].x;
                        }
                        break;
                    case Tipos.Exponencial2:
                        var dados3 = o is DadosRetaExpAjustada ? o as DadosRetaExpAjustada : null;
                        funcao.Text = "f(x) = " + dados3.B.ToString("N4") + " * e ^ (" + dados3.A.ToString("N4") + " * x)";
                        for (int i = 0; i < dados3.Y.Length; i++)
                        {
                            pontosajust[i].y = dados3.Y[i];
                            pontosajust[i].x = dados3.PontosTabelados[i].x;
                        }
                        break;
                    default:
                        break;
                }
                solucaoGrid.RowCount = (o as DadosAjuste).QtdePontos;
                for (int i = 0; i < pontosajust.Length; i++)
                {
                    solucaoGrid.Rows[i].Cells[0].Value = pontosajust[i].x;
                    solucaoGrid.Rows[i].Cells[1].Value = pontosajust[i].y;
                }
            };
        }

        private void Solução_OpenForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
