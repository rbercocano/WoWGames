namespace WowGames
{
    partial class FrmRixtyPinRecovery
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
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtRefID = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnRecovery = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(23, 99);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(117, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Reference ID";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(629, 99);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(147, 24);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Validated Token";
            // 
            // txtRefID
            // 
            this.txtRefID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtRefID.Location = new System.Drawing.Point(166, 95);
            this.txtRefID.Name = "txtRefID";
            this.txtRefID.Size = new System.Drawing.Size(412, 28);
            this.txtRefID.TabIndex = 2;
            // 
            // txtToken
            // 
            this.txtToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtToken.Location = new System.Drawing.Point(804, 95);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(412, 28);
            this.txtToken.TabIndex = 3;
            // 
            // btnRecovery
            // 
            this.btnRecovery.AutoSize = true;
            this.btnRecovery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecovery.Depth = 0;
            this.btnRecovery.Icon = null;
            this.btnRecovery.Location = new System.Drawing.Point(1275, 90);
            this.btnRecovery.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Primary = true;
            this.btnRecovery.Size = new System.Drawing.Size(141, 36);
            this.btnRecovery.TabIndex = 4;
            this.btnRecovery.Text = "Resgatar PIN";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(1, 140);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1498, 10);
            this.materialDivider1.TabIndex = 5;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(48, 261);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(170, 24);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Código do Produto";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCodProd.Location = new System.Drawing.Point(235, 257);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.ReadOnly = true;
            this.txtCodProd.Size = new System.Drawing.Size(634, 28);
            this.txtCodProd.TabIndex = 7;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(89, 209);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(129, 24);
            this.materialLabel4.TabIndex = 8;
            this.materialLabel4.Text = "ID Pagamento";
            // 
            // txtPID
            // 
            this.txtPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPID.Location = new System.Drawing.Point(235, 206);
            this.txtPID.Name = "txtPID";
            this.txtPID.ReadOnly = true;
            this.txtPID.Size = new System.Drawing.Size(634, 28);
            this.txtPID.TabIndex = 9;
            // 
            // txtQtd
            // 
            this.txtQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtQtd.Location = new System.Drawing.Point(235, 356);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.ReadOnly = true;
            this.txtQtd.Size = new System.Drawing.Size(162, 28);
            this.txtQtd.TabIndex = 11;
            this.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(112, 360);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(106, 24);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Quantidade";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPrice.Location = new System.Drawing.Point(235, 405);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(634, 28);
            this.txtPrice.TabIndex = 13;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(156, 409);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(59, 24);
            this.materialLabel6.TabIndex = 12;
            this.materialLabel6.Text = "Preço";
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(921, 206);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.RowHeadersWidth = 51;
            this.dgvResultado.RowTemplate.Height = 24;
            this.dgvResultado.Size = new System.Drawing.Size(530, 396);
            this.dgvResultado.TabIndex = 14;
            // 
            // txtProd
            // 
            this.txtProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtProd.Location = new System.Drawing.Point(235, 303);
            this.txtProd.Name = "txtProd";
            this.txtProd.ReadOnly = true;
            this.txtProd.Size = new System.Drawing.Size(634, 28);
            this.txtProd.TabIndex = 16;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(138, 307);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(77, 24);
            this.materialLabel7.TabIndex = 15;
            this.materialLabel7.Text = "Produto";
            // 
            // FrmRixtyPinRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 700);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.btnRecovery);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtRefID);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.MaximumSize = new System.Drawing.Size(1600, 700);
            this.MinimumSize = new System.Drawing.Size(1600, 700);
            this.Name = "FrmRixtyPinRecovery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIXTY - Resgatar PIN";
            this.Load += new System.EventHandler(this.FrmRixtyPinRecovery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox txtRefID;
        private System.Windows.Forms.TextBox txtToken;
        private MaterialSkin.Controls.MaterialRaisedButton btnRecovery;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtCodProd;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.TextBox txtQtd;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.TextBox txtPrice;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.TextBox txtProd;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
    }
}