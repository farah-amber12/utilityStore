namespace loginPage
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;


        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDebtAmount;
        private System.Windows.Forms.TextBox txtDebtAmount;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerPaymentDueDate;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.TextBox textBoxDebtFrom;
        private System.Windows.Forms.TextBox textBoxDebtTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerSingle;
        private System.Windows.Forms.RadioButton radioButtonAZ;
        private System.Windows.Forms.RadioButton radioButtonZA;



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

        private Button GetButton1()
        {
            return button1;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(Button button1)
        {
            
            lblContactNumber = new Label();
            txtContactNumber = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblDebtAmount = new Label();
            txtDebtAmount = new TextBox();
            lblDueDate = new Label();
            dateTimePickerPaymentDueDate = new DateTimePicker();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            btnDeleteCustomer = new Button();
            btnUpdateCustomer = new Button();
            dataGridViewCustomers = new DataGridView();
            textBoxSearch = new TextBox();
            comboBoxFilter = new ComboBox();
            btnSearch = new Button();
            btnGoBack = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxDebtFrom = new TextBox();
            textBoxDebtTo = new TextBox();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            dateTimePickerSingle = new DateTimePicker();
            radioButtonAZ = new RadioButton();
            radioButtonZA = new RadioButton();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            SuspendLayout();

            // First Name Label
            lblFirstName.AutoSize = true;
            lblFirstName.BackColor = Color.White;
            lblFirstName.Location = new Point(12, 55);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 25);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";

            // First Name TextBox
            txtFirstName.Location = new Point(212, 49);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(273, 31);
            txtFirstName.TabIndex = 1;

            // Last Name Label
            lblLastName.AutoSize = true;
            lblLastName.BackColor = Color.White;
            lblLastName.Location = new Point(12, 107);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(100, 25);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";

            // Last Name TextBox
            txtLastName.Location = new Point(212, 101);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(273, 31);
            txtLastName.TabIndex = 3;

            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.BackColor = Color.White;
            lblContactNumber.Location = new Point(12, 107);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(147, 25);
            lblContactNumber.TabIndex = 2;
            lblContactNumber.Text = "Contact Number:";
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(212, 209);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(273, 31);
            txtContactNumber.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.White;
            lblAddress.Location = new Point(20, 162);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(81, 25);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(212, 104);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(273, 31);
            txtAddress.TabIndex = 5;
            // 
            // lblDebtAmount
            // 
            lblDebtAmount.AutoSize = true;
            lblDebtAmount.BackColor = Color.White;
            lblDebtAmount.Location = new Point(20, 215);
            lblDebtAmount.Name = "lblDebtAmount";
            lblDebtAmount.Size = new Size(125, 25);
            lblDebtAmount.TabIndex = 6;
            lblDebtAmount.Text = "Debt Amount:";
            // 
            // txtDebtAmount
            // 
            txtDebtAmount.Location = new Point(212, 156);
            txtDebtAmount.Name = "txtDebtAmount";
            txtDebtAmount.Size = new Size(273, 31);
            txtDebtAmount.TabIndex = 7;
            // 
            // lblPaymentDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.BackColor = Color.White;
            lblDueDate.Location = new Point(20, 271);
            lblDueDate.Name = "lblPaymentDueDate";
            lblDueDate.Size = new Size(163, 25);
            lblDueDate.TabIndex = 8;
            lblDueDate.Text = "Payment Due Date:";
            // 
            // dateTimePickerPaymentDueDate
            // 
            dateTimePickerPaymentDueDate.Location = new Point(212, 265);
            dateTimePickerPaymentDueDate.Name = "dateTimePickerPaymentDueDate";
            dateTimePickerPaymentDueDate.Size = new Size(273, 31);
            dateTimePickerPaymentDueDate.TabIndex = 9;
            
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(16, 380);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(183, 36);
            btnDeleteCustomer.TabIndex = 11;
            btnDeleteCustomer.Text = "Delete Customer";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateCustomer.Location = new Point(261, 328);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(183, 36);
            btnUpdateCustomer.TabIndex = 13;
            btnUpdateCustomer.Text = "Update Supplier";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // dataGridViewSuppliers
            // 
            dataGridViewCustomers.BackgroundColor = Color.White;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(573, 34);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.RowHeadersWidth = 62;
            dataGridViewCustomers.Size = new Size(1098, 573);
            dataGridViewCustomers.TabIndex = 12;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(115, 433);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(264, 31);
            textBoxSearch.TabIndex = 0;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Items.AddRange(new object[] { "All", "Filter by Name", "Filter by City", "With Debt", "Without Debt", "Filter by Date" });
            comboBoxFilter.Location = new Point(123, 480);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(150, 33);
            comboBoxFilter.TabIndex = 0;
            comboBoxFilter.SelectedIndexChanged += comboBoxFilter_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.Location = new Point(400, 425);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(109, 43);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.DarkRed;
            btnGoBack.ForeColor = Color.FloralWhite;
            btnGoBack.Location = new Point(229, 380);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(150, 36);
            btnGoBack.TabIndex = 5;
            btnGoBack.Text = "Go Back";
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(16, 480);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 17;
            label1.Text = "Filter By:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkSeaGreen;
            label2.Cursor = Cursors.IBeam;
            label2.Font = new Font("Arial", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 9);
            label2.Name = "label2";
            label2.Size = new Size(257, 25);
            label2.TabIndex = 18;
            label2.Text = "Enter Details of Supplier :";
            // 
            // textBoxDebtFrom
            // 
            textBoxDebtFrom.Location = new Point(64, 543);
            textBoxDebtFrom.Name = "textBoxDebtFrom";
            textBoxDebtFrom.Size = new Size(213, 31);
            textBoxDebtFrom.TabIndex = 19;
            textBoxDebtFrom.Visible = false;
            // 
            // textBoxDebtTo
            // 
            textBoxDebtTo.Location = new Point(333, 543);
            textBoxDebtTo.Name = "textBoxDebtTo";
            textBoxDebtTo.Size = new Size(200, 31);
            textBoxDebtTo.TabIndex = 20;
            textBoxDebtTo.Visible = false;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(73, 541);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(200, 31);
            dateTimePickerFrom.TabIndex = 21;
            dateTimePickerFrom.Visible = false;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(333, 541);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(213, 31);
            dateTimePickerTo.TabIndex = 22;
            dateTimePickerTo.Visible = false;
            // 
            // dateTimePickerSingle
            // 
            dateTimePickerSingle.Location = new Point(0, 0);
            dateTimePickerSingle.Name = "dateTimePickerSingle";
            dateTimePickerSingle.Size = new Size(200, 31);
            dateTimePickerSingle.TabIndex = 27;
            // 
            // radioButtonAZ
            // 
            radioButtonAZ.Location = new Point(306, 489);
            radioButtonAZ.Name = "radioButtonAZ";
            radioButtonAZ.Size = new Size(104, 24);
            radioButtonAZ.TabIndex = 23;
            radioButtonAZ.Text = "Sort A-Z";
            radioButtonAZ.Visible = false;
            // 
            // radioButtonZA
            // 
            radioButtonZA.Location = new Point(426, 489);
            radioButtonZA.Name = "radioButtonZA";
            radioButtonZA.Size = new Size(104, 24);
            radioButtonZA.TabIndex = 24;
            radioButtonZA.Text = "Sort Z-A";
            radioButtonZA.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(294, 547);
            label3.Name = "label3";
            label3.Size = new Size(31, 23);
            label3.TabIndex = 25;
            label3.Text = "To";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(2, 541);
            label4.Name = "label4";
            label4.Size = new Size(56, 23);
            label4.TabIndex = 0;
            label4.Text = "From";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(16, 431);
            label5.Name = "label5";
            label5.Size = new Size(93, 26);
            label5.TabIndex = 26;
            label5.Text = "Search :";
            // 
            // button1
            // 
            button1.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(400, 380);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 28;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += refresh_Click;
            // 
            // CustomerForm
            // 
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1793, 752);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGoBack);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblContactNumber);
            Controls.Add(txtContactNumber);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblDebtAmount);
            Controls.Add(txtDebtAmount);
            Controls.Add(lblDueDate);
            Controls.Add(dateTimePickerPaymentDueDate);
       
            Controls.Add(btnDeleteCustomer);
            Controls.Add(textBoxSearch);
            Controls.Add(comboBoxFilter);
            Controls.Add(btnSearch);
            Controls.Add(dataGridViewCustomers);
            Controls.Add(textBoxDebtFrom);
            Controls.Add(textBoxDebtTo);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(dateTimePickerTo);
            Controls.Add(dateTimePickerSingle);
            Controls.Add(radioButtonAZ);
            Controls.Add(radioButtonZA);
            Name = "SupplierForm";
            Text = "Supplier Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

    }
}
