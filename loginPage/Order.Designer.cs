namespace loginPage
{
    partial class Order
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
            label8 = new Label();
            label9 = new Label();
            staffcombo = new ComboBox();
            label12 = new Label();
            rcvdamount = new TextBox();
            button1 = new Button();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            quantityTextBox = new TextBox();
            label13 = new Label();
            label10 = new Label();
            label1 = new Label();
            label2 = new Label();
            categoryselection = new ComboBox();
            productselection = new ComboBox();
            button2 = new Button();
            panel2 = new Panel();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            debtDueDatePicker = new DateTimePicker();
            debtDueDateLabel = new Label();
            panel4 = new Panel();
            label15 = new Label();
            label14 = new Label();
            button4 = new Button();
            panel5 = new Panel();
            lblTotalAmount = new Label();
            cartGridView = new DataGridView();
            label16 = new Label();
            label17 = new Label();
            panel3 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cartGridView).BeginInit();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(38, 9);
            label8.Name = "label8";
            label8.Size = new Size(123, 25);
            label8.TabIndex = 12;
            label8.Text = "Staff details";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(445, 16);
            label9.Name = "label9";
            label9.Size = new Size(117, 25);
            label9.TabIndex = 13;
            label9.Text = "User Name";
            // 
            // staffcombo
            // 
            staffcombo.FormattingEnabled = true;
            staffcombo.Location = new Point(445, 60);
            staffcombo.Name = "staffcombo";
            staffcombo.Size = new Size(182, 33);
            staffcombo.TabIndex = 14;
            staffcombo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(20, 68);
            label12.Name = "label12";
            label12.Size = new Size(168, 25);
            label12.TabIndex = 19;
            label12.Text = "recieved amount";
            // 
            // rcvdamount
            // 
            rcvdamount.Location = new Point(242, 62);
            rcvdamount.Name = "rcvdamount";
            rcvdamount.Size = new Size(183, 31);
            rcvdamount.TabIndex = 20;
            rcvdamount.TextChanged += textBox7_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1274, 876);
            button1.Name = "button1";
            button1.Size = new Size(153, 49);
            button1.TabIndex = 21;
            button1.Text = "place order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(61, 271);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(182, 31);
            quantityTextBox.TabIndex = 5;
            quantityTextBox.Leave += quantityTextBox_Leave_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(20, 17);
            label13.Name = "label13";
            label13.Size = new Size(140, 25);
            label13.TabIndex = 20;
            label13.Text = "Total Amount";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(61, 226);
            label10.Name = "label10";
            label10.Size = new Size(98, 26);
            label10.TabIndex = 4;
            label10.Text = "quantity";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 16);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "categories";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(61, 111);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 1;
            label2.Text = "products";
            // 
            // categoryselection
            // 
            categoryselection.FormattingEnabled = true;
            categoryselection.Location = new Point(61, 58);
            categoryselection.Name = "categoryselection";
            categoryselection.Size = new Size(182, 33);
            categoryselection.TabIndex = 2;
            categoryselection.SelectedIndexChanged += categoryselection_SelectedIndexChanged;
            // 
            // productselection
            // 
            productselection.FormattingEnabled = true;
            productselection.Location = new Point(61, 161);
            productselection.Name = "productselection";
            productselection.Size = new Size(182, 33);
            productselection.TabIndex = 3;
            productselection.SelectedIndexChanged += productselection_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(78, 335);
            button2.Name = "button2";
            button2.Size = new Size(126, 34);
            button2.TabIndex = 22;
            button2.Text = "add to cart";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(staffcombo);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(txtLastName);
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(12, 619);
            panel2.Name = "panel2";
            panel2.Size = new Size(725, 338);
            panel2.TabIndex = 16;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(61, 281);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(182, 31);
            txtPhone.TabIndex = 11;
            txtPhone.Leave += txtPhone_Leave;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(61, 163);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(182, 31);
            txtLastName.TabIndex = 10;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(62, 60);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(181, 31);
            txtFirstName.TabIndex = 9;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label7.Location = new Point(61, 225);
            label7.Name = "label7";
            label7.Size = new Size(150, 25);
            label7.TabIndex = 8;
            label7.Text = "Phone number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label6.Location = new Point(61, 119);
            label6.Name = "label6";
            label6.Size = new Size(115, 25);
            label6.TabIndex = 7;
            label6.Text = "Last Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(62, 16);
            label5.Name = "label5";
            label5.Size = new Size(118, 25);
            label5.TabIndex = 6;
            label5.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 73);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 4;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label4.Location = new Point(17, 9);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 5;
            label4.Text = "Customer Details";
            label4.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(productselection);
            panel1.Controls.Add(categoryselection);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(quantityTextBox);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(12, 156);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 387);
            panel1.TabIndex = 15;
            panel1.Paint += panel1_Paint;
            // 
            // debtDueDatePicker
            // 
            debtDueDatePicker.Location = new Point(242, 120);
            debtDueDatePicker.Name = "debtDueDatePicker";
            debtDueDatePicker.Size = new Size(300, 31);
            debtDueDatePicker.TabIndex = 24;
            debtDueDatePicker.Visible = false;
            // 
            // debtDueDateLabel
            // 
            debtDueDateLabel.AutoSize = true;
            debtDueDateLabel.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            debtDueDateLabel.Location = new Point(20, 120);
            debtDueDateLabel.Name = "debtDueDateLabel";
            debtDueDateLabel.Size = new Size(172, 25);
            debtDueDateLabel.TabIndex = 25;
            debtDueDateLabel.Text = "due date for debt";
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkSeaGreen;
            panel4.Controls.Add(label15);
            panel4.Location = new Point(-1, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(1473, 74);
            panel4.TabIndex = 26;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(509, 25);
            label15.Name = "label15";
            label15.Size = new Size(422, 26);
            label15.TabIndex = 0;
            label15.Text = "PLACE CUSTOMER'S ORDER HERE";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label14.Location = new Point(17, 11);
            label14.Name = "label14";
            label14.Size = new Size(158, 25);
            label14.TabIndex = 27;
            label14.Text = "Product Details";
            // 
            // button4
            // 
            button4.Location = new Point(1105, 876);
            button4.Name = "button4";
            button4.Size = new Size(143, 49);
            button4.TabIndex = 28;
            button4.Text = "back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(label13);
            panel5.Controls.Add(lblTotalAmount);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(rcvdamount);
            panel5.Controls.Add(debtDueDatePicker);
            panel5.Controls.Add(debtDueDateLabel);
            panel5.Location = new Point(792, 619);
            panel5.Name = "panel5";
            panel5.Size = new Size(635, 220);
            panel5.TabIndex = 29;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.Location = new Point(299, 16);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(59, 26);
            lblTotalAmount.TabIndex = 31;
            lblTotalAmount.Text = "total";
            // 
            // cartGridView
            // 
            cartGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cartGridView.Location = new Point(442, 156);
            cartGridView.Name = "cartGridView";
            cartGridView.RowHeadersWidth = 62;
            cartGridView.Size = new Size(938, 369);
            cartGridView.TabIndex = 30;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(929, 111);
            label16.Name = "label16";
            label16.Size = new Size(106, 25);
            label16.TabIndex = 32;
            label16.Text = "Your Cart";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(38, 16);
            label17.Name = "label17";
            label17.Size = new Size(145, 25);
            label17.TabIndex = 33;
            label17.Text = "Billing Details";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(label14);
            panel3.Location = new Point(73, 86);
            panel3.Name = "panel3";
            panel3.Size = new Size(199, 50);
            panel3.TabIndex = 34;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveCaption;
            panel6.Controls.Add(label4);
            panel6.Location = new Point(73, 563);
            panel6.Name = "panel6";
            panel6.Size = new Size(211, 50);
            panel6.TabIndex = 35;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ActiveCaption;
            panel7.Controls.Add(label8);
            panel7.Location = new Point(457, 563);
            panel7.Name = "panel7";
            panel7.Size = new Size(199, 50);
            panel7.TabIndex = 36;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveCaption;
            panel8.Controls.Add(label17);
            panel8.Location = new Point(1034, 547);
            panel8.Name = "panel8";
            panel8.Size = new Size(199, 50);
            panel8.TabIndex = 37;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1466, 960);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(label16);
            Controls.Add(cartGridView);
            Controls.Add(panel5);
            Controls.Add(button4);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            Name = "Order";
            Text = "Order";
            Load += Order_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cartGridView).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label8;
        private Label label9;
        private TextBox textBox7;
        private Label label12;
        private Button button1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Label debtDueDateLabel;
        private TextBox quantityTextBox;
        private Label label13;
        private Label label10;
        private Label label1;
        private Label label2;
        private ComboBox categoryselection;
        private ComboBox productselection;
        private Button button2;
        private Panel panel2;
        private TextBox txtPhone;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel panel1;
        private ComboBox comboBox1;
        private DateTimePicker debtDueDatePicker;
        private ComboBox staffcombo;
        private TextBox rcvdamount;
        private Panel panel4;
        private Label label15;
        private Label label14;
        private Button button4;
        private Panel panel5;
        private DataGridView cartGridView;
        private Label lblTotalAmount;
        private Label label16;
        private Label label17;
        private Panel panel3;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
    }
}