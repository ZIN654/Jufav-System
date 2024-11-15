using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;
using System.Threading;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel.Shapes;
using System.Data.SQLite;

namespace JUFAV_System.Components
{
    public partial class PurchaseOrderComponent : UserControl
    {
        int POID1;

        List<KeyValuePair<String, String>> DatatoUpdate = new List<KeyValuePair<string, string>>();
        public PurchaseOrderComponent(int POIDs, String Date1, String Supplier, String time, int ItemCount, double total, String Status, String ExpectedDate, int sumomntype)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            POID1 = POIDs;
            POID.Text = "PO " + POIDs.ToString();
            ReceivingDate.Text = ExpectedDate;
            Dateissued.Text = Date1;
            suppliername.Text = Supplier;
            Date.Text = time;
            TotalProducts.Text = ItemCount.ToString();
            totalamount.Text = total.ToString();
            status.Text = Status;
            loaddata();
            //Deter//mineDate(DateTime.Parse(Date1));
            if (Status == "CANCELLED")
            {
                CnclPOBTN.Visible = false;
                Delete.Visible = true;
                Archive.Visible = true;
                //incase na mag kamali just in case na tanungin kami
                //CnclPOBTN.Click += reOrder;
                //CnclPOBTN.Text = "REORDER";
            }
            if (sumomntype == 1)
            {
                CnclPOBTN.Click += CnclPOBTN_Click;
            } else
            {
             //   determineDate();
                CnclPOBTN.Text = "RECEIVE ORDER";
                CnclPOBTN.Click += receiveOrder;
                Delete.Visible = false;
                Archive.Visible = true;
            }

        }
        private void loaddata()
        {

            dataGridView1.Columns.Add("PRODUCT NAME", "PRODUCT NAME");
            dataGridView1.Columns.Add("QUANTITY", "QUANTITY");
            dataGridView1.Columns.Add("UNIT COST", "UNIT COST");
            dataGridView1.Columns.Add("TOTAL COST", "TOTAL COST");
            dataGridView1.Columns["PRODUCT NAME"].Width = 350;
            dataGridView1.Columns["QUANTITY"].Width = 70;
            dataGridView1.Columns["UNIT COST"].Width = 150;
            dataGridView1.Columns["TOTAL COST"].Width = 150;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            //  mamay aito
            //insert into data gridview
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM POITEMORDERTABLE WHERE POID = " + POID1 + ";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //ang order data dapat product name at kung ilang items ung laman nya
                dataGridView1.Rows.Add(sread1["PRODUCTNAME"].ToString(), sread1["QUANTITY"].ToString(), sread1["ORIGINALPRICE"].ToString(), sread1["TOTAL"].ToString());
                DatatoUpdate.Add(new KeyValuePair<String, String>(sread1["ITEMID"].ToString(), sread1["QUANTITY"].ToString()));
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
        }
        private void DeleteRecords()
        {
            this.Cursor = Cursors.WaitCursor;//only available sa cencel
            SQLiteCommand scom1 = new SQLiteCommand("DELETE FROM PURCHASEORDER WHERE POID =  " + POID1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY CANCELED!", "OK", 0);
            ms.Show();
        }
        private void Cancel()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE PURCHASEORDER SET ORDERSTATUS = 'CANCELLED' WHERE POID = " + POID1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "CANCEL ORDER", "ORDER SUCCESSFULLY CANCELED!", "OK", 0);
            ms.Show();
        }
        private void archive()
        {

            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            String[] Queries1 = { "INSERT INTO ARCPURCHASEORDER(POID,USERID, ORDERDATE, EXPECTEDORDERDATE, SUPPLIER, TIMES, TOTALPRODUCTS, TOTALCOST, ORDERSTATUS) SELECT * FROM PURCHASEORDER WHERE POID = " + POID1 + ";", "INSERT INTO ARCPOITEMORDERTABLE(ORDERID,USERID,POID,ITEMID,QUANTITY,PRODUCTNAME,ORIGINALPRICE,TOTAL) SELECT * FROM POITEMORDERTABLE WHERE POID = " + POID1 + ";", "INSERT INTO ARCPOSHIPTOINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS,REMARKS) SELECT * FROM POSHIPTOINFO WHERE POID = " + POID1 + ";", "INSERT INTO ARCPOVENDORINFO (ID,POID,COMPANYNAME,CONTACTPERSON,CONTACTNO,COMPANYADDRESS) SELECT * FROM POVENDORINFO WHERE POID = " + POID1 + ";" };//delete /insert,
            foreach (String i in Queries1)
            {
                scom1.CommandText = i;
                scom1.ExecuteNonQuery();//nag duduplicate ang foreign ID
                Thread.Sleep(250);
            }
            Thread.Sleep(2000);
            //if mawala ung mga nakaraang records nasa table an problemna ung mga references
            scom1.CommandText = "DELETE FROM PURCHASEORDER WHERE POID = " + POID1 + ";";
            scom1.ExecuteNonQuery();//unique constraint failed
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ARCHIVE RECORD", "RECORD SUCCESSFULLY ARCHIVED!", "OK", 0);
            ms.Show();
        }
        private void completeOrder()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE PURCHASEORDER SET ORDERSTATUS = 'COMPLETED' WHERE POID = " + POID1 + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            this.Dispose();
        }
        private void receiveProducts()
        {
            // MessageBox.Show("ARE YOU SURE YOU WANT OT RECEIVE YOU ORDERS");
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);//use  dictionary then foreach i.valuee i.key
            foreach (KeyValuePair<String, String> i in DatatoUpdate)
            {
                scom1.CommandText = "UPDATE PRODUCTS SET QUANTITY = QUANTITY + " + Convert.ToInt32(i.Value) + " WHERE PRODUCTID = " + Convert.ToInt32(i.Key) + ";";
                scom1.ExecuteNonQuery();
            }
            scom1 = null;
            GC.Collect();
            completeOrder();
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "RECEIVE ORDER", "ORDER SUCCESSFULLY RECEIVED!", "OK", 2);//updates the table into a completed order
            ms.Show();
            //di pa sure 
            //receive data insert to databas
        }
        public void determineDate()
        {
            CnclPOBTN.Enabled = false;
            if (DateTime.Parse(ReceivingDate.Text.ToString()) < DateTime.Now)
            {
                CnclPOBTN.Enabled = true;
            }
        }
        public void receiveOrder(object sender, EventArgs e)
        {
            //preview order first then check  kung ano ung  dumatng at hindi 
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(receiveProducts, 0, "RECEIVE ORDER", "ARE YOU SURE YOU WANT TO RECEIVE THIS ORDER?", "OK", 2);
            ms.Show();
        }
        private void releaseLeaks(object sender, EventArgs e)
        {

        }
        //purepdf
        private void topdetail(Document document)
        {
            //document.DefaultPageSetup.LeftMargin = "1.0cm";
            // document.DefaultPageSetup.TopMargin = "1.0cm";
            Section section = document.AddSection();
            section.PageSetup.TopMargin = 10;
            section.PageSetup.HeaderDistance = 10;

            HeaderFooter header = section.Headers.Primary;
            header.Format.SpaceAfter = 10;
            // = section.Headers.Primary.AddImage();

            Image img1 = section.AddImage(@"C://Users//asus//Desktop//CAPSTONE 2//JUFAV SYSTEM NEW - Copy//Jufav-System//JUFAV System//Resources//JFF 1.png");

            // img1.Top = "-10";

            img1.Height = "2.6cm";
            img1.Width = "2.6cm";
            img1.LockAspectRatio = true;
            img1.RelativeVertical = RelativeVertical.Line;
            img1.RelativeHorizontal = RelativeHorizontal.Margin;
            img1.Left = ShapePosition.Right;
            img1.WrapFormat.Style = WrapStyle.None;

            section.AddParagraph("");
            FormattedText ph1 = section.AddParagraph().AddFormattedText("JUFAV CONSTRUCTION SUPPLIES", TextFormat.Bold);

            section.AddParagraph("Matatalaib, Concepcion, Tarlac");
            section.AddParagraph("+63 09123123111 - +63 0923452345");
            section.AddParagraph("zr2436901@gmail.com");
            section.AddParagraph("December 21,2024");
            section.AddParagraph("");
            ph1.Font.Color = MigraDoc.DocumentObjectModel.Color.FromCmyk(100, 30, 20, 50);
            ph1.Font.Size = 14;


            MIddetail(document, section);
        }
        private void MIddetail(Document document, Section sec1)
        {
            Section section2 = sec1;
            document.DefaultPageSetup.LeftMargin = "1.0cm";
            document.DefaultPageSetup.RightMargin = "1.0cm";

            var tab = document.LastSection.AddTable();
            tab.Borders.Width = 0.5;
            tab.AddColumn("19.4cm");

            Row row = tab.AddRow();
            row.Height = "0.8cm";


            FormattedText fs = row.Cells[0].AddParagraph().AddFormattedText("PURCHASE ORDER #P-043242", TextFormat.Bold);
            row.Cells[0].Shading.Color = Color.FromRgb(12, 27, 52);
            row.Cells[0].Format.Font.Color = Colors.White;
            row = tab.AddRow();
            row.Borders.Width = 0;
            row.Height = "0.1cm";
            row.Cells[0].Shading.Color = Colors.White;

            //row.Cells[0]
            fs.Font.Size = "22";

            var table = document.LastSection.AddTable();
            table.Borders.Width = 0.5;

            //collumn creation
            table.AddColumn("19.4cm");

            //table.AddColumn("1cm");
            // table.AddColumn("2cm");
            //table.AddColumn("2cm");

            //row creation
            Row row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;
            row1.Cells[0].AddParagraph("VENDOR INFORMATION");
            row1.Cells[0].Shading.Color = Color.FromRgb(12, 27, 52);
            row1.Cells[0].Format.Font.Color = Colors.White;

            var table2 = document.LastSection.AddTable();
            table2.Borders.Width = 0.5;
            table2.AddColumn("9.7cm");
            table2.AddColumn("9.7cm");


            Row row2 = table2.AddRow();
            row2.Height = "0.8cm";
            // table2.AddColumn("5.4cm");

            // row1.Cells[3].AddParagraph("UNIT PRICE");
            // row1.Cells[4].AddParagraph("SELLING PRICE");
            //add items
            // row2 = table2.AddRow();
            //row1.Cells[1].AddParagraph("test");
            //row1.Cells[2].AddParagraph("teset12");
            FormattedText fs1 = row2.Cells[0].AddParagraph().AddFormattedText("VENDOR NAME");
            fs1.Font.Size = "6";
            row2.Cells[0].AddParagraph().AddFormattedText("IronCoLTD", TextFormat.Bold);
            FormattedText fs2 = row2.Cells[1].AddParagraph().AddFormattedText("SALES PERSON");
            fs2.Font.Size = "6";
            row2.Cells[1].AddParagraph().AddFormattedText("John Smith", TextFormat.Bold);


            var table3 = document.LastSection.AddTable();
            table3.Borders.Width = 0.5;
            table3.AddColumn("19.4cm");
            Row row3 = table3.AddRow();
            row3.Height = "0.8cm";
            FormattedText fs3 = row3.Cells[0].AddParagraph().AddFormattedText("ADDRESS");
            fs3.Font.Size = "6";
            row3.Cells[0].AddParagraph().AddFormattedText("TARLAC MATATALAIB TARLAC", TextFormat.Bold);

            //table 4 lower contact no

            var table4 = document.LastSection.AddTable();
            table4.Borders.Width = 0.5;
            table4.AddColumn("9.7cm");
            table4.AddColumn("9.7cm");


            Row row4 = table4.AddRow();
            row4.Height = "0.8cm";

            FormattedText fs4 = row4.Cells[0].AddParagraph().AddFormattedText("CONTACT NO:");
            fs4.Font.Size = "6";
            row4.Cells[0].AddParagraph().AddFormattedText("+63 095324534", TextFormat.Bold);
            FormattedText fs5 = row4.Cells[1].AddParagraph().AddFormattedText("EMAIL ADDRESS:");
            fs5.Font.Size = "6";
            row4.Cells[1].AddParagraph().AddFormattedText("sample@gmail.com", TextFormat.Bold);

            //===============================================PART II ========================================================
            var table6 = document.LastSection.AddTable();
            table6.Borders.Width = 0.5;

            //collumn creation
            table6.AddColumn("19.4cm");

            //table.AddColumn("1cm");
            // table.AddColumn("2cm");
            //table.AddColumn("2cm");

            //row creation
            Row row6 = table6.AddRow();
            row6.HeadingFormat = true;
            row6.Format.Font.Bold = true;
            row6.Cells[0].AddParagraph("CUSTOMER INFORMATION");
            row6.Cells[0].Shading.Color = Color.FromRgb(12, 27, 52);
            row6.Cells[0].Format.Font.Color = Colors.White;

            var table7 = document.LastSection.AddTable();
            table7.Borders.Width = 0.5;
            table7.AddColumn("9.7cm");
            table7.AddColumn("9.7cm");


            Row row7 = table7.AddRow();
            row7.Height = "0.8cm";
            // table2.AddColumn("5.4cm");

            // row1.Cells[3].AddParagraph("UNIT PRICE");
            // row1.Cells[4].AddParagraph("SELLING PRICE");
            //add items
            // row2 = table2.AddRow();
            //row1.Cells[1].AddParagraph("test");
            //row1.Cells[2].AddParagraph("teset12");
            FormattedText fs6 = row7.Cells[0].AddParagraph().AddFormattedText("CUSTOMER NAME");
            fs6.Font.Size = "6";
            row7.Cells[0].AddParagraph().AddFormattedText("LANIE VINLUAN", TextFormat.Bold);
            FormattedText fs7 = row7.Cells[1].AddParagraph().AddFormattedText("CONTACT PERSON");
            fs7.Font.Size = "6";
            row7.Cells[1].AddParagraph().AddFormattedText("John Smith/Sales DEpartment", TextFormat.Bold);


            var table8 = document.LastSection.AddTable();
            table8.Borders.Width = 0.5;
            table8.AddColumn("19.4cm");
            Row row8 = table8.AddRow();
            row8.Height = "0.8cm";
            FormattedText fs8 = row8.Cells[0].AddParagraph().AddFormattedText("ADDRESS");
            fs8.Font.Size = "6";
            row8.Cells[0].AddParagraph().AddFormattedText("3M TARLAC", TextFormat.Bold);

            //table 4 lower contact no

            var table9 = document.LastSection.AddTable();
            table9.Borders.Width = 0.5;
            table9.AddColumn("9.7cm");
            table9.AddColumn("9.7cm");


            Row row9 = table9.AddRow();
            row9.Height = "0.8cm";

            FormattedText fs9 = row9.Cells[0].AddParagraph().AddFormattedText("CONTACT NO:");
            fs9.Font.Size = "6";
            row9.Cells[0].AddParagraph().AddFormattedText("+63 095324534", TextFormat.Bold);
            FormattedText fs10 = row9.Cells[1].AddParagraph().AddFormattedText("EMAIL ADDRESS:");
            fs10.Font.Size = "6";
            row9.Cells[1].AddParagraph().AddFormattedText("sample@gmail.com", TextFormat.Bold);

            middledet(document, section2);

        }
        private void middledet(Document doc, Section sec)
        {
            //to continuev
            var table = doc.LastSection.AddTable();

            table.AddColumn("19.4cm");
            Row row = table.AddRow();
            row.Cells[0].AddParagraph("");

            var table10 = doc.LastSection.AddTable();
            table10.Borders.Width = 0.5;

            table10.AddColumn("10.4cm");
            table10.AddColumn("2cm");
            table10.AddColumn("2cm");
            table10.AddColumn("2.5cm");
            table10.AddColumn("2.5cm");

            Row row1 = table10.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;

            row1.Cells[0].AddParagraph("PRODUCT NAME");
            row1.Cells[1].AddParagraph("Qty.");
            row1.Cells[2].AddParagraph("UNIT");
            row1.Cells[3].AddParagraph("UNIT PRICE");
            row1.Cells[4].AddParagraph("TOTAL");
            row1.Cells[0].Shading.Color = Color.FromRgb(12, 27, 52);
            row1.Cells[0].Format.Font.Color = Colors.White;
            row1.Cells[1].Shading.Color = Color.FromRgb(12, 27, 52);
            row1.Cells[1].Format.Font.Color = Colors.White;
            row1.Cells[2].Shading.Color = Color.FromRgb(12, 27, 52);
            row1.Cells[2].Format.Font.Color = Colors.White;
            row1.Cells[3].Shading.Color = Color.FromRgb(12, 27, 52);
            row1.Cells[3].Format.Font.Color = Colors.White;
            row1.Cells[4].Shading.Color = Color.FromRgb(12, 27, 52);
            row1.Cells[4].Format.Font.Color = Colors.White;


            //addsnew row for data query
            //do your query here 





            //
            row1 = table10.AddRow();

            //for spacing 

            row1 = table10.AddRow();
            Last(doc, sec);
        }
        private void Last(Document doc1, Section sc1)
        {
            var table10 = doc1.LastSection.AddTable();
            table10.Borders.Width = 0.5;
            table10.AddColumn("9.7cm");

            Row row1 = table10.AddRow();

            row1.Cells[0].AddParagraph("SPECIAL INSTRUCTIONS/COMMENTS :");
            row1.Borders.Width = 0.0;
            row1 = table10.AddRow();
            row1.Height = "5.0cm";



        }
        private void GeneratePdf(String filename1)
        {
          
                Document document = new Document();

                topdetail(document);

                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                //testing part ng saving
                pdfRenderer.PdfDocument.Save(filename1);
                pdfRenderer = null;
                GC.Collect();
            
           
        }
        private void previewfile()
        {
            this.Cursor = Cursors.WaitCursor;
            Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(saveFileDialog1.FileName, 0, "");//just view
            pdfviewer1.Text = "Preview of PDF file";
            this.Cursor = Cursors.Default;
            pdfviewer1.Show();

            saveFileDialog1.FileName = "ListofProducts.pdf";


        }
        //purepdf
        private int genID()
        {

            String ID = "";
            Random ran1 = new Random();
            for (int i = 0;i!= 5;i++)
            {
                ID = ID + ran1.Next(1,9);
            }
            Thread.Sleep(100);
            return Convert.ToInt32(ID);
        }

        public void CnclPOBTN_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(Cancel, 0, "CANCEL ORDER", "ARE YOU SURE YOU WANT TO CANCEL THIS ORDER?", "OK", 2);
            ms.Show();
        }
        private void Preview_Click(object sender, EventArgs e)
        {
            //292 and 81
            if (this.Size.Height == 81)
            {
                this.Size = new System.Drawing.Size(0,292);  
            }
            else
            {      
                this.Size = new System.Drawing.Size(0, 81);
            }
            GC.Collect();
        }
        private void PurchaseOrderComponent_Leave(object sender, EventArgs e)
        {
            pdf.Click += null;
            Print.Click += null;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(DeleteRecords, 0, "DELETE RECORD","ARE YOU SURE YOU WANT TO DELETE THIS RECORD?", "OK", 2);
            ms.Show();
        }
        private void Archive_Click(object sender, EventArgs e)
        {

            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD?\n THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?.", "OK", 0);
            ms.Show();
        
        }
        private void pdf_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = saveFileDialog1.FileName + POID.Text + "_" + ReceivingDate.Text +"_"+ genID();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
               GeneratePdf(saveFileDialog1.FileName);

                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(previewfile, 0, "PREVIEW PDF FILE", "PDF SUCCESSFULLY SAVED!\n WOULD YOU LIKE TO PREVIEW THE DOCUMENT?", "OK", 0);
                msg2.Show();
                this.Cursor = Cursors.Default;
                //file save would you like to preview it?
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            String path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JUFAVSQLITE/REPORTSTemp/" + "PurchaseOrder_" +genID()+ ".pdf";
            //uses two path one for documents and next is for printing purposes which is created in Appdata Folder
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "PurchaseOrder_TEMPORARY" + genID() + ".pdf";
            this.Cursor = Cursors.WaitCursor;
            GeneratePdf(path);//path to app data
            GeneratePdf(path2);

            Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(path, 1, path2);
            pdfviewer1.Text = "PRINT DOCUMENT FILE";
            pdfviewer1.ShowDialog(this);
            this.Cursor = Cursors.Default;
        }
    }
}
