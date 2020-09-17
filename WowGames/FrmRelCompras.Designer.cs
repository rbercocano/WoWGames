namespace WowGames
{
    partial class FrmRelCompras
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
            this.txtSku = new System.Windows.Forms.TextBox();
            this.txtIni = new System.Windows.Forms.MaskedTextBox();
            this.txtFim = new System.Windows.Forms.MaskedTextBox();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSku
            // 
            this.txtSku.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtSku.Location = new System.Drawing.Point(94, 86);
            this.txtSku.MaxLength = 35;
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(494, 28);
            this.txtSku.TabIndex = 5;
            // 
            // txtIni
            // 
            this.txtIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtIni.Location = new System.Drawing.Point(790, 86);
            this.txtIni.Mask = "00/00/0000";
            this.txtIni.Name = "txtIni";
            this.txtIni.Size = new System.Drawing.Size(124, 28);
            this.txtIni.TabIndex = 8;
            this.txtIni.ValidatingType = typeof(System.DateTime);
            // 
            // txtFim
            // 
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtFim.Location = new System.Drawing.Point(1155, 87);
            this.txtFim.Mask = "00/00/0000";
            this.txtFim.Name = "txtFim";
            this.txtFim.Size = new System.Drawing.Size(124, 28);
            this.txtFim.TabIndex = 9;
            this.txtFim.ValidatingType = typeof(System.DateTime);
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Location = new System.Drawing.Point(12, 147);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.RowHeadersWidth = 51;
            this.dgvCompras.RowTemplate.Height = 24;
            this.dgvCompras.Size = new System.Drawing.Size(1476, 541);
            this.dgvCompras.TabIndex = 11;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(1378, 84);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(88, 36);
            this.materialRaisedButton1.TabIndex = 12;
            this.materialRaisedButton1.Text = "Buscar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(23, 90);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(45, 24);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "SKU";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(656, 90);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(99, 24);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Data Início";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(1034, 89);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(86, 24);
            this.materialLabel3.TabIndex = 15;
            this.materialLabel3.Text = "Data Fim";
            // 
            // FrmRelCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 700);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.txtFim);
            this.Controls.Add(this.txtIni);
            this.Controls.Add(this.txtSku);
            this.MaximumSize = new System.Drawing.Size(1600, 700);
            this.MinimumSize = new System.Drawing.Size(1600, 700);
            this.Name = "FrmRelCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.FrmRelCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.MaskedTextBox txtIni;
        private System.Windows.Forms.MaskedTextBox txtFim;
        private System.Windows.Forms.DataGridView dgvCompras;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}