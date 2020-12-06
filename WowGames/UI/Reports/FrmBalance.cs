using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmBalance : MaterialSkin.Controls.MaterialForm
    {
        private BalanceRepository repository = new BalanceRepository();
        public FrmBalance()
        {
            InitializeComponent();
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Date", Name = "Data Lançamento", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", Name = "Valor", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Balance", Name = "Saldo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", Name = "Descrição", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var days = string.IsNullOrEmpty(txtDias.Text) ? 0 : Convert.ToInt32(txtDias.Text);
            var result = repository.GetBalance(days);
            dgvCompras.DataSource = result;
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLancamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;

            if (e.KeyChar == '.')
            {
                e.Handled = true;
                return;
            }

            if (string.IsNullOrEmpty(txtLancamento.Text) && e.KeyChar == '-')
                return;

            var value = txtLancamento.Text + e.KeyChar.ToString();
            if (value.Contains(",") && value.Substring(value.IndexOf(',') + 1).Length > 2)
            {
                e.Handled = true;
                return;
            }
            if (!decimal.TryParse(value, NumberStyles.Any, new CultureInfo("pt-BR"), out decimal result))
                e.Handled = true;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLancamento.Text))
            {
                MessageBox.Show("Informe um valor a ser lançado.", "Atenção", MessageBoxButtons.OK);
                return;
            }

            var balance = Convert.ToDecimal(txtLancamento.Text, new CultureInfo("pt-BR"));
            repository.Add(balance);
            btnPesquisar_Click(null, null);
        }
    }
}
