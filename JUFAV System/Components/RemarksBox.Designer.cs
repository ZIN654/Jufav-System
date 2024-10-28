namespace JUFAV_System.Components
{
    partial class RemarksBox
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
            this.remarks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remarks
            // 
            this.remarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remarks.Location = new System.Drawing.Point(0, 0);
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(263, 139);
            this.remarks.TabIndex = 0;
            this.remarks.Text = "label1";
            this.remarks.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // RemarksBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.remarks);
            this.Name = "RemarksBox";
            this.Size = new System.Drawing.Size(263, 139);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label remarks;
    }
}
