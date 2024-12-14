namespace loginPage
{
    partial class cashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cashier));
            panel1 = new Panel();
            textBox1 = new TextBox();
            OrderPicture = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1216, 87);
            panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkSeaGreen;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(245, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(719, 37);
            textBox1.TabIndex = 0;
            textBox1.Text = "WELCOME TO KARMA WALA UTILITY STORE";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // OrderPicture
            // 
            OrderPicture.Image = (Image)resources.GetObject("OrderPicture.Image");
            OrderPicture.Location = new Point(90, 204);
            OrderPicture.Name = "OrderPicture";
            OrderPicture.Size = new Size(274, 316);
            OrderPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            OrderPicture.TabIndex = 2;
            OrderPicture.TabStop = false;
            OrderPicture.Click += OrderPicture_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 151);
            label1.Name = "label1";
            label1.Size = new Size(185, 26);
            label1.TabIndex = 3;
            label1.Text = "PLACE ORDER";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(798, 204);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(272, 316);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(843, 151);
            label2.Name = "label2";
            label2.Size = new Size(182, 26);
            label2.TabIndex = 5;
            label2.Text = "VIEW ORDERS";
            // 
            // cashier
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 624);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(OrderPicture);
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            Name = "cashier";
            Text = "cashier";
            Load += cashier_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OrderPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private PictureBox OrderPicture;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
    }
}