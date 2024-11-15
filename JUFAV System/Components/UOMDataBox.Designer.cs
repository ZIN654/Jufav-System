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
            this.Abbreviationlbl = new System.Windows.Forms.Label();
            this.Unitofmelbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ARCBTn = new System.Windows.Forms.PictureBox();
            this.deletebtn = new System.Windows.Forms.PictureBox();
            this.editbut = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ARCBTn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.46722F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.35426F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.31799F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.Abbreviationlbl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Unitofmelbl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(716, 58);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // Abbreviationlbl
            // 
            this.Abbreviationlbl.AutoSize = true;
            this.Abbreviationlbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Abbreviationlbl.Font = new System.Drawing.Font("Actor", 11.25F);
            this.Abbreviationlbl.Location = new System.Drawing.Point(4, 1);
            this.Abbreviationlbl.Name = "Abbreviationlbl";
            this.Abbreviationlbl.Size = new System.Drawing.Size(317, 19);
            this.Abbreviationlbl.TabIndex = 0;
            this.Abbreviationlbl.Text = "Kilograms";
            // 
            // Unitofmelbl
            // 
            this.Unitofmelbl.AutoSize = true;
            this.Unitofmelbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Unitofmelbl.Font = new System.Drawing.Font("Actor", 11.25F);
            this.Unitofmelbl.Location = new System.Drawing.Point(328, 1);
            this.Unitofmelbl.Name = "Unitofmelbl";
            this.Unitofmelbl.Size = new System.Drawing.Size(266, 19);
            this.Unitofmelbl.TabIndex = 2;
            this.Unitofmelbl.Text = "KG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ARCBTn);
            this.panel1.Controls.Add(this.deletebtn);
            this.panel1.Controls.Add(this.editbut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(601, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 50);
            this.panel1.TabIndex = 3;
            // 
            // ARCBTn
            // 
            this.ARCBTn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ARCBTn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ARCBTn.Image = global::JUFAV_System.Properties.Resources.Archive;
            this.ARCBTn.Location = new System.Drawing.Point(57, 1);
            this.ARCBTn.Name = "ARCBTn";
            this.ARCBTn.Size = new System.Drawing.Size(25, 25);
            this.ARCBTn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ARCBTn.TabIndex = 7;
            this.ARCBTn.TabStop = false;
            this.ARCBTn.Click += new System.EventHandler(this.ARCBTn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deletebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletebtn.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.deletebtn.Location = new System.Drawing.Point(0, 0);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(25, 25);
            this.deletebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deletebtn.TabIndex = 6;
            this.deletebtn.TabStop = false;
            this.deletebtn.Visible = false;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // editbut
            // 
            this.editbut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editbut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editbut.Image = global::JUFAV_System.Properties.Resources.Edit;
            this.editbut.Location = new System.Drawing.Point(86, 0);
            this.editbut.Name = "editbut";
            this.editbut.Size = new System.Drawing.Size(25, 25);
            this.editbut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editbut.TabIndex = 5;
            this.editbut.TabStop = false;
            this.editbut.Click += new System.EventHandler(this.editbut_Click);
            // 
            // UOMDataBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UOMDataBox";
            this.Size = new System.Drawing.Size(716, 58);
            this.Leave += new System.EventHandler(this.UOMDataBox_Leave);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ARCBTn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Abbreviationlbl;
        private System.Windows.Forms.Label Unitofmelbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox deletebtn;
        private System.Windows.Forms.PictureBox editbut;
        private System.Windows.Forms.PictureBox ARCBTn;
    }
}
