using Dapper;
using model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class OrcamentoDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public void InserirOrcamento(Orcamento orcamento)
        {
            sql = "INSERT INTO orcamento (data, descricao, valor_estimado, cli_id) VALUES (@Data, @Descricao, @ValorEstimado, @IdCliente)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@Data", orcamento.Data);
            cmd.Parameters.AddWithValue("@Descricao", orcamento.Descricao);
            cmd.Parameters.AddWithValue("@ValorEstimado", orcamento.ValorEstimado);
            cmd.Parameters.AddWithValue("@IdCliente", orcamento.cli_id);

            cmd.ExecuteNonQuery();

            mConn.FecharConexao();
        }

        public void EditarOrcamento(Orcamento orcamento)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE orcamento SET data = @Data, descricao = @Descricao, valor_estimado = @ValorEstimado, cli_id = @IdCliente WHERE orc_id = @orc_id";
                dbConnection.Execute(query, orcamento);
            }
        }

        public List<Orcamento> GetOrcamentos()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT orc_id, data, descricao, valor_estimado, cli_id FROM orcamento";
                return dbConnection.Query<Orcamento>(query).AsList();
            }
        }
    }
}
