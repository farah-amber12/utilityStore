namespace UtilityStoreApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            dataGridView = new DataGridView();
            btnViewCategories = new Button();
            btnViewProducts = new Button();
            btnViewCustomers = new Button();
            btnManageStaff = new Button();
            btnViewOrderDetail = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(151, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Owner!";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(20, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(776, 420);
            dataGridView.TabIndex = 1;
            // 
            // btnViewCategories
            // 
            btnViewCategories.Location = new Point(650, 60);
            btnViewCategories.Name = "btnViewCategories";
            btnViewCategories.Size = new Size(75, 23);
            btnViewCategories.TabIndex = 2;
            btnViewCategories.Text = "View Categories";
            btnViewCategories.Click += btnViewCategories_Click;
            // 
            // btnViewProducts
            // 
            btnViewProducts.Location = new Point(650, 100);
            btnViewProducts.Name = "btnViewProducts";
            btnViewProducts.Size = new Size(75, 23);
            btnViewProducts.TabIndex = 3;
            btnViewProducts.Text = "View Products";
            btnViewProducts.Click += btnViewProducts_Click;
            // 
            // btnViewCustomers
            // 
            btnViewCustomers.Location = new Point(650, 140);
            btnViewCustomers.Name = "btnViewCustomers";
            btnViewCustomers.Size = new Size(75, 23);
            btnViewCustomers.TabIndex = 4;
            btnViewCustomers.Text = "View Customers";
            btnViewCustomers.Click += btnViewCustomers_Click;
            // 
            // btnManageStaff
            // 
            btnManageStaff.Location = new Point(650, 180);
            btnManageStaff.Name = "btnManageStaff";
            btnManageStaff.Size = new Size(75, 23);
            btnManageStaff.TabIndex = 5;
            btnManageStaff.Text = "Manage Staff";
            btnManageStaff.Click += btnManageStaff_Click;
            // 
            // btnViewOrderDetail
            // 
            btnViewOrderDetail.Location = new Point(650, 220);
            btnViewOrderDetail.Name = "btnViewOrderDetail";
            btnViewOrderDetail.Size = new Size(75, 23);
            btnViewOrderDetail.TabIndex = 6;
            btnViewOrderDetail.Text = "View Orders";
            btnViewOrderDetail.Click += btnViewOrderDetail_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(650, 260);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(1157, 607);
            Controls.Add(lblWelcome);
            Controls.Add(dataGridView);
            Controls.Add(btnViewCategories);
            Controls.Add(btnViewProducts);
            Controls.Add(btnViewCustomers);
            Controls.Add(btnManageStaff);
            Controls.Add(btnViewOrderDetail);
            Controls.Add(btnLogout);
            Name = "Form2";
            Text = "Owner Dashboard";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        #region Windows Form Fields
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnViewCategories;
        private System.Windows.Forms.Button btnViewProducts;
        private System.Windows.Forms.Button btnViewCustomers;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnViewOrderDetail;
        private System.Windows.Forms.Button btnLogout;
        #endregion
    }
}
