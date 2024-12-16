namespace loginPage
{
    partial class Categories
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
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            categoryfield = new TextBox();
            button1 = new Button();
            button3 = new Button();
            dgvCategory = new DataGridView();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(673, 241);
            button2.Name = "button2";
            button2.Size = new Size(150, 34);
            button2.TabIndex = 16;
            button2.Text = "Add ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(637, 24);
            label2.Name = "label2";
            label2.Size = new Size(384, 41);
            label2.TabIndex = 15;
            label2.Text = "CATOGARY DETAILS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Banner", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(558, 125);
            label1.Name = "label1";
            label1.Size = new Size(176, 35);
            label1.TabIndex = 14;
            label1.Text = "Catogary Name :";
            // 
            // categoryfield
            // 
            categoryfield.Location = new Point(797, 130);
            categoryfield.Name = "categoryfield";
            categoryfield.Size = new Size(268, 31);
            categoryfield.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(859, 241);
            button1.Name = "button1";
            button1.Size = new Size(162, 34);
            button1.TabIndex = 17;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(486, 241);
            button3.Name = "button3";
            button3.Size = new Size(153, 34);
            button3.TabIndex = 18;
            button3.Text = "update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dgvCategory
            // 
            dgvCategory.BackgroundColor = Color.White;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(442, 311);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.RowHeadersWidth = 62;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.Size = new Size(774, 379);
            dgvCategory.TabIndex = 19;
            // 
            // button4
            // 
            button4.Location = new Point(1067, 241);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 20;
            button4.Text = "back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Categories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1898, 1024);
            Controls.Add(button4);
            Controls.Add(dgvCategory);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(categoryfield);
            Name = "Categories";
            Text = "Categories";
            Load += Categories_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label2;
        private Label label1;
        private TextBox categoryfield;
        private Button button1;
        private Button button3;
        private DataGridView dgvCategory;
        private Button button4;
    }
}