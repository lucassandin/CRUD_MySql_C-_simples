﻿using CRUD.Model.DB;
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
        private string tablePai = "pai";
        private string tableFilho = "filho";

        public DataTable RetornaTodos()
        {
            try
            {
                string sql = "";

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
    }
}
