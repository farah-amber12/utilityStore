namespace loginPage
{
    partial class StaffForm
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.btnDeleteStaff = new System.Windows.Forms.Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(30, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.PlaceholderText = "First Name";

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(250, 30);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.PlaceholderText = "Last Name";

            // cmbRole
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(30, 70);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(200, 24);
            this.cmbRole.TabIndex = 2;
            this.cmbRole.Items.AddRange(new object[] { "Owner", "Inventory Manager", "Helpers", "Organizer" });
            this.cmbRole.SelectedIndex = -1;

            // txtSalary
            this.txtSalary.Location = new System.Drawing.Point(250, 70);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(200, 22);
            this.txtSalary.TabIndex = 3;
            this.txtSalary.PlaceholderText = "Salary";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(30, 110);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 22);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.PlaceholderText = "Username";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(250, 110);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.PlaceholderText = "Password";

            // txtContactNumber
            this.txtContactNumber.Location = new System.Drawing.Point(30, 150);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 22);
            this.txtContactNumber.TabIndex = 6;
            this.txtContactNumber.PlaceholderText = "Contact Number";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(250, 150);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 22);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.PlaceholderText = "Address";

            // btnAddStaff
            this.btnAddStaff.Location = new System.Drawing.Point(30, 190);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(200, 30);
            this.btnAddStaff.TabIndex = 8;
            this.btnAddStaff.Text = "Add Staff Member";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.BtnAddStaff_Click);

            // btnDeleteStaff
            this.btnDeleteStaff.Location = new System.Drawing.Point(250, 190);
            this.btnDeleteStaff.Name = "btnDeleteStaff";
            this.btnDeleteStaff.Size = new System.Drawing.Size(200, 30);
            this.btnDeleteStaff.TabIndex = 9;
            this.btnDeleteStaff.Text = "Delete Selected Staff";
            this.btnDeleteStaff.UseVisualStyleBackColor = true;
            this.btnDeleteStaff.Click += new System.EventHandler(this.btnDeleteStaff_Click);

            // dgvStaff
            this.dgvStaff.Location = new System.Drawing.Point(30, 230);
            this.dgvStaff.Size = new System.Drawing.Size(700, 300);
            this.dgvStaff.TabIndex = 10;
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.ReadOnly = true;

            // StaffForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.btnDeleteStaff);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "StaffForm";
            this.Text = "Staff Management Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Button btnDeleteStaff;
        private System.Windows.Forms.DataGridView dgvStaff;
    }
}
