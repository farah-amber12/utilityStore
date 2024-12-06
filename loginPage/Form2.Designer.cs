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
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(128, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Owner!";
            this.lblWelcome.Click += new System.EventHandler(this.Form2_Load);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 100);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(760, 300);
            this.dataGridView.TabIndex = 1;
            // 
            // btnViewCategories
            // 
            this.btnViewCategories.Location = new System.Drawing.Point(12, 420);
            this.btnViewCategories.Name = "btnViewCategories";
            this.btnViewCategories.Size = new System.Drawing.Size(120, 40);
            this.btnViewCategories.TabIndex = 2;
            this.btnViewCategories.Text = "View Categories";
            this.btnViewCategories.UseVisualStyleBackColor = true;
            this.btnViewCategories.Click += new System.EventHandler(this.btnViewCategories_Click);
            // 
            // btnViewProducts
            // 
            this.btnViewProducts.Location = new System.Drawing.Point(140, 420);
            this.btnViewProducts.Name = "btnViewProducts";
            this.btnViewProducts.Size = new System.Drawing.Size(120, 40);
            this.btnViewProducts.TabIndex = 3;
            this.btnViewProducts.Text = "View Products";
            this.btnViewProducts.UseVisualStyleBackColor = true;
            this.btnViewProducts.Click += new System.EventHandler(this.btnViewProducts_Click);
            // 
            // btnViewCustomers
            // 
            this.btnViewCustomers.Location = new System.Drawing.Point(270, 420);
            this.btnViewCustomers.Name = "btnViewCustomers";
            this.btnViewCustomers.Size = new System.Drawing.Size(120, 40);
            this.btnViewCustomers.TabIndex = 4;
            this.btnViewCustomers.Text = "View Customers";
            this.btnViewCustomers.UseVisualStyleBackColor = true;
            this.btnViewCustomers.Click += new System.EventHandler(this.btnViewCustomers_Click);
            // 
            // btnManageStaff
            // 
            this.btnManageStaff.Location = new System.Drawing.Point(400, 420);
            this.btnManageStaff.Name = "btnManageStaff";
            this.btnManageStaff.Size = new System.Drawing.Size(120, 40);
            this.btnManageStaff.TabIndex = 5;
            this.btnManageStaff.Text = "Manage Staff";
            this.btnManageStaff.UseVisualStyleBackColor = true;
            this.btnManageStaff.Click += new System.EventHandler(this.btnManageStaff_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(530, 420);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 500);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageStaff);
            this.Controls.Add(this.btnViewCustomers);
            this.Controls.Add(this.btnViewProducts);
            this.Controls.Add(this.btnViewCategories);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.lblWelcome);
            this.Name = "Form2";
            this.Text = "Owner Dashboard";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnViewCategories;
        private System.Windows.Forms.Button btnViewProducts;
        private System.Windows.Forms.Button btnViewCustomers;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnLogout;
    }
}
