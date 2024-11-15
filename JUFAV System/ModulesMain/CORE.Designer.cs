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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORE));
            this.SplitCon = new System.Windows.Forms.SplitContainer();
            this.TABLELAYOUTRIGHT = new System.Windows.Forms.TableLayoutPanel();
            this.PROFILE = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.Role = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.OPTIONS = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HEADING = new System.Windows.Forms.Panel();
            this.Time = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.TITLEHEADING = new System.Windows.Forms.Label();
            this.showide = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCon)).BeginInit();
            this.SplitCon.Panel1.SuspendLayout();
            this.SplitCon.Panel2.SuspendLayout();
            this.SplitCon.SuspendLayout();
            this.TABLELAYOUTRIGHT.SuspendLayout();
            this.PROFILE.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.OPTIONS.SuspendLayout();
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
            this.SplitCon.SplitterDistance = 240;
            this.SplitCon.SplitterWidth = 1;
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
            this.TABLELAYOUTRIGHT.Size = new System.Drawing.Size(240, 562);
            this.TABLELAYOUTRIGHT.TabIndex = 0;
            // 
            // PROFILE
            // 
            this.PROFILE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(27)))), ((int)(((byte)(52)))));
            this.PROFILE.Controls.Add(this.tableLayoutPanel1);
            this.PROFILE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PROFILE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PROFILE.Location = new System.Drawing.Point(0, 0);
            this.PROFILE.Margin = new System.Windows.Forms.Padding(0);
            this.PROFILE.Name = "PROFILE";
            this.PROFILE.Size = new System.Drawing.Size(240, 274);
            this.PROFILE.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.10345F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.89655F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Controls.Add(this.axWindowsMediaPlayer1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Role, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Username, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.09271F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.90728F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 215);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(39, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(159, 112);
            this.axWindowsMediaPlayer1.TabIndex = 9;
            // 
            // Role
            // 
            this.Role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Role.Font = new System.Drawing.Font("Actor", 8.25F, System.Drawing.FontStyle.Bold);
            this.Role.ForeColor = System.Drawing.Color.White;
            this.Role.Location = new System.Drawing.Point(39, 137);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(159, 78);
            this.Role.TabIndex = 3;
            this.Role.Text = "ADMIN002";
            this.Role.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Username
            // 
            this.Username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Username.Font = new System.Drawing.Font("Actor", 12.25F, System.Drawing.FontStyle.Bold);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(39, 118);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(159, 19);
            this.Username.TabIndex = 2;
            this.Username.Text = "ADMIN002";
            this.Username.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OPTIONS
            // 
            this.OPTIONS.AutoScroll = true;
            this.OPTIONS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(27)))), ((int)(((byte)(52)))));
            this.OPTIONS.Controls.Add(this.button1);
            this.OPTIONS.Cursor = System.Windows.Forms.Cursors.Default;
            this.OPTIONS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OPTIONS.Location = new System.Drawing.Point(0, 274);
            this.OPTIONS.Margin = new System.Windows.Forms.Padding(0);
            this.OPTIONS.Name = "OPTIONS";
            this.OPTIONS.Size = new System.Drawing.Size(240, 288);
            this.OPTIONS.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Actor", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(0, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 494);
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
            this.HEADING.Size = new System.Drawing.Size(517, 68);
            this.HEADING.TabIndex = 2;
            // 
            // Time
            // 
            this.Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Actor", 14F, System.Drawing.FontStyle.Bold);
            this.Time.Location = new System.Drawing.Point(382, 9);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(64, 23);
            this.Time.TabIndex = 2;
            this.Time.Text = "label3";
            // 
            // Date
            // 
            this.Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Actor", 14F, System.Drawing.FontStyle.Bold);
            this.Date.Location = new System.Drawing.Point(268, 9);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(64, 23);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CORE_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CORE_FormClosed);
            this.Load += new System.EventHandler(this.CORE_Load);
            this.Leave += new System.EventHandler(this.CORE_Leave);
            this.SplitCon.Panel1.ResumeLayout(false);
            this.SplitCon.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCon)).EndInit();
            this.SplitCon.ResumeLayout(false);
            this.TABLELAYOUTRIGHT.ResumeLayout(false);
            this.PROFILE.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.OPTIONS.ResumeLayout(false);
            this.HEADING.ResumeLayout(false);
            this.HEADING.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitCon;
        private System.Windows.Forms.TableLayoutPanel TABLELAYOUTRIGHT;
        private System.Windows.Forms.Panel PROFILE;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Panel OPTIONS;
        private System.Windows.Forms.Button showide;
        private System.Windows.Forms.Panel HEADING;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label TITLEHEADING;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Role;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button button1;
    }
}