namespace Puzzle_Shop
{
    partial class frmDisplayToy
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
            this.tblToy = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToyType = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.btnOrderHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblToy)).BeginInit();
            this.SuspendLayout();
            // 
            // tblToy
            // 
            this.tblToy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblToy.Location = new System.Drawing.Point(37, 55);
            this.tblToy.Name = "tblToy";
            this.tblToy.RowTemplate.Height = 24;
            this.tblToy.Size = new System.Drawing.Size(811, 494);
            this.tblToy.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(131, 568);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(236, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 573);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // btnToyType
            // 
            this.btnToyType.Location = new System.Drawing.Point(906, 87);
            this.btnToyType.Name = "btnToyType";
            this.btnToyType.Size = new System.Drawing.Size(128, 34);
            this.btnToyType.TabIndex = 3;
            this.btnToyType.Text = "Show Toy Type";
            this.btnToyType.UseVisualStyleBackColor = true;
            this.btnToyType.Click += new System.EventHandler(this.btnToyType_Click);
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(906, 151);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(128, 33);
            this.btnReview.TabIndex = 4;
            this.btnReview.Text = "Add Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(765, 19);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(0, 17);
            this.lbWelcome.TabIndex = 5;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(935, 10);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(144, 34);
            this.btnSetting.TabIndex = 6;
            this.btnSetting.Text = "Account Settings";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(906, 225);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(128, 35);
            this.btnAddOrder.TabIndex = 7;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.Location = new System.Drawing.Point(906, 293);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(128, 39);
            this.btnViewOrder.TabIndex = 8;
            this.btnViewOrder.Text = "View Order";
            this.btnViewOrder.UseVisualStyleBackColor = true;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // btnOrderHistory
            // 
            this.btnOrderHistory.Location = new System.Drawing.Point(906, 375);
            this.btnOrderHistory.Name = "btnOrderHistory";
            this.btnOrderHistory.Size = new System.Drawing.Size(128, 41);
            this.btnOrderHistory.TabIndex = 9;
            this.btnOrderHistory.Text = "Order History";
            this.btnOrderHistory.UseVisualStyleBackColor = true;
            this.btnOrderHistory.Click += new System.EventHandler(this.btnOrderHistory_Click);
            // 
            // frmDisplayToy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 622);
            this.Controls.Add(this.btnOrderHistory);
            this.Controls.Add(this.btnViewOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.btnToyType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.tblToy);
            this.Name = "frmDisplayToy";
            this.Text = "Puzzle Shop";
            ((System.ComponentModel.ISupportInitialize)(this.tblToy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblToy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToyType;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.Button btnOrderHistory;
    }
}