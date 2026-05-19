using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class ModoCompraForm : Form
    {
        // Controles - compras abertas
        private ListView listViewCompras;
        private Button btnFecharCompra;
        private ComboBox cbUtilizadorFechou;
        private Label lbTituloCompra;
        private Label lbFechadoPor;

        // Controles - itens adquiridos
        private ListView listViewItens;
        private ComboBox cbArtigo;
        private TextBox txtQuantidadeAdquirida;
        private TextBox txtPrecoReal;
        private TextBox txtObservacoes;
        private Button btnAdicionarItem;
        private Button btnApagarItem;
        private Button btnGuardarItem;
        private Label lbTituloItens;
        private Label lbArtigo;
        private Label lbQuantidade;
        private Label lbPreco;
        private Label lbObservacoes;

        private Label lbErro;

        private int? _compraIdSelecionada = null;
        private int? _itemCompraIdEmEdicao = null;

        public ModoCompraForm()
        {
            Text = "Modo Compra";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 980;
            Height = 560;
            InitializeComponent();
            CarregarUtilizadores();
            CarregarArtigos();
            CarregarCompras();
        }

        private void InitializeComponent()
        {
            this.listViewCompras = new System.Windows.Forms.ListView();
            this.btnFecharCompra = new System.Windows.Forms.Button();
            this.cbUtilizadorFechou = new System.Windows.Forms.ComboBox();
            this.lbTituloCompra = new System.Windows.Forms.Label();
            this.lbFechadoPor = new System.Windows.Forms.Label();
            this.listViewItens = new System.Windows.Forms.ListView();
            this.cbArtigo = new System.Windows.Forms.ComboBox();
            this.txtQuantidadeAdquirida = new System.Windows.Forms.TextBox();
            this.txtPrecoReal = new System.Windows.Forms.TextBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnApagarItem = new System.Windows.Forms.Button();
            this.btnGuardarItem = new System.Windows.Forms.Button();
            this.lbTituloItens = new System.Windows.Forms.Label();
            this.lbArtigo = new System.Windows.Forms.Label();
            this.lbQuantidade = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.lbObservacoes = new System.Windows.Forms.Label();
            this.lbErro = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // listViewCompras
            this.listViewCompras.FullRowSelect = true;
            this.listViewCompras.HideSelection = false;
            this.listViewCompras.Location = new System.Drawing.Point(12, 12);
            this.listViewCompras.Name = "listViewCompras";
            this.listViewCompras.Size = new System.Drawing.Size(520, 220);
            this.listViewCompras.TabIndex = 0;
            this.listViewCompras.UseCompatibleStateImageBehavior = false;
            this.listViewCompras.View = System.Windows.Forms.View.Details;
            this.listViewCompras.SelectedIndexChanged += new System.EventHandler(this.listViewCompras_SelectedIndexChanged);
            this.listViewCompras.Columns.Add("Id", 50);
            this.listViewCompras.Columns.Add("Nome", 210);
            this.listViewCompras.Columns.Add("Data", 100);
            this.listViewCompras.Columns.Add("Utilizador", 140);

            // btnFecharCompra
            this.btnFecharCompra.Location = new System.Drawing.Point(560, 156);
            this.btnFecharCompra.Name = "btnFecharCompra";
            this.btnFecharCompra.Size = new System.Drawing.Size(120, 23);
            this.btnFecharCompra.TabIndex = 3;
            this.btnFecharCompra.Text = "Fechar Compra";
            this.btnFecharCompra.Click += new System.EventHandler(this.btnFecharCompra_Click);

            // cbUtilizadorFechou
            this.cbUtilizadorFechou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUtilizadorFechou.Location = new System.Drawing.Point(560, 114);
            this.cbUtilizadorFechou.Name = "cbUtilizadorFechou";
            this.cbUtilizadorFechou.Size = new System.Drawing.Size(220, 24);
            this.cbUtilizadorFechou.TabIndex = 2;

            // lbTituloCompra
            this.lbTituloCompra.AutoSize = true;
            this.lbTituloCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTituloCompra.Location = new System.Drawing.Point(556, 12);
            this.lbTituloCompra.Name = "lbTituloCompra";
            this.lbTituloCompra.Size = new System.Drawing.Size(116, 20);
            this.lbTituloCompra.TabIndex = 4;
            this.lbTituloCompra.Text = "Modo Compra";

            // lbFechadoPor
            this.lbFechadoPor.AutoSize = true;
            this.lbFechadoPor.Location = new System.Drawing.Point(557, 98);
            this.lbFechadoPor.Name = "lbFechadoPor";
            this.lbFechadoPor.Size = new System.Drawing.Size(84, 16);
            this.lbFechadoPor.TabIndex = 5;
            this.lbFechadoPor.Text = "Fechado por:";

            // listViewItens
            this.listViewItens.FullRowSelect = true;
            this.listViewItens.HideSelection = false;
            this.listViewItens.Location = new System.Drawing.Point(12, 288);
            this.listViewItens.Name = "listViewItens";
            this.listViewItens.Size = new System.Drawing.Size(520, 220);
            this.listViewItens.TabIndex = 6;
            this.listViewItens.UseCompatibleStateImageBehavior = false;
            this.listViewItens.View = System.Windows.Forms.View.Details;
            this.listViewItens.SelectedIndexChanged += new System.EventHandler(this.listViewItens_SelectedIndexChanged);
            this.listViewItens.Columns.Add("Id", 50);
            this.listViewItens.Columns.Add("Artigo", 150);
            this.listViewItens.Columns.Add("Qtd. Prev.", 70);
            this.listViewItens.Columns.Add("Qtd. Real", 70);
            this.listViewItens.Columns.Add("Preco", 80);
            this.listViewItens.Columns.Add("Obs.", 90);

            // cbArtigo
            this.cbArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArtigo.Location = new System.Drawing.Point(560, 330);
            this.cbArtigo.Name = "cbArtigo";
            this.cbArtigo.Size = new System.Drawing.Size(220, 24);
            this.cbArtigo.TabIndex = 7;

            // txtQuantidadeAdquirida
            this.txtQuantidadeAdquirida.Location = new System.Drawing.Point(560, 380);
            this.txtQuantidadeAdquirida.Name = "txtQuantidadeAdquirida";
            this.txtQuantidadeAdquirida.Size = new System.Drawing.Size(120, 22);
            this.txtQuantidadeAdquirida.TabIndex = 8;

            // txtPrecoReal
            this.txtPrecoReal.Location = new System.Drawing.Point(560, 430);
            this.txtPrecoReal.Name = "txtPrecoReal";
            this.txtPrecoReal.Size = new System.Drawing.Size(120, 22);
            this.txtPrecoReal.TabIndex = 9;

            // txtObservacoes
            this.txtObservacoes.Location = new System.Drawing.Point(560, 480);
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(380, 22);
            this.txtObservacoes.TabIndex = 10;

            // btnAdicionarItem
            this.btnAdicionarItem.Location = new System.Drawing.Point(12, 514);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(90, 23);
            this.btnAdicionarItem.TabIndex = 11;
            this.btnAdicionarItem.Text = "Adicionar Item";
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);

            // btnApagarItem
            this.btnApagarItem.Location = new System.Drawing.Point(108, 514);
            this.btnApagarItem.Name = "btnApagarItem";
            this.btnApagarItem.Size = new System.Drawing.Size(90, 23);
            this.btnApagarItem.TabIndex = 12;
            this.btnApagarItem.Text = "Apagar Item";
            this.btnApagarItem.Click += new System.EventHandler(this.btnApagarItem_Click);

            // btnGuardarItem
            this.btnGuardarItem.Location = new System.Drawing.Point(560, 510);
            this.btnGuardarItem.Name = "btnGuardarItem";
            this.btnGuardarItem.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarItem.TabIndex = 13;
            this.btnGuardarItem.Text = "Guardar";
            this.btnGuardarItem.Click += new System.EventHandler(this.btnGuardarItem_Click);

            // lbTituloItens
            this.lbTituloItens.AutoSize = true;
            this.lbTituloItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbTituloItens.Location = new System.Drawing.Point(556, 288);
            this.lbTituloItens.Name = "lbTituloItens";
            this.lbTituloItens.Size = new System.Drawing.Size(110, 17);
            this.lbTituloItens.TabIndex = 14;
            this.lbTituloItens.Text = "Itens reais";

            // lbArtigo
            this.lbArtigo.AutoSize = true;
            this.lbArtigo.Location = new System.Drawing.Point(557, 314);
            this.lbArtigo.Name = "lbArtigo";
            this.lbArtigo.Size = new System.Drawing.Size(43, 16);
            this.lbArtigo.TabIndex = 15;
            this.lbArtigo.Text = "Artigo:";

            // lbQuantidade
            this.lbQuantidade.AutoSize = true;
            this.lbQuantidade.Location = new System.Drawing.Point(557, 364);
            this.lbQuantidade.Name = "lbQuantidade";
            this.lbQuantidade.Size = new System.Drawing.Size(112, 16);
            this.lbQuantidade.TabIndex = 16;
            this.lbQuantidade.Text = "Quantidade real:";

            // lbPreco
            this.lbPreco.AutoSize = true;
            this.lbPreco.Location = new System.Drawing.Point(557, 414);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(70, 16);
            this.lbPreco.TabIndex = 17;
            this.lbPreco.Text = "Preco real:";

            // lbObservacoes
            this.lbObservacoes.AutoSize = true;
            this.lbObservacoes.Location = new System.Drawing.Point(557, 464);
            this.lbObservacoes.Name = "lbObservacoes";
            this.lbObservacoes.Size = new System.Drawing.Size(85, 16);
            this.lbObservacoes.TabIndex = 18;
            this.lbObservacoes.Text = "Observacoes:";

            // lbErro
            this.lbErro.AutoSize = true;
            this.lbErro.ForeColor = System.Drawing.Color.Red;
            this.lbErro.Location = new System.Drawing.Point(557, 50);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 16);
            this.lbErro.TabIndex = 19;
            this.lbErro.Visible = false;

            // ModoCompraForm
            this.ClientSize = new System.Drawing.Size(960, 548);
            this.Controls.Add(this.listViewCompras);
            this.Controls.Add(this.btnFecharCompra);
            this.Controls.Add(this.cbUtilizadorFechou);
            this.Controls.Add(this.lbTituloCompra);
            this.Controls.Add(this.lbFechadoPor);
            this.Controls.Add(this.listViewItens);
            this.Controls.Add(this.cbArtigo);
            this.Controls.Add(this.txtQuantidadeAdquirida);
            this.Controls.Add(this.txtPrecoReal);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.btnApagarItem);
            this.Controls.Add(this.btnGuardarItem);
            this.Controls.Add(this.lbTituloItens);
            this.Controls.Add(this.lbArtigo);
            this.Controls.Add(this.lbQuantidade);
            this.Controls.Add(this.lbPreco);
            this.Controls.Add(this.lbObservacoes);
            this.Controls.Add(this.lbErro);
            this.Name = "ModoCompraForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CarregarUtilizadores()
        {
            using (var context = new iShoppingContext())
            {
                var utilizadores = context.Utilizadores.ToList();
                cbUtilizadorFechou.DataSource = utilizadores;
                cbUtilizadorFechou.DisplayMember = "Username";
                cbUtilizadorFechou.ValueMember = "Id";
            }
        }

        private void CarregarArtigos()
        {
            using (var context = new iShoppingContext())
            {
                var artigos = context.Artigos.OrderBy(a => a.Descricao).ToList();
                cbArtigo.DataSource = artigos;
                cbArtigo.DisplayMember = "Descricao";
                cbArtigo.ValueMember = "Id";
            }
        }

        private void CarregarCompras()
        {
            using (var context = new iShoppingContext())
            {
                var compras = context.Compras
                    .Where(c => c.DataFechada == null)
                    .Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        c.DataCriacao,
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
                    item.Tag = compra.Id;
                    listViewCompras.Items.Add(item);
                }
            }
        }

        private void CarregarItensCompra(int compraId)
        {
            using (var context = new iShoppingContext())
            {
                var itens = context.ItensCompra
                    .Where(i => i.IdCompra == compraId)
                    .Select(i => new
                    {
                        i.Id,
                        Artigo = i.Artigo.Descricao,
                        i.QuantidadePrevista,
                        i.QuantidadeAdquirida,
                        i.PrecoUnitario,
                        i.Observacoes
                    })
                    .ToList();

                listViewItens.Items.Clear();
                foreach (var itemCompra in itens)
                {
                    var item = new ListViewItem(itemCompra.Id.ToString());
                    item.SubItems.Add(itemCompra.Artigo);
                    item.SubItems.Add(itemCompra.QuantidadePrevista.ToString("0.##"));
                    item.SubItems.Add(itemCompra.QuantidadeAdquirida?.ToString("0.##") ?? "0");
                    item.SubItems.Add(itemCompra.PrecoUnitario.ToString("0.00") + " EUR");
                    item.SubItems.Add(itemCompra.Observacoes ?? string.Empty);
                    item.Tag = itemCompra.Id;
                    listViewItens.Items.Add(item);
                }
            }
        }

        private void listViewCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCompras.SelectedItems.Count == 0)
            {
                LimparCamposCompra();
                listViewItens.Items.Clear();
                return;
            }

            var selectedItem = listViewCompras.SelectedItems[0];
            var id = (int)selectedItem.Tag;
            _compraIdSelecionada = id;
            lbErro.Visible = false;
            CarregarItensCompra(id);
        }

        private void listViewItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItens.SelectedItems.Count == 0)
            {
                LimparCamposItem();
                return;
            }

            var selectedItem = listViewItens.SelectedItems[0];
            var id = (int)selectedItem.Tag;

            using (var context = new iShoppingContext())
            {
                var itemCompra = context.ItensCompra.Find(id);
                if (itemCompra != null)
                {
                    _itemCompraIdEmEdicao = itemCompra.Id;
                    cbArtigo.SelectedValue = itemCompra.IdArtigo;
                    txtQuantidadeAdquirida.Text = itemCompra.QuantidadeAdquirida?.ToString() ?? "0";
                    txtPrecoReal.Text = itemCompra.PrecoUnitario.ToString("0.00");
                    txtObservacoes.Text = itemCompra.Observacoes ?? string.Empty;
                    lbErro.Visible = false;
                }
            }
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            LimparCamposItem();
        }

        private void btnGuardarItem_Click(object sender, EventArgs e)
        {
            if (!_compraIdSelecionada.HasValue)
            {
                lbErro.Text = "Selecione uma compra primeiro.";
                lbErro.Visible = true;
                return;
            }

            if (cbArtigo.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um artigo.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantidadeAdquirida.Text) ||
                !decimal.TryParse(txtQuantidadeAdquirida.Text, out decimal quantidade))
            {
                lbErro.Text = "A quantidade real deve ser um numero valido.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecoReal.Text) ||
                !decimal.TryParse(txtPrecoReal.Text, out decimal preco))
            {
                lbErro.Text = "O preco real deve ser um numero valido.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                if (_itemCompraIdEmEdicao.HasValue)
                {
                    var itemCompra = context.ItensCompra.Find(_itemCompraIdEmEdicao.Value);
                    if (itemCompra == null) return;

                    itemCompra.IdArtigo = (int)cbArtigo.SelectedValue;
                    itemCompra.QuantidadeAdquirida = quantidade;
                    itemCompra.PrecoUnitario = preco;
                    itemCompra.Observacoes = txtObservacoes.Text.Trim();
                    context.SaveChanges();
                    MessageBox.Show("Item atualizado com sucesso!");
                }
                else
                {
                    var itemCompra = new ItemCompra
                    {
                        IdCompra = _compraIdSelecionada.Value,
                        IdArtigo = (int)cbArtigo.SelectedValue,
                        QuantidadePrevista = 0m,
                        QuantidadeAdquirida = quantidade,
                        PrecoUnitario = preco,
                        Observacoes = txtObservacoes.Text.Trim(),
                        ArtigoPrevisto = false
                    };
                    context.ItensCompra.Add(itemCompra);
                    context.SaveChanges();
                    MessageBox.Show("Item adicionado com sucesso!");
                }
            }

            CarregarItensCompra(_compraIdSelecionada.Value);
            LimparCamposItem();
            lbErro.Visible = false;
        }

        private void btnApagarItem_Click(object sender, EventArgs e)
        {
            if (listViewItens.SelectedItems.Count == 0)
            {
                lbErro.Text = "Selecione um item para apagar.";
                lbErro.Visible = true;
                return;
            }

            if (MessageBox.Show("Tem a certeza que quer apagar este item?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            var selectedItem = listViewItens.SelectedItems[0];
            var id = (int)selectedItem.Tag;

            using (var context = new iShoppingContext())
            {
                var itemCompra = context.ItensCompra.Find(id);
                if (itemCompra != null)
                {
                    context.ItensCompra.Remove(itemCompra);
                    context.SaveChanges();
                    MessageBox.Show("Item apagado com sucesso!");
                }
            }

            if (_compraIdSelecionada.HasValue)
            {
                CarregarItensCompra(_compraIdSelecionada.Value);
            }

            LimparCamposItem();
        }

        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            if (!_compraIdSelecionada.HasValue)
            {
                lbErro.Text = "Selecione uma compra para fechar.";
                lbErro.Visible = true;
                return;
            }

            if (cbUtilizadorFechou.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione o utilizador que fechou a compra.";
                lbErro.Visible = true;
                return;
            }

            if (MessageBox.Show("Tem a certeza que quer fechar esta compra?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            using (var context = new iShoppingContext())
            {
                var compra = context.Compras.Find(_compraIdSelecionada.Value);
                if (compra != null)
                {
                    compra.DataFechada = DateTime.Now;
                    compra.IdUtilizadorFechou = (int)cbUtilizadorFechou.SelectedValue;
                    context.SaveChanges();
                    MessageBox.Show("Compra fechada com sucesso!");
                }
            }

            CarregarCompras();
            listViewItens.Items.Clear();
            LimparCamposCompra();
            LimparCamposItem();
        }

        private void LimparCamposCompra()
        {
            listViewCompras.SelectedItems.Clear();
            _compraIdSelecionada = null;
            lbErro.Visible = false;
        }

        private void LimparCamposItem()
        {
            if (cbArtigo.Items.Count > 0)
            {
                cbArtigo.SelectedIndex = 0;
            }
            txtQuantidadeAdquirida.Clear();
            txtPrecoReal.Clear();
            txtObservacoes.Clear();
            listViewItens.SelectedItems.Clear();
            _itemCompraIdEmEdicao = null;
            lbErro.Visible = false;
        }
    }
}
