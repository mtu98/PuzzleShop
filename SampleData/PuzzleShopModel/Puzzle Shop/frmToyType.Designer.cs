namespace Puzzle_Shop
{
    partial class frmToyType
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
            this.tblType = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblType)).BeginInit();
            this.SuspendLayout();
            // 
            // tblType
            // 
            this.tblType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblType.Location = new System.Drawing.Point(101, 84);
            this.tblType.Name = "tblType";
            this.tblType.RowTemplate.Height = 24;
            this.tblType.Size = new System.Drawing.Size(396, 267);
            this.tblType.TabIndex = 0;
            // 
            // frmToyType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblType);
            this.Name = "frmToyType";
            this.Text = "Toy Type";
            ((System.ComponentModel.ISupportInitialize)(this.tblType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblType;
    }
}