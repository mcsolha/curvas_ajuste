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
    public partial class Inserção : Form
    {
        string[] labelNames = new string[2] { "qtdePontosLabel", "tipoLabel" };

        private event EventHandler OpenForm;

        public void OnOpenForm(object sender)
        {
            OpenForm?.Invoke(sender, EventArgs.Empty);
        }

        public Inserção()
        {
            InitializeComponent();
            OpenForm += (sender, e) =>
            {
                qtdePontos.ResetText();
                tipos.SelectedIndex = 0;
                WindowState = FormWindowState.Maximized;
            };
            tipos.DataSource = Enum.GetNames(typeof(Ajustes.Tipos));
        }

        private void Inserção_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void qtdePontos_TextChanged(object sender, EventArgs e)
        {
            pontosTabelados.RowCount = qtdePontos.Text != "" ? int.Parse(qtdePontos.Text) <= 100 ? int.Parse(qtdePontos.Text) : 0 : 0;
        }

        private void qtdePontos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void calcular_Click(object sender, EventArgs e)
        {
            var tipo = (Tipos)tipos.SelectedIndex;
            object dadosGen = null;
            switch (tipo)
            {
                case Tipos.Reta:
                    DadosRetaExpAjustada dados = new DadosRetaExpAjustada()
                    {
                        QtdePontos = pontosTabelados.RowCount
                    };
                    dados.PontosTabelados = getPontos(pontosTabelados).ToArray();
                    dados.AjustarReta(tipo);
                    dadosGen = dados;
                    break;
                case Tipos.Polinomial:

                    DadosPoliAjustada dadopoli = new DadosPoliAjustada()
                    {
                        QtdePontos = pontosTabelados.RowCount,
                        PontosTabelados = getPontos(pontosTabelados).ToArray(),
                        GrauPoli = int.Parse(Prompt.ShowDialog("Grau do polinomio:", "Grau")),
                    };
                    dadopoli.AjustarReta(tipo);
                    dadosGen = dadopoli;
                    break;
                case Tipos.Exponencial1:
                    dados = new DadosRetaExpAjustada()
                    {
                        QtdePontos = pontosTabelados.RowCount
                    };
                    dados.PontosTabelados = getPontos(pontosTabelados).ToArray();
                    dados.AjustarReta(tipo);
                    dadosGen = dados;
                    break;
                case Tipos.Exponencial2:
                    dados = new DadosRetaExpAjustada()
                    {
                        QtdePontos = pontosTabelados.RowCount
                    };
                    dados.PontosTabelados = getPontos(pontosTabelados).ToArray();
                    dados.AjustarReta(tipo);
                    dadosGen = dados;
                    break;
                default:
                    break;
            }
            this.Hide();
            ((MainForm)MdiParent).ShowSolucForm();
            ((MainForm)MdiParent).soluc.OnOpenForm(this);
            ((MainForm)MdiParent).soluc.ShowSolution(dadosGen,tipo);
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private IEnumerable<Ponto> getPontos(DataGridView grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                yield return new Ponto() { x = Convert.ToDouble(grid.Rows[i].Cells[0].Value), y = Convert.ToDouble(grid.Rows[i].Cells[1].Value) };
            }
        }
    }
}
