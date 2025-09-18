using BLL;
using model;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCadCliente : Form
    {
        private ClienteBLL clienteBLL = new ClienteBLL();

        public frmCadCliente()
        {
            InitializeComponent();
        }

        private void CriarCliente()
        {
            Cliente cliente = new Cliente
            {
                Nome = txtNome.Text.Trim(),
                CpfCnpj = txtCPFCNPJ.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Rua = txtRua.Text.Trim(),
                Numero = int.TryParse(txtNumero.Text, out int n) ? n : 0,
                Bairro = txtBairro.Text.Trim(),
                Cidade = txtCidade.Text.Trim(),
                estado = (Cliente.Estado)cbEstado.SelectedItem,
                Observacoes = txtObservacoes.Text.Trim()
            };

            string retorno = clienteBLL.CadastrarCliente(cliente);

            if (retorno == "Sucesso")
            {
                MessageBox.Show("Cliente cadastrado com sucesso!");
                LimparCampos();
            }
            else
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LimparCampos();
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
            txtCPFCNPJ.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            cbEstado.SelectedItem = -1;
            txtObservacoes.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CriarCliente();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
