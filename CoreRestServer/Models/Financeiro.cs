using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRestServer.Models
{
    public class Financeiro
    {
        private int id;
        private string nome;
        private string descricao;
        private string setor;
        private string categoria;
        private double valor;
        private DateTime? data_vencimento;
        private DateTime? data_pagamento;
        private DateTime data_registro;
        private string pago;
        private string recebido;
        private string observacao1;
        private string observacao2;

        public Financeiro(int id, string nome, string descricao, string setor, string categoria, double valor, DateTime? data_vencimento, DateTime? data_pagamento, DateTime data_registro, string pago, string recebido, string observacao1, string observacao2)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.setor = setor;
            this.categoria = categoria;
            this.valor = valor;
            this.data_vencimento = data_vencimento;
            this.data_pagamento = data_pagamento;
            this.data_registro = data_registro;
            this.pago = pago;
            this.recebido = recebido;
            this.observacao1 = observacao1;
            this.observacao2 = observacao2;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Setor { get => setor; set => setor = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Valor { get => valor; set => valor = value; }
        public DateTime? Data_vencimento { get => data_vencimento; set => data_vencimento = value; }
        public DateTime? Data_pagamento { get => data_pagamento; set => data_pagamento = value; }
        public DateTime Data_registro { get => data_registro; set => data_registro = value; }
        public string Pago { get => pago; set => pago = value; }
        public string Recebido { get => recebido; set => recebido = value; }
        public string Observacao1 { get => observacao1; set => observacao1 = value; }
        public string Observacao2 { get => observacao2; set => observacao2 = value; }
    }
}
