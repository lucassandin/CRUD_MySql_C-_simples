using CRUD.Model.DB;
using CRUD.Model.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.ModelsDao
{
    public class FilhoDao
    {
        private string table = "filho";
        private string tablePai = "pai";

        public DataTable RetornaTodos()
        {
            try
            {
                string sql =
                    $"select "+
                    $"{table}.id as filhoId,  " +
                    $"{table}.nome as filhoNome,  " +
                    $"{table}.Idade as filhoIdade,  " +
                    $"{tablePai}.id as paiId, " +
                    $"{tablePai}.nome as paiNome, " +
                    $"{tablePai}.cpf as paiCpf " +
                    $"from {table} " +
                    $"join {tablePai} on {tablePai}.id = {table}.idPaiFk";

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

        public void Insert(Filho filho)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql =
                    $"insert into {table} (nome, idade, idPaiFk) " +
                    "values (@nome, @idade, @idPaiFk);";

                var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@nome", filho.Nome);
                command.Parameters.AddWithValue("@idade", filho.Idade);
                command.Parameters.AddWithValue("@idPaiFk", filho.Pai.Id);

                command.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(Filho filho)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql =
                    $"update {table} set " +
                    "nome = @nome, " +
                    "idade = @idade, " +
                    "idPaiFk = @idPaiFk " +
                    "where id = @id;";

                var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@nome", filho.Nome);
                command.Parameters.AddWithValue("@idade", filho.Idade);
                command.Parameters.AddWithValue("@idPaiFk", filho.Pai.Id);
                command.Parameters.AddWithValue("@id", filho.Id);

                command.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetById(int id)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql =
                    $"select " +
                    $"{table}.id as filhoId,  " +
                    $"{table}.nome as filhoNome,  " +
                    $"{table}.Idade as filhoIdade,  " +
                    $"{tablePai}.id as paiId, " +
                    $"{tablePai}.nome as paiNome, " +
                    $"{tablePai}.cpf as paiCpf " +
                    $"from {table} " +
                    $"join {tablePai} on {tablePai}.id = {table}.idPaiFk " +
                    $"where {table}.id = @id";

                var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

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

        public void Delete(int id)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql =
                    $"delete from {table} where id = @id";

                var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
