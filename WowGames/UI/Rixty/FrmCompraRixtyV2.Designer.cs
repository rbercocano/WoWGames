namespace WowGames
{
    partial class FrmCompraRixtyV2
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
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnRecovery = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblValor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSucesso = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
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
            this.materialLabel2.Size = new System.Drawing.Size(106, 24);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Quantidade";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtQuantity.Location = new System.Drawing.Point(804, 95);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(110, 28);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // btnRecovery
            // 
            this.btnRecovery.AutoSize = true;
            this.btnRecovery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecovery.Depth = 0;
            this.btnRecovery.Icon = null;
            this.btnRecovery.Location = new System.Drawing.Point(1217, 93);
            this.btnRecovery.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Primary = true;
            this.btnRecovery.Size = new System.Drawing.Size(104, 36);
            this.btnRecovery.TabIndex = 4;
            this.btnRecovery.Text = "Comprar";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(34, 206);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.RowHeadersWidth = 51;
            this.dgvResultado.RowTemplate.Height = 24;
            this.dgvResultado.Size = new System.Drawing.Size(1343, 428);
            this.dgvResultado.TabIndex = 14;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtProductCode.Location = new System.Drawing.Point(173, 96);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(412, 28);
            this.txtProductCode.TabIndex = 18;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(30, 100);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(121, 24);
            this.materialLabel8.TabIndex = 17;
            this.materialLabel8.Text = "Cód. Produto";
            // 
            // txtPreco
            // 
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPreco.Location = new System.Drawing.Point(804, 140);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = true;
            this.txtPreco.Size = new System.Drawing.Size(235, 28);
            this.txtPreco.TabIndex = 20;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(676, 143);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(59, 24);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Preço";
            // 
            // txtProd
            // 
            this.txtProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtProd.Location = new System.Drawing.Point(173, 143);
            this.txtProd.Name = "txtProd";
            this.txtProd.ReadOnly = true;
            this.txtProd.Size = new System.Drawing.Size(412, 28);
            this.txtProd.TabIndex = 22;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(30, 147);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(77, 24);
            this.materialLabel3.TabIndex = 21;
            this.materialLabel3.Text = "Produto";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(336, 650);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(0, 25);
            this.lblValor.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(223, 650);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 25);
            this.label9.TabIndex = 34;
            this.label9.Text = "Valor Total:";
            // 
            // lblSucesso
            // 
            this.lblSucesso.AutoSize = true;
            this.lblSucesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucesso.Location = new System.Drawing.Point(1135, 650);
            this.lblSucesso.Name = "lblSucesso";
            this.lblSucesso.Size = new System.Drawing.Size(0, 25);
            this.lblSucesso.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(888, 650);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "Efetuados com Sucesso:";
            // 
            // FrmCompraRixtyV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 700);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSucesso);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.btnRecovery);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.materialLabel2);
            this.Name = "FrmCompraRixtyV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIXTY - Resgatar PIN";
            this.Load += new System.EventHandler(this.FrmRixtyPinRecovery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox txtQuantity;
        private MaterialSkin.Controls.MaterialRaisedButton btnRecovery;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.TextBox txtProductCode;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.TextBox txtPreco;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtProd;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSucesso;
        private System.Windows.Forms.Label label8;
    }
}