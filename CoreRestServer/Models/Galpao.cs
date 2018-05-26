using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRestServer.Models
{
    public class Galpao
    {
        private int id;
        private string nome;
        private string metros_quadrados;
        private DateTime data_inicio;
        private DateTime data_fim;
        private decimal valor_aluguel;

        public Galpao(int id, string nome, string metros_quadrados, DateTime data_inicio, DateTime data_fim, decimal valor_aluguel)
        {
            this.id = id;
            this.nome = nome;
            this.metros_quadrados = metros_quadrados;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.valor_aluguel = valor_aluguel;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Metros_quadrados { get => metros_quadrados; set => metros_quadrados = value; }
        public DateTime Data_inicio { get => data_inicio; set => data_inicio = value; }
        public DateTime Data_fim { get => data_fim; set => data_fim = value; }
        public decimal Valor_aluguel { get => valor_aluguel; set => valor_aluguel = value; }
    }
}
