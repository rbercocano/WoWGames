using System;
using System.Windows.Forms;

namespace WowGames
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Equals("wowgames") && txtSenha.Text.Equals("Sn931bw!"))
            {
                Hide();
                var frm = new frmMain();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Usuário / Senha Inválido", "Atenção", MessageBoxButtons.OK);
            }
        }
    }
}
