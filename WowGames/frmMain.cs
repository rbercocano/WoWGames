using System;
using System.Windows.Forms;

namespace WowGames
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void MnRixty_Click(object sender, EventArgs e)
        {
            var rixtyForm = new FrmRixty();
            rixtyForm.ShowDialog();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmRelCompras();
            frm.ShowDialog();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void extratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmBalance();
            frm.ShowDialog();

        }

        private void aquiPagaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAquiPaga();
            frm.ShowDialog();

        }
    }
}
