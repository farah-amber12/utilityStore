﻿namespace loginPage
{
    partial class viewOrders
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
            ordersDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ordersDataGridView
            // 
            ordersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersDataGridView.Location = new Point(46, 79);
            ordersDataGridView.Name = "ordersDataGridView";
            ordersDataGridView.RowHeadersWidth = 62;
            ordersDataGridView.Size = new Size(1430, 595);
            ordersDataGridView.TabIndex = 0;
            // 
            // viewOrders
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 684);
            Controls.Add(ordersDataGridView);
            Name = "viewOrders";
            Text = "viewOrders";
            Load += viewOrders_Load;
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ordersDataGridView;
    }
}