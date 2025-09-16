using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //string usernameNull = txtUsuario.Text;
            //string senhaNull = txtSenha.Text;

            //if (string.IsNullOrWhiteSpace(usernameNull) || usernameNull.Contains(" ") || usernameNull.Any(char.IsUpper))
            //{
            //    MessageBox.Show("Digite um email válido e tente novamente.");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(senhaNull) || senhaNull.Contains(" "))
            //{
            //    MessageBox.Show("Digite uma senha válida e tente novamente.");
            //    return;
            //}

            //string username = txtUsuario.Text.Trim();
            //string senha = txtSenha.Text.Trim();

            //// Validar o username
            //string validarUser = loginBLL.ValidarUser(username);

            //if (validarUser == "Email incorreto")
            //{
            //    MessageBox.Show("Usuário incorreto.");
            //    return;
            //}

            //// Validar a senha
            //string validarSenha = loginBLL.ValidarSenha(senha);

            //if (validarSenha == "Senha incorreta")
            //{
            //    MessageBox.Show("Senha incorreta.");
            //    return;
            //}

            //MessageBox.Show("Sucesso ao entrar!");

            //int userChamado = loginBLL.ObterTipoUsuario(username);
            //Program.UserChamado = userChamado;
            //Program.User = username;

            var telaPrincipal = new frmMainPage();
            telaPrincipal.Closed += (s, args) => this.Close();
            telaPrincipal.Show();
        }
    }
}
