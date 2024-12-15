namespace loginPage
{
    partial class manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manager));
            panel1 = new Panel();
            textBox1 = new TextBox();
            viewAddProducts = new PictureBox();
            textBox3 = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)viewAddProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1213, 121);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkSeaGreen;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(218, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(719, 37);
            textBox1.TabIndex = 0;
            textBox1.Text = "WELCOME TO KARMA WALA UTILITY STORE";
            // 
            // viewAddProducts
            // 
            viewAddProducts.Cursor = Cursors.Hand;
            viewAddProducts.Image = (Image)resources.GetObject("viewAddProducts.Image");
            viewAddProducts.Location = new Point(708, 245);
            viewAddProducts.Name = "viewAddProducts";
            viewAddProducts.Size = new Size(257, 266);
            viewAddProducts.SizeMode = PictureBoxSizeMode.StretchImage;
            viewAddProducts.TabIndex = 3;
            viewAddProducts.TabStop = false;
            viewAddProducts.Click += viewAddProducts_Click;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(708, 180);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(257, 28);
            textBox3.TabIndex = 4;
            textBox3.Text = "         PRODUCTS";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(245, 245);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(238, 266);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 182);
            label1.Name = "label1";
            label1.Size = new Size(167, 26);
            label1.TabIndex = 6;
            label1.Text = "CATEGORIES";
            // 
            // button1
            // 
            button1.Location = new Point(1062, 586);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 7;
            button1.Text = "back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // manager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1211, 647);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(textBox3);
            Controls.Add(viewAddProducts);
            Controls.Add(panel1);
            Name = "manager";
            Text = "manager";
            Load += manager_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)viewAddProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private PictureBox viewAddProducts;
        private TextBox textBox3;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
    }
}