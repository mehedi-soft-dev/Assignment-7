using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository
{
    public class CustomerInfoRepository
    {
        public bool AddCustomer(string name, string contact, string address)
        {
            string commandString = @"INSERT INTO Customers (Name, Contact, Address) VALUES('" + name + "','" + contact + "','" + address + "')";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isAdded = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isAdded;
        }

        public bool IsCustomerExist(string name)
        {
            string commandString = @"SELECT * FROM Customers WHERE Name='" + name + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable result = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            if (result.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataTable Display()
        {
            string commandString = @"SELECT * FROM Customers";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable SearchCustomerByName(string name)
        {
            string commandString = @"SELECT * FROM Customers WHERE Name = '"+name+"'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;

        }

        public DataTable SearchCustomerById(int id)
        {
            string commandString = @"SELECT * FROM Customers WHERE ID = '" + id + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;

        }

        public bool DeleteCustomer(int id)
        {
            string commandString = @"DELETE FROM Customers WHERE ID = " + id + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isDeleted = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isDeleted;
        }

        public bool UpdateCustomer(int id, string name, string contact, string address)
        {
            string commandString = @"UPDATE Customers SET Name = '" + name + "', Contact = '" + contact + "', address = '" + address + "' WHERE ID = " + id + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection(); ;

            sqlConnection.Open();

            bool isUpdated= connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isUpdated;
        }
    }
}
