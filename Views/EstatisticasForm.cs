using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;
using iShopping;

namespace iShopping.Views
{
    public class EstatisticasForm : Form
    {
        private TabControl tabControl;
        private TabPage tabResumo;
        private TabPage tabSugestoes;
        private DataGridView dgvComprasFechadas;
        private DataGridView dgvSugestaoListaCompras;
        private Label lblSugestaoOrcamento;
        private Label lblSemanaAtual;
        private Label lblResumoMensal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Label lblComprasFechadas;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Label lblSugestaoLista;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridView dgvResumoMensal;
        private Button btnAtualizar;

        public EstatisticasForm()
        {
            Text = "Estatísticas";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 900;
            Height = 520;
            InitializeComponent();
            CarregarDados();
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabResumo = new System.Windows.Forms.TabPage();
            this.lblResumoMensal = new System.Windows.Forms.Label();
            this.dgvResumoMensal = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblComprasFechadas = new System.Windows.Forms.Label();
            this.dgvComprasFechadas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSugestoes = new System.Windows.Forms.TabPage();
            this.lblSugestaoOrcamento = new System.Windows.Forms.Label();
            this.lblSemanaAtual = new System.Windows.Forms.Label();
            this.lblSugestaoLista = new System.Windows.Forms.Label();
            this.dgvSugestaoListaCompras = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabResumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumoMensal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasFechadas)).BeginInit();
            this.tabSugestoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestaoListaCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabResumo);
            this.tabControl.Controls.Add(this.tabSugestoes);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 460);
            this.tabControl.TabIndex = 0;
            // 
            // tabResumo
            // 
            this.tabResumo.Controls.Add(this.lblResumoMensal);
            this.tabResumo.Controls.Add(this.dgvResumoMensal);
            this.tabResumo.Controls.Add(this.lblComprasFechadas);
            this.tabResumo.Controls.Add(this.dgvComprasFechadas);
            this.tabResumo.Location = new System.Drawing.Point(4, 25);
            this.tabResumo.Name = "tabResumo";
            this.tabResumo.Size = new System.Drawing.Size(852, 431);
            this.tabResumo.TabIndex = 0;
            this.tabResumo.Text = "Resumo";
            // 
            // lblResumoMensal
            // 
            this.lblResumoMensal.Location = new System.Drawing.Point(10, 15);
            this.lblResumoMensal.Name = "lblResumoMensal";
            this.lblResumoMensal.Size = new System.Drawing.Size(500, 20);
            this.lblResumoMensal.TabIndex = 0;
            this.lblResumoMensal.Text = "Orçamento, total de compras e diferença por mês";
            // 
            // dgvResumoMensal
            // 
            this.dgvResumoMensal.AllowUserToAddRows = false;
            this.dgvResumoMensal.AllowUserToDeleteRows = false;
            this.dgvResumoMensal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResumoMensal.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvResumoMensal.ColumnHeadersHeight = 29;
            this.dgvResumoMensal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvResumoMensal.Location = new System.Drawing.Point(10, 40);
            this.dgvResumoMensal.Name = "dgvResumoMensal";
            this.dgvResumoMensal.ReadOnly = true;
            this.dgvResumoMensal.RowHeadersVisible = false;
            this.dgvResumoMensal.RowHeadersWidth = 51;
            this.dgvResumoMensal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResumoMensal.Size = new System.Drawing.Size(830, 180);
            this.dgvResumoMensal.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mês/Ano";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Orçamento";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Total de Compras";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Diferença";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lblComprasFechadas
            // 
            this.lblComprasFechadas.Location = new System.Drawing.Point(10, 235);
            this.lblComprasFechadas.Name = "lblComprasFechadas";
            this.lblComprasFechadas.Size = new System.Drawing.Size(700, 20);
            this.lblComprasFechadas.TabIndex = 2;
            this.lblComprasFechadas.Text = "Compras fechadas com percentagem de artigos previstos e não previstos";
            // 
            // dgvComprasFechadas
            // 
            this.dgvComprasFechadas.AllowUserToAddRows = false;
            this.dgvComprasFechadas.AllowUserToDeleteRows = false;
            this.dgvComprasFechadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasFechadas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvComprasFechadas.ColumnHeadersHeight = 29;
            this.dgvComprasFechadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvComprasFechadas.Location = new System.Drawing.Point(10, 260);
            this.dgvComprasFechadas.Name = "dgvComprasFechadas";
            this.dgvComprasFechadas.ReadOnly = true;
            this.dgvComprasFechadas.RowHeadersVisible = false;
            this.dgvComprasFechadas.RowHeadersWidth = 51;
            this.dgvComprasFechadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasFechadas.Size = new System.Drawing.Size(830, 180);
            this.dgvComprasFechadas.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Compra";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Data Fechada";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Total Artigos";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "% Previsto";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "% Não Previsto";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // tabSugestoes
            // 
            this.tabSugestoes.Controls.Add(this.lblSugestaoOrcamento);
            this.tabSugestoes.Controls.Add(this.lblSemanaAtual);
            this.tabSugestoes.Controls.Add(this.lblSugestaoLista);
            this.tabSugestoes.Controls.Add(this.dgvSugestaoListaCompras);
            this.tabSugestoes.Controls.Add(this.btnAtualizar);
            this.tabSugestoes.Location = new System.Drawing.Point(4, 25);
            this.tabSugestoes.Name = "tabSugestoes";
            this.tabSugestoes.Size = new System.Drawing.Size(852, 431);
            this.tabSugestoes.TabIndex = 1;
            this.tabSugestoes.Text = "Sugestões";
            // 
            // lblSugestaoOrcamento
            // 
            this.lblSugestaoOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblSugestaoOrcamento.Location = new System.Drawing.Point(10, 20);
            this.lblSugestaoOrcamento.Name = "lblSugestaoOrcamento";
            this.lblSugestaoOrcamento.Size = new System.Drawing.Size(820, 22);
            this.lblSugestaoOrcamento.TabIndex = 0;
            // 
            // lblSemanaAtual
            // 
            this.lblSemanaAtual.Location = new System.Drawing.Point(10, 50);
            this.lblSemanaAtual.Name = "lblSemanaAtual";
            this.lblSemanaAtual.Size = new System.Drawing.Size(820, 22);
            this.lblSemanaAtual.TabIndex = 1;
            // 
            // lblSugestaoLista
            // 
            this.lblSugestaoLista.Location = new System.Drawing.Point(10, 72);
            this.lblSugestaoLista.Name = "lblSugestaoLista";
            this.lblSugestaoLista.Size = new System.Drawing.Size(700, 15);
            this.lblSugestaoLista.TabIndex = 2;
            this.lblSugestaoLista.Text = "Sugestão de compras para a semana atual, com base nas semanas anteriores";
            // 
            // dgvSugestaoListaCompras
            // 
            this.dgvSugestaoListaCompras.AllowUserToAddRows = false;
            this.dgvSugestaoListaCompras.AllowUserToDeleteRows = false;
            this.dgvSugestaoListaCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSugestaoListaCompras.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSugestaoListaCompras.ColumnHeadersHeight = 29;
            this.dgvSugestaoListaCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvSugestaoListaCompras.Location = new System.Drawing.Point(10, 90);
            this.dgvSugestaoListaCompras.Name = "dgvSugestaoListaCompras";
            this.dgvSugestaoListaCompras.ReadOnly = true;
            this.dgvSugestaoListaCompras.RowHeadersVisible = false;
            this.dgvSugestaoListaCompras.RowHeadersWidth = 51;
            this.dgvSugestaoListaCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSugestaoListaCompras.Size = new System.Drawing.Size(830, 300);
            this.dgvSugestaoListaCompras.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Artigo";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Frequência";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Quantidade Média Prevista";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(715, 400);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(125, 30);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // EstatisticasForm
            // 
            this.ClientSize = new System.Drawing.Size(896, 505);
            this.Controls.Add(this.tabControl);
            this.Name = "EstatisticasForm";
            this.tabControl.ResumeLayout(false);
            this.tabResumo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumoMensal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasFechadas)).EndInit();
            this.tabSugestoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestaoListaCompras)).EndInit();
            this.ResumeLayout(false);

        }

        private void CarregarDados()
        {
            if (!SessionManager.EstaLogado())
            {
                MessageBox.Show("É necessário fazer login para ver estatísticas.");
                return;
            }

            CarregarResumoMensal();
            CarregarComprasFechadas();
            GerarSugestoes();
        }

        private void CarregarResumoMensal()
        {
            dgvResumoMensal.Rows.Clear();

            using (var context = new iShoppingContext())
            {
                int utilizadorId = SessionManager.IdUtilizadorAtual;
                var orcamentos = context.Orcamentos
                    .Where(o => o.IdUtilizadorCriacao == utilizadorId)
                    .ToList();

                var compras = context.Compras
                    .Include(c => c.ItensCompra)
                    .Where(c => c.IdUtilizadorCriacao == utilizadorId && c.DataFechada != null)
                    .ToList();

                var meses = orcamentos
                    .Select(o => new { o.Ano, o.Mes })
                    .Union(compras.Select(c => new { Ano = c.DataFechada.Value.Year, Mes = c.DataFechada.Value.Month }))
                    .Distinct()
                    .OrderBy(x => x.Ano)
                    .ThenBy(x => x.Mes)
                    .ToList();

                foreach (var mes in meses)
                {
                    decimal valorOrcamento = orcamentos
                        .Where(o => o.Ano == mes.Ano && o.Mes == mes.Mes)
                        .Select(o => o.Valor)
                        .FirstOrDefault();

                    decimal totalCompras = compras
                        .Where(c => c.DataFechada.Value.Year == mes.Ano && c.DataFechada.Value.Month == mes.Mes)
                        .Sum(c => c.ItensCompra.Sum(i => i.PrecoUnitario * (i.QuantidadeAdquirida ?? i.QuantidadePrevista)));

                    decimal diferenca = valorOrcamento - totalCompras;
                    string mesAno = new DateTime(mes.Ano, mes.Mes, 1).ToString("MMMM/yyyy", CultureInfo.CurrentCulture);

                    dgvResumoMensal.Rows.Add(mesAno, valorOrcamento.ToString("0.00"), totalCompras.ToString("0.00"), diferenca.ToString("0.00"));
                }
            }
        }

        private void CarregarComprasFechadas()
        {
            dgvComprasFechadas.Rows.Clear();

            using (var context = new iShoppingContext())
            {
                int utilizadorId = SessionManager.IdUtilizadorAtual;
                var comprasFechadas = context.Compras
                    .Include(c => c.ItensCompra)
                    .Where(c => c.IdUtilizadorCriacao == utilizadorId && c.DataFechada != null)
                    .OrderByDescending(c => c.DataFechada)
                    .ToList();

                foreach (var compra in comprasFechadas)
                {
                    int totalArtigos = compra.ItensCompra.Count;
                    int artigosPrevistos = compra.ItensCompra.Count(i => i.ArtigoPrevisto);
                    int artigosNaoPrevistos = totalArtigos - artigosPrevistos;

                    decimal percentualPrevisto = totalArtigos == 0 ? 0 : (100m * artigosPrevistos / totalArtigos);
                    decimal percentualNaoPrevisto = totalArtigos == 0 ? 0 : (100m * artigosNaoPrevistos / totalArtigos);

                    dgvComprasFechadas.Rows.Add(
                        compra.Nome,
                        compra.DataFechada?.ToString("dd/MM/yyyy"),
                        totalArtigos,
                        percentualPrevisto.ToString("0.##") + "%",
                        percentualNaoPrevisto.ToString("0.##") + "%");
                }
            }
        }

        private void GerarSugestoes()
        {
            dgvSugestaoListaCompras.Rows.Clear();

            using (var context = new iShoppingContext())
            {
                int utilizadorId = SessionManager.IdUtilizadorAtual;
                var orcamentos = context.Orcamentos
                    .Where(o => o.IdUtilizadorCriacao == utilizadorId)
                    .OrderByDescending(o => o.Ano)
                    .ThenByDescending(o => o.Mes)
                    .ToList();

                var comprasFechadas = context.Compras
                    .Include(c => c.ItensCompra.Select(i => i.Artigo))
                    .Where(c => c.IdUtilizadorCriacao == utilizadorId && c.DataFechada != null)
                    .ToList();

                DateTime proximoMes = DateTime.Today.AddMonths(1);
                decimal orcamentoSugerido = 0;

                if (orcamentos.Any())
                {
                    var ultimosOrcamentos = orcamentos.Take(3).ToList();
                    orcamentoSugerido = ultimosOrcamentos.Average(o => o.Valor);
                }

                lblSugestaoOrcamento.Text = $"Orçamento sugerido para {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(proximoMes.Month)} {proximoMes.Year}: {orcamentoSugerido:0.00}";

                int semanaAtual = ObterSemanaDoMes(DateTime.Today);
                lblSemanaAtual.Text = $"Semana atual do mês: {semanaAtual}ª";

                var comprasMesmoPeriodo = comprasFechadas
                    .Where(c => ObterSemanaDoMes(c.DataFechada.Value) == semanaAtual)
                    .ToList();

                var sugestoes = comprasMesmoPeriodo
                    .SelectMany(c => c.ItensCompra)
                    .GroupBy(i => i.Artigo?.Descricao ?? "Artigo desconhecido")
                    .Select(g => new
                    {
                        Artigo = g.Key,
                        Frequencia = g.Count(),
                        QuantidadeMedia = g.Average(i => (double)i.QuantidadePrevista)
                    })
                    .OrderByDescending(x => x.Frequencia)
                    .ThenBy(x => x.Artigo)
                    .Take(20)
                    .ToList();

                foreach (var sugestao in sugestoes)
                {
                    dgvSugestaoListaCompras.Rows.Add(
                        sugestao.Artigo,
                        sugestao.Frequencia,
                        sugestao.QuantidadeMedia.ToString("0.##"));
                }

                if (!sugestoes.Any())
                {
                    dgvSugestaoListaCompras.Rows.Add("Nenhuma sugestão encontrada para esta semana do mês", string.Empty, string.Empty);
                }
            }
        }

        private int ObterSemanaDoMes(DateTime data)
        {
            int dia = data.Day;
            int semana = ((dia - 1) / 7) + 1;
            return semana > 4 ? 4 : semana;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void dgvResumoMensal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
