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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            btnManageStaff.BackColor = Color.LightBlue;
            btnManageStaff.Location = new Point(54, 225);
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
            btnManageCategories.Location = new Point(918, 225);
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(180, 50);
            btnManageCategories.TabIndex = 1;
            btnManageCategories.Text = "Manage Categories";
            btnManageCategories.UseVisualStyleBackColor = false;
            btnManageCategories.Click += btnManageCategories_Click;
            // 
            // btnManageSupplierDebt
            // 
            btnManageSupplierDebt.BackColor = Color.LightCoral;
            btnManageSupplierDebt.Location = new Point(620, 225);
            btnManageSupplierDebt.Name = "btnManageSupplierDebt";
            btnManageSupplierDebt.Size = new Size(180, 50);
            btnManageSupplierDebt.TabIndex = 2;
            btnManageSupplierDebt.Text = "Manage Supplier Debts";
            btnManageSupplierDebt.UseVisualStyleBackColor = false;
            btnManageSupplierDebt.Click += btnManageSupplierDebt_Click;
            // 
            // btnManageCustomerDebt
            // 
            btnManageCustomerDebt.BackColor = Color.LightPink;
            btnManageCustomerDebt.Location = new Point(322, 225);
            btnManageCustomerDebt.Name = "btnManageCustomerDebt";
            btnManageCustomerDebt.Size = new Size(180, 50);
            btnManageCustomerDebt.TabIndex = 3;
            btnManageCustomerDebt.Text = "Manage Customer Debts";
            btnManageCustomerDebt.UseVisualStyleBackColor = false;
            btnManageCustomerDebt.Click += btnManageCustomerDebt_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.LightYellow;
            btnManageProducts.Location = new Point(322, 474);
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
            btnManageOrders.Location = new Point(52, 474);
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
            btnLogout.Location = new Point(620, 474);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(180, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = loginPage.Properties.Resources.manage_staff;
            pictureBox1.Location = new Point(54, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = loginPage.Properties.Resources.customericon;
            pictureBox2.Location = new Point(333, 40);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(169, 167);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = loginPage.Properties.Resources.order_details;
            pictureBox3.Location = new Point(54, 281);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(171, 167);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = loginPage.Properties.Resources.catagories;
            pictureBox4.Location = new Point(918, 40);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(163, 167);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = loginPage.Properties.Resources.products_icon;
            pictureBox5.Location = new Point(322, 281);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(180, 167);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = loginPage.Properties.Resources.supplier_debt;
            pictureBox6.Location = new Point(620, 40);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(180, 179);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 12;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = loginPage.Properties.Resources.logout;
            pictureBox7.Location = new Point(620, 281);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(170, 167);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // OwnerForm
            // 
            ClientSize = new Size(1218, 614);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnManageStaff);
            Controls.Add(btnManageCategories);
            Controls.Add(btnManageSupplierDebt);
            Controls.Add(btnManageCustomerDebt);
            Controls.Add(btnManageProducts);
            Controls.Add(btnManageOrders);
            Controls.Add(btnLogout);
            Name = "OwnerForm";
            StartPosition = FormStartPosition.CenterScreen;
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

        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnManageSupplierDebt;
        private System.Windows.Forms.Button btnManageCustomerDebt;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnLogout;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
