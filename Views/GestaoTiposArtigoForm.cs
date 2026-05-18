using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class GestaoTiposArtigoForm : Form
    {
        // Controles
        private ListBox crudTArtigoLista;
        private Button crudTArtigoNovo;
        private Button crudTArtigoEliminar;
        private Button crudTArtigoGuardar;
        private TextBox crudTArtigoDescricao;
        private Label crudTArtigoTitulo;
        private Label label1;
        private Label lbErro;

        // Campo para guardar o ID do tipo de artigo em edição
        private int? _tipoArtigoIdEmEdicao = null;

        public GestaoTiposArtigoForm()
        {
            Text = "Gestão de Tipos de Artigo";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 600;
            Height = 400;
            InitializeComponent();
            CarregarTiposArtigo();
        }

        private void InitializeComponent()
        {
            this.crudTArtigoLista = new System.Windows.Forms.ListBox();
            this.crudTArtigoNovo = new System.Windows.Forms.Button();
            this.crudTArtigoEliminar = new System.Windows.Forms.Button();
            this.crudTArtigoGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.crudTArtigoDescricao = new System.Windows.Forms.TextBox();
            this.crudTArtigoTitulo = new System.Windows.Forms.Label();
            this.lbErro = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // crudTArtigoLista
            this.crudTArtigoLista.FormattingEnabled = true;
            this.crudTArtigoLista.Location = new System.Drawing.Point(12, 12);
            this.crudTArtigoLista.Name = "crudTArtigoLista";
            this.crudTArtigoLista.Size = new System.Drawing.Size(316, 225);
            this.crudTArtigoLista.TabIndex = 0;
            this.crudTArtigoLista.SelectedIndexChanged += new System.EventHandler(this.onSelectTipoArtigo);

            // crudTArtigoNovo
            this.crudTArtigoNovo.Location = new System.Drawing.Point(12, 254);
            this.crudTArtigoNovo.Name = "crudTArtigoNovo";
            this.crudTArtigoNovo.Size = new System.Drawing.Size(75, 23);
            this.crudTArtigoNovo.TabIndex = 1;
            this.crudTArtigoNovo.Text = "Novo";
            this.crudTArtigoNovo.UseVisualStyleBackColor = true;
            this.crudTArtigoNovo.Click += new System.EventHandler(this.crudTArtigoNovo_Click);

            // crudTArtigoEliminar
            this.crudTArtigoEliminar.Location = new System.Drawing.Point(105, 254);
            this.crudTArtigoEliminar.Name = "crudTArtigoEliminar";
            this.crudTArtigoEliminar.Size = new System.Drawing.Size(75, 23);
            this.crudTArtigoEliminar.TabIndex = 2;
            this.crudTArtigoEliminar.Text = "Eliminar";
            this.crudTArtigoEliminar.UseVisualStyleBackColor = true;
            this.crudTArtigoEliminar.Click += new System.EventHandler(this.crudTArtigoEliminar_Click);

            // crudTArtigoGuardar
            this.crudTArtigoGuardar.Location = new System.Drawing.Point(381, 214);
            this.crudTArtigoGuardar.Name = "crudTArtigoGuardar";
            this.crudTArtigoGuardar.Size = new System.Drawing.Size(75, 23);
            this.crudTArtigoGuardar.TabIndex = 3;
            this.crudTArtigoGuardar.Text = "Guardar";
            this.crudTArtigoGuardar.UseVisualStyleBackColor = true;
            this.crudTArtigoGuardar.Click += new System.EventHandler(this.crudTArtigoGuardar_Click);

            // label1 (Descrição)
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descrição";

            // crudTArtigoDescricao
            this.crudTArtigoDescricao.Location = new System.Drawing.Point(344, 76);
            this.crudTArtigoDescricao.Name = "crudTArtigoDescricao";
            this.crudTArtigoDescricao.Size = new System.Drawing.Size(153, 20);
            this.crudTArtigoDescricao.TabIndex = 5;

            // crudTArtigoTitulo
            this.crudTArtigoTitulo.AutoSize = true;
            this.crudTArtigoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.crudTArtigoTitulo.Location = new System.Drawing.Point(341, 22);
            this.crudTArtigoTitulo.Name = "crudTArtigoTitulo";
            this.crudTArtigoTitulo.Size = new System.Drawing.Size(161, 13);
            this.crudTArtigoTitulo.TabIndex = 6;
            this.crudTArtigoTitulo.Text = "Gestão de Tipos de Artigos";

            // lbErro
            this.lbErro.AutoSize = true;
            this.lbErro.ForeColor = System.Drawing.Color.Red;
            this.lbErro.Location = new System.Drawing.Point(344, 110);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 13);
            this.lbErro.TabIndex = 7;
            this.lbErro.Visible = false;

            // GestaoTiposArtigoForm
            this.ClientSize = new System.Drawing.Size(509, 289);
            this.Controls.Add(this.lbErro);
            this.Controls.Add(this.crudTArtigoTitulo);
            this.Controls.Add(this.crudTArtigoDescricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crudTArtigoGuardar);
            this.Controls.Add(this.crudTArtigoEliminar);
            this.Controls.Add(this.crudTArtigoNovo);
            this.Controls.Add(this.crudTArtigoLista);
            this.Name = "GestaoTiposArtigoForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Selecionar tipo de artigo na ListBox
        private void onSelectTipoArtigo(object sender, EventArgs e)
        {
            if (crudTArtigoLista.SelectedIndex == -1) return;

            using (var context = new iShoppingContext())
            {
                var tiposArtigo = context.TiposArtigo.ToList();
                var tipoArtigo = tiposArtigo[crudTArtigoLista.SelectedIndex];
                _tipoArtigoIdEmEdicao = tipoArtigo.Id; // Guarda o ID para edição
                crudTArtigoDescricao.Text = tipoArtigo.Descricao;
                lbErro.Visible = false;
                crudTArtigoTitulo.Text = "Editar Tipo de Artigo";
            }
        }

        // Carregar tipos de artigo para a ListBox
        private void CarregarTiposArtigo()
        {
            using (var context = new iShoppingContext())
            {
                var tiposArtigo = context.TiposArtigo.ToList();
                crudTArtigoLista.Items.Clear();
                foreach (var tipo in tiposArtigo)
                {
                    crudTArtigoLista.Items.Add(tipo.Descricao);
                }
            }
        }

        // Botão "Novo" - Limpa os campos
        private void crudTArtigoNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            crudTArtigoTitulo.Text = "Adicionar Tipo de Artigo";
        }

        // Botão "Eliminar" - Remove o tipo de artigo selecionado
        private void crudTArtigoEliminar_Click(object sender, EventArgs e)
        {
            if (crudTArtigoLista.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um tipo de artigo para eliminar.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                var tiposArtigo = context.TiposArtigo.ToList();
                var tipoArtigo = tiposArtigo[crudTArtigoLista.SelectedIndex];
                context.TiposArtigo.Remove(tipoArtigo);
                context.SaveChanges();
                CarregarTiposArtigo();
                LimparCampos();
            }
        }

        // Botão "Guardar" - Cria ou edita o tipo de artigo
        private void crudTArtigoGuardar_Click(object sender, EventArgs e)
        {
            // Validar campo
            if (string.IsNullOrEmpty(crudTArtigoDescricao.Text))
            {
                lbErro.Text = "A descrição é obrigatória.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                if (_tipoArtigoIdEmEdicao.HasValue)
                {
                    // --- MODO EDIÇÃO: Atualizar tipo de artigo existente ---
                    var tipoArtigo = context.TiposArtigo.Find(_tipoArtigoIdEmEdicao.Value);
                    tipoArtigo.Descricao = crudTArtigoDescricao.Text;
                    context.SaveChanges();
                }
                else
                {
                    // --- MODO CRIAÇÃO: Verificar se a descrição já existe ---
                    if (context.TiposArtigo.Any(t => t.Descricao == crudTArtigoDescricao.Text))
                    {
                        lbErro.Text = "Esta descrição já está em uso.";
                        lbErro.Visible = true;
                        return;
                    }

                    // Criar novo tipo de artigo
                    var tipoArtigo = new TipoArtigo
                    {
                        Descricao = crudTArtigoDescricao.Text
                    };

                    context.TiposArtigo.Add(tipoArtigo);
                    context.SaveChanges();
                    LimparCampos(); // Limpa os campos após criar
                }

                CarregarTiposArtigo(); // Atualiza a lista
                lbErro.Visible = false;
            }
        }

        // Limpar campos
        private void LimparCampos()
        {
            crudTArtigoDescricao.Clear();
            crudTArtigoLista.ClearSelected();
            _tipoArtigoIdEmEdicao = null; // Reseta para modo criação
            lbErro.Visible = false;
        }
    }
}