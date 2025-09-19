using Dapper;
using model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ParcelaDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public void InserirParcela(ParcelaPagamento parcela)
        {
            sql = "INSERT INTO parcela_pagamento (qtde_parcelas, qtde_parcelas_pagas, data_vencimento, valor_total, valor_abatido, situacao, pag_id) VALUES (@QtdeParcelas, @QtdeParcelasPagas, @DataVencimento, @ValorTotal, @ValorAbatido, @Situacao, @IdPagamento)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@QtdeParcelas", parcela.Parcelas);
            cmd.Parameters.AddWithValue("@QtdeParcelasPagas", parcela.ParcelasPagas);
            cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
            cmd.Parameters.AddWithValue("@ValorTotal", parcela.ValorTotal);
            cmd.Parameters.AddWithValue("@ValorAbatido", parcela.ValorAbatido);
            cmd.Parameters.AddWithValue("@Situacao", parcela.situacao.ToString());
            cmd.Parameters.AddWithValue("@IdPagamento", parcela.pag_id);

            cmd.ExecuteNonQuery();

            mConn.FecharConexao();
        }

        public void EditarParcela(ParcelaPagamento parcela)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE parcela_pagamento SET qtde_parcelas = @QtdeParcelas, qtde_parcelas_pagas = @QtdeParcelasPagas, data_vencimento = @DataVencimento, valor_total = @ValorTotal, valor_abatido = @ValorAbatido, situacao = @Situacao, pag_id = @IdPagamento WHERE par_id = @par_id";
                dbConnection.Execute(query, parcela);
            }
        }

        public List<ParcelaPagamento> GetParcelas()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT par_id, qtde_parcelas, qtde_parcelas_pagas, data_vencimento, valor_total, valor_abatido, situacao, pag_id FROM parcela_pagamento";
                return dbConnection.Query<ParcelaPagamento>(query).AsList();
            }
        }
    }
}
