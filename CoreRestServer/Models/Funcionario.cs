using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRestServer.Models
{
    public class Funcionario
    {
        private int id;
        private string nome;
        private string cpf;
        private DateTime solicitacao_inicio_ferias;
        private DateTime solicitacao_fim_ferias;

        public Funcionario(int id, string nome, string cpf, DateTime solicitacao_inicio_ferias, DateTime solicitacao_fim_ferias)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.solicitacao_inicio_ferias = solicitacao_inicio_ferias;
            this.solicitacao_fim_ferias = solicitacao_fim_ferias;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public DateTime Solicitacao_inicio_ferias { get => solicitacao_inicio_ferias; set => solicitacao_inicio_ferias = value; }
        public DateTime Solicitacao_fim_ferias { get => solicitacao_fim_ferias; set => solicitacao_fim_ferias = value; }
    }
}
