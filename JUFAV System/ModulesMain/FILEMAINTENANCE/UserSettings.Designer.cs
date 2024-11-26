namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    partial class UserSettings
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addaccountBTN = new System.Windows.Forms.Button();
            this.rcverpassBTN = new System.Windows.Forms.Button();
            this.txtboxSearchBox = new System.Windows.Forms.TextBox();
            this.srchBTN = new System.Windows.Forms.Button();
            this.ItemsBox = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.39572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.65404F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.1598F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46293F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.addaccountBTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rcverpassBTN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtboxSearchBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.srchBTN, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "NAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label2.Location = new System.Drawing.Point(145, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "USERNAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label3.Location = new System.Drawing.Point(325, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "ROLE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label4.Location = new System.Drawing.Point(502, 49);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "ACTIONS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // addaccountBTN
            // 
            this.addaccountBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addaccountBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addaccountBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addaccountBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.addaccountBTN.Location = new System.Drawing.Point(3, 3);
            this.addaccountBTN.Name = "addaccountBTN";
            this.addaccountBTN.Size = new System.Drawing.Size(136, 27);
            this.addaccountBTN.TabIndex = 4;
            this.addaccountBTN.Text = "ADD ACOUNT";
            this.addaccountBTN.UseVisualStyleBackColor = false;
            this.addaccountBTN.Click += new System.EventHandler(this.AddacountClick);
            // 
            // rcverpassBTN
            // 
            this.rcverpassBTN.BackColor = System.Drawing.SystemColors.Control;
            this.rcverpassBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcverpassBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rcverpassBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.rcverpassBTN.Location = new System.Drawing.Point(145, 3);
            this.rcverpassBTN.Name = "rcverpassBTN";
            this.rcverpassBTN.Size = new System.Drawing.Size(174, 27);
            this.rcverpassBTN.TabIndex = 5;
            this.rcverpassBTN.Text = "RECOVER PASSWORD";
            this.rcverpassBTN.UseVisualStyleBackColor = false;
            this.rcverpassBTN.Click += new System.EventHandler(this.rcverpassBTN_Click);
            // 
            // txtboxSearchBox
            // 
            this.txtboxSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtboxSearchBox.Font = new System.Drawing.Font("Actor", 11.25F);
            this.txtboxSearchBox.Location = new System.Drawing.Point(325, 4);
            this.txtboxSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtboxSearchBox.Name = "txtboxSearchBox";
            this.txtboxSearchBox.Size = new System.Drawing.Size(171, 26);
            this.txtboxSearchBox.TabIndex = 6;
            // 
            // srchBTN
            // 
            this.srchBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.srchBTN.BackgroundImage = global::JUFAV_System.Properties.Resources.Search;
            this.srchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.srchBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srchBTN.Font = new System.Drawing.Font("Actor", 11.25F);
            this.srchBTN.Location = new System.Drawing.Point(502, 3);
            this.srchBTN.Name = "srchBTN";
            this.srchBTN.Size = new System.Drawing.Size(102, 27);
            this.srchBTN.TabIndex = 7;
            this.srchBTN.UseVisualStyleBackColor = false;
            // 
            // ItemsBox
            // 
            this.ItemsBox.AutoScroll = true;
            this.ItemsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsBox.Location = new System.Drawing.Point(0, 71);
            this.ItemsBox.Name = "ItemsBox";
            this.ItemsBox.Size = new System.Drawing.Size(607, 246);
            this.ItemsBox.TabIndex = 1;
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ItemsBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserSettings";
            this.Size = new System.Drawing.Size(607, 317);
            this.Load += new System.EventHandler(this.UserSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button addaccountBTN;
        private System.Windows.Forms.TextBox txtboxSearchBox;
        private System.Windows.Forms.Button srchBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel ItemsBox;
        private System.Windows.Forms.Button rcverpassBTN;
    }
}
