using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
using System.Text.RegularExpressions;
using System.IO;

namespace JUFAV_System.ModulesMain.REPORTS
{
    public partial class StockAdjustmentsReports : UserControl
    {
        String date1;
        String date2;
        Document doc2;
        PdfDocumentRenderer pfd2;
        String titletouse = "";
        String Qerytouse;
        int count = 0;
        int caseQuery = 2;
        public StockAdjustmentsReports()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;

           
            titletouse = "ALL STOCK ADJUSTMENTS";
            LoadData("SELECT * FROM STOCKADJUSTMENTS;");
        }

        private void ClearItems()
        {
            foreach (UserControl i in ITEMSBOX.Controls)
            {
                i.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            GC.Collect();

        }
        private void LoadData(String querytoues)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = sq.ExecuteReader();
            while (sread1.Read())
            {
                // sread1["GCASHREFERENCE"].ToString()
                Components.StockAdjustmentComponentReports sl1 = new Components.StockAdjustmentComponentReports(sread1["PRODUCTNAME"].ToString(), sread1["PREVIOUSQUANTITY"].ToString(),sread1["DATEOFADJUSTMENT"].ToString(), sread1["TIMEOFADJUSTMENT"].ToString(), sread1["ADJUSTMENTTYPE"].ToString(), sread1["ADJUSTEDQUANTITY"].ToString(), sread1["REASON"].ToString() +" \n " + sread1["OTHERS"].ToString(), Convert.ToInt32(sread1["STOCKADJUSTMENTID"]));
                ITEMSBOX.Controls.Add(sl1);
            }
            sread1.Close();
            sq = null;
            sread1 = null;
            GC.Collect();
            initd.con1.Close();
        }
        private void filterBTNDAte_Click(object sender, EventArgs e)
        {
            caseQuery = 2;
            ClearItems();
            LoadData("SELECT * FROM STOCKADJUSTMENTS WHERE DATEOFADJUSTMENT BETWEEN '" + DateTime.Parse(dateTimePicker1.Text).ToShortDateString() + "' AND '" + DateTime.Parse(dateTimePicker2.Text).ToShortDateString() + "';");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            caseQuery = 0;
            titletouse = "POSITIVE VARIANTS";
            ClearItems();
            LoadData("SELECT * FROM STOCKADJUSTMENTS WHERE ADJUSTEDQUANTITY > -0;");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            titletouse = "NEGATIVE VARIANTS";
            caseQuery = 1;
            ClearItems();
            LoadData("SELECT * FROM STOCKADJUSTMENTS WHERE ADJUSTEDQUANTITY < -0;");
        }


        //pDF


        //PDF creation
        private String processdate(DateTime dt1)
        {
            String datetostring = Regex.Replace(dt1.ToShortDateString(), "/", "_");
            return datetostring;
        }
        private void GeneratePdf2(String path)
        {

            doc2 = null;
            pfd2 = null;

            doc2 = new Document();
            pfd2 = new PdfDocumentRenderer();
            //case switch gawa ka tas kapag summon type is 3 dun and sales

            CreateSalesReports(doc2);


            pfd2.Document = doc2;
            pfd2.RenderDocument();
            pfd2.PdfDocument.Save(path);//file is being used exception paag prinint
            pfd2.PdfDocument.Close();
            doc2 = null;
            pfd2 = null;
            GC.Collect();
        }
        //edit ung document data here 
        private void CreateSalesReports(Document docu1)
        {
            //define sectiomn
            this.Cursor = Cursors.WaitCursor;
            Section section1 = docu1.AddSection();

            //insert image logo kapag gagawa ng purchase order
            section1.Headers.Primary.Format.Alignment = ParagraphAlignment.Center;
            section1.Headers.Primary.AddParagraph().AddFormattedText("STOCK ADJUSTMENTS REPORTS", TextFormat.Bold).Size = "19";



            var ph = section1.AddParagraph();
            ph = section1.Headers.Primary.AddParagraph();
            ph.AddText("JUFAV CONSTRUCTIONS AND SUPPLY");//list reports ang nakalagay dapat dyan

            ph.Format.Alignment = ParagraphAlignment.Center;
            ph.AddLineBreak();




            ph.AddText(titletouse.ToUpper() + " Date: ");
            ph.AddFormattedText(DateTime.Now.ToShortDateString(), TextFormat.Bold);
            
            ph.AddLineBreak();
            ph.AddText("FROM: ");
            ph.AddFormattedText(dateTimePicker1.Text, TextFormat.Bold);
            ph.AddText("TO: ");
            ph.AddFormattedText(dateTimePicker2.Text, TextFormat.Bold);
            ph.AddLineBreak();

            var tables = section1.AddTable();
            tables.AddColumn("16.0cm");
            Row rows = tables.AddRow();

            var table = docu1.LastSection.AddTable();
            table.Borders.Width = 0.5;

            //collumn creation
            table.AddColumn("3.2cm");
            table.AddColumn("1.0cm");
            table.AddColumn("2.1cm");
            table.AddColumn("2.0cm");
            table.AddColumn("3.0cm");
            table.AddColumn("3.0cm");
            table.AddColumn("3.0cm");


            //row creation
            Row row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;
            row1.HeightRule = RowHeightRule.Auto;
            
            row1.Cells[0].AddParagraph("PRODUCT NAME");
            row1.Cells[1].AddParagraph("Qty.");
            row1.Cells[2].AddParagraph("DATE");
            row1.Cells[3].AddParagraph("TIME");
            row1.Cells[4].AddParagraph("ADJUSTMENT TYPE");
            row1.Cells[5].AddParagraph("QUANTTY ADJUSTED");
            row1.Cells[6].AddParagraph("REASON");
            //query type
            switch (caseQuery)
            {
                case 0:
                    Qerytouse = "SELECT * FROM STOCKADJUSTMENTS WHERE ADJUSTEDQUANTITY > -0;";
                    break;
                case 1:
                    Qerytouse = "SELECT * FROM STOCKADJUSTMENTS WHERE ADJUSTEDQUANTITY < -0;";
                    break;
                case 2:
                    Qerytouse = "SELECT * FROM STOCKADJUSTMENTS WHERE DATEOFADJUSTMENT BETWEEN '" + DateTime.Parse(dateTimePicker1.Text).ToShortDateString() + "' AND '" + DateTime.Parse(dateTimePicker2.Text).ToShortDateString() + "';";
                    break;
           
            }
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            //add items
            //DATEOFADJUSTMENT,TIMEOFADJUSTMENT,PRODUCTID,PRODUCTNAME,ADJUSTMENTTYPE,PREVIOUSQUANTITY,ADJUSTEDQUANTITY,REASON,OTHERS 
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand(Qerytouse, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                row1 = table.AddRow();
                row1.Cells[0].AddParagraph(sread1["PRODUCTNAME"].ToString());
                row1.Cells[1].AddParagraph(sread1["PREVIOUSQUANTITY"].ToString());
                row1.Cells[2].AddParagraph(sread1["DATEOFADJUSTMENT"].ToString());
                row1.Cells[3].AddParagraph(sread1["TIMEOFADJUSTMENT"].ToString());
                row1.Cells[4].AddParagraph(sread1["ADJUSTMENTTYPE"].ToString());
                row1.Cells[5].AddParagraph(sread1["ADJUSTEDQUANTITY"].ToString());
                row1.Cells[6].AddParagraph(sread1["REASON"].ToString() +" "+ sread1["OTHERS"].ToString());
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
            //talbe
            initd.con1.Close();
            // tofilter(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text, row1, table);
            //footer


            //auto adjust at add page pag super haba na
            ph = section1.Footers.Primary.AddParagraph();
            ph.AddText("PAGE ");
            ph.Format.Alignment = ParagraphAlignment.Right;


            this.Cursor = Cursors.Default;
        }
        //SAVE NG FILE DITO
        private int genID()
        {

            String ID = "";
            Random ran1 = new Random();
            for (int i = 0; i != 5; i++)
            {
                ID = ID + ran1.Next(1, 9);
            }
            Thread.Sleep(100);
            return Convert.ToInt32(ID);
        }
        private void previewfile()
        {
            this.Cursor = Cursors.WaitCursor;
            Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(saveFileDialog1.FileName, 0, "");//just view
            pdfviewer1.Text = "Preview of PDF file";
            this.Cursor = Cursors.Default;
            pdfviewer1.Show();

        }
        private void DownloadPDF()
        {


            saveFileDialog1.FileName = titletouse + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + genID();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                GeneratePdf2(saveFileDialog1.FileName);

                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(previewfile, 0, "PREVIEW PDF FILE", "PDF SUCCESSFULLY SAVED!\n WOULD YOU LIKE TO PREVIEW THE DOCUMENT?", "OK", 0);
                msg2.Show();
                this.Cursor = Cursors.Default;
                //file save would you like to preview it?
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            DownloadPDF();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            initd.titleofprint = "STOCK_ADJUSTMENT_REPORTS";
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/JUFAVREPORTS") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/JUFAVREPORTS");
                for (int i = 0; i != 3; i++)
                {
                    count = count + new Random().Next(0, 10);
                }
                //path2 prints the  document here //APPDATA
                String path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JUFAVSQLITE\\REPORTSTemp\\" + initd.titleofprint + "_" + processdate(DateTime.Now) + "_" + count + ".pdf";
                //path views the file //DOCUMENTS
                String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JUFAVREPORTS\\" + initd.titleofprint + "_" + processdate(DateTime.Now) + "_" + count + ".pdf";
                //generate a folder list 
                this.Cursor = Cursors.WaitCursor;

                GeneratePdf2(path);//for viewing 
                GeneratePdf2(path2);//path to app data for printing 

                Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(path, 1, path2);
                pdfviewer1.Text = "PRINT REPORTS OF: " + initd.titleofprint;
                pdfviewer1.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
            else
            {
                for (int i = 0; i != 3; i++)
                {
                    count = count + new Random().Next(0, 10);
                }
                //path2 prints the  document here //APPDATA
                String path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JUFAVSQLITE\\REPORTSTemp\\" + initd.titleofprint + "_" + processdate(DateTime.Now) + "_" + count + ".pdf";
                //path views the file //DOCUMENTS
                String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JUFAVREPORTS\\" + initd.titleofprint + "_" + processdate(DateTime.Now) + "_" + count + ".pdf";
                //generate a folder list 
                this.Cursor = Cursors.WaitCursor;

                GeneratePdf2(path);//for viewing 
                GeneratePdf2(path2);//path to app data for printing 

                Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(path, 1, path2);
                pdfviewer1.Text = "PRINT REPORTS OF: " + initd.titleofprint;
                pdfviewer1.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }
    }
}
