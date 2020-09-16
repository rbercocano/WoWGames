namespace WowGames
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.partnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnRixty = new System.Windows.Forms.ToolStripMenuItem();
            this.aquiPagaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resgatarPINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partnerToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // partnerToolStripMenuItem
            // 
            this.partnerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnRixty,
            this.aquiPagaToolStripMenuItem});
            this.partnerToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.partnerToolStripMenuItem.Name = "partnerToolStripMenuItem";
            this.partnerToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.partnerToolStripMenuItem.Text = "Partner";
            // 
            // MnRixty
            // 
            this.MnRixty.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraToolStripMenuItem,
            this.resgatarPINToolStripMenuItem});
            this.MnRixty.Name = "MnRixty";
            this.MnRixty.Size = new System.Drawing.Size(224, 28);
            this.MnRixty.Text = "Rixty";
            this.MnRixty.Click += new System.EventHandler(this.MnRixty_Click);
            // 
            // aquiPagaToolStripMenuItem
            // 
            this.aquiPagaToolStripMenuItem.Name = "aquiPagaToolStripMenuItem";
            this.aquiPagaToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.aquiPagaToolStripMenuItem.Text = "Aqui Paga";
            this.aquiPagaToolStripMenuItem.Click += new System.EventHandler(this.aquiPagaToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem,
            this.extratoToolStripMenuItem});
            this.consultasToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(106, 28);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // extratoToolStripMenuItem
            // 
            this.extratoToolStripMenuItem.Name = "extratoToolStripMenuItem";
            this.extratoToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.extratoToolStripMenuItem.Text = "Extrato";
            this.extratoToolStripMenuItem.Click += new System.EventHandler(this.extratoToolStripMenuItem_Click);
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.compraToolStripMenuItem.Text = "Compra";
            this.compraToolStripMenuItem.Click += new System.EventHandler(this.compraToolStripMenuItem_Click);
            // 
            // resgatarPINToolStripMenuItem
            // 
            this.resgatarPINToolStripMenuItem.Name = "resgatarPINToolStripMenuItem";
            this.resgatarPINToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.resgatarPINToolStripMenuItem.Text = "Resgatar PIN";
            this.resgatarPINToolStripMenuItem.Click += new System.EventHandler(this.resgatarPINToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WoW Games";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem partnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnRixty;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extratoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aquiPagaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resgatarPINToolStripMenuItem;
    }
}