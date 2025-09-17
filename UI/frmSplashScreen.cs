using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(3);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                new frmLogin().Show();
                this.Hide();
            }
        }
    }
}
