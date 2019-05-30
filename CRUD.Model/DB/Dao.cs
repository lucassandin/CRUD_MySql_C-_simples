using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.DB
{
    public class Dao
    {
        public static string connectionstring = "server=localhost;port=3306;database=crud_simples;uid=root;pwd=root;";

        public static MySqlConnection connection = null;
        public static MySqlCommand command;

        // retorna todos
        public static DataTable GetData(string sql)
        {
            try
            {
                connection = new MySqlConnection(connectionstring);
                connection.Open();
                command = new MySqlCommand(sql, connection);

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
