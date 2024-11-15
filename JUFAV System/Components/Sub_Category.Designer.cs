namespace JUFAV_System.Components
{
    partial class Sub_Category
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ArcBTN = new System.Windows.Forms.PictureBox();
            this.trashbtn = new System.Windows.Forms.PictureBox();
            this.editbtn = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArcBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trashbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.49397F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.50602F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(647, 58);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label7.Location = new System.Drawing.Point(326, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "0.342";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label6.Location = new System.Drawing.Point(155, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "WOODS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Actor", 11.25F);
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ply-Wood";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ArcBTN);
            this.panel1.Controls.Add(this.trashbtn);
            this.panel1.Controls.Add(this.editbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(515, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 50);
            this.panel1.TabIndex = 10;
            // 
            // ArcBTN
            // 
            this.ArcBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArcBTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArcBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArcBTN.Image = global::JUFAV_System.Properties.Resources.Archive;
            this.ArcBTN.Location = new System.Drawing.Point(70, 2);
            this.ArcBTN.Name = "ArcBTN";
            this.ArcBTN.Size = new System.Drawing.Size(27, 25);
            this.ArcBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArcBTN.TabIndex = 2;
            this.ArcBTN.TabStop = false;
            this.ArcBTN.Click += new System.EventHandler(this.Archive_Click);
            // 
            // trashbtn
            // 
            this.trashbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trashbtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trashbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trashbtn.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.trashbtn.Location = new System.Drawing.Point(0, 2);
            this.trashbtn.Name = "trashbtn";
            this.trashbtn.Size = new System.Drawing.Size(29, 25);
            this.trashbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trashbtn.TabIndex = 1;
            this.trashbtn.TabStop = false;
            this.trashbtn.Visible = false;
            this.trashbtn.Click += new System.EventHandler(this.TrashBTN_Click);
            // 
            // editbtn
            // 
            this.editbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editbtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editbtn.Image = global::JUFAV_System.Properties.Resources.Edit;
            this.editbtn.Location = new System.Drawing.Point(101, 2);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(27, 25);
            this.editbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editbtn.TabIndex = 0;
            this.editbtn.TabStop = false;
            this.editbtn.Click += new System.EventHandler(this.editBTN_Click);
            // 
            // Sub_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Sub_Category";
            this.Size = new System.Drawing.Size(647, 58);
            this.Leave += new System.EventHandler(this.Sub_Category_Leave);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArcBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trashbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editbtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox trashbtn;
        private System.Windows.Forms.PictureBox editbtn;
        private System.Windows.Forms.PictureBox ArcBTN;
    }
}
