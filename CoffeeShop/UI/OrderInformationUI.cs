using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Manager;

namespace CoffeeShop
{
    public partial class OrderInformationUI : Form
    {
        OrderInfoManager _orderManager = new OrderInfoManager();
        CustomerInfoManager _customerInfoManager = new CustomerInfoManager();

        public OrderInformationUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter Customer Name..!");
                    return;
                }

                if (!_orderManager.IsCustomerExist(customerNameTextBox.Text))
                {
                    MessageBox.Show("No Customer found whith this name...!");
                    return;
                }

                if (String.IsNullOrEmpty(itemNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter an Item...!");
                    return;
                }

                if (!_orderManager.IsItemExist(itemNameTextBox.Text))
                {
                    MessageBox.Show("No Item found whith this Name...!");
                    return;
                }

                if (String.IsNullOrEmpty(quantityTextBox.Text))
                {
                    MessageBox.Show("Please EnterQuantity..!");
                    return;
                }

                if(_orderManager.AddOrder(customerNameTextBox.Text, itemNameTextBox.Text, Convert.ToInt32(quantityTextBox.Text)))
                {
                    showDataGridView.DataSource = _orderManager.Display();
                    MessageBox.Show("Order Completed..!");
                }
                else
                {
                    MessageBox.Show("Order Not Completed..!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = _orderManager.Display();
                if (result.Rows.Count > 0)
                {
                    showDataGridView.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No Data Found");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter ID..!");
                    return;
                }

                bool isExist = _orderManager.IsOrderExist(Convert.ToInt32(idTextBox.Text));

                if (!isExist)
                {
                    MessageBox.Show("No Order Information is found with this ID..!");
                    return;
                }

                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please EnterName!");
                    return;
                }

                if (!_orderManager.IsCustomerExist(customerNameTextBox.Text))
                {
                    MessageBox.Show("No Customer found whith this name...!");
                    return;
                }

                if (String.IsNullOrEmpty(itemNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter an Item!");
                    return;
                }

                if (!_orderManager.IsItemExist(itemNameTextBox.Text))
                {
                    MessageBox.Show("No Item found whith this Name...!");
                    return;
                }

                if (String.IsNullOrEmpty(quantityTextBox.Text))
                {
                    MessageBox.Show("Please Enter Quantity..!");
                    return;
                }

                if (_orderManager.UpdateOrder(Convert.ToInt32(idTextBox.Text), customerNameTextBox.Text, itemNameTextBox.Text, Convert.ToInt32(quantityTextBox.Text)))
                {
                    showDataGridView.DataSource = _orderManager.Display();
                    MessageBox.Show("Updated Successfully...!");
                }
                else
                {
                    MessageBox.Show("Not Updated...!");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter a Name...!");
                    return;
                }

                DataTable result = _orderManager.SearchOrderByName(customerNameTextBox.Text);

                if (result.Rows.Count > 0)
                {
                    showDataGridView.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No Data Found...!");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter a ID...!");
                    return;
                }

                DataTable result = _orderManager.SearchOrderById (Convert.ToInt32(idTextBox.Text));

                if (result.Rows.Count > 0)
                {
                    bool isDeleted = _orderManager.DeleteOrder(Convert.ToInt32(idTextBox.Text));

                    showDataGridView.DataSource = _orderManager.Display();

                    if (isDeleted)
                        MessageBox.Show("Delete Successfully...!");
                    else
                        MessageBox.Show("Not Deleted..!");
                }
                else
                {
                    MessageBox.Show("No Data Found With This ID...!");
                    return;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
