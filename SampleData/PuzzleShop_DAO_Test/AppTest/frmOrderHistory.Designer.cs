namespace AppTest
{
    partial class frmOrderHistory
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
            this.tblOrderHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tblOrderHistory
            // 
            this.tblOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOrderHistory.Location = new System.Drawing.Point(51, 56);
            this.tblOrderHistory.Name = "tblOrderHistory";
            this.tblOrderHistory.RowTemplate.Height = 24;
            this.tblOrderHistory.Size = new System.Drawing.Size(494, 294);
            this.tblOrderHistory.TabIndex = 0;
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblOrderHistory);
            this.Name = "frmOrderHistory";
            this.Text = "Order History";
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblOrderHistory;
    }
}