﻿using System;
using System.Windows.Forms;
using WowGames.UI.CryptoVoucher;

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

        private void resgatarPINV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmProdutosRixty
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmCatalogoEpay()
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void consultaBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmSkuSearch(3)
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void relatórioComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new FrmComprasSintetico()
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void voucherToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new FrmVoucher()
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void listaDeJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPinupGames()
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void listaDeVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPinupVoucherList()
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void gameOrderInquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPinupOrderInquiry()
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void voucherInquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPinupVoucherInquiry()
            {
                MdiParent = this
            };
            frm.Show();

        }

        private void voucherBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPinupBalanceInquiry()
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void estoqueVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPinupVoucherStock()
            {
                MdiParent = this
            };
            frm.Show();

        }
    }
}
