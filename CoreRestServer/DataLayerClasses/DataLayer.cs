using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using CoreRestServer.Models;

namespace CoreRestServer.DataLayerClasses
{
    public class DataLayer
    {

       MySqlConnection connection;

        public DataLayer(IConfiguration configuration)
        {
            String connectionString = configuration.GetConnectionString("localDB");
            connection = new MySqlConnection(connectionString);
        }

        #region . Financeiro .
        public IEnumerable<Financeiro> GetFinanceiros(int Id)
        {
            List<Financeiro> financeiros = new List<Financeiro>();
            MySqlCommand command;
            if (Id == 0)
            {
                command = new MySqlCommand("SELECT id, nome, descricao, setor,categoria,valor,data_vencimento,data_pagamento,data_registro,pago,recebido,observacao1,observacao2 FROM sige.lancamentos", connection);
            }
            else
            {
                command = new MySqlCommand("SELECT id, nome, descricao, setor,categoria,valor,data_vencimento,data_pagamento,data_registro,pago,recebido,observacao1,observacao2 FROM sige.lancamentos WHERE id = " + Id, connection);
            }

            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]);
                    string nome = reader["nome"] == DBNull.Value ? "" : Convert.ToString(reader["nome"]);
                    string descricao = reader["descricao"] == DBNull.Value ? "" : Convert.ToString(reader["descricao"]);
                    string setor = reader["setor"] == DBNull.Value ? "" : Convert.ToString(reader["setor"]);
                    string categoria = reader["categoria"] == DBNull.Value ? "" : Convert.ToString(reader["categoria"]);
                    double valor = reader["valor"] == DBNull.Value ? 0 : Convert.ToDouble(reader["valor"]);
                    string pago = reader["pago"] == DBNull.Value ? "" : Convert.ToString(reader["pago"]);
                    string recebido = reader["recebido"] == DBNull.Value ? "" : Convert.ToString(reader["recebido"]);
                    string observacao1 = reader["observacao1"] == DBNull.Value ? "" : Convert.ToString(reader["observacao1"]);
                    string observacao2 = reader["observacao2"] == DBNull.Value ? "" : Convert.ToString(reader["observacao2"]);
                    DateTime? data_vencimento = (reader["data_vencimento"] == DBNull.Value) ? (DateTime?)null : ((DateTime)reader["data_vencimento"]);
                    DateTime? data_pagamento = (reader["data_pagamento"] == DBNull.Value) ? (DateTime?)null : ((DateTime)reader["data_pagamento"]);
                    DateTime data_registro = (reader["data_registro"] == DBNull.Value) ? DateTime.Now : ((DateTime)reader["data_registro"]);

                    Financeiro financeiro = new Financeiro(id, nome, descricao, setor, categoria, valor, data_vencimento, data_pagamento, data_registro, pago, recebido, observacao1, observacao2);
                    financeiros.Add(financeiro);
                }
            }

            connection.Close();
            return financeiros;
        }

        public IEnumerable<Financeiro> GetFinanceirosBySetor(string setorRecebido)
        {
            List<Financeiro> financeiros = new List<Financeiro>();
            MySqlCommand command;

            command = new MySqlCommand("SELECT id, nome, descricao, setor,categoria,valor,data_vencimento,data_pagamento,data_registro,pago,recebido,observacao1,observacao2 FROM sige.lancamentos where setor = '" + setorRecebido + "'", connection);


            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]);
                    string nome = reader["nome"] == DBNull.Value ? "" : Convert.ToString(reader["nome"]);
                    string descricao = reader["descricao"] == DBNull.Value ? "" : Convert.ToString(reader["descricao"]);
                    string setor = reader["setor"] == DBNull.Value ? "" : Convert.ToString(reader["setor"]);
                    string categoria = reader["categoria"] == DBNull.Value ? "" : Convert.ToString(reader["categoria"]);
                    double valor = reader["valor"] == DBNull.Value ? 0 : Convert.ToDouble(reader["valor"]);
                    string pago = reader["pago"] == DBNull.Value ? "" : Convert.ToString(reader["pago"]);
                    string recebido = reader["recebido"] == DBNull.Value ? "" : Convert.ToString(reader["recebido"]);
                    string observacao1 = reader["observacao1"] == DBNull.Value ? "" : Convert.ToString(reader["observacao1"]);
                    string observacao2 = reader["observacao2"] == DBNull.Value ? "" : Convert.ToString(reader["observacao2"]);
                    DateTime? data_vencimento = (reader["data_vencimento"] == DBNull.Value) ? (DateTime?)null : ((DateTime)reader["data_vencimento"]);
                    DateTime? data_pagamento = (reader["data_pagamento"] == DBNull.Value) ? (DateTime?)null : ((DateTime)reader["data_pagamento"]);
                    DateTime data_registro = (reader["data_registro"] == DBNull.Value) ? DateTime.Now : ((DateTime)reader["data_registro"]);

                    Financeiro financeiro = new Financeiro(id, nome, descricao, setor, categoria, valor, data_vencimento, data_pagamento, data_registro, pago, recebido, observacao1, observacao2);
                    financeiros.Add(financeiro);
                }
            }

            connection.Close();
            return financeiros;
        }

        public Financeiro CreateFinanceiro(Financeiro financeiro)
        {
            MySqlCommand command;

            string Nome = "'" + financeiro.Nome + "'";
            string Descricao = "'" + financeiro.Descricao + "'";
            string Setor = "'" + financeiro.Setor + "'";
            string Categoria = "'" + financeiro.Categoria + "'";
            string Valor = financeiro.Valor.ToString().Replace(",", ".");
            string Data_vencimento = "'" + financeiro.Data_vencimento.ToString() + "'";
            string Data_pagamento = "'" + financeiro.Data_pagamento.ToString() + "'";
            string Data_registro = "'" + financeiro.Data_registro.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Pago = "'" + financeiro.Pago + "'";
            string Recebido = "'" + financeiro.Recebido + "'";
            string Observacao1 = "'" + financeiro.Observacao1 + "'";
            string Observacao2 = "'" + financeiro.Observacao2 + "'";

            if (Descricao == "''") Descricao = "NULL";
            if (Setor == "''") Setor = "NULL";
            if (Categoria == "''") Categoria = "NULL";
            if (Data_vencimento == "''") Data_vencimento = "NULL";
            if (Data_pagamento == "''") Data_pagamento = "NULL";
            if (Pago == "''") Pago = "NULL";
            if (Recebido == "''") Recebido = "NULL";
            if (Observacao1 == "''") Observacao1 = "NULL";
            if (Observacao2 == "''") Observacao2 = "NULL";

            command = new MySqlCommand("INSERT INTO sige.lancamentos (nome, descricao, setor, categoria, valor, data_vencimento, data_pagamento, data_registro, pago, recebido, observacao1, observacao2) VALUES (" + Nome + "," + Descricao + "," + Setor + "," + Categoria + "," + Valor + "," + Data_vencimento + "," + Data_pagamento + "," + Data_registro + "," + Pago + "," + Recebido + "," + Observacao1 + "," + Observacao2 + ");"
                + "SELECT LAST_INSERT_ID()", connection);

            connection.Open();

            command.ExecuteScalar();
            long id = command.LastInsertedId;

            connection.Close();

            financeiro.Id = int.Parse(id.ToString());

            return financeiro;
        }

        public Financeiro UpdateFinanceiro(int id,Financeiro financeiro)
        {
            MySqlCommand command;

            financeiro.Id = id;

            string Nome = "'" + financeiro.Nome + "'";
            string Descricao = "'" + financeiro.Descricao + "'";
            string Setor = "'" + financeiro.Setor + "'";
            string Categoria = "'" + financeiro.Categoria + "'";
            string Valor = financeiro.Valor.ToString().Replace(",", ".");
            string Data_vencimento = "'" + financeiro.Data_vencimento.ToString() + "'";
            string Data_pagamento = "'" + financeiro.Data_pagamento.ToString() + "'";
            string Data_registro = "'" + financeiro.Data_registro.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Pago = "'" + financeiro.Pago + "'";
            string Recebido = "'" + financeiro.Recebido + "'";
            string Observacao1 = "'" + financeiro.Observacao1 + "'";
            string Observacao2 = "'" + financeiro.Observacao2 + "'";

            if (Descricao == "''") Descricao = "NULL";
            if (Setor == "''") Setor = "NULL";
            if (Categoria == "''") Categoria = "NULL";
            if (Data_vencimento == "''") Data_vencimento = "NULL";
            if (Data_pagamento == "''") Data_pagamento = "NULL";
            if (Pago == "''") Pago = "NULL";
            if (Recebido == "''") Recebido = "NULL";
            if (Observacao1 == "''") Observacao1 = "NULL";
            if (Observacao2 == "''") Observacao2 = "NULL";

            command = new MySqlCommand("UPDATE sige.lancamentos SET nome=" + Nome + ", descricao = " + Descricao + ", setor = " + Setor + ", categoria = " + Categoria + ", valor = " + Valor + ", data_vencimento = " + Data_vencimento + ", data_pagamento = " + Data_pagamento + ", data_registro = " + Data_registro + ", pago = " + Pago + ", recebido = " + Recebido + ", observacao1 = " + Observacao1 + ", observacao2 = " + Observacao2 + " WHERE id = " + id, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            return financeiro;
        }

        public void DeleteFinanceiro(int id)
        {
            MySqlCommand command;

            command = new MySqlCommand("DELETE FROM sige.lancamentos WHERE id = " + id, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

        #region . Funcionario .

        public IEnumerable<Funcionario> GetFuncionarios(int Id)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            MySqlCommand command;

            if (Id == 0)
            {
                command = new MySqlCommand("SELECT id, nome, cpf, solicitacao_inicio_ferias, solicitacao_fim_ferias FROM sige.funcionarios_financeiro", connection);
            }
            else
            {
                command = new MySqlCommand("SELECT id, nome, cpf, solicitacao_inicio_ferias, solicitacao_fim_ferias FROM sige.funcionarios_financeiro WHERE id = " + Id, connection);
            }

            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]);
                    string nome = reader["nome"] == DBNull.Value ? "" : Convert.ToString(reader["nome"]);
                    string cpf = reader["cpf"] == DBNull.Value ? "" : Convert.ToString(reader["cpf"]);
                    DateTime solicitacao_inicio_ferias = (reader["solicitacao_inicio_ferias"] == DBNull.Value) ? DateTime.Now : ((DateTime)reader["solicitacao_inicio_ferias"]);
                    DateTime solicitacao_fim_ferias = (reader["solicitacao_fim_ferias"] == DBNull.Value) ? DateTime.Now : ((DateTime)reader["solicitacao_fim_ferias"]);

                    Funcionario funcionario = new Funcionario(id, nome, cpf, solicitacao_inicio_ferias, solicitacao_fim_ferias);
                    funcionarios.Add(funcionario);
                }
            }

            connection.Close();
            return funcionarios;
        }

        public Funcionario CreateFuncionario(Funcionario funcionario)
        {  
            #region .: Tratamento de dados :.
            string Nome = "'" + funcionario.Nome + "'";
            string Cpf = "'" + funcionario.Cpf + "'";
            string Solicitacao_inicio_ferias = "'" + funcionario.Solicitacao_inicio_ferias.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Solicitacao_fim_ferias = "'" + funcionario.Solicitacao_fim_ferias.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            if (Nome == "''") Nome = "NULL";
            if (Cpf == "''") Cpf = "NULL";
            if (Solicitacao_inicio_ferias == "''") Solicitacao_inicio_ferias = "NULL";
            if (Solicitacao_fim_ferias == "''") Solicitacao_fim_ferias = "NULL";
            #endregion

            #region .: Conexao :.
            MySqlCommand command;

            command = new MySqlCommand("INSERT INTO sige.funcionarios_financeiro (nome, cpf, solicitacao_inicio_ferias, solicitacao_fim_ferias) VALUES (" 
                + Nome + "," + Cpf + "," + Solicitacao_inicio_ferias + "," + Solicitacao_fim_ferias + ");"
                + "SELECT LAST_INSERT_ID()", connection);

            connection.Open();

            command.ExecuteScalar();
            long id = command.LastInsertedId;

            connection.Close();

            funcionario.Id = int.Parse(id.ToString());
            #endregion

            return funcionario;
        }

        public Funcionario UpdateFuncionario(int id, Funcionario funcionario)
        {
            #region .: Tratamento de dados :.
            funcionario.Id = id;
            string Nome = "'" + funcionario.Nome + "'";
            string Cpf = "'" + funcionario.Cpf + "'";
            string Solicitacao_inicio_ferias = "'" + funcionario.Solicitacao_inicio_ferias.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Solicitacao_fim_ferias = "'" + funcionario.Solicitacao_fim_ferias.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            if (Nome == "''") Nome = "NULL";
            if (Cpf == "''") Cpf = "NULL";
            if (Solicitacao_inicio_ferias == "''") Solicitacao_inicio_ferias = "NULL";
            if (Solicitacao_fim_ferias == "''") Solicitacao_fim_ferias = "NULL";
            #endregion

            #region .: Conexao :.
            MySqlCommand command;

            command = new MySqlCommand("UPDATE sige.funcionarios_financeiro SET nome = " + Nome
                + ", cpf = " + Cpf
                + ", solicitacao_inicio_ferias = " + Solicitacao_inicio_ferias
                + ", solicitacao_fim_ferias = " + Solicitacao_fim_ferias
                + "WHERE id = " + id, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            #endregion

            return funcionario;
        }

        public void DeleteFuncionario(int id)
        {
            MySqlCommand command;

            command = new MySqlCommand("DELETE FROM sige.funcionarios_financeiro WHERE id = " + id, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

        #region . Galpao .

        public IEnumerable<Galpao> GetGalpoes(int Id)
        {
            List<Galpao> galpoes = new List<Galpao>();

            MySqlCommand command;

            if (Id == 0)
            {
                command = new MySqlCommand("SELECT id, nome, metros_quadrados, data_inicio, data_fim, valor_aluguel FROM sige.galpoes_aluguel", connection);
            }
            else
            {
                command = new MySqlCommand("SELECT id, nome, metros_quadrados, data_inicio, data_fim, valor_aluguel FROM sige.galpoes_aluguel WHERE id = " + Id, connection);
            }

            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]);
                    string nome = reader["nome"] == DBNull.Value ? "" : Convert.ToString(reader["nome"]);
                    string metros_quadrados = reader["metros_quadrados"] == DBNull.Value ? "" : Convert.ToString(reader["metros_quadrados"]);
                    DateTime data_inicio = (reader["data_inicio"] == DBNull.Value) ? DateTime.Now : ((DateTime)reader["data_inicio"]);
                    DateTime data_fim = (reader["data_fim"] == DBNull.Value) ? DateTime.Now : ((DateTime)reader["data_fim"]);
                    decimal valor_aluguel = reader["valor_aluguel"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["valor_aluguel"]);

                    Galpao galpao = new Galpao(id, nome, metros_quadrados, data_inicio, data_fim, valor_aluguel);
                    galpoes.Add(galpao);
                }
            }

            connection.Close();
            return galpoes;
        }

        public Galpao CreateGalpao(Galpao galpao)
        {
            #region .: Tratamento de dados :.
            string Nome = "'" + galpao.Nome + "'";
            string Metros_quadrados = "'" + galpao.Metros_quadrados + "'";
            string Data_inicio = "'" + galpao.Data_inicio.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Data_fim = "'" + galpao.Data_fim.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Valor_aluguel = galpao.Valor_aluguel.ToString().Replace(",",".");

            if (Nome == "''") Nome = "NULL";
            if (Metros_quadrados == "''") Metros_quadrados = "NULL";
            if (Data_inicio == "''") Data_inicio = "NULL";
            if (Data_fim == "''") Data_fim = "NULL";
            if (Valor_aluguel == "''") Data_fim = "NULL";
            #endregion

            #region .: Conexao :.
            MySqlCommand command;

            command = new MySqlCommand("INSERT INTO sige.galpoes_aluguel (nome, Metros_quadrados, Data_inicio, Data_fim, Valor_aluguel) VALUES ("
                + Nome + "," + Metros_quadrados + "," + Data_inicio + "," + Data_fim + "," + Valor_aluguel + ");"
                + "SELECT LAST_INSERT_ID()", connection);

            connection.Open();

            command.ExecuteScalar();
            long id = command.LastInsertedId;

            connection.Close();

            galpao.Id = int.Parse(id.ToString());
            #endregion

            return galpao;
        }

        public Galpao UpdateGalpao(int id, Galpao galpao)
        {
            #region .: Tratamento de dados :.
            galpao.Id = id;
            string Nome = "'" + galpao.Nome + "'";
            string Metros_quadrados = "'" + galpao.Metros_quadrados + "'";
            string Data_inicio = "'" + galpao.Data_inicio.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Data_fim = "'" + galpao.Data_fim.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string Valor_aluguel = galpao.Valor_aluguel.ToString().Replace(",",".");

            if (Nome == "''") Nome = "NULL";
            if (Metros_quadrados == "''") Metros_quadrados = "NULL";
            if (Data_inicio == "''") Data_inicio = "NULL";
            if (Data_fim == "''") Data_fim = "NULL";
            if (Valor_aluguel == "''") Data_fim = "NULL";
            #endregion

            #region .: Conexao :.
            MySqlCommand command;

            command = new MySqlCommand("UPDATE sige.galpoes_aluguel SET nome = " + Nome
                + ", metros_quadrados = " + Metros_quadrados
                + ", data_inicio = " + Data_inicio
                + ", data_fim = " + Data_fim
                + ", valor_aluguel = " + Valor_aluguel
                + "WHERE id = " + id, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            #endregion

            return galpao;
        }

        public void DeleteGalpao(int id)
        {
            MySqlCommand command;

            command = new MySqlCommand("DELETE FROM sige.galpoes_aluguel WHERE id = " + id, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

    }
}
