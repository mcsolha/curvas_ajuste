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
    public partial class MainForm : Form
    {
        public Inserção insert;
        public Solução soluc;
        

        public MainForm()
        {
            InitializeComponent();
        }

        public void ShowSolucForm()
        {
            if (soluc == null)
            {
                soluc = new Solução();
                soluc.MdiParent = this;
            }
            soluc.Show();
        }

        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(insert == null)
            {
                insert = new Inserção();
                insert.MdiParent = this;
            }
            if(this.ActiveMdiChild == null || this.ActiveMdiChild.Tag.ToString() != "insert")
            {
                insert.Show();
                insert.OnOpenForm(this);
            }
        }
    }
}
