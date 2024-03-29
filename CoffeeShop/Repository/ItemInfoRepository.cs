﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository
{
    public class ItemInfoRepository
    {
        public bool AddItem(string name, int price)
        {
            string commandString = @"INSERT INTO Items (Name, Price) VALUES('" + name + "'," + price + ")";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isAdded = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isAdded;
        }

        public DataTable Display()
        {
            string commandString = @"SELECT * FROM Items";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool IsItemExist(string name)
        {
            string commandString = @"SELECT * FROM Items WHERE Name='" + name + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            DataTable result = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            if (result.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataTable SearchItemByName(string name)
        {
            string commandString = @"SELECT * FROM Items WHERE Name = '" + name + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable SearchItemById(int id)
        {
            string commandString = @"SELECT * FROM Items WHERE ID = '" + id + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool DeleteItem(int id)
        {
            string commandString = @"DELETE FROM Items WHERE ID = " + id + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isDeleted = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isDeleted;
        }

        public bool UpdateItem(int id, string name, int price)
        {
            string commandString = @"UPDATE Items SET Name = '" + name + "', Price = " + price + " WHERE ID = " + id + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isUpdated = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isUpdated;
        }
    }
}
