using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class GestaoArtigosForm : Form
    {
        private ListView listView;
        private TextBox crudArtigoNomeInput;
        private ComboBox crudArtigoTipoInput;
        private TextBox crudArtigoPrecoInput;
        private Button crudArtigoAdicionar;
        private Button crudArtigoApagar;
        private Button crudArtigoGuardar;
        private Label lbTitulo;
        private Label lbNome;
        private Label lbTipo;
        private Label lbPreco;
        private Label lbErro;

        private int? _artigoIdEmEdicao = null;

        public GestaoArtigosForm()
        {
            Text = "Gestão de Artigos";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 800;
            Height = 362;
            InitializeComponent();
            CarregarTiposArtigo();
            CarregarArtigos();
        }

        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.crudArtigoNomeInput = new System.Windows.Forms.TextBox();
            this.crudArtigoTipoInput = new System.Windows.Forms.ComboBox();
            this.crudArtigoPrecoInput = new System.Windows.Forms.TextBox();
            this.crudArtigoAdicionar = new System.Windows.Forms.Button();
            this.crudArtigoApagar = new System.Windows.Forms.Button();
            this.crudArtigoGuardar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.lbErro = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // listView
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(532, 300);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);

            // Adicionar colunas ao ListView
            this.listView.Columns.Add("ID", 50);
            this.listView.Columns.Add("Descrição", 200);
            this.listView.Columns.Add("Tipo", 150);
            this.listView.Columns.Add("Preço Médio", 100);

            // crudArtigoNomeInput
            this.crudArtigoNomeInput.Location = new System.Drawing.Point(550, 50);
            this.crudArtigoNomeInput.Name = "crudArtigoNomeInput";
            this.crudArtigoNomeInput.Size = new System.Drawing.Size(200, 22);
            this.crudArtigoNomeInput.TabIndex = 1;

            // crudArtigoTipoInput
            this.crudArtigoTipoInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crudArtigoTipoInput.Location = new System.Drawing.Point(550, 100);
            this.crudArtigoTipoInput.Name = "crudArtigoTipoInput";
            this.crudArtigoTipoInput.Size = new System.Drawing.Size(200, 24);
            this.crudArtigoTipoInput.TabIndex = 2;

            // crudArtigoPrecoInput
            this.crudArtigoPrecoInput.Location = new System.Drawing.Point(550, 150);
            this.crudArtigoPrecoInput.Name = "crudArtigoPrecoInput";
            this.crudArtigoPrecoInput.Size = new System.Drawing.Size(200, 22);
            this.crudArtigoPrecoInput.TabIndex = 3;

            // crudArtigoAdicionar (ANTIGO: crudArtigoNovo)
            this.crudArtigoAdicionar.Location = new System.Drawing.Point(12, 318);
            this.crudArtigoAdicionar.Name = "crudArtigoAdicionar";
            this.crudArtigoAdicionar.Size = new System.Drawing.Size(75, 23);
            this.crudArtigoAdicionar.TabIndex = 4;
            this.crudArtigoAdicionar.Text = "Adicionar";
            this.crudArtigoAdicionar.Click += new System.EventHandler(this.crudArtigoAdicionar_Click);

            // crudArtigoApagar
            this.crudArtigoApagar.Location = new System.Drawing.Point(93, 318);
            this.crudArtigoApagar.Name = "crudArtigoApagar";
            this.crudArtigoApagar.Size = new System.Drawing.Size(75, 23);
            this.crudArtigoApagar.TabIndex = 5;
            this.crudArtigoApagar.Text = "Apagar";
            this.crudArtigoApagar.Click += new System.EventHandler(this.crudArtigoApagar_Click);

            // crudArtigoGuardar
            this.crudArtigoGuardar.Location = new System.Drawing.Point(550, 199);
            this.crudArtigoGuardar.Name = "crudArtigoGuardar";
            this.crudArtigoGuardar.Size = new System.Drawing.Size(75, 23);
            this.crudArtigoGuardar.TabIndex = 6;
            this.crudArtigoGuardar.Text = "Guardar";
            this.crudArtigoGuardar.Click += new System.EventHandler(this.crudArtigoGuardar_Click);

            // lbTitulo
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.Location = new System.Drawing.Point(550, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(155, 20);
            this.lbTitulo.TabIndex = 7;
            this.lbTitulo.Text = "Gestão de Artigos";

            // lbNome
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(550, 34);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(47, 16);
            this.lbNome.TabIndex = 8;
            this.lbNome.Text = "Nome:";

            // lbTipo
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(550, 84);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(38, 16);
            this.lbTipo.TabIndex = 9;
            this.lbTipo.Text = "Tipo:";

            // lbPreco
            this.lbPreco.AutoSize = true;
            this.lbPreco.Location = new System.Drawing.Point(550, 134);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(46, 16);
            this.lbPreco.TabIndex = 10;
            this.lbPreco.Text = "Preço:";

            // lbErro
            this.lbErro.AutoSize = true;
            this.lbErro.Location = new System.Drawing.Point(550, 180);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 16);
            this.lbErro.TabIndex = 11;
            this.lbErro.Visible = false;

            // Adicionar controles ao formulário
            this.Controls.Add(this.listView);
            this.Controls.Add(this.crudArtigoNomeInput);
            this.Controls.Add(this.crudArtigoTipoInput);
            this.Controls.Add(this.crudArtigoPrecoInput);
            this.Controls.Add(this.crudArtigoAdicionar);
            this.Controls.Add(this.crudArtigoApagar);
            this.Controls.Add(this.crudArtigoGuardar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.lbPreco);
            this.Controls.Add(this.lbErro);

            this.ClientSize = new System.Drawing.Size(800, 362);
            this.Name = "GestaoArtigosForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CarregarTiposArtigo()
        {
            using (var context = new iShoppingContext())
            {
                var tipos = context.TiposArtigo.ToList();
                crudArtigoTipoInput.DataSource = tipos;
                crudArtigoTipoInput.DisplayMember = "Descricao";
                crudArtigoTipoInput.ValueMember = "Id";
            }
        }

        private void CarregarArtigos()
        {
            using (var context = new iShoppingContext())
            {
                var artigos = context.Artigos
                    .Select(a => new
                    {
                        a.Id,
                        a.Descricao,
                        Tipo = a.TipoArtigo.Descricao,
                        a.PrecoMedio
                    })
                    .ToList();

                listView.Items.Clear();
                foreach (var artigo in artigos)
                {
                    var item = new ListViewItem(artigo.Id.ToString());
                    item.SubItems.Add(artigo.Descricao);
                    item.SubItems.Add(artigo.Tipo);
                    item.SubItems.Add(artigo.PrecoMedio.ToString("0.00") + " €");
                    item.Tag = artigo.Id;
                    listView.Items.Add(item);
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                LimparCampos();
                return;
            }

            var selectedItem = listView.SelectedItems[0];
            var id = (int)selectedItem.Tag;

            using (var context = new iShoppingContext())
            {
                var artigo = context.Artigos.Find(id);
                if (artigo != null)
                {
                    _artigoIdEmEdicao = artigo.Id;
                    crudArtigoNomeInput.Text = artigo.Descricao;
                    crudArtigoTipoInput.SelectedValue = artigo.IdTipoArtigo;
                    crudArtigoPrecoInput.Text = artigo.PrecoMedio.ToString();
                    lbErro.Visible = false;
                    lbTitulo.Text = "Editar Artigo";
                }
            }
        }

        private void crudArtigoAdicionar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            lbTitulo.Text = "Adicionar Artigo";
        }

        private void crudArtigoGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(crudArtigoNomeInput.Text))
            {
                lbErro.Text = "O nome é obrigatório.";
                lbErro.Visible = true;
                return;
            }

            if (crudArtigoTipoInput.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um tipo de artigo.";
                lbErro.Visible = true;
                return;
            }

            if (!decimal.TryParse(crudArtigoPrecoInput.Text, out decimal preco))
            {
                lbErro.Text = "O preço deve ser um número válido.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                if (_artigoIdEmEdicao.HasValue)
                {
                    var artigo = context.Artigos.Find(_artigoIdEmEdicao.Value);
                    artigo.Descricao = crudArtigoNomeInput.Text;
                    artigo.IdTipoArtigo = (int)crudArtigoTipoInput.SelectedValue;
                    artigo.PrecoMedio = preco;
                    context.SaveChanges();
                }
                else
                {
                    if (context.Artigos.Any(a => a.Descricao == crudArtigoNomeInput.Text))
                    {
                        lbErro.Text = "Já existe um artigo com esta descrição.";
                        lbErro.Visible = true;
                        return;
                    }

                    var artigo = new Artigo
                    {
                        Descricao = crudArtigoNomeInput.Text,
                        IdTipoArtigo = (int)crudArtigoTipoInput.SelectedValue,
                        PrecoMedio = preco
                    };
                    context.Artigos.Add(artigo);
                    context.SaveChanges();
                    LimparCampos();
                }
                CarregarArtigos();
                lbErro.Visible = false;
            }
        }

        private void crudArtigoApagar_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                lbErro.Text = "Selecione um artigo para apagar.";
                lbErro.Visible = true;
                return;
            }

            if (MessageBox.Show("Tem a certeza que quer apagar este artigo?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            var selectedItem = listView.SelectedItems[0];
            var id = (int)selectedItem.Tag;

            using (var context = new iShoppingContext())
            {
                var artigo = context.Artigos.Find(id);
                if (artigo != null)
                {
                    context.Artigos.Remove(artigo);
                    context.SaveChanges();
                    CarregarArtigos();
                    LimparCampos();
                    MessageBox.Show("Artigo apagado com sucesso!");
                }
            }
        }

        private void LimparCampos()
        {
            crudArtigoNomeInput.Clear();
            crudArtigoPrecoInput.Clear();
            listView.SelectedItems.Clear();
            _artigoIdEmEdicao = null;
            lbErro.Visible = false;
        }
    }
}