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
    public partial class FrnAddEquipamento : Form
    {
        public FrnAddEquipamento()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sistema formSistema = new Sistema();
            formSistema.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conectaBanco con = new conectaBanco();
            bool retorno = con.insereEquipamento(txtaddEquipamento.Text);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
                MessageBox.Show("Equipamente adicionado com sucesso");
            txtaddEquipamento.Clear();
            txtaddEquipamento.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
