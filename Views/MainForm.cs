using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public partial class MainForm : Form
    {
        private readonly int _utilizadorId;
        private readonly string _utilizadorNome;

        public MainForm(Utilizador utilizador)
        {
            InitializeComponent();
            _utilizadorId = utilizador.Id;
            _utilizadorNome = utilizador.Nome;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUtilizadorLogado.Text = $"Utilizador: {_utilizadorNome}";
            CarregarComprasAbertas();
        }

        private void CarregarComprasAbertas()
        {
            lvComprasAbertas.Items.Clear();

            using (var context = new iShoppingContext())
            {
                var compras = context.Compras
                    .Where(c => c.IdUtilizadorCriacao == _utilizadorId && c.DataFechada == null)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();

                foreach (var compra in compras)
                {
                    var item = new ListViewItem(compra.Nome);
                    item.SubItems.Add(compra.DataCriacao.ToString("dd/MM/yyyy"));
                    lvComprasAbertas.Items.Add(item);
                }
            }
        }

        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GestaoUtilizadoresForm().Show();
        }

        private void tiposArtigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GestaoTiposArtigoForm().Show();
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GestaoArtigosForm().Show();
        }

        private void orcamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GestaoOrcamentosForm().Show();
        }

        private void planeamentoComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PlaneamentoComprasForm().Show();
        }

        private void modoCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ModoCompraForm().Show();
        }

        private void estatisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EstatisticasForm().Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
