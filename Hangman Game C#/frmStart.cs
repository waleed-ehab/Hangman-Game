using System;
using System.Windows.Forms;

namespace Hangman_Game_C_
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmGame frm = new frmGame();
            this.Hide();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnStart_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }
    }
}
