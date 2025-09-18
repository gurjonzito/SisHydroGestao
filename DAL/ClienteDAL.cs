using Dapper;
using model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ClienteDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public void InserirCliente(Cliente cliente)
        {
            // Inserir o novo cliente na tabela
            sql = "INSERT INTO cliente (nome, cpf_cnpj, telefone, rua, numero, bairro, cidade, estado, observacoes) VALUES (@Nome, @CpfCnpj, @Telefone, @Rua, @Numero, @Bairro, @Cidade, @Estado, @Observacoes)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CpfCnpj", cliente.CpfCnpj);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@Rua", cliente.Rua);
            cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
            cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", cliente.estado.ToString());
            cmd.Parameters.AddWithValue("@Observacoes", cliente.Observacoes);

            cmd.ExecuteNonQuery();

            // Fechar a conexão após a execução
            mConn.FecharConexao();
        }

        public bool ExisteCpfCnpj(string cpfCnpj)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT COUNT(1) FROM cliente WHERE cpf_cnpj = @CpfCnpj";
                return dbConnection.ExecuteScalar<int>(query, new { cpfCnpj }) > 0;
            }
        }

        public void EditarCliente(Cliente cliente)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE cliente SET nome = @Nome, cpf_cnpj = @CpfCnpj, telefone = @Telefone, rua = @Rua, numero = @Numero, bairro = @Bairro, cidade = @Cidade, estado = @Estado, observacoes = @Observacoes WHERE cli_id = @cli_id";
                dbConnection.Execute(query, cliente);
            }
        }

        public List<Cliente> GetClientes()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT cli_id, nome, cpf_cnpj, telefone, rua, numero, bairro, cidade, estado, observacoes FROM cliente";
                return dbConnection.Query<Cliente>(query).AsList();
            }
        }
    }
}
