
namespace loginPage
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            label3 = new Label();
            label4 = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            comboBoxRole = new ComboBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(423, 193);
            label3.Name = "label3";
            label3.Size = new Size(111, 26);
            label3.TabIndex = 2;
            label3.Text = "username";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(426, 250);
            label4.Name = "label4";
            label4.Size = new Size(108, 26);
            label4.TabIndex = 3;
            label4.Text = "password";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(573, 188);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(185, 31);
            tbUsername.TabIndex = 4;
            tbUsername.TextChanged += textBox1_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(573, 245);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(185, 31);
            tbPassword.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSeaGreen;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(573, 367);
            button1.Name = "button1";
            button1.Size = new Size(91, 40);
            button1.TabIndex = 6;
            button1.Text = "login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(817, 74);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(210, 22);
            label2.Name = "label2";
            label2.Size = new Size(367, 36);
            label2.TabIndex = 0;
            label2.Text = "Karma Wala Utility Store";
            label2.Click += label2_Click;
            // 
            // comboBoxRole
            // 
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Items.AddRange(new object[] { "Select Role", "Owner", "Cashier", "Manager" });
            comboBoxRole.Location = new Point(573, 119);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(185, 33);
            comboBoxRole.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(440, 126);
            label5.Name = "label5";
            label5.Size = new Size(59, 26);
            label5.TabIndex = 9;
            label5.Text = "Role";
            label5.Click += label5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(391, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(693, 367);
            button2.Name = "button2";
            button2.Size = new Size(91, 40);
            button2.TabIndex = 11;
            button2.Text = "clear";
            button2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(573, 308);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(151, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "show password";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(817, 475);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(comboBoxRole);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label4;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button button1;
        private Panel panel1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label5;
        private PictureBox pictureBox1;
        private Button button2;
        private CheckBox checkBox1;
        private ComboBox comboBoxRole;
    }
}
