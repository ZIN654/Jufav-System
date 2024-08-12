namespace JUFAV_System.Components
{
    partial class UOMDataBox
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
            this.lblrole = new System.Windows.Forms.Label();
            this.deletebtn = new System.Windows.Forms.PictureBox();
            this.editbut = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.46722F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.63319F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.3455F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.181011F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblname, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblrole, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.deletebtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.editbut, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(718, 63);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblname.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblname.Location = new System.Drawing.Point(4, 1);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(319, 19);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Kilograms";
            // 
            // lblrole
            // 
            this.lblrole.AutoSize = true;
            this.lblrole.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblrole.Font = new System.Drawing.Font("Actor", 11.25F);
            this.lblrole.Location = new System.Drawing.Point(330, 1);
            this.lblrole.Name = "lblrole";
            this.lblrole.Size = new System.Drawing.Size(270, 19);
            this.lblrole.TabIndex = 2;
            this.lblrole.Text = "KG";
            // 
            // deletebtn
            // 
            this.deletebtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deletebtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletebtn.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.deletebtn.Location = new System.Drawing.Point(667, 4);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(47, 26);
            this.deletebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deletebtn.TabIndex = 4;
            this.deletebtn.TabStop = false;
            // 
            // editbut
            // 
            this.editbut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editbut.Dock = System.Windows.Forms.DockStyle.Top;
            this.editbut.Image = global::JUFAV_System.Properties.Resources.Edit__1_;
            this.editbut.Location = new System.Drawing.Point(607, 4);
            this.editbut.Name = "editbut";
            this.editbut.Size = new System.Drawing.Size(53, 26);
            this.editbut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editbut.TabIndex = 3;
            this.editbut.TabStop = false;
            // 
            // UOMDataBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UOMDataBox";
            this.Size = new System.Drawing.Size(718, 63);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblrole;
        private System.Windows.Forms.PictureBox deletebtn;
        private System.Windows.Forms.PictureBox editbut;
    }
}
