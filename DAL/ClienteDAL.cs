using model;
using MySql.Data.MySqlClient;
using System;
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

        public void EditarCliente(Cliente cliente)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE cliente SET nome = @Nome, CpfCnpj = @CpfCnpj, Telefone = @Telefone, Endereco = @Endereco WHERE cli_id = @Id";
                dbConnection.Execute(query, cliente);
            }
        }
    }
}
