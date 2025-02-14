using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar;
        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }



        private void Sistema_Load(object sender, EventArgs e)
        {
            listaCBEquipamento();
            lista_gridCliente();
        }

        public void listaCBEquipamento()
        {
            conectaBanco con = new conectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaEquipamento();
            cbEquipamento.DataSource = tabelaDados;
            cbEquipamento.DisplayMember = "equipamento";
            cbEquipamento.ValueMember = "idequipamento";
            
            cbAlteraEquipamento.DataSource = tabelaDados;
            cbAlteraEquipamento.DisplayMember = "equipamento";
            cbAlteraEquipamento.ValueMember = "idequipamento";

            limpaCampos();

        }

        void lista_gridCliente()
        {
            conectaBanco con = new conectaBanco();
            dgCliente.DataSource = con.listaCliente();
            dgCliente.Columns["idcliente"].Visible = false;

        }




        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
           (dgCliente.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("nome like '{0}%'", txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            int linha = dgCliente.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgCliente.Rows[linha].Cells["idcliente"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Cliente", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                conectaBanco con = new conectaBanco();
                bool retorno = con.deletaCliente(id);
                if (retorno == true)
                {
                    MessageBox.Show("Cliente excluida com sucesso!");
                    lista_gridCliente();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
                int linha = dgCliente.CurrentRow.Index;// pega a linha selecionada
                idAlterar = Convert.ToInt32(
                  dgCliente.Rows[linha].Cells["idCliente"].Value.ToString());
                txtAlteraNome.Text =
                     dgCliente.Rows[linha].Cells["nome"].Value.ToString();
                txtAlteracpf.Text =
                    dgCliente.Rows[linha].Cells["cpf"].Value.ToString();
                txtAlteratelefone.Text =
                    dgCliente.Rows[linha].Cells["telefone"].Value.ToString();
                txtAlteraValor.Text =
                    dgCliente.Rows[linha].Cells["valor"].Value.ToString();
                cbAlteraEquipamento.Text =
                    dgCliente.Rows[linha].Cells["equipamento"].Value.ToString();
                tabControl1.SelectedTab = tabAlterar;// muda aba
            
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            conectaBanco con = new conectaBanco();
            cliente novoCliente = new cliente();
            novoCliente.Nome = txtAlteraNome.Text;
            novoCliente.Cpf = txtAlteracpf.Text;
            novoCliente.Telefone = txtAlteratelefone.Text;
            novoCliente.Equipamento = Convert.ToInt32(cbAlteraEquipamento.SelectedValue.ToString());
            novoCliente.Valor = Convert.ToDouble(txtAlteraValor.Text);
            bool retorno = con.alteraCliente(novoCliente, idAlterar);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
                MessageBox.Show("Alteração realizada com sucesso!");
            
            lista_gridCliente();
            limpaCampos();
            tabControl1.SelectedTab = tabBuscar;


        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
            FrnAddEquipamento formEquipamento = new FrnAddEquipamento();
            this.Hide();
            formEquipamento.ShowDialog();
            this.Close();
        }

        void limpaCampos()
        {
            txtnome.Clear();
            txtcpf.Clear();
            txttelefone.Clear();
            cbEquipamento.Text = "";
            txtvalor.Clear();
            txtnome.Focus();

            txtAlteraNome.Clear();
            txtAlteracpf.Clear();
            txtAlteratelefone.Clear();
            cbAlteraEquipamento.Text = "";
            txtAlteraValor.Clear();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            conectaBanco con = new conectaBanco();
            cliente novoCliente = new cliente();
            novoCliente.Nome = txtnome.Text;
            novoCliente.Cpf = txtcpf.Text;
            novoCliente.Telefone = txttelefone.Text;
            novoCliente.Equipamento = Convert.ToInt32(cbEquipamento.SelectedValue.ToString());
            novoCliente.Valor = Convert.ToDouble(txtvalor.Text);
            bool retorno = con.insereCliente(novoCliente);
            if (retorno == false)
                MessageBox.Show(con.mensagem);

            limpaCampos();
            lista_gridCliente();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbAlteraEquipamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEquipamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
