﻿namespace JUFAV_System.Components
{
    partial class DataBox
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblname = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblrole = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ARCBTN = new System.Windows.Forms.PictureBox();
            this.rcvBTN = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.PictureBox();
            this.editbut = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ARCBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47505F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.86388F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.72727F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.27273F));
            this.tableLayoutPanel2.Controls.Add(this.lblname, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblusername, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblrole, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(551, 64);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblname.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblname.Location = new System.Drawing.Point(4, 1);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(121, 19);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Juan Dela Cruz";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblusername.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblusername.Location = new System.Drawing.Point(132, 1);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(129, 19);
            this.lblusername.TabIndex = 1;
            this.lblusername.Text = "Juan21";
            // 
            // lblrole
            // 
            this.lblrole.AutoSize = true;
            this.lblrole.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblrole.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblrole.Location = new System.Drawing.Point(268, 1);
            this.lblrole.Name = "lblrole";
            this.lblrole.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.lblrole.Size = new System.Drawing.Size(161, 19);
            this.lblrole.TabIndex = 2;
            this.lblrole.Text = "Administrator";
            this.lblrole.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ARCBTN);
            this.panel1.Controls.Add(this.rcvBTN);
            this.panel1.Controls.Add(this.deletebtn);
            this.panel1.Controls.Add(this.editbut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(436, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 56);
            this.panel1.TabIndex = 3;
            // 
            // ARCBTN
            // 
            this.ARCBTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ARCBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ARCBTN.Image = global::JUFAV_System.Properties.Resources.Archive;
            this.ARCBTN.Location = new System.Drawing.Point(55, 1);
            this.ARCBTN.Name = "ARCBTN";
            this.ARCBTN.Size = new System.Drawing.Size(25, 25);
            this.ARCBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ARCBTN.TabIndex = 10;
            this.ARCBTN.TabStop = false;
            this.ARCBTN.Click += new System.EventHandler(this.ARCBTN_Click);
            // 
            // rcvBTN
            // 
            this.rcvBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rcvBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rcvBTN.Location = new System.Drawing.Point(0, 32);
            this.rcvBTN.Name = "rcvBTN";
            this.rcvBTN.Size = new System.Drawing.Size(111, 24);
            this.rcvBTN.TabIndex = 9;
            this.rcvBTN.Text = "RECOVER PASSWORD";
            this.rcvBTN.UseVisualStyleBackColor = true;
            this.rcvBTN.Visible = false;
            this.rcvBTN.Click += new System.EventHandler(this.Recover_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deletebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletebtn.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.deletebtn.Location = new System.Drawing.Point(3, 1);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(25, 25);
            this.deletebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deletebtn.TabIndex = 8;
            this.deletebtn.TabStop = false;
            this.deletebtn.Visible = false;
            this.deletebtn.Click += new System.EventHandler(this.deleteBTNClick);
            // 
            // editbut
            // 
            this.editbut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editbut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editbut.Image = global::JUFAV_System.Properties.Resources.Edit;
            this.editbut.Location = new System.Drawing.Point(84, 1);
            this.editbut.Name = "editbut";
            this.editbut.Size = new System.Drawing.Size(25, 25);
            this.editbut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editbut.TabIndex = 7;
            this.editbut.TabStop = false;
            this.editbut.Click += new System.EventHandler(this.editbut_Click);
            // 
            // DataBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "DataBox";
            this.Size = new System.Drawing.Size(551, 64);
            this.Leave += new System.EventHandler(this.DataBox_Leave);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ARCBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblrole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox deletebtn;
        private System.Windows.Forms.PictureBox editbut;
        private System.Windows.Forms.Button rcvBTN;
        private System.Windows.Forms.PictureBox ARCBTN;
    }
}
