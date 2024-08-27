namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    partial class Sales
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
            this.ResprodChbox = new System.Windows.Forms.CheckBox();
            this.Saleschbox = new System.Windows.Forms.CheckBox();
            this.Saleschbx = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.ResprodChbox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Saleschbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Saleschbx, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 54);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ResprodChbox
            // 
            this.ResprodChbox.AutoSize = true;
            this.ResprodChbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ResprodChbox.Checked = true;
            this.ResprodChbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResprodChbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResprodChbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResprodChbox.Font = new System.Drawing.Font("Actor", 9.75F);
            this.ResprodChbox.Location = new System.Drawing.Point(423, 3);
            this.ResprodChbox.Name = "ResprodChbox";
            this.ResprodChbox.Size = new System.Drawing.Size(206, 21);
            this.ResprodChbox.TabIndex = 2;
            this.ResprodChbox.Text = "Reserved Products";
            this.ResprodChbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ResprodChbox.UseVisualStyleBackColor = false;
            this.ResprodChbox.MouseEnter += new System.EventHandler(this.ResprodChbox_MouseEnter);
            this.ResprodChbox.MouseLeave += new System.EventHandler(this.ResprodChbox_MouseLeave);
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
            this.Saleschbox.Text = "SALES";
            this.Saleschbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Saleschbox.UseVisualStyleBackColor = false;
            this.Saleschbox.CheckedChanged += new System.EventHandler(this.Saleschbox_CheckedChanged);
            this.Saleschbox.MouseEnter += new System.EventHandler(this.Saleschbox_MouseEnter);
            this.Saleschbox.MouseLeave += new System.EventHandler(this.Saleschbox_MouseLeave);
            // 
            // Saleschbx
            // 
            this.Saleschbx.AutoSize = true;
            this.Saleschbx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Saleschbx.Checked = true;
            this.Saleschbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Saleschbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Saleschbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Saleschbx.Font = new System.Drawing.Font("Actor", 9.75F);
            this.Saleschbx.Location = new System.Drawing.Point(213, 3);
            this.Saleschbx.Name = "Saleschbx";
            this.Saleschbx.Size = new System.Drawing.Size(204, 21);
            this.Saleschbx.TabIndex = 1;
            this.Saleschbx.Text = "Sales";
            this.Saleschbx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Saleschbx.UseVisualStyleBackColor = false;
            this.Saleschbx.MouseEnter += new System.EventHandler(this.Saleschbx_MouseEnter);
            this.Saleschbx.MouseLeave += new System.EventHandler(this.Saleschbx_MouseLeave);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Sales";
            this.Size = new System.Drawing.Size(632, 54);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox ResprodChbox;
        private System.Windows.Forms.CheckBox Saleschbox;
        private System.Windows.Forms.CheckBox Saleschbx;
    }
}
