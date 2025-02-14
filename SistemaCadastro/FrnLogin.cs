using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrnLogin : Form
    {
        public FrnLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conectaBanco con = new conectaBanco();
            if(con.verifica(txtUsuarioLogin.Text, txtSenhaLogin.Text) == true)
            {
                Sistema formSistema = new Sistema();
                this.Hide();
                formSistema.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Incorreta" + con.mensagem);
            }
        }
    }
}
