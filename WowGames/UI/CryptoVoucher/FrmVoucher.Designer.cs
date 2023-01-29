namespace WowGames.UI.CryptoVoucher
{
    partial class FrmVoucher
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
            this.btnCriar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnResgatar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Balance = new System.Windows.Forms.TabPage();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgSaldo = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgVoucher = new System.Windows.Forms.DataGridView();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDate2 = new System.Windows.Forms.TextBox();
            this.txtOrder2 = new System.Windows.Forms.TextBox();
            this.txtCode2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Balance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaldo)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCriar
            // 
            this.btnCriar.AutoSize = true;
            this.btnCriar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCriar.Depth = 0;
            this.btnCriar.Icon = null;
            this.btnCriar.Location = new System.Drawing.Point(889, 11);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCriar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Primary = true;
            this.btnCriar.Size = new System.Drawing.Size(60, 36);
            this.btnCriar.TabIndex = 4;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtAmount.Location = new System.Drawing.Point(360, 8);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.MaxLength = 35;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(176, 24);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "0,00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(305, 11);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(45, 19);
            this.materialLabel3.TabIndex = 37;
            this.materialLabel3.Text = "Valor";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCurrency.Location = new System.Drawing.Point(66, 5);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrency.MaxLength = 35;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(176, 24);
            this.txtCurrency.TabIndex = 1;
            this.txtCurrency.Text = "BRL";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(7, 8);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(55, 19);
            this.materialLabel2.TabIndex = 35;
            this.materialLabel2.Text = "Moeda";
            // 
            // btnResgatar
            // 
            this.btnResgatar.AutoSize = true;
            this.btnResgatar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResgatar.Depth = 0;
            this.btnResgatar.Icon = null;
            this.btnResgatar.Location = new System.Drawing.Point(600, 16);
            this.btnResgatar.Margin = new System.Windows.Forms.Padding(2);
            this.btnResgatar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResgatar.Name = "btnResgatar";
            this.btnResgatar.Primary = true;
            this.btnResgatar.Size = new System.Drawing.Size(90, 36);
            this.btnResgatar.TabIndex = 39;
            this.btnResgatar.Text = "Resgatar";
            this.btnResgatar.UseVisualStyleBackColor = true;
            this.btnResgatar.Click += new System.EventHandler(this.btnResgatar_Click);
            // 
            // txtPedido
            // 
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPedido.Location = new System.Drawing.Point(204, 21);
            this.txtPedido.Margin = new System.Windows.Forms.Padding(2);
            this.txtPedido.MaxLength = 100;
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(360, 24);
            this.txtPedido.TabIndex = 36;
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(123, 24);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(77, 19);
            this.materialLabel14.TabIndex = 35;
            this.materialLabel14.Text = "Nº Pedido";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Balance);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(962, 508);
            this.tabControl1.TabIndex = 47;
            // 
            // Balance
            // 
            this.Balance.Controls.Add(this.materialRaisedButton1);
            this.Balance.Controls.Add(this.dgSaldo);
            this.Balance.Location = new System.Drawing.Point(4, 22);
            this.Balance.Name = "Balance";
            this.Balance.Padding = new System.Windows.Forms.Padding(3);
            this.Balance.Size = new System.Drawing.Size(954, 482);
            this.Balance.TabIndex = 0;
            this.Balance.Text = "Saldo";
            this.Balance.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(433, 407);
            this.materialRaisedButton1.Margin = new System.Windows.Forms.Padding(2);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(94, 36);
            this.materialRaisedButton1.TabIndex = 46;
            this.materialRaisedButton1.Text = "Atualizar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // dgSaldo
            // 
            this.dgSaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaldo.Location = new System.Drawing.Point(6, 6);
            this.dgSaldo.Name = "dgSaldo";
            this.dgSaldo.Size = new System.Drawing.Size(942, 396);
            this.dgSaldo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgVoucher);
            this.tabPage2.Controls.Add(this.materialLabel4);
            this.tabPage2.Controls.Add(this.txtQtd);
            this.tabPage2.Controls.Add(this.txtCurrency);
            this.tabPage2.Controls.Add(this.materialLabel2);
            this.tabPage2.Controls.Add(this.materialLabel3);
            this.tabPage2.Controls.Add(this.txtAmount);
            this.tabPage2.Controls.Add(this.btnCriar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(954, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compra Voucher";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(609, 11);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(84, 19);
            this.materialLabel4.TabIndex = 40;
            this.materialLabel4.Text = "Quantidade";
            // 
            // txtQtd
            // 
            this.txtQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtQtd.Location = new System.Drawing.Point(697, 8);
            this.txtQtd.Margin = new System.Windows.Forms.Padding(2);
            this.txtQtd.MaxLength = 35;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(176, 24);
            this.txtQtd.TabIndex = 3;
            this.txtQtd.Text = "1";
            this.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCode2);
            this.tabPage1.Controls.Add(this.txtOrder2);
            this.tabPage1.Controls.Add(this.txtDate2);
            this.tabPage1.Controls.Add(this.materialLabel7);
            this.tabPage1.Controls.Add(this.materialLabel6);
            this.tabPage1.Controls.Add(this.materialLabel5);
            this.tabPage1.Controls.Add(this.materialLabel14);
            this.tabPage1.Controls.Add(this.txtPedido);
            this.tabPage1.Controls.Add(this.btnResgatar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(954, 482);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Resgatar Voucher";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgVoucher
            // 
            this.dgVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVoucher.Location = new System.Drawing.Point(11, 52);
            this.dgVoucher.Name = "dgVoucher";
            this.dgVoucher.Size = new System.Drawing.Size(937, 404);
            this.dgVoucher.TabIndex = 42;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(148, 249);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(40, 19);
            this.materialLabel5.TabIndex = 40;
            this.materialLabel5.Text = "Data";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(111, 282);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(77, 19);
            this.materialLabel6.TabIndex = 41;
            this.materialLabel6.Text = "Nº Pedido";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(148, 312);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(33, 19);
            this.materialLabel7.TabIndex = 42;
            this.materialLabel7.Text = "PIN";
            // 
            // txtDate2
            // 
            this.txtDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtDate2.Location = new System.Drawing.Point(204, 246);
            this.txtDate2.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate2.MaxLength = 100;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.ReadOnly = true;
            this.txtDate2.Size = new System.Drawing.Size(360, 24);
            this.txtDate2.TabIndex = 43;
            // 
            // txtOrder2
            // 
            this.txtOrder2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtOrder2.Location = new System.Drawing.Point(204, 279);
            this.txtOrder2.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder2.MaxLength = 100;
            this.txtOrder2.Name = "txtOrder2";
            this.txtOrder2.ReadOnly = true;
            this.txtOrder2.Size = new System.Drawing.Size(360, 24);
            this.txtOrder2.TabIndex = 44;
            // 
            // txtCode2
            // 
            this.txtCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCode2.Location = new System.Drawing.Point(204, 312);
            this.txtCode2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCode2.MaxLength = 100;
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.ReadOnly = true;
            this.txtCode2.Size = new System.Drawing.Size(360, 24);
            this.txtCode2.TabIndex = 45;
            // 
            // FrmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 600);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmVoucher";
            this.Text = "Crypto Voucher";
            this.Load += new System.EventHandler(this.FrmVoucher_Load);
            this.tabControl1.ResumeLayout(false);
            this.Balance.ResumeLayout(false);
            this.Balance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaldo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVoucher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtAmount;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtCurrency;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnCriar;
        private MaterialSkin.Controls.MaterialRaisedButton btnResgatar;
        private System.Windows.Forms.TextBox txtPedido;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Balance;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgSaldo;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgVoucher;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.TextBox txtCode2;
        private System.Windows.Forms.TextBox txtOrder2;
        private System.Windows.Forms.TextBox txtDate2;
    }
}