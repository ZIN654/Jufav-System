namespace JUFAV_System.ModulesMain.INVENTORY
{
    partial class PurchaseOrder
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PndBTN = new System.Windows.Forms.Button();
            this.CrtPOBTN = new System.Windows.Forms.Button();
            this.txtboxSearchBox = new System.Windows.Forms.TextBox();
            this.srchBTN = new System.Windows.Forms.Button();
            this.STATUSHEADING = new System.Windows.Forms.Label();
            this.CnclBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ItemsBox = new System.Windows.Forms.Panel();
            this.ItemSwitch = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.36652F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.07792F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.07792F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.Controls.Add(this.PndBTN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CrtPOBTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtboxSearchBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.srchBTN, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.STATUSHEADING, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CnclBTN, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Actor", 8.25F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 95);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // PndBTN
            // 
            this.PndBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PndBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PndBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PndBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.PndBTN.Location = new System.Drawing.Point(3, 35);
            this.PndBTN.Name = "PndBTN";
            this.PndBTN.Size = new System.Drawing.Size(87, 28);
            this.PndBTN.TabIndex = 7;
            this.PndBTN.Text = "PENDING PURCHASE ORDER";
            this.PndBTN.UseVisualStyleBackColor = false;
            this.PndBTN.Click += new System.EventHandler(this.PndBTN_Click);
            // 
            // CrtPOBTN
            // 
            this.CrtPOBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CrtPOBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrtPOBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CrtPOBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.CrtPOBTN.Location = new System.Drawing.Point(3, 3);
            this.CrtPOBTN.Name = "CrtPOBTN";
            this.CrtPOBTN.Size = new System.Drawing.Size(87, 26);
            this.CrtPOBTN.TabIndex = 4;
            this.CrtPOBTN.Text = "CREATE PURCHASE ORDER";
            this.CrtPOBTN.UseVisualStyleBackColor = false;
            this.CrtPOBTN.Click += new System.EventHandler(this.CrtPOBTN_Click);
            // 
            // txtboxSearchBox
            // 
            this.txtboxSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtboxSearchBox.Font = new System.Drawing.Font("Actor", 11.25F);
            this.txtboxSearchBox.Location = new System.Drawing.Point(278, 4);
            this.txtboxSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtboxSearchBox.Name = "txtboxSearchBox";
            this.txtboxSearchBox.Size = new System.Drawing.Size(263, 26);
            this.txtboxSearchBox.TabIndex = 6;
            this.txtboxSearchBox.Text = "SEARCH";
            // 
            // srchBTN
            // 
            this.srchBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.srchBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.Search;
            this.srchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.srchBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srchBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.srchBTN.Location = new System.Drawing.Point(547, 3);
            this.srchBTN.Name = "srchBTN";
            this.srchBTN.Size = new System.Drawing.Size(143, 26);
            this.srchBTN.TabIndex = 7;
            this.srchBTN.UseVisualStyleBackColor = false;
            this.srchBTN.Click += new System.EventHandler(this.srchBTN_Click);
            // 
            // STATUSHEADING
            // 
            this.STATUSHEADING.AutoSize = true;
            this.STATUSHEADING.Dock = System.Windows.Forms.DockStyle.Fill;
            this.STATUSHEADING.Font = new System.Drawing.Font("Actor", 9F, System.Drawing.FontStyle.Bold);
            this.STATUSHEADING.Location = new System.Drawing.Point(3, 66);
            this.STATUSHEADING.Name = "STATUSHEADING";
            this.STATUSHEADING.Size = new System.Drawing.Size(87, 26);
            this.STATUSHEADING.TabIndex = 8;
            this.STATUSHEADING.Text = "TITLE";
            this.STATUSHEADING.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CnclBTN
            // 
            this.CnclBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CnclBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnclBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CnclBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.CnclBTN.Location = new System.Drawing.Point(96, 35);
            this.CnclBTN.Name = "CnclBTN";
            this.CnclBTN.Size = new System.Drawing.Size(85, 28);
            this.CnclBTN.TabIndex = 6;
            this.CnclBTN.Text = "CANCELED PURCHASE ORDER";
            this.CnclBTN.UseVisualStyleBackColor = false;
            this.CnclBTN.Click += new System.EventHandler(this.CnclBTN_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Actor", 8.25F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 95);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.91667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(693, 33);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "PURCHASE ORDER ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(89, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "ORDER DATE ISSUED ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(175, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "SUPPLIER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(261, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "TIME";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(347, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "TOTAL PRODUCTS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(433, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "TOTAL COST";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(519, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "STATUS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Location = new System.Drawing.Point(605, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "ACTIONS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ItemsBox
            // 
            this.ItemsBox.AutoScroll = true;
            this.ItemsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsBox.Location = new System.Drawing.Point(0, 128);
            this.ItemsBox.Name = "ItemsBox";
            this.ItemsBox.Size = new System.Drawing.Size(693, 262);
            this.ItemsBox.TabIndex = 5;
            // 
            // ItemSwitch
            // 
            this.ItemSwitch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ItemSwitch.Location = new System.Drawing.Point(0, 390);
            this.ItemSwitch.Name = "ItemSwitch";
            this.ItemSwitch.Size = new System.Drawing.Size(693, 36);
            this.ItemSwitch.TabIndex = 4;
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemsBox);
            this.Controls.Add(this.ItemSwitch);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PurchaseOrder";
            this.Size = new System.Drawing.Size(693, 426);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CrtPOBTN;
        private System.Windows.Forms.TextBox txtboxSearchBox;
        private System.Windows.Forms.Button srchBTN;
        private System.Windows.Forms.Button CnclBTN;
        private System.Windows.Forms.Button PndBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label STATUSHEADING;
        private System.Windows.Forms.Panel ItemsBox;
        private System.Windows.Forms.Panel ItemSwitch;
    }
}
