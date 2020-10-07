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
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmRelCompras
            {
                MdiParent = this
            };
            frm.Show();

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
            var frm = new FrmBalance
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void aquiPagaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAquiPaga
            {
                MdiParent = this
            };
            frm.Show();

        }


        private void resgatarPINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmRixtyPinRecovery
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new FrmSkuSearch(1)
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void sKUToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new FrmSku    
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void ePayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new FrmSkuSearch(3)
            {
                MdiParent = this
            };
            frm.Show();

        }
    }
}
