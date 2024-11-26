namespace JUFAV_System.ModulesMain.UTILITIES
{
    partial class BCKRS
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
            this.Pane = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bxkBTN = new System.Windows.Forms.Button();
            this.rstrBTN = new System.Windows.Forms.Button();
            this.Pane.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pane
            // 
            this.Pane.BackColor = System.Drawing.SystemColors.Control;
            this.Pane.ColumnCount = 2;
            this.Pane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.90341F));
            this.Pane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.09659F));
            this.Pane.Controls.Add(this.panel1, 1, 0);
            this.Pane.Controls.Add(this.panel2, 0, 0);
            this.Pane.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Pane.Location = new System.Drawing.Point(1, 1);
            this.Pane.Name = "Pane";
            this.Pane.RowCount = 2;
            this.Pane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.70248F));
            this.Pane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.29752F));
            this.Pane.Size = new System.Drawing.Size(704, 484);
            this.Pane.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bxkBTN);
            this.panel1.Controls.Add(this.rstrBTN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(298, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(403, 191);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Actor", 12F);
            this.label2.Location = new System.Drawing.Point(5, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "PATH : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Actor", 12F);
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATABASE PATH:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(289, 191);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Actor", 27.75F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 162);
            this.label4.TabIndex = 5;
            this.label4.Text = "00/00/00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Actor", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "LAST BACKUP :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "sql";
            this.openFileDialog1.FileName = "JufavDatabase.sql";
            this.openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Tag = "Restore database sample format \"databasename\".sqlite";
            this.openFileDialog1.Title = "Restore Database";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sql";
            this.saveFileDialog1.FileName = "JufavDatabase.sql";
            this.saveFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            this.saveFileDialog1.InitialDirectory = "C:\\";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // bxkBTN
            // 
            this.bxkBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bxkBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bxkBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bxkBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bxkBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bxkBTN.Image = global::JUFAV_System.Properties.Resources.Backupicon;
            this.bxkBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bxkBTN.Location = new System.Drawing.Point(5, 54);
            this.bxkBTN.Margin = new System.Windows.Forms.Padding(10);
            this.bxkBTN.Name = "bxkBTN";
            this.bxkBTN.Size = new System.Drawing.Size(391, 65);
            this.bxkBTN.TabIndex = 3;
            this.bxkBTN.Text = "BACKUP DATABASE";
            this.bxkBTN.UseVisualStyleBackColor = false;
            this.bxkBTN.Click += new System.EventHandler(this.bxkBTN_Click);
            // 
            // rstrBTN
            // 
            this.rstrBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rstrBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rstrBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rstrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rstrBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstrBTN.Image = global::JUFAV_System.Properties.Resources.RestoreIcon;
            this.rstrBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rstrBTN.Location = new System.Drawing.Point(5, 119);
            this.rstrBTN.Margin = new System.Windows.Forms.Padding(10);
            this.rstrBTN.Name = "rstrBTN";
            this.rstrBTN.Size = new System.Drawing.Size(391, 65);
            this.rstrBTN.TabIndex = 2;
            this.rstrBTN.Text = "RESTORE DATABASE";
            this.rstrBTN.UseVisualStyleBackColor = false;
            this.rstrBTN.Click += new System.EventHandler(this.rstrBTN_Click);
            // 
            // BCKRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Pane);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Name = "BCKRS";
            this.Size = new System.Drawing.Size(708, 488);
            this.Pane.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Pane;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bxkBTN;
        private System.Windows.Forms.Button rstrBTN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
