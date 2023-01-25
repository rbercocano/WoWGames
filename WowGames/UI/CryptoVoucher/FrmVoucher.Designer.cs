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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCriar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblData2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPedido2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblCode2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.btnResgatar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtOrderRes = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtCode2 = new System.Windows.Forms.TextBox();
            this.txtOrder2 = new System.Windows.Forms.TextBox();
            this.txtDate2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(11, 75);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(62, 19);
            this.materialLabel1.TabIndex = 33;
            this.materialLabel1.Text = "Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtBalance.Location = new System.Drawing.Point(77, 72);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(2);
            this.txtBalance.MaxLength = 35;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(176, 24);
            this.txtBalance.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.txtOrderRes);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.materialLabel6);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.btnCriar);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 322);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criar Voucher";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(5, 291);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(90, 19);
            this.materialLabel6.TabIndex = 42;
            this.materialLabel6.Text = "Data Pedido";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(5, 263);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(77, 19);
            this.materialLabel5.TabIndex = 41;
            this.materialLabel5.Text = "Nº Pedido";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(5, 235);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(57, 19);
            this.materialLabel4.TabIndex = 40;
            this.materialLabel4.Text = "Código";
            // 
            // btnCriar
            // 
            this.btnCriar.AutoSize = true;
            this.btnCriar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCriar.Depth = 0;
            this.btnCriar.Icon = null;
            this.btnCriar.Location = new System.Drawing.Point(291, 82);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCriar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Primary = true;
            this.btnCriar.Size = new System.Drawing.Size(60, 36);
            this.btnCriar.TabIndex = 39;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtAmount.Location = new System.Drawing.Point(175, 54);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.MaxLength = 35;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(176, 24);
            this.txtAmount.TabIndex = 38;
            this.txtAmount.Text = "0,00";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(120, 57);
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
            this.txtCurrency.Location = new System.Drawing.Point(175, 26);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrency.MaxLength = 35;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(176, 24);
            this.txtCurrency.TabIndex = 36;
            this.txtCurrency.Text = "BRL";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(116, 29);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(55, 19);
            this.materialLabel2.TabIndex = 35;
            this.materialLabel2.Text = "Moeda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCode2);
            this.groupBox2.Controls.Add(this.txtOrder2);
            this.groupBox2.Controls.Add(this.txtDate2);
            this.groupBox2.Controls.Add(this.lblData2);
            this.groupBox2.Controls.Add(this.lblPedido2);
            this.groupBox2.Controls.Add(this.lblCode2);
            this.groupBox2.Controls.Add(this.materialLabel10);
            this.groupBox2.Controls.Add(this.materialLabel11);
            this.groupBox2.Controls.Add(this.materialLabel12);
            this.groupBox2.Controls.Add(this.btnResgatar);
            this.groupBox2.Controls.Add(this.txtPedido);
            this.groupBox2.Controls.Add(this.materialLabel14);
            this.groupBox2.Location = new System.Drawing.Point(509, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 322);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resgatar Voucher";
            // 
            // lblData2
            // 
            this.lblData2.AutoSize = true;
            this.lblData2.Depth = 0;
            this.lblData2.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblData2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblData2.Location = new System.Drawing.Point(141, 291);
            this.lblData2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblData2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(0, 19);
            this.lblData2.TabIndex = 45;
            // 
            // lblPedido2
            // 
            this.lblPedido2.AutoSize = true;
            this.lblPedido2.Depth = 0;
            this.lblPedido2.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPedido2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPedido2.Location = new System.Drawing.Point(141, 263);
            this.lblPedido2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPedido2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPedido2.Name = "lblPedido2";
            this.lblPedido2.Size = new System.Drawing.Size(0, 19);
            this.lblPedido2.TabIndex = 44;
            // 
            // lblCode2
            // 
            this.lblCode2.AutoSize = true;
            this.lblCode2.Depth = 0;
            this.lblCode2.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCode2.Location = new System.Drawing.Point(141, 235);
            this.lblCode2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCode2.Name = "lblCode2";
            this.lblCode2.Size = new System.Drawing.Size(0, 19);
            this.lblCode2.TabIndex = 43;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(5, 291);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(90, 19);
            this.materialLabel10.TabIndex = 42;
            this.materialLabel10.Text = "Data Pedido";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(5, 263);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(77, 19);
            this.materialLabel11.TabIndex = 41;
            this.materialLabel11.Text = "Nº Pedido";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(5, 235);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(57, 19);
            this.materialLabel12.TabIndex = 40;
            this.materialLabel12.Text = "Código";
            // 
            // btnResgatar
            // 
            this.btnResgatar.AutoSize = true;
            this.btnResgatar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResgatar.Depth = 0;
            this.btnResgatar.Icon = null;
            this.btnResgatar.Location = new System.Drawing.Point(373, 79);
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
            this.txtPedido.Location = new System.Drawing.Point(103, 23);
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
            this.materialLabel14.Location = new System.Drawing.Point(22, 26);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(77, 19);
            this.materialLabel14.TabIndex = 35;
            this.materialLabel14.Text = "Nº Pedido";
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtDate.Location = new System.Drawing.Point(99, 288);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate.MaxLength = 35;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(364, 24);
            this.txtDate.TabIndex = 43;
            // 
            // txtOrderRes
            // 
            this.txtOrderRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtOrderRes.Location = new System.Drawing.Point(99, 260);
            this.txtOrderRes.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrderRes.MaxLength = 35;
            this.txtOrderRes.Name = "txtOrderRes";
            this.txtOrderRes.ReadOnly = true;
            this.txtOrderRes.Size = new System.Drawing.Size(364, 24);
            this.txtOrderRes.TabIndex = 44;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCode.Location = new System.Drawing.Point(99, 232);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtCode.MaxLength = 35;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(364, 24);
            this.txtCode.TabIndex = 45;
            // 
            // txtCode2
            // 
            this.txtCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCode2.Location = new System.Drawing.Point(99, 232);
            this.txtCode2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCode2.MaxLength = 35;
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.ReadOnly = true;
            this.txtCode2.Size = new System.Drawing.Size(364, 24);
            this.txtCode2.TabIndex = 48;
            // 
            // txtOrder2
            // 
            this.txtOrder2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtOrder2.Location = new System.Drawing.Point(99, 260);
            this.txtOrder2.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrder2.MaxLength = 35;
            this.txtOrder2.Name = "txtOrder2";
            this.txtOrder2.ReadOnly = true;
            this.txtOrder2.Size = new System.Drawing.Size(364, 24);
            this.txtOrder2.TabIndex = 47;
            // 
            // txtDate2
            // 
            this.txtDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtDate2.Location = new System.Drawing.Point(99, 288);
            this.txtDate2.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate2.MaxLength = 35;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.ReadOnly = true;
            this.txtDate2.Size = new System.Drawing.Size(364, 24);
            this.txtDate2.TabIndex = 46;
            // 
            // FrmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.materialLabel1);
            this.Name = "FrmVoucher";
            this.Text = "FrmVoucher";
            this.Load += new System.EventHandler(this.FrmVoucher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAmount;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtCurrency;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnCriar;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel lblData2;
        private MaterialSkin.Controls.MaterialLabel lblPedido2;
        private MaterialSkin.Controls.MaterialLabel lblCode2;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialRaisedButton btnResgatar;
        private System.Windows.Forms.TextBox txtPedido;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtOrderRes;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtCode2;
        private System.Windows.Forms.TextBox txtOrder2;
        private System.Windows.Forms.TextBox txtDate2;
    }
}