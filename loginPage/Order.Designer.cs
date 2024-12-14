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
            panel3 = new Panel();
            staffcombo = new ComboBox();
            label12 = new Label();
            rcvdamount = new TextBox();
            button1 = new Button();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            quantityTextBox = new TextBox();
            label13 = new Label();
            label10 = new Label();
            txtSubtotal = new TextBox();
            label1 = new Label();
            label2 = new Label();
            categoryselection = new ComboBox();
            productselection = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label11 = new Label();
            panel4 = new Panel();
            label15 = new Label();
            label14 = new Label();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 29);
            label8.Name = "label8";
            label8.Size = new Size(104, 25);
            label8.TabIndex = 12;
            label8.Text = "Staff details";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(40, 94);
            label9.Name = "label9";
            label9.Size = new Size(59, 25);
            label9.TabIndex = 13;
            label9.Text = "Name";
            // 
            // panel3
            // 
            panel3.Controls.Add(staffcombo);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(820, 156);
            panel3.Name = "panel3";
            panel3.Size = new Size(487, 155);
            panel3.TabIndex = 17;
            // 
            // staffcombo
            // 
            staffcombo.FormattingEnabled = true;
            staffcombo.Location = new Point(161, 91);
            staffcombo.Name = "staffcombo";
            staffcombo.Size = new Size(182, 33);
            staffcombo.TabIndex = 14;
            staffcombo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(860, 468);
            label12.Name = "label12";
            label12.Size = new Size(144, 25);
            label12.TabIndex = 19;
            label12.Text = "recieved amount";
            // 
            // rcvdamount
            // 
            rcvdamount.Location = new Point(860, 527);
            rcvdamount.Name = "rcvdamount";
            rcvdamount.Size = new Size(183, 31);
            rcvdamount.TabIndex = 20;
            rcvdamount.TextChanged += textBox7_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(922, 689);
            button1.Name = "button1";
            button1.Size = new Size(153, 49);
            button1.TabIndex = 21;
            button1.Text = "place order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            label13.Location = new Point(860, 357);
            label13.Name = "label13";
            label13.Size = new Size(82, 25);
            label13.TabIndex = 20;
            label13.Text = "sub total";
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
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(860, 401);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(182, 31);
            txtSubtotal.TabIndex = 21;
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
            button2.Location = new Point(67, 513);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 22;
            button2.Text = "add to cart";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(217, 513);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 22;
            button3.Text = "view cart";
            button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(txtLastName);
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(414, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 323);
            panel2.TabIndex = 16;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(62, 271);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 31);
            txtPhone.TabIndex = 11;
            txtPhone.Leave += txtPhone_Leave;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(62, 163);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 31);
            txtLastName.TabIndex = 10;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(62, 60);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 31);
            txtFirstName.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label7.Location = new Point(62, 227);
            label7.Name = "label7";
            label7.Size = new Size(150, 25);
            label7.TabIndex = 8;
            label7.Text = "Phone number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label6.Location = new Point(62, 111);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label4.Location = new Point(515, 111);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 5;
            label4.Text = "Customer Details";
            label4.Click += label4_Click;
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
            // panel1
            // 
            panel1.Controls.Add(productselection);
            panel1.Controls.Add(categoryselection);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(quantityTextBox);
            panel1.Location = new Point(12, 156);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 323);
            panel1.TabIndex = 15;
            panel1.Paint += panel1_Paint;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(73, 716);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 24;
            dateTimePicker1.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(73, 670);
            label11.Name = "label11";
            label11.Size = new Size(152, 25);
            label11.TabIndex = 25;
            label11.Text = "due date for debt";
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkSeaGreen;
            panel4.Controls.Add(label15);
            panel4.Location = new Point(-1, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(1183, 74);
            panel4.TabIndex = 26;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(354, 23);
            label15.Name = "label15";
            label15.Size = new Size(422, 26);
            label15.TabIndex = 0;
            label15.Text = "PLACE CUSTOMER'S ORDER HERE";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            label14.Location = new Point(73, 111);
            label14.Name = "label14";
            label14.Size = new Size(158, 25);
            label14.TabIndex = 27;
            label14.Text = "Product Details";
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 812);
            Controls.Add(label14);
            Controls.Add(panel4);
            Controls.Add(label11);
            Controls.Add(dateTimePicker1);
            Controls.Add(button3);
            Controls.Add(panel2);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(rcvdamount);
            Controls.Add(button1);
            Controls.Add(panel3);
            Controls.Add(label12);
            Controls.Add(panel1);
            Controls.Add(txtSubtotal);
            Controls.Add(label13);
            Cursor = Cursors.Hand;
            Name = "Order";
            Text = "Order";
            Load += Order_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label8;
        private Label label9;
        private Panel panel3;
        private TextBox textBox7;
        private Label label12;
        private Button button1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Label label11;
        private TextBox quantityTextBox;
        private Label label13;
        private Label label10;
        private TextBox txtSubtotal;
        private Label label1;
        private Label label2;
        private ComboBox categoryselection;
        private ComboBox productselection;
        private Button button2;
        private Button button3;
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
        private DateTimePicker dateTimePicker1;
        private ComboBox staffcombo;
        private TextBox rcvdamount;
        private Panel panel4;
        private Label label15;
        private Label label14;
    }
}