namespace JUFAV_System.Components
{
    partial class SalesPaymentMethodOrderList
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
            this.quantity = new System.Windows.Forms.Label();
            this.Prodname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Controls.Add(this.quantity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Prodname, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // quantity
            // 
            this.quantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantity.Font = new System.Drawing.Font("Actor", 11.25F, System.Drawing.FontStyle.Bold);
            this.quantity.Location = new System.Drawing.Point(185, 0);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(176, 24);
            this.quantity.TabIndex = 1;
            this.quantity.Text = "label2";
            this.quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Prodname
            // 
            this.Prodname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Prodname.Font = new System.Drawing.Font("Actor", 11.25F, System.Drawing.FontStyle.Bold);
            this.Prodname.Location = new System.Drawing.Point(3, 0);
            this.Prodname.Name = "Prodname";
            this.Prodname.Size = new System.Drawing.Size(176, 24);
            this.Prodname.TabIndex = 0;
            this.Prodname.Text = "label1";
            this.Prodname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(364, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 24);
            this.panel1.TabIndex = 2;
            // 
            // Price
            // 
            this.Price.Dock = System.Windows.Forms.DockStyle.Right;
            this.Price.Font = new System.Drawing.Font("Actor", 11.25F, System.Drawing.FontStyle.Bold);
            this.Price.Location = new System.Drawing.Point(75, 0);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(71, 24);
            this.Price.TabIndex = 3;
            this.Price.Text = "label3";
            this.Price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // SalesPaymentMethodOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SalesPaymentMethodOrderList";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(516, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label quantity;
        private System.Windows.Forms.Label Prodname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label label1;
    }
}
