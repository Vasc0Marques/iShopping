using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class GestaoOrcamentosForm : Form
    {
        // Controles principais
        private ListView listView;
        private TextBox crudOrcamentoValorInput;
        private ComboBox crudOrcamentoMesInput;
        private TextBox crudOrcamentoAnoInput;
        private ComboBox crudOrcamentoUtilizadorInput;
        private Button crudOrcamentoAdiocionar;
        private Button crudOrcamentoApagar;
        private Button crudOrcamentoGuardar;
        private Label lbTitulo;
        private Label lbValor;
        private Label lbMes;
        private Label lbAno;
        private Label lbUtilizador;
        private Label lbErro;

        // Controles de filtro
        private ComboBox cbFiltroUtilizador;
        private ComboBox cbFiltroMes;
        private ComboBox cbFiltroAno;
        private Button btnFiltrar;

        // Array com os nomes dos meses (índice 0 = Janeiro, 1 = Fevereiro, etc.)
        private readonly string[] _meses = {
            "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
            "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
        };

        private int? _orcamentoIdEmEdicao = null;

        public GestaoOrcamentosForm()
        {
            Text = "Gestão de Orçamentos";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 800;
            Height = 350;
            InitializeComponent();
            CarregarUtilizadores();
            CarregarMeses();
            CarregarFiltros();
            CarregarOrcamentos();
        }

        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.crudOrcamentoValorInput = new System.Windows.Forms.TextBox();
            this.crudOrcamentoMesInput = new System.Windows.Forms.ComboBox();
            this.crudOrcamentoAnoInput = new System.Windows.Forms.TextBox();
            this.crudOrcamentoUtilizadorInput = new System.Windows.Forms.ComboBox();
            this.crudOrcamentoAdiocionar = new System.Windows.Forms.Button();
            this.crudOrcamentoApagar = new System.Windows.Forms.Button();
            this.crudOrcamentoGuardar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.lbMes = new System.Windows.Forms.Label();
            this.lbAno = new System.Windows.Forms.Label();
            this.lbUtilizador = new System.Windows.Forms.Label();
            this.lbErro = new System.Windows.Forms.Label();
            this.cbFiltroUtilizador = new System.Windows.Forms.ComboBox();
            this.cbFiltroMes = new System.Windows.Forms.ComboBox();
            this.cbFiltroAno = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 44);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(500, 250);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // crudOrcamentoValorInput
            // 
            this.crudOrcamentoValorInput.Location = new System.Drawing.Point(551, 76);
            this.crudOrcamentoValorInput.Name = "crudOrcamentoValorInput";
            this.crudOrcamentoValorInput.Size = new System.Drawing.Size(200, 22);
            this.crudOrcamentoValorInput.TabIndex = 1;
            // 
            // crudOrcamentoMesInput
            // 
            this.crudOrcamentoMesInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crudOrcamentoMesInput.Location = new System.Drawing.Point(551, 126);
            this.crudOrcamentoMesInput.Name = "crudOrcamentoMesInput";
            this.crudOrcamentoMesInput.Size = new System.Drawing.Size(200, 24);
            this.crudOrcamentoMesInput.TabIndex = 2;
            this.crudOrcamentoMesInput.SelectedIndexChanged += new System.EventHandler(this.crudOrcamentoMesInput_SelectedIndexChanged);
            // 
            // crudOrcamentoAnoInput
            // 
            this.crudOrcamentoAnoInput.Location = new System.Drawing.Point(551, 176);
            this.crudOrcamentoAnoInput.Name = "crudOrcamentoAnoInput";
            this.crudOrcamentoAnoInput.Size = new System.Drawing.Size(200, 22);
            this.crudOrcamentoAnoInput.TabIndex = 3;
            // 
            // crudOrcamentoUtilizadorInput
            // 
            this.crudOrcamentoUtilizadorInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crudOrcamentoUtilizadorInput.Location = new System.Drawing.Point(551, 226);
            this.crudOrcamentoUtilizadorInput.Name = "crudOrcamentoUtilizadorInput";
            this.crudOrcamentoUtilizadorInput.Size = new System.Drawing.Size(200, 24);
            this.crudOrcamentoUtilizadorInput.TabIndex = 4;
            // 
            // crudOrcamentoAdiocionar
            // 
            this.crudOrcamentoAdiocionar.Location = new System.Drawing.Point(12, 300);
            this.crudOrcamentoAdiocionar.Name = "crudOrcamentoAdiocionar";
            this.crudOrcamentoAdiocionar.Size = new System.Drawing.Size(75, 23);
            this.crudOrcamentoAdiocionar.TabIndex = 5;
            this.crudOrcamentoAdiocionar.Text = "Adicionar";
            this.crudOrcamentoAdiocionar.Click += new System.EventHandler(this.crudOrcamentoNovo_Click);
            // 
            // crudOrcamentoApagar
            // 
            this.crudOrcamentoApagar.Location = new System.Drawing.Point(109, 300);
            this.crudOrcamentoApagar.Name = "crudOrcamentoApagar";
            this.crudOrcamentoApagar.Size = new System.Drawing.Size(75, 23);
            this.crudOrcamentoApagar.TabIndex = 6;
            this.crudOrcamentoApagar.Text = "Apagar";
            this.crudOrcamentoApagar.Click += new System.EventHandler(this.crudOrcamentoApagar_Click);
            // 
            // crudOrcamentoGuardar
            // 
            this.crudOrcamentoGuardar.Location = new System.Drawing.Point(611, 271);
            this.crudOrcamentoGuardar.Name = "crudOrcamentoGuardar";
            this.crudOrcamentoGuardar.Size = new System.Drawing.Size(75, 23);
            this.crudOrcamentoGuardar.TabIndex = 7;
            this.crudOrcamentoGuardar.Text = "Guardar";
            this.crudOrcamentoGuardar.Click += new System.EventHandler(this.crudOrcamentoGuardar_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.Location = new System.Drawing.Point(550, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(195, 20);
            this.lbTitulo.TabIndex = 8;
            this.lbTitulo.Text = "Gestão de Orçamentos";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(551, 60);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(42, 16);
            this.lbValor.TabIndex = 9;
            this.lbValor.Text = "Valor:";
            // 
            // lbMes
            // 
            this.lbMes.AutoSize = true;
            this.lbMes.Location = new System.Drawing.Point(551, 110);
            this.lbMes.Name = "lbMes";
            this.lbMes.Size = new System.Drawing.Size(36, 16);
            this.lbMes.TabIndex = 10;
            this.lbMes.Text = "Mês:";
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Location = new System.Drawing.Point(551, 160);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(34, 16);
            this.lbAno.TabIndex = 11;
            this.lbAno.Text = "Ano:";
            // 
            // lbUtilizador
            // 
            this.lbUtilizador.AutoSize = true;
            this.lbUtilizador.Location = new System.Drawing.Point(551, 210);
            this.lbUtilizador.Name = "lbUtilizador";
            this.lbUtilizador.Size = new System.Drawing.Size(66, 16);
            this.lbUtilizador.TabIndex = 12;
            this.lbUtilizador.Text = "Utilizador:";
            // 
            // lbErro
            // 
            this.lbErro.AutoSize = true;
            this.lbErro.Location = new System.Drawing.Point(551, 246);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 16);
            this.lbErro.TabIndex = 13;
            this.lbErro.Visible = false;
            // 
            // cbFiltroUtilizador
            // 
            this.cbFiltroUtilizador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroUtilizador.Location = new System.Drawing.Point(12, 12);
            this.cbFiltroUtilizador.Name = "cbFiltroUtilizador";
            this.cbFiltroUtilizador.Size = new System.Drawing.Size(150, 24);
            this.cbFiltroUtilizador.TabIndex = 8;
            // 
            // cbFiltroMes
            // 
            this.cbFiltroMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroMes.Location = new System.Drawing.Point(170, 12);
            this.cbFiltroMes.Name = "cbFiltroMes";
            this.cbFiltroMes.Size = new System.Drawing.Size(100, 24);
            this.cbFiltroMes.TabIndex = 9;
            // 
            // cbFiltroAno
            // 
            this.cbFiltroAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroAno.Location = new System.Drawing.Point(280, 12);
            this.cbFiltroAno.Name = "cbFiltroAno";
            this.cbFiltroAno.Size = new System.Drawing.Size(100, 24);
            this.cbFiltroAno.TabIndex = 10;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(390, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            //
            //colunas
            //
            listView.Columns.Add("Id", 50);
            listView.Columns.Add("Valor", 100);
            listView.Columns.Add("Mês", 100);
            listView.Columns.Add("Ano", 60);
            listView.Columns.Add("Utilizador", 120);
            // 
            // GestaoOrcamentosForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.crudOrcamentoValorInput);
            this.Controls.Add(this.crudOrcamentoMesInput);
            this.Controls.Add(this.crudOrcamentoAnoInput);
            this.Controls.Add(this.crudOrcamentoUtilizadorInput);
            this.Controls.Add(this.crudOrcamentoAdiocionar);
            this.Controls.Add(this.crudOrcamentoApagar);
            this.Controls.Add(this.crudOrcamentoGuardar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.lbMes);
            this.Controls.Add(this.lbAno);
            this.Controls.Add(this.lbUtilizador);
            this.Controls.Add(this.lbErro);
            this.Controls.Add(this.cbFiltroUtilizador);
            this.Controls.Add(this.cbFiltroMes);
            this.Controls.Add(this.cbFiltroAno);
            this.Controls.Add(this.btnFiltrar);
            this.Name = "GestaoOrcamentosForm";
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        private void CarregarUtilizadores()
        {
            using (var context = new iShoppingContext())
            {
                var utilizadores = context.Utilizadores.ToList();
                crudOrcamentoUtilizadorInput.DataSource = utilizadores;
                crudOrcamentoUtilizadorInput.DisplayMember = "Username";
                crudOrcamentoUtilizadorInput.ValueMember = "Id";
            }
        }

        private void CarregarMeses()
        {
            crudOrcamentoMesInput.Items.AddRange(_meses);
            crudOrcamentoMesInput.SelectedIndex = 0; // Seleciona "Janeiro" por defeito
        }

        private void CarregarFiltros()
        {
            using (var context = new iShoppingContext())
            {
                // Utilizadores (para filtro)
                var utilizadores = context.Utilizadores.ToList();
                var utilizadorTodos = new Utilizador { Id = -1, Username = "Todos" };
                var utilizadoresComTodos = new System.Collections.Generic.List<Utilizador> { utilizadorTodos };
                utilizadoresComTodos.AddRange(utilizadores);
                cbFiltroUtilizador.DataSource = utilizadoresComTodos;
                cbFiltroUtilizador.DisplayMember = "Username";
                cbFiltroUtilizador.ValueMember = "Id";
                cbFiltroUtilizador.SelectedIndex = 0;

                // Meses (para filtro, com nomes)
                var mesesFiltro = new System.Collections.Generic.List<string> { "Todos" };
                mesesFiltro.AddRange(_meses);
                cbFiltroMes.DataSource = mesesFiltro;
                cbFiltroMes.SelectedIndex = 0;

                // Anos (dinâmico)
                var anos = context.Orcamentos.Select(o => o.Ano).Distinct().OrderBy(a => a).ToList();
                var anosComTodos = new System.Collections.Generic.List<string> { "Todos" };
                foreach (var ano in anos) anosComTodos.Add(ano.ToString());
                cbFiltroAno.DataSource = anosComTodos;
                cbFiltroAno.SelectedIndex = 0;
            }
        }

        private void CarregarOrcamentos()
        {
            CarregarOrcamentosFiltrados(null, null, null);
        }

        private void CarregarOrcamentosFiltrados(int? utilizadorId, int? mes, int? ano)
        {
            using (var context = new iShoppingContext())
            {
                var query = context.Orcamentos.AsQueryable();

                if (utilizadorId.HasValue && utilizadorId.Value != -1)
                    query = query.Where(o => o.IdUtilizadorCriacao == utilizadorId.Value);
                if (mes.HasValue && mes.Value != -1)
                    query = query.Where(o => o.Mes == mes.Value);
                if (ano.HasValue && ano.Value != -1)
                    query = query.Where(o => o.Ano == ano.Value);

                var orcamentos = query
                    .Select(o => new
                    {
                        o.Id,
                        o.Valor,
                        o.Mes,
                        o.Ano,
                        Utilizador = o.UtilizadorCriacao.Username
                    })
                    .ToList();

                listView.Items.Clear();
                foreach (var orcamento in orcamentos)
                {
                    var item = new ListViewItem(orcamento.Id.ToString());
                    item.SubItems.Add(orcamento.Valor.ToString("0.00") + " €");
                    item.SubItems.Add(_meses[orcamento.Mes - 1]); // Converter número (1-12) para nome
                    item.SubItems.Add(orcamento.Ano.ToString());
                    item.SubItems.Add(orcamento.Utilizador);
                    item.Tag = orcamento.Id;
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
                var orcamento = context.Orcamentos.Find(id);
                if (orcamento != null)
                {
                    _orcamentoIdEmEdicao = orcamento.Id;
                    crudOrcamentoValorInput.Text = orcamento.Valor.ToString();
                    crudOrcamentoMesInput.SelectedIndex = orcamento.Mes - 1; // Converter número (1-12) para índice (0-11)
                    crudOrcamentoAnoInput.Text = orcamento.Ano.ToString();
                    crudOrcamentoUtilizadorInput.SelectedValue = orcamento.IdUtilizadorCriacao;
                    lbErro.Visible = false;
                    lbTitulo.Text = "Editar Orçamento";
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int? utilizadorId = (cbFiltroUtilizador.SelectedIndex > 0) ? (int)cbFiltroUtilizador.SelectedValue : (int?)null;
            int? mes = (cbFiltroMes.SelectedIndex > 0) ? Array.IndexOf(_meses, cbFiltroMes.Text) + 1 : (int?)null; // Converter nome para número (1-12)
            int? ano = (cbFiltroAno.SelectedIndex > 0) ? int.Parse(cbFiltroAno.Text) : (int?)null;

            CarregarOrcamentosFiltrados(utilizadorId, mes, ano);
        }

        private void crudOrcamentoNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            lbTitulo.Text = "Adicionar Orçamento";
        }

        private void crudOrcamentoGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(crudOrcamentoValorInput.Text))
            {
                lbErro.Text = "O valor é obrigatório.";
                lbErro.Visible = true;
                return;
            }

            if (!decimal.TryParse(crudOrcamentoValorInput.Text, out decimal valor))
            {
                lbErro.Text = "O valor deve ser um número válido.";
                lbErro.Visible = true;
                return;
            }

            if (crudOrcamentoMesInput.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um mês.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(crudOrcamentoAnoInput.Text) || !int.TryParse(crudOrcamentoAnoInput.Text, out int ano))
            {
                lbErro.Text = "O ano deve ser um número válido.";
                lbErro.Visible = true;
                return;
            }

            if (crudOrcamentoUtilizadorInput.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um utilizador.";
                lbErro.Visible = true;
                return;
            }

            int mesNumerico = crudOrcamentoMesInput.SelectedIndex + 1; // Converter índice (0-11) para número (1-12)

            using (var context = new iShoppingContext())
            {
                if (_orcamentoIdEmEdicao.HasValue)
                {
                    var orcamento = context.Orcamentos.Find(_orcamentoIdEmEdicao.Value);
                    orcamento.Valor = valor;
                    orcamento.Mes = mesNumerico;
                    orcamento.Ano = ano;
                    orcamento.IdUtilizadorCriacao = (int)crudOrcamentoUtilizadorInput.SelectedValue;
                    context.SaveChanges();
                    MessageBox.Show("Orçamento atualizado com sucesso!");
                }
                else
                {
                    if (context.Orcamentos.Any(o => o.Mes == mesNumerico && o.Ano == ano && o.IdUtilizadorCriacao == (int)crudOrcamentoUtilizadorInput.SelectedValue))
                    {
                        lbErro.Text = "Já existe um orçamento para este mês e utilizador.";
                        lbErro.Visible = true;
                        return;
                    }

                    var orcamento = new Orcamento
                    {
                        Valor = valor,
                        Mes = mesNumerico,
                        Ano = ano,
                        IdUtilizadorCriacao = (int)crudOrcamentoUtilizadorInput.SelectedValue,
                        DataCriacao = DateTime.Now
                    };
                    context.Orcamentos.Add(orcamento);
                    context.SaveChanges();
                    MessageBox.Show("Orçamento criado com sucesso!");
                    LimparCampos();
                }
                // Atualiza a lista com os filtros atuais
                int? filtroUtilizadorId = (cbFiltroUtilizador.SelectedIndex > 0) ? (int?)cbFiltroUtilizador.SelectedValue : null;
                int? filtroMes = (cbFiltroMes.SelectedIndex > 0) ? Array.IndexOf(_meses, cbFiltroMes.Text) + 1 : (int?)null;
                int? filtroAno = (cbFiltroAno.SelectedIndex > 0) ? int.Parse(cbFiltroAno.Text) : (int?)null;
                CarregarOrcamentosFiltrados(filtroUtilizadorId, filtroMes, filtroAno);
                lbErro.Visible = false;
            }
        }

        private void crudOrcamentoApagar_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                lbErro.Text = "Selecione um orçamento para apagar.";
                lbErro.Visible = true;
                return;
            }

            if (MessageBox.Show("Tem a certeza que quer apagar este orçamento?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            var selectedItem = listView.SelectedItems[0];
            var id = (int)selectedItem.Tag;

            using (var context = new iShoppingContext())
            {
                var orcamento = context.Orcamentos.Find(id);
                if (orcamento != null)
                {
                    context.Orcamentos.Remove(orcamento);
                    context.SaveChanges();
                    // Atualiza a lista com os filtros atuais
                    int? filtroUtilizadorId = (cbFiltroUtilizador.SelectedIndex > 0) ? (int?)cbFiltroUtilizador.SelectedValue : null;
                    int? filtroMes = (cbFiltroMes.SelectedIndex > 0) ? Array.IndexOf(_meses, cbFiltroMes.Text) + 1 : (int?)null;
                    int? filtroAno = (cbFiltroAno.SelectedIndex > 0) ? int.Parse(cbFiltroAno.Text) : (int?)null;
                    CarregarOrcamentosFiltrados(filtroUtilizadorId, filtroMes, filtroAno);
                    LimparCampos();
                    MessageBox.Show("Orçamento apagado com sucesso!");
                }
            }
        }

        private void LimparCampos()
        {
            crudOrcamentoValorInput.Clear();
            crudOrcamentoMesInput.SelectedIndex = 0;
            crudOrcamentoAnoInput.Clear();
            listView.SelectedItems.Clear();
            _orcamentoIdEmEdicao = null;
            lbErro.Visible = false;
        }

        private void crudOrcamentoMesInput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}