namespace loginPage
{
    partial class profit_information
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
            DailyProfit = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DailyProfit).BeginInit();
            SuspendLayout();
            // 
            // DailyProfit
            // 
            DailyProfit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DailyProfit.Location = new Point(84, 84);
            DailyProfit.Name = "DailyProfit";
            DailyProfit.RowHeadersWidth = 62;
            DailyProfit.Size = new Size(695, 381);
            DailyProfit.TabIndex = 0;
            DailyProfit.CellContentClick += DailyProfit_CellContentClick;
            // 
            // profit_information
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 574);
            Controls.Add(DailyProfit);
            Name = "profit_information";
            Text = "profit_information";
            ((System.ComponentModel.ISupportInitialize)DailyProfit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DailyProfit;
    }
}