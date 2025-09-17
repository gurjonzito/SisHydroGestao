using MySql.Data.MySqlClient;

namespace DAL
{
    public class ConexaoDB
    {
        public MySqlConnection mConn;

        public string conec = "server=hydro_temp.mysql.dbaas.com.br;database=hydro_temp;user=hydro_temp;password=noiRBerserk@91;";

        public MySqlConnection AbrirConexao()
        {
            mConn = new MySqlConnection(conec);
            mConn.Open();

            return mConn;
        }
        public void FecharConexao()
        {
            mConn = new MySqlConnection(conec);
            mConn.Clone();
            mConn.Dispose();
            mConn.ClearAllPoolsAsync();
        }
    }
}
