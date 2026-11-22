using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm custForm = new CustomerForm();
            custForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
