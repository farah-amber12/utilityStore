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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerForm));
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
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            panel1.SuspendLayout();
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
            btnManageCategories.Location = new Point(168, 182);
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
            btnManageSupplierDebt.Location = new Point(161, 430);
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
            btnManageProducts.Location = new Point(161, 300);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(222, 55);
            btnManageProducts.TabIndex = 8;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // btnManageOrders
            // 
            btnManageOrders.BackColor = Color.DarkSeaGreen;
            btnManageOrders.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageOrders.ForeColor = Color.White;
            btnManageOrders.Location = new Point(168, 529);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(222, 60);
            btnManageOrders.TabIndex = 0;
            btnManageOrders.Text = "Manage Orders";
            btnManageOrders.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LightCoral;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(161, 970);
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
            pictureBox1.Location = new Point(26, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = loginPage.Properties.Resources.catagories;
            pictureBox2.Location = new Point(26, 133);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(117, 99);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = loginPage.Properties.Resources.supplier_debt;
            pictureBox3.Location = new Point(29, 397);
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
            pictureBox5.Location = new Point(26, 258);
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
            pictureBox7.Location = new Point(12, 940);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(119, 98);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 11;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = loginPage.Properties.Resources.order_details;
            pictureBox8.Location = new Point(12, 510);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(127, 91);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 12;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(26, 807);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(113, 99);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 13;
            pictureBox9.TabStop = false;
            // 
            // panel1
            // 
            // panel1.BackColor = Color.DarkSeaGreen;
            // panel1.Controls.Add(label1);
            // panel1.Cursor = Cursors.Hand;
            // panel1.Location = new Point(168, 831);
            // panel1.Name = "panel1";
            // panel1.Size = new Size(215, 50);
            // panel1.TabIndex = 14;
            // panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 14);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 0;
            label1.Text = "Profit ";
            // 
            // OwnerForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1920, 1050);
            Controls.Add(panel1);
            Controls.Add(pictureBox9);
            Controls.Add(pictureBox8);
            Controls.Add(btnManageStaff);
            Controls.Add(pictureBox1);
            Controls.Add(btnManageCategories);
            Controls.Add(pictureBox2);
            Controls.Add(btnManageSupplierDebt);
            Controls.Add(pictureBox3);
            Controls.Add(btnManageCustomerDebt);
            Controls.Add(btnManageOrders);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private Panel panel1;
        private Label label1;
    }
}
