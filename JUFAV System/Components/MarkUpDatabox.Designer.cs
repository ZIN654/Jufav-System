namespace JUFAV_System.Components
{
    partial class MarkUpDatabox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trash = new System.Windows.Forms.PictureBox();
            this.editBTN = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBTN)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Actor", 12F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "12.00";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trash);
            this.panel1.Controls.Add(this.editBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(471, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 52);
            this.panel1.TabIndex = 2;
            // 
            // trash
            // 
            this.trash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trash.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.trash.Location = new System.Drawing.Point(172, 1);
            this.trash.Name = "trash";
            this.trash.Size = new System.Drawing.Size(25, 25);
            this.trash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trash.TabIndex = 1;
            this.trash.TabStop = false;
            this.trash.Click += new System.EventHandler(this.trash_Click);
            // 
            // editBTN
            // 
            this.editBTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editBTN.Image = global::JUFAV_System.Properties.Resources.Edit;
            this.editBTN.Location = new System.Drawing.Point(143, 1);
            this.editBTN.Name = "editBTN";
            this.editBTN.Size = new System.Drawing.Size(25, 25);
            this.editBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editBTN.TabIndex = 0;
            this.editBTN.TabStop = false;
            this.editBTN.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MarkUpDatabox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MarkUpDatabox";
            this.Size = new System.Drawing.Size(674, 58);
            this.Leave += new System.EventHandler(this.MarkUpDatabox_Leave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBTN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox trash;
        private System.Windows.Forms.PictureBox editBTN;
    }
}
