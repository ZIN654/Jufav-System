namespace JUFAV_System.ModulesMain
{
    partial class CORE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORE));
            this.SplitCon = new System.Windows.Forms.SplitContainer();
            this.TABLELAYOUTRIGHT = new System.Windows.Forms.TableLayoutPanel();
            this.PROFILE = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.Label();
            this.Profilebox = new System.Windows.Forms.PictureBox();
            this.LOGOUTBTN = new System.Windows.Forms.Button();
            this.OPTIONS = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HEADING = new System.Windows.Forms.Panel();
            this.Time = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.TITLEHEADING = new System.Windows.Forms.Label();
            this.showide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCon)).BeginInit();
            this.SplitCon.Panel1.SuspendLayout();
            this.SplitCon.Panel2.SuspendLayout();
            this.SplitCon.SuspendLayout();
            this.TABLELAYOUTRIGHT.SuspendLayout();
            this.PROFILE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profilebox)).BeginInit();
            this.HEADING.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitCon
            // 
            this.SplitCon.AccessibleName = "SplitCon";
            this.SplitCon.BackColor = System.Drawing.SystemColors.Control;
            this.SplitCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCon.Location = new System.Drawing.Point(0, 0);
            this.SplitCon.Margin = new System.Windows.Forms.Padding(0);
            this.SplitCon.Name = "SplitCon";
            // 
            // SplitCon.Panel1
            // 
            this.SplitCon.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SplitCon.Panel1.Controls.Add(this.TABLELAYOUTRIGHT);
            this.SplitCon.Panel1MinSize = 0;
            // 
            // SplitCon.Panel2
            // 
            this.SplitCon.Panel2.AccessibleName = "MAIN.Panel2";
            this.SplitCon.Panel2.Controls.Add(this.panel1);
            this.SplitCon.Panel2.Controls.Add(this.HEADING);
            this.SplitCon.Panel2.Controls.Add(this.showide);
            this.SplitCon.Panel2MinSize = 0;
            this.SplitCon.Size = new System.Drawing.Size(778, 562);
            this.SplitCon.SplitterDistance = 253;
            this.SplitCon.SplitterWidth = 2;
            this.SplitCon.TabIndex = 0;
            // 
            // TABLELAYOUTRIGHT
            // 
            this.TABLELAYOUTRIGHT.ColumnCount = 1;
            this.TABLELAYOUTRIGHT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TABLELAYOUTRIGHT.Controls.Add(this.PROFILE, 0, 0);
            this.TABLELAYOUTRIGHT.Controls.Add(this.OPTIONS, 0, 1);
            this.TABLELAYOUTRIGHT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TABLELAYOUTRIGHT.Location = new System.Drawing.Point(0, 0);
            this.TABLELAYOUTRIGHT.Margin = new System.Windows.Forms.Padding(0);
            this.TABLELAYOUTRIGHT.Name = "TABLELAYOUTRIGHT";
            this.TABLELAYOUTRIGHT.RowCount = 2;
            this.TABLELAYOUTRIGHT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.TABLELAYOUTRIGHT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TABLELAYOUTRIGHT.Size = new System.Drawing.Size(253, 562);
            this.TABLELAYOUTRIGHT.TabIndex = 0;
            // 
            // PROFILE
            // 
            this.PROFILE.Controls.Add(this.Username);
            this.PROFILE.Controls.Add(this.Profilebox);
            this.PROFILE.Controls.Add(this.LOGOUTBTN);
            this.PROFILE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PROFILE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PROFILE.Location = new System.Drawing.Point(0, 0);
            this.PROFILE.Margin = new System.Windows.Forms.Padding(0);
            this.PROFILE.Name = "PROFILE";
            this.PROFILE.Size = new System.Drawing.Size(253, 274);
            this.PROFILE.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Actor", 11.25F, System.Drawing.FontStyle.Bold);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(80, 136);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(89, 19);
            this.Username.TabIndex = 2;
            this.Username.Text = "ADMIN002";
            // 
            // Profilebox
            // 
            this.Profilebox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Profilebox.Location = new System.Drawing.Point(78, 48);
            this.Profilebox.Name = "Profilebox";
            this.Profilebox.Size = new System.Drawing.Size(87, 76);
            this.Profilebox.TabIndex = 1;
            this.Profilebox.TabStop = false;
            // 
            // LOGOUTBTN
            // 
            this.LOGOUTBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LOGOUTBTN.BackgroundImage")));
            this.LOGOUTBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LOGOUTBTN.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LOGOUTBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOGOUTBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LOGOUTBTN.Location = new System.Drawing.Point(0, 0);
            this.LOGOUTBTN.Name = "LOGOUTBTN";
            this.LOGOUTBTN.Size = new System.Drawing.Size(26, 23);
            this.LOGOUTBTN.TabIndex = 0;
            this.LOGOUTBTN.UseVisualStyleBackColor = true;
            // 
            // OPTIONS
            // 
            this.OPTIONS.AutoScroll = true;
            this.OPTIONS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OPTIONS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OPTIONS.Location = new System.Drawing.Point(0, 274);
            this.OPTIONS.Margin = new System.Windows.Forms.Padding(0);
            this.OPTIONS.Name = "OPTIONS";
            this.OPTIONS.Size = new System.Drawing.Size(253, 288);
            this.OPTIONS.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 494);
            this.panel1.TabIndex = 3;
            // 
            // HEADING
            // 
            this.HEADING.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HEADING.Controls.Add(this.Time);
            this.HEADING.Controls.Add(this.Date);
            this.HEADING.Controls.Add(this.TITLEHEADING);
            this.HEADING.Dock = System.Windows.Forms.DockStyle.Top;
            this.HEADING.Location = new System.Drawing.Point(20, 0);
            this.HEADING.Name = "HEADING";
            this.HEADING.Size = new System.Drawing.Size(503, 68);
            this.HEADING.TabIndex = 2;
            // 
            // Time
            // 
            this.Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Actor", 12F, System.Drawing.FontStyle.Bold);
            this.Time.Location = new System.Drawing.Point(369, 9);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(56, 21);
            this.Time.TabIndex = 2;
            this.Time.Text = "label3";
            // 
            // Date
            // 
            this.Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Actor", 12F, System.Drawing.FontStyle.Bold);
            this.Date.Location = new System.Drawing.Point(255, 9);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(57, 21);
            this.Date.TabIndex = 1;
            this.Date.Text = "label2";
            // 
            // TITLEHEADING
            // 
            this.TITLEHEADING.AutoSize = true;
            this.TITLEHEADING.Font = new System.Drawing.Font("Actor", 15.75F, System.Drawing.FontStyle.Bold);
            this.TITLEHEADING.Location = new System.Drawing.Point(12, 19);
            this.TITLEHEADING.Name = "TITLEHEADING";
            this.TITLEHEADING.Size = new System.Drawing.Size(68, 26);
            this.TITLEHEADING.TabIndex = 0;
            this.TITLEHEADING.Text = "label1";
            // 
            // showide
            // 
            this.showide.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.showide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showide.Dock = System.Windows.Forms.DockStyle.Left;
            this.showide.FlatAppearance.BorderSize = 0;
            this.showide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showide.Font = new System.Drawing.Font("Actor", 9.75F, System.Drawing.FontStyle.Bold);
            this.showide.Location = new System.Drawing.Point(0, 0);
            this.showide.Margin = new System.Windows.Forms.Padding(0);
            this.showide.Name = "showide";
            this.showide.Size = new System.Drawing.Size(20, 562);
            this.showide.TabIndex = 1;
            this.showide.Text = "<";
            this.showide.UseVisualStyleBackColor = false;
            // 
            // CORE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 562);
            this.Controls.Add(this.SplitCon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CORE";
            this.Text = "JUFAV SALES AND INVENTORY SYSTEM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CORE_FormClosed);
            this.Load += new System.EventHandler(this.CORE_Load);
            this.SplitCon.Panel1.ResumeLayout(false);
            this.SplitCon.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCon)).EndInit();
            this.SplitCon.ResumeLayout(false);
            this.TABLELAYOUTRIGHT.ResumeLayout(false);
            this.PROFILE.ResumeLayout(false);
            this.PROFILE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profilebox)).EndInit();
            this.HEADING.ResumeLayout(false);
            this.HEADING.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitCon;
        private System.Windows.Forms.TableLayoutPanel TABLELAYOUTRIGHT;
        private System.Windows.Forms.Panel PROFILE;
        private System.Windows.Forms.PictureBox Profilebox;
        private System.Windows.Forms.Button LOGOUTBTN;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Panel OPTIONS;
        private System.Windows.Forms.Button showide;
        private System.Windows.Forms.Panel HEADING;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label TITLEHEADING;
        private System.Windows.Forms.Panel panel1;
    }
}