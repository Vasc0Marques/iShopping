using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class PlaneamentoCompraForm : Form
    {
        private TextBox txtNomeCompra;
        private ComboBox cbUtilizador;
        private Button btnGuardarCompra;
        private Label lbTituloCompra;
        private Label lbNomeCompra;
        private Label lbUtilizador;
        private Label lbErro;

        private ListView listViewItens;
        private ComboBox cbArtigo;
        private TextBox txtQuantidadePrevista;
        private TextBox txtPrecoEstimado;
        private TextBox txtObservacoes;
        private Button btnAdicionarItem;
        private Button btnApagarItem;
        private Button btnGuardarItem;
        private Label lbTituloItens;
        private Label lbArtigo;
        private Label lbQuantidade;
        private Label lbPreco;
        private Label lbObservacoes;

        private int? _compraIdEmEdicao = null;
        private int? _itemCompraIdEmEdicao = null;
        private bool _compraSelecionadaFechada = false;

        public PlaneamentoCompraForm(int? compraId = null)
        {
            Text = "Compra Planeada";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 980;
            Height = 560;
            InitializeComponent();
            CarregarUtilizadores();
            CarregarArtigos();

            if (compraId.HasValue)
            {
                CarregarCompra(compraId.Value);
                CarregarItensCompra(compraId.Value);
            }
            else
            {
                AtualizarEstadoEdicaoCompra();
            }
        }

        private void InitializeComponent()
        {
            this.txtNomeCompra = new System.Windows.Forms.TextBox();
            this.cbUtilizador = new System.Windows.Forms.ComboBox();
            this.btnGuardarCompra = new System.Windows.Forms.Button();
            this.lbTituloCompra = new System.Windows.Forms.Label();
            this.lbNomeCompra = new System.Windows.Forms.Label();
            this.lbUtilizador = new System.Windows.Forms.Label();
            this.lbErro = new System.Windows.Forms.Label();
            this.listViewItens = new System.Windows.Forms.ListView();
            this.cbArtigo = new System.Windows.Forms.ComboBox();
            this.txtQuantidadePrevista = new System.Windows.Forms.TextBox();
            this.txtPrecoEstimado = new System.Windows.Forms.TextBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnApagarItem = new System.Windows.Forms.Button();
            this.btnGuardarItem = new System.Windows.Forms.Button();
            this.lbTituloItens = new System.Windows.Forms.Label();
            this.lbArtigo = new System.Windows.Forms.Label();
            this.lbQuantidade = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.lbObservacoes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeCompra
            // 
            this.txtNomeCompra.Location = new System.Drawing.Point(16, 71);
            this.txtNomeCompra.Name = "txtNomeCompra";
            this.txtNomeCompra.Size = new System.Drawing.Size(334, 20);
            this.txtNomeCompra.TabIndex = 1;
            // 
            // cbUtilizador
            // 
            this.cbUtilizador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUtilizador.Location = new System.Drawing.Point(16, 121);
            this.cbUtilizador.Name = "cbUtilizador";
            this.cbUtilizador.Size = new System.Drawing.Size(220, 21);
            this.cbUtilizador.TabIndex = 2;
            // 
            // btnGuardarCompra
            // 
            this.btnGuardarCompra.Location = new System.Drawing.Point(16, 162);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCompra.TabIndex = 3;
            this.btnGuardarCompra.Text = "Guardar";
            this.btnGuardarCompra.Click += new System.EventHandler(this.btnGuardarCompra_Click);
            // 
            // lbTituloCompra
            // 
            this.lbTituloCompra.AutoSize = true;
            this.lbTituloCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTituloCompra.Location = new System.Drawing.Point(12, 9);
            this.lbTituloCompra.Name = "lbTituloCompra";
            this.lbTituloCompra.Size = new System.Drawing.Size(151, 20);
            this.lbTituloCompra.TabIndex = 4;
            this.lbTituloCompra.Text = "Compra Planeada";
            // 
            // lbNomeCompra
            // 
            this.lbNomeCompra.AutoSize = true;
            this.lbNomeCompra.Location = new System.Drawing.Point(13, 55);
            this.lbNomeCompra.Name = "lbNomeCompra";
            this.lbNomeCompra.Size = new System.Drawing.Size(38, 13);
            this.lbNomeCompra.TabIndex = 5;
            this.lbNomeCompra.Text = "Nome:";
            // 
            // lbUtilizador
            // 
            this.lbUtilizador.AutoSize = true;
            this.lbUtilizador.Location = new System.Drawing.Point(13, 105);
            this.lbUtilizador.Name = "lbUtilizador";
            this.lbUtilizador.Size = new System.Drawing.Size(53, 13);
            this.lbUtilizador.TabIndex = 6;
            this.lbUtilizador.Text = "Utilizador:";
            // 
            // lbErro
            // 
            this.lbErro.AutoSize = true;
            this.lbErro.ForeColor = System.Drawing.Color.Red;
            this.lbErro.Location = new System.Drawing.Point(13, 197);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 13);
            this.lbErro.TabIndex = 7;
            this.lbErro.Visible = false;
            // 
            // listViewItens
            // 
            this.listViewItens.FullRowSelect = true;
            this.listViewItens.HideSelection = false;
            this.listViewItens.Location = new System.Drawing.Point(382, 12);
            this.listViewItens.Name = "listViewItens";
            this.listViewItens.Size = new System.Drawing.Size(566, 495);
            this.listViewItens.TabIndex = 8;
            this.listViewItens.UseCompatibleStateImageBehavior = false;
            this.listViewItens.View = System.Windows.Forms.View.Details;
            this.listViewItens.SelectedIndexChanged += new System.EventHandler(this.listViewItens_SelectedIndexChanged);
            // 
            // cbArtigo
            // 
            this.cbArtigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArtigo.Location = new System.Drawing.Point(17, 257);
            this.cbArtigo.Name = "cbArtigo";
            this.cbArtigo.Size = new System.Drawing.Size(220, 21);
            this.cbArtigo.TabIndex = 9;
            // 
            // txtQuantidadePrevista
            // 
            this.txtQuantidadePrevista.Location = new System.Drawing.Point(17, 307);
            this.txtQuantidadePrevista.Name = "txtQuantidadePrevista";
            this.txtQuantidadePrevista.Size = new System.Drawing.Size(120, 20);
            this.txtQuantidadePrevista.TabIndex = 10;
            // 
            // txtPrecoEstimado
            // 
            this.txtPrecoEstimado.Location = new System.Drawing.Point(17, 357);
            this.txtPrecoEstimado.Name = "txtPrecoEstimado";
            this.txtPrecoEstimado.Size = new System.Drawing.Size(120, 20);
            this.txtPrecoEstimado.TabIndex = 11;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(17, 407);
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(333, 20);
            this.txtObservacoes.TabIndex = 12;
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Location = new System.Drawing.Point(382, 513);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(90, 23);
            this.btnAdicionarItem.TabIndex = 13;
            this.btnAdicionarItem.Text = "Adicionar Item";
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // btnApagarItem
            // 
            this.btnApagarItem.Location = new System.Drawing.Point(478, 513);
            this.btnApagarItem.Name = "btnApagarItem";
            this.btnApagarItem.Size = new System.Drawing.Size(90, 23);
            this.btnApagarItem.TabIndex = 14;
            this.btnApagarItem.Text = "Apagar Item";
            this.btnApagarItem.Click += new System.EventHandler(this.btnApagarItem_Click);
            // 
            // btnGuardarItem
            // 
            this.btnGuardarItem.Location = new System.Drawing.Point(17, 437);
            this.btnGuardarItem.Name = "btnGuardarItem";
            this.btnGuardarItem.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarItem.TabIndex = 15;
            this.btnGuardarItem.Text = "Guardar";
            this.btnGuardarItem.Click += new System.EventHandler(this.btnGuardarItem_Click);
            // 
            // lbTituloItens
            // 
            this.lbTituloItens.AutoSize = true;
            this.lbTituloItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbTituloItens.Location = new System.Drawing.Point(13, 215);
            this.lbTituloItens.Name = "lbTituloItens";
            this.lbTituloItens.Size = new System.Drawing.Size(114, 17);
            this.lbTituloItens.TabIndex = 16;
            this.lbTituloItens.Text = "Itens previstos";
            // 
            // lbArtigo
            // 
            this.lbArtigo.AutoSize = true;
            this.lbArtigo.Location = new System.Drawing.Point(14, 241);
            this.lbArtigo.Name = "lbArtigo";
            this.lbArtigo.Size = new System.Drawing.Size(37, 13);
            this.lbArtigo.TabIndex = 17;
            this.lbArtigo.Text = "Artigo:";
            // 
            // lbQuantidade
            // 
            this.lbQuantidade.AutoSize = true;
            this.lbQuantidade.Location = new System.Drawing.Point(14, 291);
            this.lbQuantidade.Name = "lbQuantidade";
            this.lbQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lbQuantidade.TabIndex = 18;
            this.lbQuantidade.Text = "Quantidade:";
            // 
            // lbPreco
            // 
            this.lbPreco.AutoSize = true;
            this.lbPreco.Location = new System.Drawing.Point(14, 341);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(83, 13);
            this.lbPreco.TabIndex = 19;
            this.lbPreco.Text = "Preco estimado:";
            // 
            // lbObservacoes
            // 
            this.lbObservacoes.AutoSize = true;
            this.lbObservacoes.Location = new System.Drawing.Point(14, 391);
            this.lbObservacoes.Name = "lbObservacoes";
            this.lbObservacoes.Size = new System.Drawing.Size(73, 13);
            this.lbObservacoes.TabIndex = 20;
            this.lbObservacoes.Text = "Observacoes:";
            // 
            // PlaneamentoCompraForm
            // 
            this.ClientSize = new System.Drawing.Size(960, 548);
            this.Controls.Add(this.txtNomeCompra);
            this.Controls.Add(this.cbUtilizador);
            this.Controls.Add(this.btnGuardarCompra);
            this.Controls.Add(this.lbTituloCompra);
            this.Controls.Add(this.lbNomeCompra);
            this.Controls.Add(this.lbUtilizador);
            this.Controls.Add(this.lbErro);
            this.Controls.Add(this.listViewItens);
            this.Controls.Add(this.cbArtigo);
            this.Controls.Add(this.txtQuantidadePrevista);
            this.Controls.Add(this.txtPrecoEstimado);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.btnApagarItem);
            this.Controls.Add(this.btnGuardarItem);
            this.Controls.Add(this.lbTituloItens);
            this.Controls.Add(this.lbArtigo);
            this.Controls.Add(this.lbQuantidade);
            this.Controls.Add(this.lbPreco);
            this.Controls.Add(this.lbObservacoes);
            this.Name = "PlaneamentoCompraForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CarregarUtilizadores()
        {
            using (var context = new iShoppingContext())
            {
                var utilizadores = context.Utilizadores.ToList();
                cbUtilizador.DataSource = utilizadores;
                cbUtilizador.DisplayMember = "Username";
                cbUtilizador.ValueMember = "Id";
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

        private void CarregarCompra(int compraId)
        {
            using (var context = new iShoppingContext())
            {
                var compra = context.Compras.Find(compraId);
                if (compra == null) return;

                _compraIdEmEdicao = compra.Id;
                _compraSelecionadaFechada = compra.DataFechada.HasValue;
                txtNomeCompra.Text = compra.Nome;
                cbUtilizador.SelectedValue = compra.IdUtilizadorCriacao;
                lbTituloCompra.Text = compra.DataFechada.HasValue ? "Compra Planeada (Fechada)" : "Editar Compra Planeada";
                AtualizarEstadoEdicaoCompra();
            }
        }

        private void CarregarItensCompra(int compraId)
        {
            using (var context = new iShoppingContext())
            {
                var itens = context.ItensCompra
                    .Where(i => i.IdCompra == compraId && i.ArtigoPrevisto)
                    .Select(i => new
                    {
                        i.Id,
                        Artigo = i.Artigo.Descricao,
                        i.QuantidadePrevista,
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
                    item.SubItems.Add(itemCompra.PrecoUnitario.ToString("0.00") + " EUR");
                    item.SubItems.Add(itemCompra.Observacoes ?? string.Empty);
                    item.Tag = itemCompra.Id;
                    listViewItens.Items.Add(item);
                }
            }
        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            if (_compraSelecionadaFechada)
            {
                lbErro.Text = "Esta compra esta fechada e nao pode ser editada.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomeCompra.Text))
            {
                lbErro.Text = "O nome da compra e obrigatorio.";
                lbErro.Visible = true;
                return;
            }

            if (cbUtilizador.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um utilizador.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                if (_compraIdEmEdicao.HasValue)
                {
                    var compra = context.Compras.Find(_compraIdEmEdicao.Value);
                    if (compra == null) return;

                    compra.Nome = txtNomeCompra.Text.Trim();
                    compra.IdUtilizadorCriacao = (int)cbUtilizador.SelectedValue;
                    context.SaveChanges();
                    MessageBox.Show("Compra planeada atualizada com sucesso!");
                }
                else
                {
                    var compra = new Compra
                    {
                        Nome = txtNomeCompra.Text.Trim(),
                        IdUtilizadorCriacao = (int)cbUtilizador.SelectedValue,
                        DataCriacao = DateTime.Now
                    };
                    context.Compras.Add(compra);
                    context.SaveChanges();
                    MessageBox.Show("Compra planeada criada com sucesso!");
                    _compraIdEmEdicao = compra.Id;
                    AtualizarEstadoEdicaoCompra();
                }
            }

            lbErro.Visible = false;
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
                    txtQuantidadePrevista.Text = itemCompra.QuantidadePrevista.ToString();
                    txtPrecoEstimado.Text = itemCompra.PrecoUnitario.ToString("0.00");
                    txtObservacoes.Text = itemCompra.Observacoes ?? string.Empty;
                    lbErro.Visible = false;
                }
            }
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (_compraSelecionadaFechada)
            {
                lbErro.Text = "Esta compra esta fechada e nao pode ser editada.";
                lbErro.Visible = true;
                return;
            }

            LimparCamposItem();
        }

        private void btnGuardarItem_Click(object sender, EventArgs e)
        {
            if (_compraSelecionadaFechada)
            {
                lbErro.Text = "Esta compra esta fechada e nao pode ser editada.";
                lbErro.Visible = true;
                return;
            }

            if (!_compraIdEmEdicao.HasValue)
            {
                lbErro.Text = "Guarde a compra antes de adicionar itens.";
                lbErro.Visible = true;
                return;
            }

            if (cbArtigo.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um artigo.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantidadePrevista.Text) ||
                !decimal.TryParse(txtQuantidadePrevista.Text, out decimal quantidade))
            {
                lbErro.Text = "A quantidade prevista deve ser um numero valido.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecoEstimado.Text) ||
                !decimal.TryParse(txtPrecoEstimado.Text, out decimal preco))
            {
                lbErro.Text = "O preco estimado deve ser um numero valido.";
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
                    itemCompra.QuantidadePrevista = quantidade;
                    itemCompra.PrecoUnitario = preco;
                    itemCompra.Observacoes = txtObservacoes.Text.Trim();
                    itemCompra.ArtigoPrevisto = true;
                    context.SaveChanges();
                    MessageBox.Show("Item atualizado com sucesso!");
                }
                else
                {
                    var itemCompra = new ItemCompra
                    {
                        IdCompra = _compraIdEmEdicao.Value,
                        IdArtigo = (int)cbArtigo.SelectedValue,
                        QuantidadePrevista = quantidade,
                        PrecoUnitario = preco,
                        Observacoes = txtObservacoes.Text.Trim(),
                        ArtigoPrevisto = true
                    };
                    context.ItensCompra.Add(itemCompra);
                    context.SaveChanges();
                    MessageBox.Show("Item adicionado com sucesso!");
                }
            }

            CarregarItensCompra(_compraIdEmEdicao.Value);
            LimparCamposItem();
            lbErro.Visible = false;
        }

        private void btnApagarItem_Click(object sender, EventArgs e)
        {
            if (_compraSelecionadaFechada)
            {
                lbErro.Text = "Esta compra esta fechada e nao pode ser editada.";
                lbErro.Visible = true;
                return;
            }

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

            if (_compraIdEmEdicao.HasValue)
            {
                CarregarItensCompra(_compraIdEmEdicao.Value);
            }

            LimparCamposItem();
        }

        private void LimparCamposItem()
        {
            if (cbArtigo.Items.Count > 0)
            {
                cbArtigo.SelectedIndex = 0;
            }
            txtQuantidadePrevista.Clear();
            txtPrecoEstimado.Clear();
            txtObservacoes.Clear();
            listViewItens.SelectedItems.Clear();
            _itemCompraIdEmEdicao = null;
            lbErro.Visible = false;
        }

        private void AtualizarEstadoEdicaoCompra()
        {
            bool podeEditar = !_compraSelecionadaFechada;
            txtNomeCompra.Enabled = podeEditar;
            cbUtilizador.Enabled = podeEditar;
            btnGuardarCompra.Enabled = podeEditar;

            cbArtigo.Enabled = podeEditar;
            txtQuantidadePrevista.Enabled = podeEditar;
            txtPrecoEstimado.Enabled = podeEditar;
            txtObservacoes.Enabled = podeEditar;
            btnAdicionarItem.Enabled = podeEditar;
            btnGuardarItem.Enabled = podeEditar;
            btnApagarItem.Enabled = podeEditar;
        }
    }
}
