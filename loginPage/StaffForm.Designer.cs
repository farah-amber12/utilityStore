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
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            cmbRole = new ComboBox();
            txtSalary = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtContactNumber = new TextBox();
            txtAddress = new TextBox();
            btnAddStaff = new Button();
            btnUpdateStaff = new Button();
            btnDeleteStaff = new Button();
            dgvStaff = new DataGridView();
            txtSearchName = new TextBox();
            txtMinSalary = new TextBox();
            txtMaxSalary = new TextBox();
            cmbSearchRole = new ComboBox();
            btnSearch = new Button();
            rbtnSortAZ = new RadioButton();
            rbtnSortZA = new RadioButton();
            cmbFilterType = new ComboBox();
            lblSearch = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(38, 55);
            txtFirstName.Margin = new Padding(4, 5, 4, 5);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(249, 31);
            txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(312, 55);
            txtLastName.Margin = new Padding(4, 5, 4, 5);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(249, 31);
            txtLastName.TabIndex = 1;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Owner", "Inventory Manager", "Helpers", "Organizer", "Cashier" });
            cmbRole.Location = new Point(38, 232);
            cmbRole.Margin = new Padding(4, 5, 4, 5);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(249, 33);
            cmbRole.TabIndex = 2;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(312, 109);
            txtSalary.Margin = new Padding(4, 5, 4, 5);
            txtSalary.Name = "txtSalary";
            txtSalary.PlaceholderText = "Salary";
            txtSalary.Size = new Size(249, 31);
            txtSalary.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(38, 172);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(249, 31);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(312, 172);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(249, 31);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(38, 109);
            txtContactNumber.Margin = new Padding(4, 5, 4, 5);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.PlaceholderText = "Contact Number";
            txtContactNumber.Size = new Size(249, 31);
            txtContactNumber.TabIndex = 6;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(312, 234);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(249, 31);
            txtAddress.TabIndex = 7;
            // 
            // btnAddStaff
            // 
            btnAddStaff.Location = new Point(38, 297);
            btnAddStaff.Margin = new Padding(4, 5, 4, 5);
            btnAddStaff.Name = "btnAddStaff";
            btnAddStaff.Size = new Size(188, 47);
            btnAddStaff.TabIndex = 8;
            btnAddStaff.Text = "Add Staff Member";
            btnAddStaff.UseVisualStyleBackColor = true;
            btnAddStaff.Click += BtnAddStaff_Click;
            // 
            // btnUpdateStaff
            // 
            btnUpdateStaff.Location = new Point(238, 297);
            btnUpdateStaff.Margin = new Padding(4, 5, 4, 5);
            btnUpdateStaff.Name = "btnUpdateStaff";
            btnUpdateStaff.Size = new Size(210, 47);
            btnUpdateStaff.TabIndex = 9;
            btnUpdateStaff.Text = "Update Staff Member";
            btnUpdateStaff.UseVisualStyleBackColor = true;
            btnUpdateStaff.Click += BtnUpdateStaff_Click;
            // 
            // btnDeleteStaff
            // 
            btnDeleteStaff.Location = new Point(472, 297);
            btnDeleteStaff.Margin = new Padding(4, 5, 4, 5);
            btnDeleteStaff.Name = "btnDeleteStaff";
            btnDeleteStaff.Size = new Size(188, 47);
            btnDeleteStaff.TabIndex = 10;
            btnDeleteStaff.Text = "Delete Selected Staff";
            btnDeleteStaff.UseVisualStyleBackColor = true;
            btnDeleteStaff.Click += btnDeleteStaff_Click;
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.ColumnHeadersHeight = 34;
            dgvStaff.Location = new Point(38, 364);
            dgvStaff.Margin = new Padding(4, 5, 4, 5);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.RowHeadersWidth = 62;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.Size = new Size(1449, 620);
            dgvStaff.TabIndex = 11;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(888, 66);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(200, 31);
            txtSearchName.TabIndex = 0;
            // 
            // txtMinSalary
            // 
            txtMinSalary.Location = new Point(1084, 144);
            txtMinSalary.Name = "txtMinSalary";
            txtMinSalary.Size = new Size(149, 31);
            txtMinSalary.TabIndex = 1;
            // 
            // txtMaxSalary
            // 
            txtMaxSalary.Location = new Point(1268, 144);
            txtMaxSalary.Name = "txtMaxSalary";
            txtMaxSalary.Size = new Size(140, 31);
            txtMaxSalary.TabIndex = 2;
            // 
            // cmbSearchRole
            // 
            cmbSearchRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchRole.FormattingEnabled = true;
            cmbSearchRole.Location = new Point(888, 198);
            cmbSearchRole.Name = "cmbSearchRole";
            cmbSearchRole.Size = new Size(200, 33);
            cmbSearchRole.TabIndex = 4;
            cmbSearchRole.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1133, 64);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // rbtnSortAZ
            // 
            rbtnSortAZ.AutoSize = true;
            rbtnSortAZ.Location = new Point(1084, 140);
            rbtnSortAZ.Name = "rbtnSortAZ";
            rbtnSortAZ.Size = new Size(66, 29);
            rbtnSortAZ.TabIndex = 2;
            rbtnSortAZ.Text = "A-Z";
            rbtnSortAZ.UseVisualStyleBackColor = true;
            rbtnSortAZ.Visible = false;
            // 
            // rbtnSortZA
            // 
            rbtnSortZA.AutoSize = true;
            rbtnSortZA.Location = new Point(1179, 138);
            rbtnSortZA.Name = "rbtnSortZA";
            rbtnSortZA.Size = new Size(66, 29);
            rbtnSortZA.TabIndex = 3;
            rbtnSortZA.Text = "Z-A";
            rbtnSortZA.UseVisualStyleBackColor = true;
            rbtnSortZA.Visible = false;
            // 
            // cmbFilterType
            // 
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.FormattingEnabled = true;
            cmbFilterType.Items.AddRange(new object[] { "Select Filter", "All", "Name", "Role", "Salary" });
            cmbFilterType.Location = new Point(888, 142);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(150, 33);
            cmbFilterType.TabIndex = 0;
            cmbFilterType.SelectedIndexChanged += cmbFilterType_SelectedIndexChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(775, 66);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 25);
            lblSearch.TabIndex = 7;
            lblSearch.Text = "Search :";
            lblSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(765, 142);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 12;
            label1.Text = "Filter By :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1084, 109);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 13;
            label2.Text = "Min Salary: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1234, 110);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 14;
            label3.Text = "Max. Salary:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(757, 201);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 15;
            label4.Text = "Select Role:";
            // 
            // button1
            // 
            button1.Location = new Point(682, 248);
            button1.Name = "button1";
            button1.Size = new Size(125, 35);
            button1.TabIndex = 16;
            button1.Text = "Clear Fields";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ClrBtn_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Crimson;
            button2.ForeColor = Color.White;
            button2.Location = new Point(723, 310);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 17;
            button2.Text = "Go Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += goback_Click;
            // 
            // StaffForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 1016);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvStaff);
            Controls.Add(btnAddStaff);
            Controls.Add(btnUpdateStaff);
            Controls.Add(btnDeleteStaff);
            Controls.Add(txtAddress);
            Controls.Add(txtContactNumber);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtSalary);
            Controls.Add(cmbRole);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnSearch);
            Controls.Add(cmbSearchRole);
            Controls.Add(cmbFilterType);
            Controls.Add(txtMaxSalary);
            Controls.Add(txtMinSalary);
            Controls.Add(txtSearchName);
            Controls.Add(lblSearch);
            Controls.Add(rbtnSortAZ);
            Controls.Add(rbtnSortZA);
            Margin = new Padding(4, 5, 4, 5);
            Name = "StaffForm";
            Text = "Staff Management Form";
            WindowState = FormWindowState.Maximized;
            Load += StaffForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button btnUpdateStaff;
        private System.Windows.Forms.Button btnDeleteStaff;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtMinSalary;
        private System.Windows.Forms.TextBox txtMaxSalary;
        private System.Windows.Forms.ComboBox cmbSearchRole;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblMinSalary;
        private System.Windows.Forms.Label lblMaxSalary;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.RadioButton rbtnSortAZ;
        private System.Windows.Forms.RadioButton rbtnSortZA;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}
