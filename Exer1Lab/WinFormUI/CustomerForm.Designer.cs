namespace WinFormUI
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtCustomerId = new TextBox();
            lblName = new Label();
            lblEmail = new Label();
            lblCustomerId = new Label();
            btnAddCustomer = new Button();
            btnGetCustomer = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(264, 92);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(264, 137);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 39);
            txtEmail.TabIndex = 1;
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(264, 182);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(200, 39);
            txtCustomerId.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(44, 99);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 32);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(44, 144);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 32);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(44, 189);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(144, 32);
            lblCustomerId.TabIndex = 5;
            lblCustomerId.Text = "Customer Id";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(687, 464);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(150, 46);
            btnAddCustomer.TabIndex = 6;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnGetCustomer
            // 
            btnGetCustomer.Location = new Point(843, 464);
            btnGetCustomer.Name = "btnGetCustomer";
            btnGetCustomer.Size = new Size(150, 46);
            btnGetCustomer.TabIndex = 7;
            btnGetCustomer.Text = "Get";
            btnGetCustomer.UseVisualStyleBackColor = true;
            btnGetCustomer.Click += btnGetCustomer_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(596, 127);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(480, 300);
            dataGridView1.TabIndex = 8;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 746);
            Controls.Add(dataGridView1);
            Controls.Add(btnGetCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(lblCustomerId);
            Controls.Add(lblEmail);
            Controls.Add(lblName);
            Controls.Add(txtCustomerId);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtCustomerId;
        private Label lblName;
        private Label lblEmail;
        private Label lblCustomerId;
        private Button btnAddCustomer;
        private Button btnGetCustomer;
        private DataGridView dataGridView1;
    }
}