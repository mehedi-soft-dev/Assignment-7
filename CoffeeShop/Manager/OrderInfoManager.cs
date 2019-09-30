using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Repository;

namespace CoffeeShop.Manager
{
    public class OrderInfoManager
    {
        OrderInfoRepository _orderRepository = new OrderInfoRepository();
        CustomerInfoRepository _customerRepository = new CustomerInfoRepository();
        ItemInfoRepository _itemRepository = new ItemInfoRepository();

        public bool AddOrder(string name, string item, int qty)
        {
            String customerName, contact, address, ItemName;
            int quantity, price, totalBill;

            DataTable searchCustomer = _customerRepository.SearchCustomerByName(name);
            DataTable searchItem = _itemRepository.SearchItemByName(item);

            customerName = name;
            contact = searchCustomer.Rows[0]["Contact"].ToString();
            address = searchCustomer.Rows[0]["Address"].ToString();
            ItemName = item;
            price = Convert.ToInt32(searchItem.Rows[0]["Price"].ToString());
            quantity = qty;
            totalBill = price * quantity;

            return _orderRepository.AddOrder(name, contact, address, item, price, quantity, totalBill);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public bool IsCustomerExist(string name)
        {
            return _customerRepository.IsCustomerExist(name);
        }

        public bool IsItemExist(string name)
        {
            return _itemRepository.IsItemExist(name);
        }

        public bool IsOrderExist(int id)
        {
            return _orderRepository.IsOrderExist(id);
        }

        public bool UpdateOrder(int id, string name, string item, int qty)
        {
            String customerName, contact, address, ItemName;
            int customerId, quantity, price, totalBill;

            DataTable searchCustomer = _customerRepository.SearchCustomerByName(name);
            DataTable searchItem = _itemRepository.SearchItemByName(item);

            customerId = id;
            customerName = name;
            contact = searchCustomer.Rows[0]["Contact"].ToString();
            address = searchCustomer.Rows[0]["Address"].ToString();
            ItemName = item;
            price = Convert.ToInt32(searchItem.Rows[0]["Price"].ToString());
            quantity = qty;
            totalBill = price * quantity;

            return _orderRepository.UpdateOrder(id, name, contact, address, item, price, quantity, totalBill);
        }

        public DataTable SearchOrderByName(string name)
        {
            return _orderRepository.SearchOrderByName(name);
        }

        public DataTable SearchOrderById(int id)
        {
            return _orderRepository.SearchOrderById(id);
        }

        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}
