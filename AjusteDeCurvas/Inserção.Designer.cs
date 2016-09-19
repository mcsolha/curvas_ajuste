namespace AjusteDeCurvas
{
    partial class Inserção
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.dadosFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.qtdePontosLabel = new System.Windows.Forms.Label();
            this.qtdePontos = new System.Windows.Forms.TextBox();
            this.tipoLabel = new System.Windows.Forms.Label();
            this.tipos = new System.Windows.Forms.ComboBox();
            this.pontosTabelados = new System.Windows.Forms.DataGridView();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcular = new System.Windows.Forms.Button();
            this.mainTable.SuspendLayout();
            this.dadosFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pontosTabelados)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Controls.Add(this.dadosFlow, 0, 0);
            this.mainTable.Controls.Add(this.pontosTabelados, 0, 1);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 2;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Size = new System.Drawing.Size(606, 336);
            this.mainTable.TabIndex = 0;
            this.mainTable.Tag = "Container";
            // 
            // dadosFlow
            // 
            this.dadosFlow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dadosFlow.AutoSize = true;
            this.dadosFlow.Controls.Add(this.qtdePontosLabel);
            this.dadosFlow.Controls.Add(this.qtdePontos);
            this.dadosFlow.Controls.Add(this.tipoLabel);
            this.dadosFlow.Controls.Add(this.tipos);
            this.dadosFlow.Controls.Add(this.calcular);
            this.dadosFlow.Location = new System.Drawing.Point(74, 3);
            this.dadosFlow.Name = "dadosFlow";
            this.dadosFlow.Size = new System.Drawing.Size(458, 31);
            this.dadosFlow.TabIndex = 0;
            // 
            // qtdePontosLabel
            // 
            this.qtdePontosLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.qtdePontosLabel.AutoSize = true;
            this.qtdePontosLabel.Location = new System.Drawing.Point(3, 9);
            this.qtdePontosLabel.Name = "qtdePontosLabel";
            this.qtdePontosLabel.Size = new System.Drawing.Size(97, 13);
            this.qtdePontosLabel.TabIndex = 0;
            this.qtdePontosLabel.Text = "Quantidade pontos";
            // 
            // qtdePontos
            // 
            this.qtdePontos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.qtdePontos.Location = new System.Drawing.Point(106, 5);
            this.qtdePontos.Name = "qtdePontos";
            this.qtdePontos.Size = new System.Drawing.Size(100, 20);
            this.qtdePontos.TabIndex = 1;
            this.qtdePontos.TextChanged += new System.EventHandler(this.qtdePontos_TextChanged);
            this.qtdePontos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtdePontos_KeyPress);
            // 
            // tipoLabel
            // 
            this.tipoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tipoLabel.AutoSize = true;
            this.tipoLabel.Location = new System.Drawing.Point(212, 9);
            this.tipoLabel.Name = "tipoLabel";
            this.tipoLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tipoLabel.Size = new System.Drawing.Size(85, 13);
            this.tipoLabel.TabIndex = 2;
            this.tipoLabel.Text = "Tipo de Ajuste";
            // 
            // tipos
            // 
            this.tipos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tipos.FormattingEnabled = true;
            this.tipos.Location = new System.Drawing.Point(303, 5);
            this.tipos.Name = "tipos";
            this.tipos.Size = new System.Drawing.Size(121, 21);
            this.tipos.TabIndex = 3;
            // 
            // pontosTabelados
            // 
            this.pontosTabelados.AllowUserToAddRows = false;
            this.pontosTabelados.AllowUserToDeleteRows = false;
            this.pontosTabelados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pontosTabelados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.pontosTabelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pontosTabelados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y});
            this.pontosTabelados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pontosTabelados.Location = new System.Drawing.Point(3, 40);
            this.pontosTabelados.Name = "pontosTabelados";
            this.pontosTabelados.RowHeadersVisible = false;
            this.pontosTabelados.Size = new System.Drawing.Size(600, 293);
            this.pontosTabelados.TabIndex = 1;
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.Name = "x";
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.Name = "y";
            // 
            // calcular
            // 
            this.calcular.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calcular.BackColor = System.Drawing.Color.Transparent;
            this.calcular.BackgroundImage = global::AjusteDeCurvas.Properties.Resources.next;
            this.calcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.calcular.Location = new System.Drawing.Point(430, 3);
            this.calcular.Name = "calcular";
            this.calcular.Size = new System.Drawing.Size(25, 25);
            this.calcular.TabIndex = 4;
            this.calcular.UseVisualStyleBackColor = false;
            this.calcular.Click += new System.EventHandler(this.calcular_Click);
            // 
            // Inserção
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 336);
            this.ControlBox = false;
            this.Controls.Add(this.mainTable);
            this.Name = "Inserção";
            this.Tag = "insert";
            this.Text = "Inserção";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inserção_FormClosing);
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            this.dadosFlow.ResumeLayout(false);
            this.dadosFlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pontosTabelados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.FlowLayoutPanel dadosFlow;
        private System.Windows.Forms.Label qtdePontosLabel;
        private System.Windows.Forms.TextBox qtdePontos;
        private System.Windows.Forms.Label tipoLabel;
        private System.Windows.Forms.ComboBox tipos;
        private System.Windows.Forms.DataGridView pontosTabelados;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.Button calcular;
    }
}