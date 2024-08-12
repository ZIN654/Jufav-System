namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    partial class Category
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addCatBTN = new System.Windows.Forms.Button();
            this.txtboxSearchBox = new System.Windows.Forms.TextBox();
            this.srchBTN = new System.Windows.Forms.Button();
            this.ItemSwitch = new System.Windows.Forms.Panel();
            this.ItemsBox = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.39572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.60428F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.78418F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46293F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.addCatBTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtboxSearchBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.srchBTN, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 71);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "CATEGORY NAME:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label4.Location = new System.Drawing.Point(566, 49);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label4.Size = new System.Drawing.Size(114, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "ACTIONS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // addCatBTN
            // 
            this.addCatBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addCatBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addCatBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCatBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.addCatBTN.Location = new System.Drawing.Point(3, 3);
            this.addCatBTN.Name = "addCatBTN";
            this.addCatBTN.Size = new System.Drawing.Size(153, 27);
            this.addCatBTN.TabIndex = 4;
            this.addCatBTN.Text = "ADD NEW";
            this.addCatBTN.UseVisualStyleBackColor = false;
            // 
            // txtboxSearchBox
            // 
            this.txtboxSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtboxSearchBox.Font = new System.Drawing.Font("Actor", 11.25F);
            this.txtboxSearchBox.Location = new System.Drawing.Point(343, 4);
            this.txtboxSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtboxSearchBox.Name = "txtboxSearchBox";
            this.txtboxSearchBox.Size = new System.Drawing.Size(217, 26);
            this.txtboxSearchBox.TabIndex = 6;
            this.txtboxSearchBox.Text = "SEARCH";
            // 
            // srchBTN
            // 
            this.srchBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.srchBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.Search__2_;
            this.srchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.srchBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srchBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.srchBTN.Location = new System.Drawing.Point(566, 3);
            this.srchBTN.Name = "srchBTN";
            this.srchBTN.Size = new System.Drawing.Size(114, 27);
            this.srchBTN.TabIndex = 7;
            this.srchBTN.UseVisualStyleBackColor = false;
            // 
            // ItemSwitch
            // 
            this.ItemSwitch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ItemSwitch.Location = new System.Drawing.Point(0, 490);
            this.ItemSwitch.Name = "ItemSwitch";
            this.ItemSwitch.Size = new System.Drawing.Size(683, 36);
            this.ItemSwitch.TabIndex = 2;
            // 
            // ItemsBox
            // 
            this.ItemsBox.AutoScroll = true;
            this.ItemsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsBox.Location = new System.Drawing.Point(0, 71);
            this.ItemsBox.Name = "ItemsBox";
            this.ItemsBox.Size = new System.Drawing.Size(683, 419);
            this.ItemsBox.TabIndex = 3;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemsBox);
            this.Controls.Add(this.ItemSwitch);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Category";
            this.Size = new System.Drawing.Size(683, 526);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addCatBTN;
        private System.Windows.Forms.TextBox txtboxSearchBox;
        private System.Windows.Forms.Button srchBTN;
        private System.Windows.Forms.Panel ItemSwitch;
        private System.Windows.Forms.Panel ItemsBox;
    }
}
