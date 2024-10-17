namespace JUFAV_System.Messageboxes
{
    partial class PdfFileViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfFileViewer));
            this.OPTIONS = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Print = new System.Windows.Forms.Button();
            this.OPTIONS.SuspendLayout();
            this.SuspendLayout();
            // 
            // OPTIONS
            // 
            this.OPTIONS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OPTIONS.Controls.Add(this.label1);
            this.OPTIONS.Controls.Add(this.comboBox1);
            this.OPTIONS.Controls.Add(this.Print);
            this.OPTIONS.Dock = System.Windows.Forms.DockStyle.Top;
            this.OPTIONS.Location = new System.Drawing.Point(0, 0);
            this.OPTIONS.Name = "OPTIONS";
            this.OPTIONS.Size = new System.Drawing.Size(812, 47);
            this.OPTIONS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PRINTER TO USE :";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(336, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // Print
            // 
            this.Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print.Location = new System.Drawing.Point(3, 3);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(164, 39);
            this.Print.TabIndex = 0;
            this.Print.Text = "PRINT DOCUMENT";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // PdfFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 649);
            this.Controls.Add(this.OPTIONS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PdfFileViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PdfFileViewer";
            this.OPTIONS.ResumeLayout(false);
            this.OPTIONS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OPTIONS;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}