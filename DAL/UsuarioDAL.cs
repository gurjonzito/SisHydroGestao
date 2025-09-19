using Dapper;
using model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class UsuarioDAL
    {
        ConexaoDB mConn = new ConexaoDB();
        string sql;
        MySqlCommand cmd;

        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public string ObterSenhaCriptografada(string usuario)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT senha FROM usuario WHERE login = @Login";
                return dbConnection.ExecuteScalar<string>(query, new { usuario });
            }
        }

        public void InserirUsuario(Usuario usuario)
        {
            string senhaNaoCriptografada = usuario.Senha;
            string senhaCriptografada = HashPassword(senhaNaoCriptografada);
            usuario.Senha = senhaCriptografada;

            sql = "INSERT INTO usuario (nome, email, login, senha) VALUES (@Nome, @Email, @Login, @Senha)";
            cmd = new MySqlCommand(sql, mConn.AbrirConexao());

            cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@Email", usuario.Email);
            cmd.Parameters.AddWithValue("@Login", usuario.Login);
            cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

            cmd.ExecuteNonQuery();

            mConn.FecharConexao();
        }

        public void EditarUsuario(Usuario usuario)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "UPDATE usuario SET nome = @Nome, email = @Email, login = @Login, senha = @Senha WHERE user_id = @user_id";
                dbConnection.Execute(query, usuario);
            }
        }

        public List<Usuario> GetUsuarios()
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT * FROM usuario";
                return dbConnection.Query<Usuario>(query).AsList();
            }
        }

        public Usuario ObterUsuarioPorLogin(string usuario)
        {
            using (IDbConnection dbConnection = mConn.AbrirConexao())
            {
                string query = "SELECT * FROM usuario WHERE login = @Login";
                return dbConnection.QueryFirstOrDefault<Usuario>(query, new { usuario });
            }
        }
    }
}
