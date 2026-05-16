using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class GestaoUtilizadoresForm : Form
    {
        // Controles
        private ListBox crudUserLista;
        private TextBox crudUserNome;
        private TextBox crudUserUsername;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button crudUserAdicionar;
        private Button crudUserApagar;
        private Button crudUserGuardar;
        private Label lbErro;
        private Label labelTitulo;
        private TextBox crudUserPassword;

        // Campo para guardar o ID do utilizador em edição
        private int? _utilizadorIdEmEdicao = null;

        public GestaoUtilizadoresForm()
        {
            Text = "Gestão de Utilizadores";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 600;
            Height = 400;
            InitializeComponent();
            CarregarUtilizadores();
        }

        private void InitializeComponent()
        {
            this.crudUserLista = new System.Windows.Forms.ListBox();
            this.crudUserNome = new System.Windows.Forms.TextBox();
            this.crudUserUsername = new System.Windows.Forms.TextBox();
            this.crudUserPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.crudUserAdicionar = new System.Windows.Forms.Button();
            this.crudUserApagar = new System.Windows.Forms.Button();
            this.crudUserGuardar = new System.Windows.Forms.Button();
            this.lbErro = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crudUserLista
            // 
            this.crudUserLista.FormattingEnabled = true;
            this.crudUserLista.Location = new System.Drawing.Point(12, 12);
            this.crudUserLista.Name = "crudUserLista";
            this.crudUserLista.Size = new System.Drawing.Size(333, 225);
            this.crudUserLista.TabIndex = 0;
            this.crudUserLista.SelectedIndexChanged += new System.EventHandler(this.onSelectUser);
            // 
            // crudUserNome
            // 
            this.crudUserNome.Location = new System.Drawing.Point(365, 65);
            this.crudUserNome.Name = "crudUserNome";
            this.crudUserNome.Size = new System.Drawing.Size(139, 20);
            this.crudUserNome.TabIndex = 1;
            // 
            // crudUserUsername
            // 
            this.crudUserUsername.Location = new System.Drawing.Point(365, 113);
            this.crudUserUsername.Name = "crudUserUsername";
            this.crudUserUsername.Size = new System.Drawing.Size(139, 20);
            this.crudUserUsername.TabIndex = 2;
            // 
            // crudUserPassword
            // 
            this.crudUserPassword.Location = new System.Drawing.Point(365, 161);
            this.crudUserPassword.Name = "crudUserPassword";
            this.crudUserPassword.Size = new System.Drawing.Size(139, 20);
            this.crudUserPassword.TabIndex = 3;
            this.crudUserPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // crudUserAdicionar
            // 
            this.crudUserAdicionar.Location = new System.Drawing.Point(12, 243);
            this.crudUserAdicionar.Name = "crudUserAdicionar";
            this.crudUserAdicionar.Size = new System.Drawing.Size(75, 23);
            this.crudUserAdicionar.TabIndex = 7;
            this.crudUserAdicionar.Text = "Novo";
            this.crudUserAdicionar.UseVisualStyleBackColor = true;
            this.crudUserAdicionar.Click += new System.EventHandler(this.crudUserAdicionar_Click);
            // 
            // crudUserApagar
            // 
            this.crudUserApagar.Location = new System.Drawing.Point(93, 243);
            this.crudUserApagar.Name = "crudUserApagar";
            this.crudUserApagar.Size = new System.Drawing.Size(75, 23);
            this.crudUserApagar.TabIndex = 9;
            this.crudUserApagar.Text = "Apagar";
            this.crudUserApagar.UseVisualStyleBackColor = true;
            this.crudUserApagar.Click += new System.EventHandler(this.crudUserApagar_Click);
            // 
            // crudUserGuardar
            // 
            this.crudUserGuardar.Location = new System.Drawing.Point(370, 214);
            this.crudUserGuardar.Name = "crudUserGuardar";
            this.crudUserGuardar.Size = new System.Drawing.Size(123, 23);
            this.crudUserGuardar.TabIndex = 10;
            this.crudUserGuardar.Text = "Guardar";
            this.crudUserGuardar.UseVisualStyleBackColor = true;
            this.crudUserGuardar.Click += new System.EventHandler(this.crudUserGuardar_Click);
            // 
            // lbErro
            // 
            this.lbErro.AutoSize = true;
            this.lbErro.ForeColor = System.Drawing.Color.Red;
            this.lbErro.Location = new System.Drawing.Point(367, 187);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 13);
            this.lbErro.TabIndex = 11;
            this.lbErro.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(367, 22);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(135, 13);
            this.labelTitulo.TabIndex = 12;
            this.labelTitulo.Text = "Gestão de Utilizadores";
            // 
            // GestaoUtilizadoresForm
            // 
            this.ClientSize = new System.Drawing.Size(540, 276);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.lbErro);
            this.Controls.Add(this.crudUserGuardar);
            this.Controls.Add(this.crudUserApagar);
            this.Controls.Add(this.crudUserAdicionar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crudUserPassword);
            this.Controls.Add(this.crudUserUsername);
            this.Controls.Add(this.crudUserNome);
            this.Controls.Add(this.crudUserLista);
            this.Name = "GestaoUtilizadoresForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Selecionar utilizador na ListBox
        private void onSelectUser(object sender, EventArgs e)
        {
            if (crudUserLista.SelectedIndex == -1) return;

            using (var context = new iShoppingContext())
            {
                var utilizadores = context.Utilizadores.ToList();
                var user = utilizadores[crudUserLista.SelectedIndex];
                _utilizadorIdEmEdicao = user.Id; // Guarda o ID para edição
                crudUserNome.Text = user.Nome;
                crudUserUsername.Text = user.Username;
                crudUserPassword.Text = user.Password;
                lbErro.Visible = false;
                labelTitulo.Text = "Editar utilizador";
            }
        }

        // Carregar utilizadores para a ListBox
        private void CarregarUtilizadores()
        {
            using (var context = new iShoppingContext())
            {
                var utilizadores = context.Utilizadores.ToList();
                crudUserLista.Items.Clear();
                foreach (var user in utilizadores)
                {
                    crudUserLista.Items.Add($"{user.Nome} ({user.Username})");
                }
            }
        }

        // Botão "Novo" - Limpa os campos
        private void crudUserAdicionar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            labelTitulo.Text = "Adicionar utilizador";
        }

        // Botão "Editar" - Preenche os campos com o utilizador selecionado
        private void crudUserEditar_Click(object sender, EventArgs e)
        {
            if (crudUserLista.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um utilizador para editar.";
                lbErro.Visible = true;
                return;
            }
        }

        private void crudUserApagar_Click(object sender, EventArgs e)
        {
            if (crudUserLista.SelectedIndex == -1)
            {
                lbErro.Text = "Selecione um utilizador para apagar.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                var utilizadores = context.Utilizadores.ToList();
                var user = utilizadores[crudUserLista.SelectedIndex];
                context.Utilizadores.Remove(user);
                context.SaveChanges();
                CarregarUtilizadores();
                LimparCampos();
            }
        }

        private void crudUserGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrEmpty(crudUserNome.Text))
            {
                lbErro.Text = "O nome é obrigatório.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(crudUserUsername.Text))
            {
                lbErro.Text = "O username é obrigatório.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(crudUserPassword.Text))
            {
                lbErro.Text = "A password é obrigatória.";
                lbErro.Visible = true;
                return;
            }

            using (var context = new iShoppingContext())
            {
                if (_utilizadorIdEmEdicao.HasValue)
                {
                    var utilizador = context.Utilizadores.Find(_utilizadorIdEmEdicao.Value);
                    utilizador.Nome = crudUserNome.Text;
                    utilizador.Username = crudUserUsername.Text;
                    utilizador.Password = crudUserPassword.Text;
                    context.SaveChanges();
                }
                else
                {
                    if (context.Utilizadores.Any(u => u.Username == crudUserUsername.Text))
                    {
                        lbErro.Text = "O username já está em uso.";
                        lbErro.Visible = true;
                        return;
                    }

                    var utilizador = new Utilizador
                    {
                        Nome = crudUserNome.Text,
                        Username = crudUserUsername.Text,
                        Password = crudUserPassword.Text,
                        DataRegisto = DateTime.Now
                    };

                    context.Utilizadores.Add(utilizador);
                    context.SaveChanges();
                    LimparCampos(); 
                }

                CarregarUtilizadores(); 
                lbErro.Visible = false;
            }
        }

        // Limpar campos
        private void LimparCampos()
        {
            crudUserNome.Clear();
            crudUserUsername.Clear();
            crudUserPassword.Clear();
            crudUserLista.ClearSelected();
            _utilizadorIdEmEdicao = null;   
            lbErro.Visible = false;
        }
    }
}