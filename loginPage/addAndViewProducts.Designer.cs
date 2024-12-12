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
            label3 = new Label();
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
            label11 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label12 = new Label();
            cmbUnit = new ComboBox();
            dtpExpiryDate = new DateTimePicker();
            categorycombo = new ComboBox();
            label13 = new Label();
            suppliercombo = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            productsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 26);
            label3.Name = "label3";
            label3.Size = new Size(131, 25);
            label3.TabIndex = 3;
            label3.Text = "product details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 88);
            label4.Name = "label4";
            label4.Size = new Size(131, 25);
            label4.TabIndex = 4;
            label4.Text = " Product Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 148);
            label5.Name = "label5";
            label5.Size = new Size(136, 25);
            label5.TabIndex = 5;
            label5.Text = "Category Name";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 208);
            label6.Name = "label6";
            label6.Size = new Size(110, 25);
            label6.TabIndex = 6;
            label6.Text = "Brand Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(952, 88);
            label7.Name = "label7";
            label7.Size = new Size(99, 25);
            label7.TabIndex = 7;
            label7.Text = "Stock Level";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(419, 156);
            label8.Name = "label8";
            label8.Size = new Size(124, 25);
            label8.TabIndex = 8;
            label8.Text = "Purchase Price";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(419, 225);
            label9.Name = "label9";
            label9.Size = new Size(116, 25);
            label9.TabIndex = 9;
            label9.Text = " Selling Price ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(419, 88);
            label10.Name = "label10";
            label10.Size = new Size(101, 25);
            label10.TabIndex = 10;
            label10.Text = "Expiry Date";
            // 
            // button1
            // 
            button1.Location = new Point(557, 307);
            button1.Name = "button1";
            button1.Size = new Size(150, 34);
            button1.TabIndex = 11;
            button1.Text = "Add Product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(176, 88);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(150, 31);
            txtProductName.TabIndex = 13;
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(176, 219);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new Size(150, 31);
            txtBrandName.TabIndex = 15;
            // 
            // txtStockLevel
            // 
            txtStockLevel.Location = new Point(1105, 88);
            txtStockLevel.Name = "txtStockLevel";
            txtStockLevel.Size = new Size(150, 31);
            txtStockLevel.TabIndex = 16;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(557, 153);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(150, 31);
            txtPurchasePrice.TabIndex = 17;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(557, 225);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(150, 31);
            txtSellingPrice.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(730, 26);
            label11.Name = "label11";
            label11.Size = new Size(210, 25);
            label11.TabIndex = 20;
            label11.Text = "complete product details";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(393, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(10, 21);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(952, 161);
            label12.Name = "label12";
            label12.Size = new Size(42, 25);
            label12.TabIndex = 22;
            label12.Text = "unit";
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
            categorycombo.Location = new Point(176, 148);
            categorycombo.Name = "categorycombo";
            categorycombo.Size = new Size(150, 33);
            categorycombo.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(952, 228);
            label13.Name = "label13";
            label13.Size = new Size(127, 25);
            label13.TabIndex = 26;
            label13.Text = "supplier Name";
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
            button2.Location = new Point(778, 307);
            button2.Name = "button2";
            button2.Size = new Size(178, 34);
            button2.TabIndex = 28;
            button2.Text = "delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(308, 307);
            button3.Name = "button3";
            button3.Size = new Size(161, 34);
            button3.TabIndex = 29;
            button3.Text = "update";
            button3.UseVisualStyleBackColor = true;
            // 
            // productsGridView
            // 
            productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGridView.Location = new Point(5, 382);
            productsGridView.Name = "productsGridView";
            productsGridView.RowHeadersWidth = 62;
            productsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsGridView.Size = new Size(1378, 435);
            productsGridView.TabIndex = 30;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1627, 783);
            Controls.Add(productsGridView);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(suppliercombo);
            Controls.Add(label13);
            Controls.Add(categorycombo);
            Controls.Add(dtpExpiryDate);
            Controls.Add(cmbUnit);
            Controls.Add(label12);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label11);
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
            Controls.Add(label3);
            Name = "Products";
            Text = "Products";
            Load += addAndViewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
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
        private Label label11;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label12;
        private ComboBox cmbUnit;
        private DateTimePicker dtpExpiryDate;
        private ComboBox categorycombo;
        private Label label13;
        private ComboBox suppliercombo;
        private Button button2;
        private Button button3;
        private DataGridView productsGridView;
    }
}