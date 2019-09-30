using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository
{
    public class OrderInfoRepository
    {
        public bool AddOrder(string name, string contact, string address, string item, int price, int quantity, int totalBill)
        {
            string commandString = @"INSERT INTO Orders (Name, Contact, Address, Item, Price, Quantity, TotalBill) VALUES('" + name + "','" + contact + "','" + address + "', '" + item + "', " + price + ", " + quantity + ", " + totalBill + ")";
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
            string commandString = @"SELECT * FROM Orders";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool IsOrderExist(int id)
        {
            string commandString = @"SELECT * FROM Orders WHERE ID='" + id + "'";
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

        public DataTable SearchOrderByName(string name)
        {
            string commandString = @"SELECT * FROM Orders WHERE Name = '" + name + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable SearchOrderById(int id)
        {
            string commandString = @"SELECT * FROM Orders WHERE ID = '" + id + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }



        public bool DeleteOrder(int id)
        {
            string commandString = @"DELETE FROM Orders WHERE ID = " + id + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isDeleted = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isDeleted;
        }

        public bool UpdateOrder(int id, string name, string contact, string address, string item, int price, int quantity, int totalBill)
        {
            string commandString = @"UPDATE Orders SET Name = '" + name + "', Contact = '" + contact + "', Address = '" + address + "', Item = '" + item + "', Price = " + price + ", Quantity = " + quantity + ", TotalBill = " + totalBill + " WHERE ID = " + id + "";
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
