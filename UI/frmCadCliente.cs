using model;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCadCliente : Form
    {
        public frmCadCliente()
        {
            InitializeComponent();
        }

        private Cliente CriarCliente()
        {
            return new Cliente
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                CpfCnpj = txtCPFCNPJ.Text.Replace(".", "").Replace("-", ""),
                Telefone = txtTelefone.Text
            };
        }

        private void ValidarEntradaNumerica(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita apenas números", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEndereco.Clear();
            txtCPFCNPJ.Clear();
            txtTelefone.Clear();
            txtObservacoes.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var cliente = CriarCliente();

            //    string mensagem = _pacienteController.InserirPacienteComEndereco(cliente);
            //    MessageBox.Show(mensagem);

            //    if (mensagem.Contains("Paciente cadastrado com sucesso!"))
            //    {
            //        LimparCampos();
            //        txtNome.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
