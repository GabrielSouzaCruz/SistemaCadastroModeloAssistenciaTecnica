using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class cliente
    {
        string nome;
        string cpf;
        string telefone;
        int equipamento;
        string descricao;
        double valor;

        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public double Valor { get => valor; set => valor = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public int Equipamento { get => equipamento; set => equipamento = value; }
    }
}
