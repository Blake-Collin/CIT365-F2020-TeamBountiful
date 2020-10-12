namespace MegaDesk1._0
{
    partial class SearchQuotes
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
            this.searchQuoteMaterialDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchQuotes = new System.Windows.Forms.Button();
            this.dataGridSearchQuotes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // searchQuoteMaterialDropdown
            // 
            this.searchQuoteMaterialDropdown.FormattingEnabled = true;
            this.searchQuoteMaterialDropdown.Items.AddRange(new object[] {
            "Laminate",
            "Oak",
            "Rosewood",
            "Veneer",
            "Pine"});
            this.searchQuoteMaterialDropdown.Location = new System.Drawing.Point(162, 122);
            this.searchQuoteMaterialDropdown.Name = "searchQuoteMaterialDropdown";
            this.searchQuoteMaterialDropdown.Size = new System.Drawing.Size(121, 21);
            this.searchQuoteMaterialDropdown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Surface Material";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(79, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "To see all quotes with the same surface material, choose the appropriate material" +
    " and click SEARCH";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSearchQuotes
            // 
            this.btnSearchQuotes.Location = new System.Drawing.Point(162, 175);
            this.btnSearchQuotes.Name = "btnSearchQuotes";
            this.btnSearchQuotes.Size = new System.Drawing.Size(75, 23);
            this.btnSearchQuotes.TabIndex = 3;
            this.btnSearchQuotes.Text = "SEARCH";
            this.btnSearchQuotes.UseVisualStyleBackColor = true;
            this.btnSearchQuotes.Click += new System.EventHandler(this.btnSearchQuotes_Click);
            // 
            // dataGridSearchQuotes
            // 
            this.dataGridSearchQuotes.AllowUserToAddRows = false;
            this.dataGridSearchQuotes.AllowUserToDeleteRows = false;
            this.dataGridSearchQuotes.AllowUserToResizeColumns = false;
            this.dataGridSearchQuotes.AllowUserToResizeRows = false;
            this.dataGridSearchQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearchQuotes.Location = new System.Drawing.Point(346, 48);
            this.dataGridSearchQuotes.Name = "dataGridSearchQuotes";
            this.dataGridSearchQuotes.Size = new System.Drawing.Size(240, 150);
            this.dataGridSearchQuotes.TabIndex = 4;
            // 
            // SearchQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 280);
            this.Controls.Add(this.dataGridSearchQuotes);
            this.Controls.Add(this.btnSearchQuotes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchQuoteMaterialDropdown);
            this.Name = "SearchQuotes";
            this.Text = "Search Quotes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchQuotes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchQuotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox searchQuoteMaterialDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchQuotes;
        private System.Windows.Forms.DataGridView dataGridSearchQuotes;
    }
}