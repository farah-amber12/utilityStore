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
            btnManageSupplierDebt = new Button();
            btnManageCustomerDebt = new Button();
            btnManageProducts = new Button();
            btnManageOrders = new Button();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // btnManageStaff
            // 
            btnManageStaff.BackColor = Color.DarkSeaGreen;
            btnManageStaff.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageStaff.ForeColor = Color.White;
            btnManageStaff.Location = new Point(168, 54);
            btnManageStaff.Name = "btnManageStaff";
            btnManageStaff.Size = new Size(222, 50);
            btnManageStaff.TabIndex = 0;
            btnManageStaff.Text = "Manage Staff";
            btnManageStaff.UseVisualStyleBackColor = false;
            btnManageStaff.Click += btnManageStaff_Click;
            // 
            // btnManageCategories
            // 
            btnManageCategories.BackColor = Color.DarkSeaGreen;
            btnManageCategories.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageCategories.ForeColor = Color.White;
            btnManageCategories.Location = new Point(168, 200);
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(222, 50);
            btnManageCategories.TabIndex = 2;
            btnManageCategories.Text = "Manage Categories";
            btnManageCategories.UseVisualStyleBackColor = false;
            btnManageCategories.Click += btnManageCategories_Click;
            // 
            // btnManageSupplierDebt
            // 
            btnManageSupplierDebt.BackColor = Color.DarkSeaGreen;
            btnManageSupplierDebt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageSupplierDebt.ForeColor = Color.White;
            btnManageSupplierDebt.Location = new Point(161, 510);
            btnManageSupplierDebt.Name = "btnManageSupplierDebt";
            btnManageSupplierDebt.Size = new Size(222, 50);
            btnManageSupplierDebt.TabIndex = 4;
            btnManageSupplierDebt.Text = "Manage Supplier Debt";
            btnManageSupplierDebt.UseVisualStyleBackColor = false;
            btnManageSupplierDebt.Click += btnManageSupplierDebt_Click;
            // 
            // btnManageCustomerDebt
            // 
            btnManageCustomerDebt.BackColor = Color.DarkSeaGreen;
            btnManageCustomerDebt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageCustomerDebt.ForeColor = Color.White;
            btnManageCustomerDebt.Location = new Point(168, 671);
            btnManageCustomerDebt.Name = "btnManageCustomerDebt";
            btnManageCustomerDebt.Size = new Size(222, 50);
            btnManageCustomerDebt.TabIndex = 6;
            btnManageCustomerDebt.Text = "Manage Customer Debt";
            btnManageCustomerDebt.UseVisualStyleBackColor = false;
            btnManageCustomerDebt.Click += btnManageCustomerDebt_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.DarkSeaGreen;
            btnManageProducts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageProducts.ForeColor = Color.White;
            btnManageProducts.Location = new Point(168, 350);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(222, 55);
            btnManageProducts.TabIndex = 8;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // btnManageOrders
            // 
            btnManageOrders.Location = new Point(0, 0);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(75, 23);
            btnManageOrders.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LightCoral;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(168, 865);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(222, 50);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = loginPage.Properties.Resources.manage_staff;
            pictureBox1.Location = new Point(26, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = loginPage.Properties.Resources.catagories;
            pictureBox2.Location = new Point(26, 178);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(117, 99);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = loginPage.Properties.Resources.supplier_debt;
            pictureBox3.Location = new Point(30, 494);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(113, 83);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = loginPage.Properties.Resources.customericon;
            pictureBox4.Location = new Point(26, 648);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(113, 99);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = loginPage.Properties.Resources.products_icon;
            pictureBox5.Location = new Point(26, 333);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(117, 97);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(100, 50);
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = loginPage.Properties.Resources.logout;
            pictureBox7.Location = new Point(24, 840);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(119, 98);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 11;
            pictureBox7.TabStop = false;
            // 
            // OwnerForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1920, 1080);
            Controls.Add(btnManageStaff);
            Controls.Add(pictureBox1);
            Controls.Add(btnManageCategories);
            Controls.Add(pictureBox2);
            Controls.Add(btnManageSupplierDebt);
            Controls.Add(pictureBox3);
            Controls.Add(btnManageCustomerDebt);
            Controls.Add(pictureBox4);
            Controls.Add(btnManageProducts);
            Controls.Add(pictureBox5);
            Controls.Add(btnLogout);
            Controls.Add(pictureBox7);
            Name = "OwnerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Owner Dashboard";
            Load += OwnerForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
        }

        private Button btnManageStaff;
        private Button btnManageCategories;
        private Button btnManageSupplierDebt;
        private Button btnManageCustomerDebt;
        private Button btnManageProducts;
        private Button btnManageOrders;
        private Button btnLogout;

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;

        private DataGridView dataGridView1;
    }
}
