using System.Data.Entity;
using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;
using System.Reflection;
using iShopping;

namespace iShopping.Views
{
    public class PlaneamentoComprasForm : Form
    {
        private ListView listViewCompras;
        private ComboBox cbEstado;
        private Button btnFiltrar;
        private Button btnCriar;
        private Button btnEditar;
        private Button btnApagar;
        private Label lbTitulo;
        private Button exportarCompras;
        private Label lbErro;

        public PlaneamentoComprasForm()
        {
            Text = "Planeamento de Compras";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 800;
            Height = 420;
            InitializeComponent();
            CarregarEstados();
            CarregarCompras("Todos");
        }

        private void InitializeComponent()
        {
            this.listViewCompras = new System.Windows.Forms.ListView();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbErro = new System.Windows.Forms.Label();
            this.exportarCompras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewCompras
            // 
            this.listViewCompras.FullRowSelect = true;
            this.listViewCompras.HideSelection = false;
            this.listViewCompras.Location = new System.Drawing.Point(12, 44);
            this.listViewCompras.Name = "listViewCompras";
            this.listViewCompras.Size = new System.Drawing.Size(756, 300);
            this.listViewCompras.TabIndex = 2;
            this.listViewCompras.UseCompatibleStateImageBehavior = false;
            this.listViewCompras.View = System.Windows.Forms.View.Details;
            this.listViewCompras.Columns.Add("Id", 50);
            this.listViewCompras.Columns.Add("Nome", 180);
            this.listViewCompras.Columns.Add("Data Criação", 100);
            this.listViewCompras.Columns.Add("Utilizador", 100);
            this.listViewCompras.Columns.Add("Estado", 200);
            this.listViewCompras.SelectedIndexChanged += new System.EventHandler(this.listViewCompras_SelectedIndexChanged);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Location = new System.Drawing.Point(525, 14);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(160, 24);
            this.cbEstado.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(693, 14);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(12, 354);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 3;
            this.btnCriar.Text = "Criar";
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(93, 354);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(174, 354);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(75, 23);
            this.btnApagar.TabIndex = 5;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.Location = new System.Drawing.Point(12, 14);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(261, 25);
            this.lbTitulo.TabIndex = 5;
            this.lbTitulo.Text = "Planeamento de Compras";
            // 
            // lbErro
            // 
            this.lbErro.AutoSize = true;
            this.lbErro.ForeColor = System.Drawing.Color.Red;
            this.lbErro.Location = new System.Drawing.Point(552, 44);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 16);
            this.lbErro.TabIndex = 6;
            this.lbErro.Visible = false;
            // 
            // exportarCompras
            // 
            this.exportarCompras.Location = new System.Drawing.Point(255, 354);
            this.exportarCompras.Name = "exportarCompras";
            this.exportarCompras.Size = new System.Drawing.Size(199, 24);
            this.exportarCompras.TabIndex = 8;
            this.exportarCompras.Text = "Exportar Compras Fechadas";
            this.exportarCompras.UseVisualStyleBackColor = true;
            this.exportarCompras.Click += new System.EventHandler(this.exportarCompras_Click);
            // 
            // PlaneamentoComprasForm
            // 
            this.ClientSize = new System.Drawing.Size(780, 390);
            this.Controls.Add(this.exportarCompras);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.listViewCompras);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbErro);
            this.Name = "PlaneamentoComprasForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CarregarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add("Todos");
            cbEstado.Items.Add("Em planeamento");
            cbEstado.Items.Add("Fechada");
            cbEstado.SelectedIndex = 0;
        }

        private void CarregarCompras(string estado)
        {
            if (!SessionManager.EstaLogado())
            {
                MessageBox.Show("Utilizador não autenticado.");
                return;
            }

            using (var context = new iShoppingContext())
            {
                var query = context.Compras.AsQueryable();
                query = query.Where(c => c.IdUtilizadorCriacao == SessionManager.IdUtilizadorAtual);

                if (estado == "Em planeamento")
                {
                    query = query.Where(c => c.DataFechada == null);
                }
                else if (estado == "Fechada")
                {
                    query = query.Where(c => c.DataFechada != null);
                }

                var compras = query
                    .Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        c.DataCriacao,
                        c.DataFechada,
                        Utilizador = c.UtilizadorCriacao.Username
                    })
                    .ToList();

                listViewCompras.Items.Clear();
                foreach (var compra in compras)
                {
                    var item = new ListViewItem(compra.Id.ToString());
                    item.SubItems.Add(compra.Nome);
                    item.SubItems.Add(compra.DataCriacao.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(compra.Utilizador);
                    item.SubItems.Add(compra.DataFechada.HasValue ? "Fechada" : "Em planeamento");
                    item.Tag = compra.Id;
                    listViewCompras.Items.Add(item);
                }
            }
        }

        private void btnFiltrar_Click(object sender, System.EventArgs e)
        {
            CarregarCompras(cbEstado.Text);
        }

        private void btnCriar_Click(object sender, System.EventArgs e)
        {
            using (var form = new PlaneamentoCompraForm())
            {
                form.ShowDialog(this);
            }

            CarregarCompras(cbEstado.Text);
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (listViewCompras.SelectedItems.Count == 0)
            {
                lbErro.Text = "Selecione uma compra para editar.";
                lbErro.Visible = true;
                return;
            }

            var selectedItem = listViewCompras.SelectedItems[0];
            var id = (int)selectedItem.Tag;
            lbErro.Visible = false;

            using (var form = new PlaneamentoCompraForm(id))
            {
                form.ShowDialog(this);
            }

            CarregarCompras(cbEstado.Text);
        }

        private void btnApagar_Click(object sender, System.EventArgs e)
        {
            if (listViewCompras.SelectedItems.Count == 0)
            {
                lbErro.Text = "Selecione uma compra para apagar.";
                lbErro.Visible = true;
                return;
            }

            var selectedItem = listViewCompras.SelectedItems[0];
            var id = (int)selectedItem.Tag;

            using (var context = new iShoppingContext())
            {
                var compra = context.Compras.Find(id);
                if (compra == null)
                {
                    lbErro.Text = "Compra não encontrada.";
                    lbErro.Visible = true;
                    return;
                }

                if (compra.DataFechada.HasValue)
                {
                    MessageBox.Show("Compras fechadas não podem ser apagadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Tem a certeza que quer apagar a compra '{compra.Nome}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                context.Compras.Remove(compra);
                context.SaveChanges();
            }

            lbErro.Visible = false;
            CarregarCompras(cbEstado.Text);
        }

        private void listViewCompras_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void exportarCompras_Click(object sender, EventArgs e)
        {
            using (var context = new iShoppingContext())
            {
                int idUtilizador = SessionManager.IdUtilizadorAtual;
                string nomeUtilizador = SessionManager.UsernameUtilizadorAtual;

                var comprasFechadas = context.Compras
                    .Where(c => c.IdUtilizadorCriacao == idUtilizador && c.DataFechada != null)
                    .Include(c => c.ItensCompra.Select(i => i.Artigo))
                    .ToList();

                if (comprasFechadas.Count == 0)
                {
                    MessageBox.Show("Não há compras fechadas para exportar.");
                    return;
                }

                string filePath = $"compras_fechadas_utilizador_{nomeUtilizador}.csv";

                using (var writer = new System.IO.StreamWriter(filePath))
                {
                    writer.WriteLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;PrecoUnitario;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida");

                    foreach (var compra in comprasFechadas)
                    {
                        foreach (var item in compra.ItensCompra)
                        {
                            string dataCriacao = compra.DataCriacao.ToString("dd/MM/yyyy HH:mm");
                            string dataFechada = compra.DataFechada.Value.ToString("dd/MM/yyyy HH:mm");

                            string artigoPrevisto = item.ArtigoPrevisto ? "Sim" : "Nao";
                            string artigoNaoPrevisto = !item.ArtigoPrevisto ? "Sim" : "Nao";

                            string precoUnitario = item.PrecoUnitario.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(",", ".");
                            decimal qtdPrevista = Convert.ToDecimal(item.QuantidadePrevista);
                            decimal qtdAdquirida = Convert.ToDecimal(item.QuantidadeAdquirida);
                            string quantidadePrevista = qtdPrevista.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
                            string quantidadeAdquirida = qtdAdquirida.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);

                            writer.WriteLine($"{compra.Nome};{dataCriacao};{dataFechada};{item.Artigo.Descricao};{artigoPrevisto};{precoUnitario};{artigoNaoPrevisto};{quantidadePrevista};{quantidadeAdquirida}");
                        }
                    }
                }

                MessageBox.Show($"Compras exportadas com sucesso para o ficheiro: {filePath}");
            }
        }
    }
}