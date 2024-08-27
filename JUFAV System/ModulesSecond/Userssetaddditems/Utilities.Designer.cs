namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    partial class Utilities
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
            this.archChbox = new System.Windows.Forms.CheckBox();
            this.Saleschbox = new System.Windows.Forms.CheckBox();
            this.BaRChbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.archChbox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Saleschbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BaRChbox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 54);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // archChbox
            // 
            this.archChbox.AutoSize = true;
            this.archChbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.archChbox.Checked = true;
            this.archChbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.archChbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.archChbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.archChbox.Font = new System.Drawing.Font("Actor", 9.75F);
            this.archChbox.Location = new System.Drawing.Point(423, 3);
            this.archChbox.Name = "archChbox";
            this.archChbox.Size = new System.Drawing.Size(206, 21);
            this.archChbox.TabIndex = 2;
            this.archChbox.Text = "Archives";
            this.archChbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.archChbox.UseVisualStyleBackColor = false;
            this.archChbox.MouseEnter += new System.EventHandler(this.archChbox_MouseEnter);
            this.archChbox.MouseLeave += new System.EventHandler(this.archChbox_MouseLeave);
            // 
            // Saleschbox
            // 
            this.Saleschbox.AutoSize = true;
            this.Saleschbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Saleschbox.Checked = true;
            this.Saleschbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Saleschbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Saleschbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Saleschbox.Font = new System.Drawing.Font("Actor", 11.25F, System.Drawing.FontStyle.Bold);
            this.Saleschbox.Location = new System.Drawing.Point(3, 3);
            this.Saleschbox.Name = "Saleschbox";
            this.Saleschbox.Size = new System.Drawing.Size(204, 21);
            this.Saleschbox.TabIndex = 0;
            this.Saleschbox.Text = "UTILITIES";
            this.Saleschbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Saleschbox.UseVisualStyleBackColor = false;
            this.Saleschbox.CheckedChanged += new System.EventHandler(this.Saleschbox_CheckedChanged);
            this.Saleschbox.MouseEnter += new System.EventHandler(this.Saleschbox_MouseEnter);
            this.Saleschbox.MouseLeave += new System.EventHandler(this.Saleschbox_MouseLeave);
            // 
            // BaRChbox
            // 
            this.BaRChbox.AutoSize = true;
            this.BaRChbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BaRChbox.Checked = true;
            this.BaRChbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BaRChbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BaRChbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaRChbox.Font = new System.Drawing.Font("Actor", 9.75F);
            this.BaRChbox.Location = new System.Drawing.Point(213, 3);
            this.BaRChbox.Name = "BaRChbox";
            this.BaRChbox.Size = new System.Drawing.Size(204, 21);
            this.BaRChbox.TabIndex = 1;
            this.BaRChbox.Text = "Backup and Restore";
            this.BaRChbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BaRChbox.UseVisualStyleBackColor = false;
            this.BaRChbox.MouseEnter += new System.EventHandler(this.BaRChbox_MouseEnter);
            this.BaRChbox.MouseLeave += new System.EventHandler(this.BaRChbox_MouseLeave);
            // 
            // Utilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Utilities";
            this.Size = new System.Drawing.Size(632, 54);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox archChbox;
        private System.Windows.Forms.CheckBox Saleschbox;
        private System.Windows.Forms.CheckBox BaRChbox;
    }
}
