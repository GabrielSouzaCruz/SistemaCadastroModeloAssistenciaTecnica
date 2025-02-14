using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaCadastro
{
    class conectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=banco_siscadastro");
        public string mensagem;
        public bool insereCliente(cliente novoCliente)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereCliente", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nome", novoCliente.Nome);
                cmd.Parameters.AddWithValue("cpf", novoCliente.Cpf);
                cmd.Parameters.AddWithValue("telefone", novoCliente.Telefone);
                cmd.Parameters.AddWithValue("equipamento", novoCliente.Equipamento);
                cmd.Parameters.AddWithValue("valor", novoCliente.Valor);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }

        }// fim do insereCliente

        public DataTable listaEquipamento()
        {
            // comentario
            MySqlCommand cmd = new MySqlCommand("sp_listaEquipamento", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_Equipamento
        public DataTable listaCliente()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_Cliente
        public bool deletaCliente(int idRemoveClientes)
        {
            MySqlCommand cmd = new MySqlCommand("sp_removeCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idclientes", idRemoveClientes);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim deletaCliente 
        public bool alteraCliente(cliente alteraCliente, int idClientes)
        {
            MySqlCommand cmd = new MySqlCommand("sp_alteraCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idClientes", idClientes);
            cmd.Parameters.AddWithValue("nome", alteraCliente.Nome);
            cmd.Parameters.AddWithValue("cpf", alteraCliente.Cpf);
            cmd.Parameters.AddWithValue("telefone", alteraCliente.Telefone);
            cmd.Parameters.AddWithValue("equipamento", alteraCliente.Equipamento);
            cmd.Parameters.AddWithValue("valor", alteraCliente.Valor);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim update_Cliente
        public bool insereEquipamento(string equipamento)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereEquipamento", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("equipamento", equipamento);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }

        }// fim do insereEquipamento
        public bool verifica(string user, string pass)
        {
            string senhaHash = Biblioteca.makeHash(pass);
            MySqlCommand cmd = new MySqlCommand("consultaLogin", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usuario", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);
            try
            {
                conexao.Open();//abrindo a conexão;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();// tabela virtual
                da.Fill(ds); //passando os valores consultados para o DataSet
                if (ds.Tables[0].Rows.Count > 0) // verifica se houve retorno
                    return true;
                else
                    return false;

            }
            catch (MySqlException er)
            {
                mensagem = "Erro" + er.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }



    }
}
