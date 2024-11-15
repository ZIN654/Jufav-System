namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    partial class UnitOfMeasures
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
            this.addUoMBTN = new System.Windows.Forms.Button();
            this.txtboxSearchBox = new System.Windows.Forms.TextBox();
            this.srchBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxEntryCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemsBox = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.28492F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.96648F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.34078F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.12849F));
            this.tableLayoutPanel1.Controls.Add(this.addUoMBTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtboxSearchBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.srchBTN, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 105);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // addUoMBTN
            // 
            this.addUoMBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addUoMBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addUoMBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUoMBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.addUoMBTN.Location = new System.Drawing.Point(3, 3);
            this.addUoMBTN.Name = "addUoMBTN";
            this.addUoMBTN.Size = new System.Drawing.Size(218, 28);
            this.addUoMBTN.TabIndex = 4;
            this.addUoMBTN.Text = "ADD NEW";
            this.addUoMBTN.UseVisualStyleBackColor = false;
            // 
            // txtboxSearchBox
            // 
            this.txtboxSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtboxSearchBox.Font = new System.Drawing.Font("Actor", 11.25F);
            this.txtboxSearchBox.Location = new System.Drawing.Point(327, 4);
            this.txtboxSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtboxSearchBox.Name = "txtboxSearchBox";
            this.txtboxSearchBox.Size = new System.Drawing.Size(290, 26);
            this.txtboxSearchBox.TabIndex = 6;
            this.txtboxSearchBox.Text = "SEARCH BY UNIT";
            this.txtboxSearchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtboxSearchBox_MouseClick);
            // 
            // srchBTN
            // 
            this.srchBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.srchBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.Search;
            this.srchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.srchBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.srchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srchBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.srchBTN.Location = new System.Drawing.Point(623, 3);
            this.srchBTN.Name = "srchBTN";
            this.srchBTN.Size = new System.Drawing.Size(68, 28);
            this.srchBTN.TabIndex = 7;
            this.srchBTN.UseVisualStyleBackColor = false;
            this.srchBTN.Click += new System.EventHandler(this.srchBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABBREVIATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label3.Location = new System.Drawing.Point(327, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "UNIT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label4.Location = new System.Drawing.Point(623, 83);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "ACTIONS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBoxEntryCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 33);
            this.panel1.TabIndex = 8;
            // 
            // txtBoxEntryCount
            // 
            this.txtBoxEntryCount.Location = new System.Drawing.Point(157, 6);
            this.txtBoxEntryCount.Name = "txtBoxEntryCount";
            this.txtBoxEntryCount.Size = new System.Drawing.Size(56, 20);
            this.txtBoxEntryCount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "SHOW ENTRY COUNT:";
            // 
            // ItemsBox
            // 
            this.ItemsBox.AutoScroll = true;
            this.ItemsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsBox.Location = new System.Drawing.Point(0, 105);
            this.ItemsBox.Name = "ItemsBox";
            this.ItemsBox.Size = new System.Drawing.Size(716, 386);
            this.ItemsBox.TabIndex = 3;
            // 
            // UnitOfMeasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemsBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UnitOfMeasures";
            this.Size = new System.Drawing.Size(716, 491);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button addUoMBTN;
        private System.Windows.Forms.TextBox txtboxSearchBox;
        private System.Windows.Forms.Button srchBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel ItemsBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxEntryCount;
    }
}
