using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Interfaces;

namespace UI
{
    public partial class frmMainPage : Form
    {
        private ucClientes ucClientes;
        private ucHome ucHome;

        public frmMainPage()
        {
            InitializeComponent();
            AtualizaDataHora();
            MenuBotoes();
        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {
            DefinirPaineis();
            IniciarHome();
        }

        private void MenuBotoes()
        {
            btnHome.FlatAppearance.BorderSize = 0;
            btnCliente.FlatAppearance.BorderSize = 0;
            btnServico.FlatAppearance.BorderSize = 0;
            btnPecas.FlatAppearance.BorderSize = 0;
            btnCadUser.FlatAppearance.BorderSize = 0;
            btnContas.FlatAppearance.BorderSize = 0;
            btnRelatorios.FlatAppearance.BorderSize = 0;
            btnSair.FlatAppearance.BorderSize = 0;

            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnCliente.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnServico.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnPecas.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnCadUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnContas.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnRelatorios.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
            btnSair.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 58, 79);
        }

        public void AtualizaDataHora()
        {
            lblData.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("pt-BR"));

            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AtualizaDataHora();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (ucClientes == null)
                ucClientes = new ucClientes();

            AbrirUserControl(ucClientes);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente encerrar o programa?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DefinirPaineis()
        {
            // Topo
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 30;

            // Rodapé
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 75;

            // Menu lateral
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 200;

            // Main ocupa o que sobrar
            pnlMain.Dock = DockStyle.Fill;

            // Ordem correta de adição
            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlMenu);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlTop);
        }

        private void AbrirUserControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Margin = new Padding(0);
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void IniciarHome()
        {
            if (ucHome == null)
                ucHome = new ucHome();

            AbrirUserControl(ucHome);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AbrirUserControl(ucHome);
        }
    }
}
