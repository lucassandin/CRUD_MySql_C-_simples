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
    public class PaiDao
    {
        private string table = "pai";

        public DataTable RetornaTodos()
        {
            try
            {
                string sql = $"select * from {table}";

                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                var command = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                connection.Close();

                return dt;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Pai pai)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql =
                    $"insert into {table} (nome, cpf) " +
                    "values (@nome, @cpf);";

                var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@nome", pai.Nome);
                command.Parameters.AddWithValue("@cpf", pai.Cpf);

                command.ExecuteNonQuery();

                connection.Close();

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(Pai pai)
        {
            try
            {
                var connection = new MySqlConnection(Dao.connectionstring);
                connection.Open();

                string sql =
                    $"update {table} set " +
                    "nome = @nome, " +
                    "cpf = @cpf " +
                    "where id = @id;";

                var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@nome", pai.Nome);
                command.Parameters.AddWithValue("@cpf", pai.Cpf);
                command.Parameters.AddWithValue("@id", pai.Id);

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
                    $"select * from {table} where id = @id";

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
