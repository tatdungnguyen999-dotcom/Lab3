using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinFormUI
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerService _customerService;
        public CustomerForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            dataGridView1.DataSource = _customerService.GetAllCustomers();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text
            };
            _customerService.AddCustomer(customer);
            MessageBox.Show("Customer added successfully!");
            LoadCustomers();
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCustomerId.Text, out int customerId))
            {
                var customer = _customerService.GetCustomer(customerId);
                if (customer != null)
                {
                    txtName.Text = customer.Name;
                    txtEmail.Text = customer.Email;
                }
                else
                {
                    MessageBox.Show("Customer not found!");
                }
            }
        }
    }
}
