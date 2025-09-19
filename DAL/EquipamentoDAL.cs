using Dapper;
using model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class EquipamentoDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public void InserirEquipamento(Equipamento equipamento)
        {
            sql = "INSERT INTO equipamento (nome, codigo, qtde_estoque, preco_compra, fabricante, entrada) VALUES (@Nome, @Codigo, @QtdeEstoque, @PrecoCompra, @Fabricante, @Entrada)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@Nome", equipamento.Nome);
            cmd.Parameters.AddWithValue("@Codigo", equipamento.Codigo);
            cmd.Parameters.AddWithValue("@QtdeEstoque", equipamento.QtdeEstoque);
            cmd.Parameters.AddWithValue("@PrecoCompra", equipamento.PrecoCompra);
            cmd.Parameters.AddWithValue("@Fabricante", equipamento.Fabricante);
            cmd.Parameters.AddWithValue("@Entrada", equipamento.Entrada);

            cmd.ExecuteNonQuery();

            mConn.FecharConexao();
        }

        public void EditarEquipamento(Equipamento equipamento)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE equipamento SET nome = @Nome, codigo = @Codigo, qtde_estoque = @QtdeEstoque, preco_compra = @PrecoCompra, fabricante = @Fabricante, entrada = @Entrada WHERE equ_id = @equ_id";
                dbConnection.Execute(query, equipamento);
            }
        }

        public List<Equipamento> GetEquipamentos()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT equ_id, nome, codigo, qtde_estoque, preco_compra, fabricante, entrada FROM equipamento";
                return dbConnection.Query<Equipamento>(query).AsList();
            }
        }
    }
}
