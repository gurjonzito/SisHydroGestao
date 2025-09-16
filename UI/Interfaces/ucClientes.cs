using System.Windows.Forms;

namespace UI
{
    public partial class ucClientes : UserControl
    {
        public ucClientes()
        {
            InitializeComponent();
            this.Margin = new Padding(0);
        }

        private void btnCadastrar_Click(object sender, System.EventArgs e)
        {
            var cadCliente = new frmCadCliente();
            cadCliente.Show();
        }
    }
}
