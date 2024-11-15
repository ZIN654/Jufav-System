namespace JUFAV_System.Components
{
    partial class PurchaseOrderComponent
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
            this.Items = new System.Windows.Forms.TableLayoutPanel();
            this.CnclPOBTN = new System.Windows.Forms.Button();
            this.POID = new System.Windows.Forms.Label();
            this.Dateissued = new System.Windows.Forms.Label();
            this.suppliername = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.TotalProducts = new System.Windows.Forms.Label();
            this.totalamount = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Delete = new System.Windows.Forms.PictureBox();
            this.Archive = new System.Windows.Forms.PictureBox();
            this.Preview = new System.Windows.Forms.PictureBox();
            this.Print = new System.Windows.Forms.PictureBox();
            this.pdf = new System.Windows.Forms.PictureBox();
            this.ReceivingDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Items.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Archive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Items
            // 
            this.Items.ColumnCount = 8;
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.611452F));
            this.Items.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.54192F));
            this.Items.Controls.Add(this.CnclPOBTN, 7, 1);
            this.Items.Controls.Add(this.POID, 0, 0);
            this.Items.Controls.Add(this.Dateissued, 1, 0);
            this.Items.Controls.Add(this.suppliername, 2, 0);
            this.Items.Controls.Add(this.Date, 3, 0);
            this.Items.Controls.Add(this.TotalProducts, 4, 0);
            this.Items.Controls.Add(this.totalamount, 5, 0);
            this.Items.Controls.Add(this.status, 6, 0);
            this.Items.Controls.Add(this.panel1, 7, 0);
            this.Items.Controls.Add(this.ReceivingDate, 1, 1);
            this.Items.Controls.Add(this.label1, 0, 1);
            this.Items.Dock = System.Windows.Forms.DockStyle.Top;
            this.Items.Font = new System.Drawing.Font("Actor", 8.25F);
            this.Items.Location = new System.Drawing.Point(3, 0);
            this.Items.Name = "Items";
            this.Items.RowCount = 2;
            this.Items.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.91667F));
            this.Items.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.Items.Size = new System.Drawing.Size(972, 81);
            this.Items.TabIndex = 4;
            // 
            // CnclPOBTN
            // 
            this.CnclPOBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CnclPOBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnclPOBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CnclPOBTN.Location = new System.Drawing.Point(819, 49);
            this.CnclPOBTN.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.CnclPOBTN.Name = "CnclPOBTN";
            this.CnclPOBTN.Size = new System.Drawing.Size(153, 29);
            this.CnclPOBTN.TabIndex = 8;
            this.CnclPOBTN.Text = "CANCEL ORDER";
            this.CnclPOBTN.UseVisualStyleBackColor = true;
            // 
            // POID
            // 
            this.POID.AutoSize = true;
            this.POID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POID.Font = new System.Drawing.Font("Actor", 11.25F);
            this.POID.Location = new System.Drawing.Point(3, 0);
            this.POID.Name = "POID";
            this.POID.Size = new System.Drawing.Size(115, 46);
            this.POID.TabIndex = 0;
            this.POID.Text = "PO 000312";
            // 
            // Dateissued
            // 
            this.Dateissued.AutoSize = true;
            this.Dateissued.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dateissued.Font = new System.Drawing.Font("Actor", 11.25F);
            this.Dateissued.Location = new System.Drawing.Point(124, 0);
            this.Dateissued.Name = "Dateissued";
            this.Dateissued.Size = new System.Drawing.Size(115, 46);
            this.Dateissued.TabIndex = 1;
            this.Dateissued.Text = "01/12/2023\r\n";
            // 
            // suppliername
            // 
            this.suppliername.AutoSize = true;
            this.suppliername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suppliername.Font = new System.Drawing.Font("Actor", 11.25F);
            this.suppliername.Location = new System.Drawing.Point(245, 0);
            this.suppliername.Name = "suppliername";
            this.suppliername.Size = new System.Drawing.Size(115, 46);
            this.suppliername.TabIndex = 2;
            this.suppliername.Text = "IronCo.ltd";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date.Font = new System.Drawing.Font("Actor", 11.25F);
            this.Date.Location = new System.Drawing.Point(366, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(115, 46);
            this.Date.TabIndex = 3;
            this.Date.Text = "12:23 PM";
            // 
            // TotalProducts
            // 
            this.TotalProducts.AutoSize = true;
            this.TotalProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalProducts.Font = new System.Drawing.Font("Actor", 11.25F);
            this.TotalProducts.Location = new System.Drawing.Point(487, 0);
            this.TotalProducts.Name = "TotalProducts";
            this.TotalProducts.Size = new System.Drawing.Size(115, 46);
            this.TotalProducts.TabIndex = 4;
            this.TotalProducts.Text = "32";
            // 
            // totalamount
            // 
            this.totalamount.AutoSize = true;
            this.totalamount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalamount.Font = new System.Drawing.Font("Actor", 11.25F);
            this.totalamount.Location = new System.Drawing.Point(608, 0);
            this.totalamount.Name = "totalamount";
            this.totalamount.Size = new System.Drawing.Size(115, 46);
            this.totalamount.TabIndex = 5;
            this.totalamount.Text = "0,000.00";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.status.Font = new System.Drawing.Font("Actor", 11.25F);
            this.status.Location = new System.Drawing.Point(729, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(87, 46);
            this.status.TabIndex = 6;
            this.status.Text = "PENDING";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Archive);
            this.panel1.Controls.Add(this.Preview);
            this.panel1.Controls.Add(this.Print);
            this.panel1.Controls.Add(this.pdf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(819, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 46);
            this.panel1.TabIndex = 8;
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete.Image = global::JUFAV_System.Properties.Resources.dlt;
            this.Delete.Location = new System.Drawing.Point(1, 4);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(29, 27);
            this.Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Delete.TabIndex = 4;
            this.Delete.TabStop = false;
            this.Delete.Tag = "Delete this record";
            this.Delete.Visible = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Archive
            // 
            this.Archive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Archive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Archive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Archive.Image = global::JUFAV_System.Properties.Resources.Archive;
            this.Archive.Location = new System.Drawing.Point(31, 4);
            this.Archive.Name = "Archive";
            this.Archive.Size = new System.Drawing.Size(29, 27);
            this.Archive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Archive.TabIndex = 3;
            this.Archive.TabStop = false;
            this.Archive.Tag = "Archive this record";
            this.Archive.Visible = false;
            this.Archive.Click += new System.EventHandler(this.Archive_Click);
            // 
            // Preview
            // 
            this.Preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Preview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Preview.Image = global::JUFAV_System.Properties.Resources.Eye;
            this.Preview.Location = new System.Drawing.Point(61, 4);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(29, 27);
            this.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Preview.TabIndex = 2;
            this.Preview.TabStop = false;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // Print
            // 
            this.Print.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Print.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Print.Image = global::JUFAV_System.Properties.Resources.Print;
            this.Print.Location = new System.Drawing.Point(121, 4);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(29, 27);
            this.Print.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Print.TabIndex = 1;
            this.Print.TabStop = false;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // pdf
            // 
            this.pdf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pdf.Image = global::JUFAV_System.Properties.Resources.ExportPdf;
            this.pdf.Location = new System.Drawing.Point(91, 4);
            this.pdf.Name = "pdf";
            this.pdf.Size = new System.Drawing.Size(29, 27);
            this.pdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pdf.TabIndex = 0;
            this.pdf.TabStop = false;
            this.pdf.Click += new System.EventHandler(this.pdf_Click);
            // 
            // ReceivingDate
            // 
            this.ReceivingDate.AutoSize = true;
            this.ReceivingDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceivingDate.Font = new System.Drawing.Font("Actor", 9.75F, System.Drawing.FontStyle.Bold);
            this.ReceivingDate.Location = new System.Drawing.Point(124, 46);
            this.ReceivingDate.Name = "ReceivingDate";
            this.ReceivingDate.Size = new System.Drawing.Size(115, 35);
            this.ReceivingDate.TabIndex = 9;
            this.ReceivingDate.Text = "RECEIVING DATE:";
            this.ReceivingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Actor", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "RECEIVING DATE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(972, 208);
            this.dataGridView1.TabIndex = 9;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Purchase_Order_";
            this.saveFileDialog1.Filter = "pdf file (*.pdf)|*.pdf";
            // 
            // PurchaseOrderComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Items);
            this.Name = "PurchaseOrderComponent";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Size = new System.Drawing.Size(978, 81);
            this.Leave += new System.EventHandler(this.PurchaseOrderComponent_Leave);
            this.Items.ResumeLayout(false);
            this.Items.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Archive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Items;
        private System.Windows.Forms.Label POID;
        private System.Windows.Forms.Label Dateissued;
        private System.Windows.Forms.Label suppliername;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label TotalProducts;
        private System.Windows.Forms.Label totalamount;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Print;
        private System.Windows.Forms.PictureBox pdf;
        private System.Windows.Forms.Button CnclPOBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox Preview;
        private System.Windows.Forms.Label ReceivingDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Delete;
        private System.Windows.Forms.PictureBox Archive;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
