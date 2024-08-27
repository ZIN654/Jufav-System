namespace JUFAV_System.Messageboxes
{
    partial class MessageboxConfirmation
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
            this.msgboxCore = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnclose = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.PictureBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.mainmsgbox = new System.Windows.Forms.TableLayoutPanel();
            this.msgboxCore.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.mainmsgbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgboxCore
            // 
            this.msgboxCore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgboxCore.BackColor = System.Drawing.SystemColors.Control;
            this.msgboxCore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.msgboxCore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgboxCore.Controls.Add(this.mainmsgbox);
            this.msgboxCore.ForeColor = System.Drawing.Color.Red;
            this.msgboxCore.Location = new System.Drawing.Point(395, 182);
            this.msgboxCore.Name = "msgboxCore";
            this.msgboxCore.Size = new System.Drawing.Size(386, 173);
            this.msgboxCore.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.msgboxCore, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1176, 538);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Actor", 12F);
            this.btnclose.ForeColor = System.Drawing.Color.Black;
            this.btnclose.Location = new System.Drawing.Point(252, 135);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(129, 33);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "CLOSE";
            this.btnclose.UseVisualStyleBackColor = false;
            // 
            // icon
            // 
            this.icon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.icon.Location = new System.Drawing.Point(25, 43);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(85, 74);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon.TabIndex = 4;
            this.icon.TabStop = false;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblmsg.Font = new System.Drawing.Font("Actor", 12F);
            this.lblmsg.ForeColor = System.Drawing.Color.Black;
            this.lblmsg.Location = new System.Drawing.Point(136, 28);
            this.lblmsg.Margin = new System.Windows.Forms.Padding(0);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(248, 104);
            this.lblmsg.TabIndex = 3;
            this.lblmsg.Text = "MESSAGE";
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnconfirm
            // 
            this.btnconfirm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnconfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconfirm.Font = new System.Drawing.Font("Actor", 12F);
            this.btnconfirm.ForeColor = System.Drawing.Color.Black;
            this.btnconfirm.Location = new System.Drawing.Point(3, 135);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(130, 33);
            this.btnconfirm.TabIndex = 2;
            this.btnconfirm.Text = "CONFIRM";
            this.btnconfirm.UseVisualStyleBackColor = false;
            // 
            // lbltitle
            // 
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltitle.Font = new System.Drawing.Font("Actor", 9F);
            this.lbltitle.ForeColor = System.Drawing.Color.Black;
            this.lbltitle.Location = new System.Drawing.Point(3, 5);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(130, 23);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "lbl1";
            // 
            // mainmsgbox
            // 
            this.mainmsgbox.ColumnCount = 2;
            this.mainmsgbox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.mainmsgbox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainmsgbox.Controls.Add(this.lbltitle, 0, 0);
            this.mainmsgbox.Controls.Add(this.btnconfirm, 0, 2);
            this.mainmsgbox.Controls.Add(this.lblmsg, 1, 1);
            this.mainmsgbox.Controls.Add(this.icon, 0, 1);
            this.mainmsgbox.Controls.Add(this.btnclose, 1, 2);
            this.mainmsgbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainmsgbox.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.mainmsgbox.Location = new System.Drawing.Point(0, 0);
            this.mainmsgbox.Margin = new System.Windows.Forms.Padding(5);
            this.mainmsgbox.Name = "mainmsgbox";
            this.mainmsgbox.RowCount = 3;
            this.mainmsgbox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.mainmsgbox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainmsgbox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.mainmsgbox.Size = new System.Drawing.Size(384, 171);
            this.mainmsgbox.TabIndex = 0;
            // 
            // MessageboxConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1176, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageboxConfirmation";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageboxConfirmation";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msgboxCore.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.mainmsgbox.ResumeLayout(false);
            this.mainmsgbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel msgboxCore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel mainmsgbox;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Button btnclose;
    }
}