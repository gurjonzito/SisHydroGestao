using Dapper;
using model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class PagamentoDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public void InserirPagamento(Pagamento pagamento)
        {
            sql = "INSERT INTO pagamento (forma_pagto, data_pagto, valor_pago, parcelado, situacao, ser_id) VALUES (@FormaPagto, @DataPagto, @ValorPago, @Parcelado, @Situacao, @IdServico)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@FormaPagto", pagamento.FormaPagamento);
            cmd.Parameters.AddWithValue("@DataPagto", pagamento.DataPagamento);
            cmd.Parameters.AddWithValue("@ValorPago", pagamento.ValorPago);
            cmd.Parameters.AddWithValue("@Parcelado", pagamento.Parcelado);
            cmd.Parameters.AddWithValue("@Situacao", pagamento.situacao.ToString());
            cmd.Parameters.AddWithValue("@IdServico", pagamento.ser_id);

            cmd.ExecuteNonQuery();

            mConn.FecharConexao();
        }

        public void EditarPagamento(Pagamento pagamento)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE pagamento SET forma_pagto = @FormaPagto, data_pagto = @DataPagto, valor_pago = @ValorPago, parcelado = @Parcelado, situacao = @Situacao, ser_id = @IdServico WHERE pag_id = @pag_id";
                dbConnection.Execute(query, pagamento);
            }
        }

        public List<Pagamento> GetPagamentos()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT pag_id, forma_pagto, data_pagto, valor_pago, parcelado, situacao, ser_id FROM pagamento";
                return dbConnection.Query<Pagamento>(query).AsList();
            }
        }
    }
}
