namespace UtilityStoreApp
{
    partial class OwnerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnManageStaff = new Button();
            btnManageCategories = new Button();
            btnManageSupplierDebts = new Button();
            btnManageCustomerDebts = new Button();
            btnManageProducts = new Button();
            btnManageOrders = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnManageStaff
            // 
            btnManageStaff.BackColor = Color.LightBlue;
            btnManageStaff.Location = new Point(30, 30);
            btnManageStaff.Name = "btnManageStaff";
            btnManageStaff.Size = new Size(180, 50);
            btnManageStaff.TabIndex = 0;
            btnManageStaff.Text = "Manage Staff";
            btnManageStaff.UseVisualStyleBackColor = false;
            btnManageStaff.Click += btnManageStaff_Click;
            // 
            // btnManageCategories
            // 
            btnManageCategories.BackColor = Color.LightGreen;
            btnManageCategories.Location = new Point(220, 30);
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(180, 50);
            btnManageCategories.TabIndex = 1;
            btnManageCategories.Text = "Manage Categories";
            btnManageCategories.UseVisualStyleBackColor = false;
            btnManageCategories.Click += btnManageCategories_Click;
            // 
            // btnManageSupplierDebts
            // 
            btnManageSupplierDebts.BackColor = Color.LightCoral;
            btnManageSupplierDebts.Location = new Point(410, 30);
            btnManageSupplierDebts.Name = "btnManageSupplierDebts";
            btnManageSupplierDebts.Size = new Size(180, 50);
            btnManageSupplierDebts.TabIndex = 2;
            btnManageSupplierDebts.Text = "Manage Supplier Debts";
            btnManageSupplierDebts.UseVisualStyleBackColor = false;
            btnManageSupplierDebts.Click += btnManageSupplierDebts_Click;
            // 
            // btnManageCustomerDebts
            // 
            btnManageCustomerDebts.BackColor = Color.LightPink;
            btnManageCustomerDebts.Location = new Point(30, 100);
            btnManageCustomerDebts.Name = "btnManageCustomerDebts";
            btnManageCustomerDebts.Size = new Size(180, 50);
            btnManageCustomerDebts.TabIndex = 3;
            btnManageCustomerDebts.Text = "Manage Customer Debts";
            btnManageCustomerDebts.UseVisualStyleBackColor = false;
            btnManageCustomerDebts.Click += btnManageCustomerDebts_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.LightYellow;
            btnManageProducts.Location = new Point(220, 100);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(180, 50);
            btnManageProducts.TabIndex = 4;
            btnManageProducts.Text = "View Products";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // btnManageOrders
            // 
            btnManageOrders.BackColor = Color.LightGray;
            btnManageOrders.Location = new Point(410, 100);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(180, 50);
            btnManageOrders.TabIndex = 5;
            btnManageOrders.Text = "View Orders";
            btnManageOrders.UseVisualStyleBackColor = false;
            btnManageOrders.Click += btnManageOrders_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.Location = new Point(220, 170);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(180, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // OwnerForm
            // 
            ClientSize = new Size(1198, 486);
            Controls.Add(btnManageStaff);
            Controls.Add(btnManageCategories);
            Controls.Add(btnManageSupplierDebts);
            Controls.Add(btnManageCustomerDebts);
            Controls.Add(btnManageProducts);
            Controls.Add(btnManageOrders);
            Controls.Add(btnLogout);
            Name = "OwnerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += OwnerForm_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnManageSupplierDebts;
        private System.Windows.Forms.Button btnManageCustomerDebts;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnLogout;
    }
}
