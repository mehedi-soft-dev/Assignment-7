using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Repository;

namespace CoffeeShop.Manager
{
    class CustomerInfoManager
    {
        CustomerInfoRepository _customerRepository = new CustomerInfoRepository();

        public bool AddCustomer(string name, string contact, string address)
        {
            return _customerRepository.AddCustomer(name, contact, address);
        }

        public bool IsCustomerExist(string name)
        {
            return _customerRepository.IsCustomerExist(name);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public DataTable SearchCustomerByName(string name)
        {
            return _customerRepository.SearchCustomerByName(name);
        }

        public DataTable SearchCustomerById(int id)
        {
            return _customerRepository.SearchCustomerById(id);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public bool UpdateCustomer(int id, string name, string contact, string address)
        {
            return _customerRepository.UpdateCustomer(id, name, contact, address);
        }
    }
}
