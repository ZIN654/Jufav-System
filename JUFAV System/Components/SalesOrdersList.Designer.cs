namespace JUFAV_System.Components
{
    partial class SalesOrdersList
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
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.total = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.DecrementBTN = new System.Windows.Forms.Button();
            this.IncrmentBTN = new System.Windows.Forms.Button();
            this.quantitytxtbox = new System.Windows.Forms.TextBox();
            this.Prodname = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.TrashBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel7.ColumnCount = 5;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.48564F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.51436F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel7.Controls.Add(this.total, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.panel10, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.Prodname, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.Price, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.TrashBTN, 4, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(582, 34);
            this.tableLayoutPanel7.TabIndex = 10;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total.Location = new System.Drawing.Point(475, 1);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(68, 32);
            this.total.TabIndex = 3;
            this.total.Text = "label26";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.DecrementBTN);
            this.panel10.Controls.Add(this.IncrmentBTN);
            this.panel10.Controls.Add(this.quantitytxtbox);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(380, 1);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(91, 32);
            this.panel10.TabIndex = 5;
            // 
            // DecrementBTN
            // 
            this.DecrementBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.Minus;
            this.DecrementBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DecrementBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.DecrementBTN.FlatAppearance.BorderSize = 0;
            this.DecrementBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecrementBTN.Location = new System.Drawing.Point(0, 0);
            this.DecrementBTN.Name = "DecrementBTN";
            this.DecrementBTN.Size = new System.Drawing.Size(20, 32);
            this.DecrementBTN.TabIndex = 1;
            this.DecrementBTN.UseVisualStyleBackColor = true;
            this.DecrementBTN.Click += new System.EventHandler(this.DecrementBTN_Click);
            // 
            // IncrmentBTN
            // 
            this.IncrmentBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.Plus;
            this.IncrmentBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IncrmentBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.IncrmentBTN.FlatAppearance.BorderSize = 0;
            this.IncrmentBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IncrmentBTN.Location = new System.Drawing.Point(71, 0);
            this.IncrmentBTN.Name = "IncrmentBTN";
            this.IncrmentBTN.Size = new System.Drawing.Size(20, 32);
            this.IncrmentBTN.TabIndex = 0;
            this.IncrmentBTN.UseVisualStyleBackColor = true;
            this.IncrmentBTN.Click += new System.EventHandler(this.IncrmentBTN_Click);
            // 
            // quantitytxtbox
            // 
            this.quantitytxtbox.Font = new System.Drawing.Font("Actor", 12F);
            this.quantitytxtbox.Location = new System.Drawing.Point(25, 3);
            this.quantitytxtbox.Name = "quantitytxtbox";
            this.quantitytxtbox.Size = new System.Drawing.Size(39, 27);
            this.quantitytxtbox.TabIndex = 2;
            this.quantitytxtbox.Text = "1";
            this.quantitytxtbox.Click += new System.EventHandler(this.quantitytxtbox_Click);
            this.quantitytxtbox.TextChanged += new System.EventHandler(this.quantitytxtbox_TextChanged);
            // 
            // Prodname
            // 
            this.Prodname.AutoSize = true;
            this.Prodname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Prodname.Location = new System.Drawing.Point(4, 1);
            this.Prodname.Name = "Prodname";
            this.Prodname.Size = new System.Drawing.Size(215, 32);
            this.Prodname.TabIndex = 4;
            this.Prodname.Text = "label6";
            this.Prodname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Price.Location = new System.Drawing.Point(226, 1);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(150, 32);
            this.Price.TabIndex = 0;
            this.Price.Text = "label28";
            this.Price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrashBTN
            // 
            this.TrashBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.dlt;
            this.TrashBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TrashBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.TrashBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrashBTN.Location = new System.Drawing.Point(555, 1);
            this.TrashBTN.Margin = new System.Windows.Forms.Padding(0);
            this.TrashBTN.Name = "TrashBTN";
            this.TrashBTN.Size = new System.Drawing.Size(26, 32);
            this.TrashBTN.TabIndex = 6;
            this.TrashBTN.UseVisualStyleBackColor = true;
            this.TrashBTN.Click += new System.EventHandler(this.TrashBTN_Click);
            // 
            // SalesOrdersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.tableLayoutPanel7);
            this.Name = "SalesOrdersList";
            this.Size = new System.Drawing.Size(582, 34);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label Prodname;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button DecrementBTN;
        private System.Windows.Forms.Button IncrmentBTN;
        private System.Windows.Forms.TextBox quantitytxtbox;
        private System.Windows.Forms.Button TrashBTN;
    }
}
