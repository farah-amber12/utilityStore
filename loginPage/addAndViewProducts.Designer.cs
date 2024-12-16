namespace loginPage
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button1 = new Button();
            txtProductName = new TextBox();
            txtBrandName = new TextBox();
            txtStockLevel = new TextBox();
            txtPurchasePrice = new TextBox();
            txtSellingPrice = new TextBox();
            label12 = new Label();
            cmbUnit = new ComboBox();
            dtpExpiryDate = new DateTimePicker();
            categorycombo = new ComboBox();
            label13 = new Label();
            suppliercombo = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            productsGridView = new DataGridView();
            button4 = new Button();
            label3 = new Label();
            label11 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label4.ForeColor = Color.MediumSeaGreen;
            label4.Location = new Point(1, 90);
            label4.Name = "label4";
            label4.Size = new Size(184, 29);
            label4.TabIndex = 4;
            label4.Text = " Product Name :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label5.ForeColor = Color.MediumSeaGreen;
            label5.Location = new Point(-4, 150);
            label5.Name = "label5";
            label5.Size = new Size(191, 29);
            label5.TabIndex = 5;
            label5.Text = "Category Name :";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label6.ForeColor = Color.MediumSeaGreen;
            label6.Location = new Point(29, 215);
            label6.Name = "label6";
            label6.Size = new Size(156, 29);
            label6.TabIndex = 6;
            label6.Text = "Brand Name :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label7.ForeColor = Color.MediumSeaGreen;
            label7.Location = new Point(933, 90);
            label7.Name = "label7";
            label7.Size = new Size(148, 29);
            label7.TabIndex = 7;
            label7.Text = "Stock Level :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label8.ForeColor = Color.MediumSeaGreen;
            label8.Location = new Point(400, 158);
            label8.Name = "label8";
            label8.Size = new Size(184, 29);
            label8.TabIndex = 8;
            label8.Text = "Purchase Price :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label9.ForeColor = Color.MediumSeaGreen;
            label9.Location = new Point(400, 227);
            label9.Name = "label9";
            label9.Size = new Size(160, 29);
            label9.TabIndex = 9;
            label9.Text = " Selling Price ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label10.ForeColor = Color.MediumSeaGreen;
            label10.Location = new Point(400, 90);
            label10.Name = "label10";
            label10.Size = new Size(160, 29);
            label10.TabIndex = 10;
            label10.Text = "Expiry Date : ";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSeaGreen;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(557, 307);
            button1.Name = "button1";
            button1.Size = new Size(165, 52);
            button1.TabIndex = 11;
            button1.Text = "Add Product : ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(179, 90);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(150, 31);
            txtProductName.TabIndex = 13;
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(178, 213);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new Size(150, 31);
            txtBrandName.TabIndex = 15;
            // 
            // txtStockLevel
            // 
            txtStockLevel.Location = new Point(1105, 90);
            txtStockLevel.Name = "txtStockLevel";
            txtStockLevel.Size = new Size(150, 31);
            txtStockLevel.TabIndex = 16;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(585, 153);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(150, 31);
            txtPurchasePrice.TabIndex = 17;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(588, 225);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(150, 31);
            txtSellingPrice.TabIndex = 18;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label12.ForeColor = Color.MediumSeaGreen;
            label12.Location = new Point(933, 163);
            label12.Name = "label12";
            label12.Size = new Size(78, 29);
            label12.TabIndex = 22;
            label12.Text = "Unit : ";
            // 
            // cmbUnit
            // 
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Items.AddRange(new object[] { "piece", "miligram", "gram", "kilogram", "millilitre", "liter", "" });
            cmbUnit.Location = new Point(1105, 153);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(150, 33);
            cmbUnit.TabIndex = 23;
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Location = new Point(557, 86);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(324, 31);
            dtpExpiryDate.TabIndex = 24;
            dtpExpiryDate.Value = new DateTime(2024, 12, 8, 18, 41, 0, 0);
            // 
            // categorycombo
            // 
            categorycombo.FormattingEnabled = true;
            categorycombo.Location = new Point(181, 150);
            categorycombo.Name = "categorycombo";
            categorycombo.Size = new Size(150, 33);
            categorycombo.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Bell MT", 12F, FontStyle.Bold);
            label13.ForeColor = Color.MediumSeaGreen;
            label13.Location = new Point(933, 230);
            label13.Name = "label13";
            label13.Size = new Size(181, 29);
            label13.TabIndex = 26;
            label13.Text = "Supplier Name :";
            // 
            // suppliercombo
            // 
            suppliercombo.FormattingEnabled = true;
            suppliercombo.Location = new Point(1105, 225);
            suppliercombo.Name = "suppliercombo";
            suppliercombo.Size = new Size(150, 33);
            suppliercombo.TabIndex = 27;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkSeaGreen;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(778, 307);
            button2.Name = "button2";
            button2.Size = new Size(193, 52);
            button2.TabIndex = 28;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkSeaGreen;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(308, 307);
            button3.Name = "button3";
            button3.Size = new Size(176, 52);
            button3.TabIndex = 29;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            // 
            // productsGridView
            // 
            productsGridView.BackgroundColor = Color.White;
            productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGridView.Location = new Point(38, 402);
            productsGridView.Name = "productsGridView";
            productsGridView.RowHeadersWidth = 62;
            productsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsGridView.Size = new Size(1326, 380);
            productsGridView.TabIndex = 30;
            productsGridView.CellContentClick += productsGridView_CellContentClick;
            // 
            // button4
            // 
            button4.Location = new Point(1140, 853);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 31;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sylfaen", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(267, 47);
            label3.TabIndex = 3;
            label3.Text = "Product Details";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Sylfaen", 18F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.RightToLeft = RightToLeft.Yes;
            label11.Size = new Size(431, 47);
            label11.TabIndex = 20;
            label11.Text = "Complete Product Details";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.DarkSeaGreen;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.4117641F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Location = new Point(38, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(326, 68);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.BackColor = Color.DarkSeaGreen;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.4117641F));
            tableLayoutPanel2.Controls.Add(label11, 0, 0);
            tableLayoutPanel2.Location = new Point(419, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(836, 68);
            tableLayoutPanel2.TabIndex = 33;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1385, 905);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(button4);
            Controls.Add(productsGridView);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(suppliercombo);
            Controls.Add(label13);
            Controls.Add(categorycombo);
            Controls.Add(dtpExpiryDate);
            Controls.Add(cmbUnit);
            Controls.Add(label12);
            Controls.Add(txtSellingPrice);
            Controls.Add(txtPurchasePrice);
            Controls.Add(txtStockLevel);
            Controls.Add(txtBrandName);
            Controls.Add(txtProductName);
            Controls.Add(button1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tableLayoutPanel1);
            Name = "Products";
            Text = "Products";
            Load += addAndViewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button1;
        private TextBox txtProductName;
        private TextBox txtBrandName;
        private TextBox txtStockLevel;
        private TextBox txtPurchasePrice;
        private TextBox txtSellingPrice;
        private Label label12;
        private ComboBox cmbUnit;
        private DateTimePicker dtpExpiryDate;
        private ComboBox categorycombo;
        private Label label13;
        private ComboBox suppliercombo;
        private Button button2;
        private Button button3;
        private DataGridView productsGridView;
        private Button button4;
        private Label label3;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}