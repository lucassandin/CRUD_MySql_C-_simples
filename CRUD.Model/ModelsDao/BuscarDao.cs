using CRUD.Model.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.ModelsDao
{
    public class BuscarDao
    {
        public DataTable RetornaTodos()
        {
            try
            {
                string sql = $"select " +
                    $"filho.id as filhoId, "+
                    $"filho.nome as filhoNome , "+
                    $"filho.Idade as filhoIdade, "+
                    $"pai.id as paiId, "+
                    $"pai.nome as paiNome, "+
                    $"pai.cpf as paiCpf "+
                    $"from filho "+
                    $"join pai on pai.id = filho.idPaiFk";

                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                var command = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                connection.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscarPorNome(string tabela, string procurar)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql = "";

                if (tabela == "pai")
                {
                    sql = $"select * from {tabela} where nome like '%" + procurar + "%'";
                } else
                {
                    sql = 
                    $"select "+
                    $"filho.id as filhoId, " +
                    $"filho.nome as filhoNome, " +
                    $"filho.Idade as filhoIdade, " +
                    $"pai.id as paiId, " +
                    $"pai.nome as paiNome, " +
                    $"pai.cpf as paiCpf " +
                    $"from filho " +
                    $"join pai on pai.id = filho.idPaiFk " +
                    $"where filho.nome like '%" + procurar + "%'";
                }

                

                var command = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                connection.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
