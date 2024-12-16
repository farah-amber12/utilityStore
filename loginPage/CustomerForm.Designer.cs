
namespace loginPage
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

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

        private void InitializeComponent()
        {
            dateTimePickerPaymentDueDate = new DateTimePicker();
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
            // 
            // dateTimePickerPaymentDueDate
            // 
            dateTimePickerPaymentDueDate.Location = new Point(91, 69);
            dateTimePickerPaymentDueDate.Name = "dateTimePickerPaymentDueDate";
            dateTimePickerPaymentDueDate.Size = new Size(322, 31);
            dateTimePickerPaymentDueDate.TabIndex = 15;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.BackColor = Color.DarkSlateGray;
            btnDeleteCustomer.ForeColor = Color.White;
            btnDeleteCustomer.Location = new Point(259, 119);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(222, 44);
            btnDeleteCustomer.TabIndex = 2;
            btnDeleteCustomer.Text = "Delete Customer";
            btnDeleteCustomer.UseVisualStyleBackColor = false;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.BackColor = Color.DarkSlateGray;
            btnUpdateCustomer.ForeColor = Color.White;
            btnUpdateCustomer.Location = new Point(29, 119);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(210, 44);
            btnUpdateCustomer.TabIndex = 3;
            btnUpdateCustomer.Text = "Update Customer";
            btnUpdateCustomer.UseVisualStyleBackColor = false;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.BackgroundColor = Color.White;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(609, 12);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.RowHeadersWidth = 62;
            dataGridViewCustomers.Size = new Size(1098, 573);
            dataGridViewCustomers.TabIndex = 4;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(141, 181);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(233, 31);
            textBoxSearch.TabIndex = 5;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilter.Items.AddRange(new object[] { "All", "Filter by Name", "Filter by City", "With Debt", "Without Debt", "Filter by Date" });
            comboBoxFilter.Location = new Point(133, 239);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(150, 33);
            comboBoxFilter.TabIndex = 6;
            comboBoxFilter.SelectedIndexChanged += comboBoxFilter_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkSlateGray;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(403, 177);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(128, 37);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.DarkRed;
            btnGoBack.ForeColor = Color.White;
            btnGoBack.Location = new Point(365, 367);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(150, 36);
            btnGoBack.TabIndex = 0;
            btnGoBack.Text = "Go Back";
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 242);
            label1.Name = "label1";
            label1.Size = new Size(111, 33);
            label1.TabIndex = 7;
            label1.Text = "Filter By:";
            // 
            // label2
            // 
            label2.BackColor = Color.DarkSeaGreen;
            label2.Font = new Font("Britannic Bold", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 184);
            label2.Name = "label2";
            label2.Size = new Size(104, 42);
            label2.TabIndex = 8;
            label2.Text = "Search  :";
            // 
            // textBoxDebtFrom
            // 
            textBoxDebtFrom.Location = new Point(180, 310);
            textBoxDebtFrom.Name = "textBoxDebtFrom";
            textBoxDebtFrom.Size = new Size(159, 31);
            textBoxDebtFrom.TabIndex = 11;
            textBoxDebtFrom.Visible = false;
            // 
            // textBoxDebtTo
            // 
            textBoxDebtTo.Location = new Point(162, 368);
            textBoxDebtTo.Name = "textBoxDebtTo";
            textBoxDebtTo.Size = new Size(166, 31);
            textBoxDebtTo.TabIndex = 13;
            textBoxDebtTo.Visible = false;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(171, 310);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(188, 31);
            dateTimePickerFrom.TabIndex = 0;
            dateTimePickerFrom.Visible = false;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(159, 367);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(200, 31);
            dateTimePickerTo.TabIndex = 0;
            dateTimePickerTo.Visible = false;
            // 
            // dateTimePickerSingle
            // 
            dateTimePickerSingle.Location = new Point(141, 179);
            dateTimePickerSingle.Name = "dateTimePickerSingle";
            dateTimePickerSingle.Size = new Size(233, 31);
            dateTimePickerSingle.TabIndex = 0;
            dateTimePickerSingle.Visible = false;
            // 
            // radioButtonAZ
            // 
            radioButtonAZ.AutoSize = true;
            radioButtonAZ.Location = new Point(309, 246);
            radioButtonAZ.Name = "radioButtonAZ";
            radioButtonAZ.Size = new Size(104, 29);
            radioButtonAZ.TabIndex = 0;
            radioButtonAZ.TabStop = true;
            radioButtonAZ.Text = "Sort A-Z";
            radioButtonAZ.UseVisualStyleBackColor = true;
            radioButtonAZ.Visible = false;
            // 
            // radioButtonZA
            // 
            radioButtonZA.AutoSize = true;
            radioButtonZA.Location = new Point(419, 246);
            radioButtonZA.Name = "radioButtonZA";
            radioButtonZA.Size = new Size(104, 29);
            radioButtonZA.TabIndex = 0;
            radioButtonZA.TabStop = true;
            radioButtonZA.Text = "Sort Z-A";
            radioButtonZA.UseVisualStyleBackColor = true;
            radioButtonZA.Visible = false;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.Menu;
            label3.Location = new Point(12, 303);
            label3.Name = "label3";
            label3.Size = new Size(127, 35);
            label3.TabIndex = 10;
            label3.Text = " Range From:";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Menu;
            label4.Location = new Point(9, 367);
            label4.Name = "label4";
            label4.Size = new Size(130, 33);
            label4.TabIndex = 12;
            label4.Text = " Range To:";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.BackColor = Color.LightYellow;
            label5.Location = new Point(9, 9);
            label5.Name = "label5";
            label5.Size = new Size(230, 31);
            label5.TabIndex = 14;
            label5.Text = "Payment Date To Update :";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(403, 307);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = false;
            button1.Click += refresh_Click;
            // 
            // CustomerForm
            // 
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1793, 752);
            Controls.Add(btnGoBack);
            Controls.Add(btnSearch);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(dataGridViewCustomers);
            Controls.Add(textBoxSearch);
            Controls.Add(comboBoxFilter);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBoxDebtFrom);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(dateTimePickerSingle);
            Controls.Add(dateTimePickerTo);
            Controls.Add(radioButtonAZ);
            Controls.Add(radioButtonZA);
            Controls.Add(label4);
            Controls.Add(textBoxDebtTo);
            Controls.Add(label5);
            Controls.Add(dateTimePickerPaymentDueDate);
            Name = "CustomerForm";
            Text = "Customer Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
