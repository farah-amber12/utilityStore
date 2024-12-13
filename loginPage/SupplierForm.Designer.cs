namespace loginPage
{
    partial class SupplierForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDebtAmount;
        private System.Windows.Forms.TextBox txtDebtAmount;
        private System.Windows.Forms.Label lblPaymentDueDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerPaymentDueDate;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Button btnUpdateSupplier;
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSupplierName = new Label();
            txtSupplierName = new TextBox();
            lblContactNumber = new Label();
            txtContactNumber = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblDebtAmount = new Label();
            txtDebtAmount = new TextBox();
            lblPaymentDueDate = new Label();
            dateTimePickerPaymentDueDate = new DateTimePicker();
            btnAddSupplier = new Button();
            btnDeleteSupplier = new Button();
            btnUpdateSupplier = new Button();
            dataGridViewSuppliers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).BeginInit();
            SuspendLayout();

            // 
            // lblSupplierName
            // 
            lblSupplierName.AutoSize = true;
            lblSupplierName.Location = new Point(20, 20);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.Size = new Size(133, 25);
            lblSupplierName.TabIndex = 0;
            lblSupplierName.Text = "Supplier Name:";

            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(189, 20);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(273, 31);
            txtSupplierName.TabIndex = 1;

            // 
            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.Location = new Point(20, 60);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(147, 25);
            lblContactNumber.TabIndex = 2;
            lblContactNumber.Text = "Contact Number:";

            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(189, 60);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(273, 31);
            txtContactNumber.TabIndex = 3;

            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(20, 100);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(81, 25);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";

            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(189, 100);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(273, 31);
            txtAddress.TabIndex = 5;

            // 
            // lblDebtAmount
            // 
            lblDebtAmount.AutoSize = true;
            lblDebtAmount.Location = new Point(4, 146);
            lblDebtAmount.Name = "lblDebtAmount";
            lblDebtAmount.Size = new Size(125, 25);
            lblDebtAmount.TabIndex = 6;
            lblDebtAmount.Text = "Debt Amount:";

            // 
            // txtDebtAmount
            // 
            txtDebtAmount.Location = new Point(189, 140);
            txtDebtAmount.Name = "txtDebtAmount";
            txtDebtAmount.Size = new Size(273, 31);
            txtDebtAmount.TabIndex = 7;

            // 
            // lblPaymentDueDate
            // 
            lblPaymentDueDate.AutoSize = true;
            lblPaymentDueDate.Location = new Point(4, 199);
            lblPaymentDueDate.Name = "lblPaymentDueDate";
            lblPaymentDueDate.Size = new Size(163, 25);
            lblPaymentDueDate.TabIndex = 8;
            lblPaymentDueDate.Text = "Payment Due Date:";

            // 
            // dateTimePickerPaymentDueDate
            // 
            dateTimePickerPaymentDueDate.Location = new Point(189, 193);
            dateTimePickerPaymentDueDate.Name = "dateTimePickerPaymentDueDate";
            dateTimePickerPaymentDueDate.Size = new Size(273, 31);
            dateTimePickerPaymentDueDate.TabIndex = 9;

            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(50, 288);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(183, 36);
            btnAddSupplier.TabIndex = 10;
            btnAddSupplier.Text = "Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;

            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Location = new Point(280, 288);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(183, 36);
            btnDeleteSupplier.TabIndex = 11;
            btnDeleteSupplier.Text = "Delete Supplier";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;

            // 
            // dataGridViewSuppliers
            // 
            dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSuppliers.Location = new Point(506, 12);
            dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            dataGridViewSuppliers.RowHeadersWidth = 62;
            dataGridViewSuppliers.Size = new Size(780, 527);
            dataGridViewSuppliers.TabIndex = 12;

            // Update Supplier Button
           
            btnUpdateSupplier.Location = new Point(450, 288);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(183, 36);
            btnUpdateSupplier.TabIndex = 13;
            btnUpdateSupplier.Text = "Update Supplier";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;

          



            // 
            // SupplierForm
            // 
            
            ClientSize = new Size(1312, 596);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(lblSupplierName);
            Controls.Add(txtSupplierName);
            Controls.Add(lblContactNumber);
            Controls.Add(txtContactNumber);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblDebtAmount);
            Controls.Add(txtDebtAmount);
            Controls.Add(lblPaymentDueDate);
            Controls.Add(dateTimePickerPaymentDueDate);
            Controls.Add(btnAddSupplier);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(dataGridViewSuppliers);
            Name = "SupplierForm";
            Text = "Supplier Management";
            Load += SupplierForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
