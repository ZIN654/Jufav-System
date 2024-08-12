namespace JUFAV_System.Components
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
            this.editbut = new System.Windows.Forms.PictureBox();
            this.deletebtn = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47505F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.86388F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.74592F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.030151F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.695142F));
            this.tableLayoutPanel2.Controls.Add(this.lblname, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblusername, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblrole, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.editbut, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.deletebtn, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(551, 63);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblname.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblname.Location = new System.Drawing.Point(4, 1);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(122, 19);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Juan Dela Cruz";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblusername.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblusername.Location = new System.Drawing.Point(133, 1);
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
            this.lblrole.Location = new System.Drawing.Point(269, 1);
            this.lblrole.Name = "lblrole";
            this.lblrole.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.lblrole.Size = new System.Drawing.Size(211, 19);
            this.lblrole.TabIndex = 2;
            this.lblrole.Text = "Administrator";
            this.lblrole.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // editbut
            // 
            this.editbut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editbut.Dock = System.Windows.Forms.DockStyle.Top;
            this.editbut.Image = global::JUFAV_System.Properties.Resources.Edit__1_;
            this.editbut.Location = new System.Drawing.Point(487, 4);
            this.editbut.Name = "editbut";
            this.editbut.Size = new System.Drawing.Size(26, 26);
            this.editbut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editbut.TabIndex = 3;
            this.editbut.TabStop = false;
            // 
            // deletebtn
            // 
            this.deletebtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deletebtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletebtn.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.deletebtn.Location = new System.Drawing.Point(520, 4);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(27, 26);
            this.deletebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deletebtn.TabIndex = 4;
            this.deletebtn.TabStop = false;
            // 
            // DataBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "DataBox";
            this.Size = new System.Drawing.Size(551, 63);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblrole;
        private System.Windows.Forms.PictureBox editbut;
        private System.Windows.Forms.PictureBox deletebtn;
    }
}
