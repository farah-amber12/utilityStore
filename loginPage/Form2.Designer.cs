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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnViewCategories = new System.Windows.Forms.Button();
            this.btnViewProducts = new System.Windows.Forms.Button();
            this.btnViewCustomers = new System.Windows.Forms.Button();
            this.btnManageStaff = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(100, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Owner!";
            // 
            // dataGridView
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(20, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(600, 300);
            this.dataGridView.TabIndex = 1;
            // 
            // btnViewCategories
            this.btnViewCategories.Text = "View Categories";
            this.btnViewCategories.Click += btnViewCategories_Click;
            this.btnViewCategories.Location = new System.Drawing.Point(650, 60);

            // btnViewProducts
            this.btnViewProducts.Text = "View Products";
            this.btnViewProducts.Click += btnViewProducts_Click;
            this.btnViewProducts.Location = new System.Drawing.Point(650, 100);

            // btnViewCustomers
            this.btnViewCustomers.Text = "View Customers";
            this.btnViewCustomers.Click += btnViewCustomers_Click;
            this.btnViewCustomers.Location = new System.Drawing.Point(650, 140);

            // btnManageStaff
            this.btnManageStaff.Text = "Manage Staff";
            this.btnManageStaff.Click += btnManageStaff_Click;
            this.btnManageStaff.Location = new System.Drawing.Point(650, 180);

            // btnViewOrders
            this.btnViewOrders.Text = "View Orders";
            this.btnViewOrders.Click += btnViewOrders_Click;
            this.btnViewOrders.Location = new System.Drawing.Point(650, 220);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += btnLogout_Click;
            this.btnLogout.Location = new System.Drawing.Point(650, 260);

            // Add controls
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnViewCategories);
            this.Controls.Add(this.btnViewProducts);
            this.Controls.Add(this.btnViewCustomers);
            this.Controls.Add(this.btnManageStaff);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.btnLogout);

            // Form properties
            this.Text = "Owner Dashboard";
            this.Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Windows Form Fields
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnViewCategories;
        private System.Windows.Forms.Button btnViewProducts;
        private System.Windows.Forms.Button btnViewCustomers;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnLogout;
        #endregion
    }
}
