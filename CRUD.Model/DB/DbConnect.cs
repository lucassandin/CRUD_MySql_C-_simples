using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.DB
{
    public class DbConnect
    {
        public string server = "localhost";
        public string port = "3306";
        public string dbName = "crud";
        public string user = "root";
        public string pass = "root";

        public string mErro = "";

        public MySqlConnection conn;

        public DbConnect()
        {
            GetConexao();
        }

        // Faz a Conexao com o Banco de Dados
        private void GetConexao()
        {
            try
            {
                string connectionString = $"Server={this.server};Port={this.port};Database={this.dbName};Uid={this.user};Pwd={this.pass}";

                conn = new MySqlConnection(connectionString);
            }
            catch (Exception erro)
            {
                mErro = erro.Message;
                conn = null;
            }
        }

        // Verifica se existe erro
        public Boolean ExisteErro()
        {
            if (mErro.Length > 0)
            {
                return true;
            }
            return false;
        }

        // Abre conexao com o Banco de Dados
        public Boolean OpenConexao()
        {
            try
            {
                conn.Open();
            }
            catch (Exception erro)
            {
                this.mErro = erro.Message;
                return false;
            }

            return true;
        }

        // Fecha conexao com o Banco de Dados
        public void CloseConexao()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
