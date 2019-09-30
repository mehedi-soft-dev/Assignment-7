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
    public class ItemInfoManager
    {
        ItemInfoRepository _itemInfoRepository = new ItemInfoRepository();

        public bool AddItem(string name, int price)
        {
            return _itemInfoRepository.AddItem(name, price);
        }

        public bool IsItemrExist(string name)
        {
            return _itemInfoRepository.IsItemExist(name);
        }

        public DataTable Display()
        {
            return _itemInfoRepository.Display();
        }

        public DataTable SearchItemByName(string name)
        {
            return _itemInfoRepository.SearchItemByName(name);
        }

        public DataTable SearchItemById(int id)
        {
            return _itemInfoRepository.SearchItemById(id);
        }

        public bool DeleteItem(int id)
        {
            return _itemInfoRepository.DeleteItem(id);
        }

        public bool UpdateItem(int id, string name, int price)
        {
            return _itemInfoRepository.UpdateItem(id, name, price);
        }
    }
}
