using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public class RegistoForm : Form
    {
        private TextBox txtNome;
        private TextBox txtPassword;
        private Button btnRegistarUser;
        private Label lbNome;
        private Label lbUsername;
        private Label lbPassword;
        private Button btnCancelarRegisto;
        private Label lbErro;
        private TextBox txtUsername;

        public RegistoForm()
        {
            InitializeComponent();
            Text = "Registo";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 500;
            Height = 300;
        }

        private void InitializeComponent()
        {
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnRegistarUser = new System.Windows.Forms.Button();
            this.lbNome = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnCancelarRegisto = new System.Windows.Forms.Button();
            this.lbErro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(25, 28);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(176, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(25, 119);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(176, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(25, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(176, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // btnRegistarUser
            // 
            this.btnRegistarUser.Location = new System.Drawing.Point(118, 186);
            this.btnRegistarUser.Name = "btnRegistarUser";
            this.btnRegistarUser.Size = new System.Drawing.Size(83, 21);
            this.btnRegistarUser.TabIndex = 5;
            this.btnRegistarUser.Text = "Registar";
            this.btnRegistarUser.UseVisualStyleBackColor = true;
            this.btnRegistarUser.Click += new System.EventHandler(this.btnRegistarUser_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(22, 9);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(35, 13);
            this.lbNome.TabIndex = 6;
            this.lbNome.Text = "Nome";
            this.lbNome.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(22, 60);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(55, 13);
            this.lbUsername.TabIndex = 7;
            this.lbUsername.Text = "Username";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(22, 103);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Password";
            // 
            // btnCancelarRegisto
            // 
            this.btnCancelarRegisto.Location = new System.Drawing.Point(25, 186);
            this.btnCancelarRegisto.Name = "btnCancelarRegisto";
            this.btnCancelarRegisto.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarRegisto.TabIndex = 9;
            this.btnCancelarRegisto.Text = "Cancelar";
            this.btnCancelarRegisto.UseVisualStyleBackColor = true;
            this.btnCancelarRegisto.Click += new System.EventHandler(this.btnCancelarRegisto_Click);
            // 
            // lbErro
            // 
            this.lbErro.AutoSize = true;
            this.lbErro.ForeColor = System.Drawing.Color.Red;
            this.lbErro.Location = new System.Drawing.Point(42, 158);
            this.lbErro.Name = "lbErro";
            this.lbErro.Size = new System.Drawing.Size(0, 13);
            this.lbErro.TabIndex = 10;
            this.lbErro.Visible = false;
            // 
            // RegistoForm
            // 
            this.ClientSize = new System.Drawing.Size(226, 221);
            this.Controls.Add(this.lbErro);
            this.Controls.Add(this.btnCancelarRegisto);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.btnRegistarUser);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNome);
            this.Name = "RegistoForm";
            this.Load += new System.EventHandler(this.RegistoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void RegistoForm_Load(object sender, System.EventArgs e)
        {

        }

        private void btnRegistarUser_Click(object sender, System.EventArgs e)
        {
            // Limpar mensagens anteriores
            lbErro.Visible = false;

            // Validar campos
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lbErro.Text = "O nome é obrigatório.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                lbErro.Text = "O username é obrigatório.";
                lbErro.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lbErro.Text = "A password é obrigatória.";
                lbErro.Visible = true;
                return;
            }

            // Verificar se o username já existe
            using (var context = new iShoppingContext())
            {
                if (context.Utilizadores.Any(u => u.Username == txtUsername.Text))
                {
                    lbErro.Text = "O username já está em uso.";
                    lbErro.Visible = true;
                    return;
                }

                // Criar novo utilizador
                var utilizador = new Utilizador
                {
                    Nome = txtNome.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    DataRegisto = DateTime.Now
                };

                // Guardar na base de dados
                context.Utilizadores.Add(utilizador);
                context.SaveChanges();



                // Limpar campos
                txtNome.Clear();
                txtUsername.Clear();
                txtPassword.Clear();

                this.Close();
            }
        }

        private void btnCancelarRegisto_Click(object sender, EventArgs e)
        {
            //close registo form
            this.Close();
        }
    }
}
