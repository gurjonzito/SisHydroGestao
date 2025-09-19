using Dapper;
using model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ServicoDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public void InserirServico(Servico servico)
        {
            sql = "INSERT INTO servico (tipo, data_execucao, descricao, valor, status, cli_id, orc_id) VALUES (@Tipo, @DataExecucao, @Descricao, @Valor, @Status, @IdCliente, @IdOrcamento)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@Tipo", servico.TipoServico);
            cmd.Parameters.AddWithValue("@DataExecucao", servico.DataExecucao);
            cmd.Parameters.AddWithValue("@Descricao", servico.Descricao);
            cmd.Parameters.AddWithValue("@Valor", servico.Valor);
            cmd.Parameters.AddWithValue("@Status", servico.status.ToString());
            cmd.Parameters.AddWithValue("@IdCliente", servico.cli_id);
            cmd.Parameters.AddWithValue("@IdOrcamento", servico.orc_id);

            cmd.ExecuteNonQuery();

            mConn.FecharConexao();
        }

        public void EditarServico(Servico servico)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE servico SET tipo = @Tipo, data_execucao = @DataExecucao, descricao = @Descricao, valor = @Valor, status = @Status WHERE ser_id = @ser_id";
                dbConnection.Execute(query, servico);
            }
        }

        public List<Servico> GetServicos()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT ser_id, tipo, data_execucao, descricao, valor, status, cli_id, orc_id FROM servico";
                return dbConnection.Query<Servico>(query).AsList();
            }
        }
    }
}
