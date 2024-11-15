namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    partial class Sales
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SalesBTN = new System.Windows.Forms.Button();
            this.SalesPanelBTN = new System.Windows.Forms.Button();
            this.RprodBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SalesBTN
            // 
            this.SalesBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SalesBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SalesBTN.FlatAppearance.BorderSize = 0;
            this.SalesBTN.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SalesBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.SalesBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SalesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesBTN.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SalesBTN.Image = global::JUFAV_System.Properties.Resources.POS;
            this.SalesBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SalesBTN.Location = new System.Drawing.Point(0, 0);
            this.SalesBTN.Name = "SalesBTN";
            this.SalesBTN.Size = new System.Drawing.Size(234, 38);
            this.SalesBTN.TabIndex = 2;
            this.SalesBTN.Text = "           SALES";
            this.SalesBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SalesBTN.UseVisualStyleBackColor = false;
            // 
            // SalesPanelBTN
            // 
            this.SalesPanelBTN.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SalesPanelBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SalesPanelBTN.FlatAppearance.BorderSize = 0;
            this.SalesPanelBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SalesPanelBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesPanelBTN.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SalesPanelBTN.Location = new System.Drawing.Point(0, 38);
            this.SalesPanelBTN.Margin = new System.Windows.Forms.Padding(0);
            this.SalesPanelBTN.Name = "SalesPanelBTN";
            this.SalesPanelBTN.Size = new System.Drawing.Size(234, 38);
            this.SalesPanelBTN.TabIndex = 3;
            this.SalesPanelBTN.Text = "Sales";
            this.SalesPanelBTN.UseVisualStyleBackColor = false;
            // 
            // RprodBTN
            // 
            this.RprodBTN.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.RprodBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.RprodBTN.FlatAppearance.BorderSize = 0;
            this.RprodBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RprodBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RprodBTN.ForeColor = System.Drawing.SystemColors.InfoText;
            this.RprodBTN.Location = new System.Drawing.Point(0, 76);
            this.RprodBTN.Margin = new System.Windows.Forms.Padding(0);
            this.RprodBTN.Name = "RprodBTN";
            this.RprodBTN.Size = new System.Drawing.Size(234, 38);
            this.RprodBTN.TabIndex = 4;
            this.RprodBTN.Text = "Reserved Products";
            this.RprodBTN.UseVisualStyleBackColor = false;
            this.RprodBTN.Click += new System.EventHandler(this.RprodBTN_Click);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RprodBTN);
            this.Controls.Add(this.SalesPanelBTN);
            this.Controls.Add(this.SalesBTN);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Sales";
            this.Size = new System.Drawing.Size(234, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SalesBTN;
        private System.Windows.Forms.Button SalesPanelBTN;
        private System.Windows.Forms.Button RprodBTN;
    }
}
