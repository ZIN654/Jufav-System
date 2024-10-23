namespace JUFAV_System.Components
{
    partial class SmalloptionDashBoard
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
            this.PrntLst = new System.Windows.Forms.Button();
            this.RportsBTN = new System.Windows.Forms.Button();
            this.CreatePOBTN = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // PrntLst
            // 
            this.PrntLst.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrntLst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrntLst.Location = new System.Drawing.Point(1, 59);
            this.PrntLst.Name = "PrntLst";
            this.PrntLst.Size = new System.Drawing.Size(197, 32);
            this.PrntLst.TabIndex = 2;
            this.PrntLst.Text = "PRINT THIS LIST";
            this.PrntLst.UseVisualStyleBackColor = true;
            this.PrntLst.Click += new System.EventHandler(this.PrntLst_Click);
            // 
            // RportsBTN
            // 
            this.RportsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.RportsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RportsBTN.Location = new System.Drawing.Point(1, 30);
            this.RportsBTN.Name = "RportsBTN";
            this.RportsBTN.Size = new System.Drawing.Size(197, 29);
            this.RportsBTN.TabIndex = 1;
            this.RportsBTN.Text = "GO TO REPORTS";
            this.RportsBTN.UseVisualStyleBackColor = true;
            this.RportsBTN.Click += new System.EventHandler(this.RportsBTN_Click);
            // 
            // CreatePOBTN
            // 
            this.CreatePOBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreatePOBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePOBTN.Location = new System.Drawing.Point(1, 1);
            this.CreatePOBTN.Name = "CreatePOBTN";
            this.CreatePOBTN.Size = new System.Drawing.Size(197, 29);
            this.CreatePOBTN.TabIndex = 0;
            this.CreatePOBTN.Text = "CREATE P.O";
            this.CreatePOBTN.UseVisualStyleBackColor = true;
            this.CreatePOBTN.Click += new System.EventHandler(this.CreatePOBTN_Click);
            // 
            // SmalloptionDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PrntLst);
            this.Controls.Add(this.RportsBTN);
            this.Controls.Add(this.CreatePOBTN);
            this.Name = "SmalloptionDashBoard";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(199, 93);
            this.Leave += new System.EventHandler(this.SmalloptionDashBoard_Leave);
            this.MouseLeave += new System.EventHandler(this.SmalloptionDashBoard_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button PrntLst;
        private System.Windows.Forms.Button RportsBTN;
        private System.Windows.Forms.Button CreatePOBTN;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
