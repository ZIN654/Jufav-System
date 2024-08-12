namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    partial class DASHBOARD
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
            this.DasBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DasBTN
            // 
            this.DasBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DasBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DasBTN.FlatAppearance.BorderSize = 0;
            this.DasBTN.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DasBTN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.DasBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DasBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DasBTN.ForeColor = System.Drawing.SystemColors.InfoText;
            this.DasBTN.Image = global::JUFAV_System.Properties.Resources.dash;
            this.DasBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DasBTN.Location = new System.Drawing.Point(0, 0);
            this.DasBTN.Name = "DasBTN";
            this.DasBTN.Size = new System.Drawing.Size(234, 38);
            this.DasBTN.TabIndex = 14;
            this.DasBTN.Text = "           DASHBOARD";
            this.DasBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DasBTN.UseVisualStyleBackColor = false;
            // 
            // DASHBOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DasBTN);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DASHBOARD";
            this.Size = new System.Drawing.Size(234, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DasBTN;
    }
}
