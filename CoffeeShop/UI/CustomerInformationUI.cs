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
    public partial class CustomerInformationUI : Form
    {
        CustomerInfoManager _customerManager = new CustomerInfoManager();

        public CustomerInformationUI()
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

                if (_customerManager.IsCustomerExist(customerNameTextBox.Text))
                {
                    MessageBox.Show("This Customer Already Exist..!");
                    return;
                }

                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("Please Enter Valid Mobile Number..!");
                    return;
                }

                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("Please Enter Customer Address..!");
                    return;
                }

                if(_customerManager.AddCustomer(customerNameTextBox.Text, contactTextBox.Text, addressTextBox.Text))
                {
                    showDataGridView.DataSource = _customerManager.Display();
                    MessageBox.Show("Customer Added Successfully...!");
                }
                else
                {
                    MessageBox.Show("Not Added...!");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = _customerManager.Display();

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
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }  
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation
                if(String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter a ID for Update...!");
                    return;
                }

                DataTable result = _customerManager.SearchCustomerById(Convert.ToInt32(idTextBox.Text));
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found with this ID");
                    return;
                }

                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter Name...!");
                    return;
                }
                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("Please Enter contact number...!");
                    return;
                }
                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("Please Enter Address...!");
                    return;
                }

                DataTable isNameExist = _customerManager.SearchCustomerByName(customerNameTextBox.Text);

                if (isNameExist.Rows.Count > 0 && (Convert.ToInt32(isNameExist.Rows[0]["ID"]) != Convert.ToInt32(idTextBox.Text)))
                {
                    MessageBox.Show("Customer Name already Exist...!");
                    return;
                }

                //Update
                if(_customerManager.UpdateCustomer(Convert.ToInt32(idTextBox.Text),customerNameTextBox.Text, contactTextBox.Text, addressTextBox.Text))
                {
                    showDataGridView.DataSource = _customerManager.Display();
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

                DataTable result = _customerManager.SearchCustomerByName(customerNameTextBox.Text);

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
            catch(Exception exception)
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
                    MessageBox.Show("Please Enter ID...!");
                    return;
                }

                DataTable result = _customerManager.SearchCustomerById(Convert.ToInt32(idTextBox.Text));

                if (result.Rows.Count > 0)
                {
                    bool isDeleted = _customerManager.DeleteCustomer(Convert.ToInt32(idTextBox.Text));

                    showDataGridView.DataSource = _customerManager.Display();

                    if (isDeleted)
                        MessageBox.Show("Delete Successfully...!");
                    else
                        MessageBox.Show("Not Deleted..!");
                }
                else
                {
                    MessageBox.Show("No Data Found with this ID...!");
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
