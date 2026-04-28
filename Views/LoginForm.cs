using System;
using System.Linq;
using System.Windows.Forms;
using iShopping.Data;
using iShopping.Models;

namespace iShopping.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblErro.Visible = false;

            using (var context = new iShoppingContext())
            {
                var utilizador = context.Utilizadores
                    .FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);

                if (utilizador != null)
                {
                    var mainForm = new MainForm(utilizador);
                    mainForm.Show();
                    Hide();
                }
                else
                {
                    lblErro.Text = "Credenciais inválidas!";
                    lblErro.Visible = true;
                }
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            var registoForm = new RegistoForm();
            registoForm.Show();
        }
    }
}
