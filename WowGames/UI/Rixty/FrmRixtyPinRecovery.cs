using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Proxy;

namespace WowGames
{
    public partial class FrmRixtyPinRecovery : MaterialSkin.Controls.MaterialForm
    {
        public FrmRixtyPinRecovery()
        {
            InitializeComponent();
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            var proxy = new RixtyProxy();
            if (string.IsNullOrEmpty(txtRefID.Text))
            {
                MessageBox.Show("O campo Reference ID é obrigatório", "Atenção");
                return;
            }
            if (string.IsNullOrEmpty(txtToken.Text))
            {
                MessageBox.Show("O campo Validated Token é obrigatório", "Atenção");
                return;
            }
            var result = proxy.GetPurchaseConfirmation(txtRefID.Text, txtToken.Text);
            if (result == null || !result.Coupons.Any())
            {
                MessageBox.Show("PIN não encontrado", "Atenção");
                return;
            }
            txtPID.Text = result.PaymentId;
            txtCodProd.Text = result.ProductCode;
            txtPrice.Text = result.TotalPrice.ToString();
            txtQtd.Text = result.Quantity;
            txtProd.Text = result.ProductDescription;

            var pins = result.Coupons.SelectMany(c => c.Pins).ToList();
            var serials = result.Coupons.SelectMany(c => c.Serials).ToList();
            var total = pins.Count() > serials.Count() ? pins.Count() : serials.Count();
            var pinSerials = new List<PinAndSerial>();
            for (int i = 0; i < total; i++)
            {
                pinSerials.Add(new PinAndSerial
                {
                    PIN = i < pins.Count() ? pins[i] : string.Empty,
                    Serial = i < serials.Count() ? serials[i] : string.Empty
                });
            }
            dgvResultado.DataSource = pinSerials;
        }

        private void FrmRixtyPinRecovery_Load(object sender, EventArgs e)
        {

            dgvResultado.AutoGenerateColumns = false;
            dgvResultado.AutoSize = false;
            dgvResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvResultado.ReadOnly = true;
            dgvResultado.AllowUserToAddRows = false;

            dgvResultado.ColumnCount = 2;
            dgvResultado.Columns[0].Visible = true;
            dgvResultado.Columns[0].HeaderText = "PIN";
            dgvResultado.Columns[0].DataPropertyName = "PIN";

            dgvResultado.Columns[1].Visible = true;
            dgvResultado.Columns[1].HeaderText = "Serial";
            dgvResultado.Columns[1].DataPropertyName = "Serial";
        }
    }
}
