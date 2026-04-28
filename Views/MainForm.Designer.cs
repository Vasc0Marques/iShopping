namespace iShopping.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposArtigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orcamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeamentoComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEstatisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ListView lvComprasAbertas;
        private System.Windows.Forms.ColumnHeader colNomeCompra;
        private System.Windows.Forms.ColumnHeader colDataCriacao;
        private System.Windows.Forms.Label lblUtilizadorLogado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposArtigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orcamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeamentoComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verEstatisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvComprasAbertas = new System.Windows.Forms.ListView();
            this.colNomeCompra = new System.Windows.Forms.ColumnHeader();
            this.colDataCriacao = new System.Windows.Forms.ColumnHeader();
            this.lblUtilizadorLogado = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestaoToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.estatisticasToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestaoToolStripMenuItem
            // 
            this.gestaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.tiposArtigoToolStripMenuItem,
            this.artigosToolStripMenuItem,
            this.orcamentosToolStripMenuItem});
            this.gestaoToolStripMenuItem.Name = "gestaoToolStripMenuItem";
            this.gestaoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.gestaoToolStripMenuItem.Text = "Gestão";
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem_Click);
            // 
            // tiposArtigoToolStripMenuItem
            // 
            this.tiposArtigoToolStripMenuItem.Name = "tiposArtigoToolStripMenuItem";
            this.tiposArtigoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.tiposArtigoToolStripMenuItem.Text = "Tipos de Artigo";
            this.tiposArtigoToolStripMenuItem.Click += new System.EventHandler(this.tiposArtigoToolStripMenuItem_Click);
            // 
            // artigosToolStripMenuItem
            // 
            this.artigosToolStripMenuItem.Name = "artigosToolStripMenuItem";
            this.artigosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.artigosToolStripMenuItem.Text = "Artigos";
            this.artigosToolStripMenuItem.Click += new System.EventHandler(this.artigosToolStripMenuItem_Click);
            // 
            // orcamentosToolStripMenuItem
            // 
            this.orcamentosToolStripMenuItem.Name = "orcamentosToolStripMenuItem";
            this.orcamentosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.orcamentosToolStripMenuItem.Text = "Orçamentos";
            this.orcamentosToolStripMenuItem.Click += new System.EventHandler(this.orcamentosToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planeamentoComprasToolStripMenuItem,
            this.modoCompraToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // planeamentoComprasToolStripMenuItem
            // 
            this.planeamentoComprasToolStripMenuItem.Name = "planeamentoComprasToolStripMenuItem";
            this.planeamentoComprasToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.planeamentoComprasToolStripMenuItem.Text = "Planeamento de Compras";
            this.planeamentoComprasToolStripMenuItem.Click += new System.EventHandler(this.planeamentoComprasToolStripMenuItem_Click);
            // 
            // modoCompraToolStripMenuItem
            // 
            this.modoCompraToolStripMenuItem.Name = "modoCompraToolStripMenuItem";
            this.modoCompraToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.modoCompraToolStripMenuItem.Text = "Modo Compra";
            this.modoCompraToolStripMenuItem.Click += new System.EventHandler(this.modoCompraToolStripMenuItem_Click);
            // 
            // estatisticasToolStripMenuItem
            // 
            this.estatisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEstatisticasToolStripMenuItem});
            this.estatisticasToolStripMenuItem.Name = "estatisticasToolStripMenuItem";
            this.estatisticasToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.estatisticasToolStripMenuItem.Text = "Estatísticas";
            // 
            // verEstatisticasToolStripMenuItem
            // 
            this.verEstatisticasToolStripMenuItem.Name = "verEstatisticasToolStripMenuItem";
            this.verEstatisticasToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.verEstatisticasToolStripMenuItem.Text = "Ver Estatísticas";
            this.verEstatisticasToolStripMenuItem.Click += new System.EventHandler(this.estatisticasToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // lvComprasAbertas
            // 
            this.lvComprasAbertas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNomeCompra,
            this.colDataCriacao});
            this.lvComprasAbertas.FullRowSelect = true;
            this.lvComprasAbertas.HideSelection = false;
            this.lvComprasAbertas.Location = new System.Drawing.Point(16, 64);
            this.lvComprasAbertas.Name = "lvComprasAbertas";
            this.lvComprasAbertas.Size = new System.Drawing.Size(728, 340);
            this.lvComprasAbertas.TabIndex = 1;
            this.lvComprasAbertas.UseCompatibleStateImageBehavior = false;
            this.lvComprasAbertas.View = System.Windows.Forms.View.Details;
            // 
            // colNomeCompra
            // 
            this.colNomeCompra.Text = "Compra";
            this.colNomeCompra.Width = 480;
            // 
            // colDataCriacao
            // 
            this.colDataCriacao.Text = "Data Criação";
            this.colDataCriacao.Width = 160;
            // 
            // lblUtilizadorLogado
            // 
            this.lblUtilizadorLogado.AutoSize = true;
            this.lblUtilizadorLogado.Location = new System.Drawing.Point(16, 36);
            this.lblUtilizadorLogado.Name = "lblUtilizadorLogado";
            this.lblUtilizadorLogado.Size = new System.Drawing.Size(0, 13);
            this.lblUtilizadorLogado.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 420);
            this.Controls.Add(this.lblUtilizadorLogado);
            this.Controls.Add(this.lvComprasAbertas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iShopping";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
