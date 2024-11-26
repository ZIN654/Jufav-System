using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//for DATABASE AND SQL CONNECTION
using System.Data.SQLite;
using JUFAV_System.dll;
//FOR PDF GENERATION AND PRINT
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;


namespace JUFAV_System.ModulesMain.REPORTS
{
    public partial class SalesReports : UserControl
    {
        Document doc2;
        PdfDocumentRenderer pfd2;
        int count = 0;
        String Qerytouse;
        int caseQuery = 0;
        String titletouse = "";
        public SalesReports()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            titletouse = "ALL SALES";
            LoadData("SELECT * FROM SALES;");

            label4.Text = LoadDataCount("SELECT COUNT(*) FROM SALES WHERE DATEOFSALE = '" + DateTime.Now.ToShortDateString() + "';").ToString();
            label6.Text = LoadDataCount("SELECT COUNT(*) FROM SALES WHERE date(substr(DATEOFSALE,7,4)|| '-' || substr(DATEOFSALE,4,2) || '-' || substr(DATEOFSALE,1,2)) BETWEEN date('now','weekday 0','-6 days') AND date('now','weekday 0');").ToString();
            label5.Text = LoadDataCount("SELECT COUNT(*) FROM SALES WHERE substr(DATEOFSALE,7,4) || '-' || substr(DATEOFSALE,4,2) = strftime('%Y-%m','now');").ToString();
        }
        private int LoadDataCount(String querytoues)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            int count = 0;
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            count = Convert.ToInt32(sq.ExecuteScalar());
            sq = null;
            GC.Collect();
            initd.con1.Close();
            return count;     
        }
        private void LoadData(String querytoues) {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = sq.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesComponentReports sl1 = new Components.SalesComponentReports(sread1["CUSTOMERNAME"].ToString(), sread1["TOTALPRICE"].ToString(),sread1["DISCOUNT"].ToString(), sread1["TOTALITEMS"].ToString(), sread1["DATEOFSALE"].ToString(), sread1["PAYMENTTYPE"].ToString(), sread1["CUSTOMERPAYMENT"].ToString(), Convert.ToInt32(sread1["SALEID"]), sread1["GCASHREFERENCE"].ToString());
                ITEMSBOX.Controls.Add(sl1);
            }
            sread1.Close();
            sq = null;
            sread1 = null;
            GC.Collect();
            initd.con1.Close();    
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
        //refine GAMIT MO NALNG UNG LOAD DATA KALIKUT UNG PARAM SWITCHCASE CHANGE QUERY 
        private void TodaysSale()
        {
            ClearItems();
            LoadData("SELECT * FROM SALES WHERE DATEOFSALE = '"+DateTime.Now.ToShortDateString()+"'");
        }
        private void WeeksSale()
        {
            ClearItems();
            LoadData("SELECT * FROM SALES WHERE date(substr(DATEOFSALE,7,4)|| '-' || substr(DATEOFSALE,4,2) || '-' || substr(DATEOFSALE,1,2)) BETWEEN date('now','weekday 0','-6 days') AND date('now','weekday 0');");
        }
        private void MonthSale()
        {
            ClearItems();
            LoadData("SELECT * FROM SALES WHERE substr(DATEOFSALE,7,4) || '-' || substr(DATEOFSALE,4,2) = strftime('%Y-%m','now');");

        }
    
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
            section1.Headers.Primary.AddParagraph().AddFormattedText("SALES REPORTS", TextFormat.Bold).Size = "19";



            var ph = section1.AddParagraph();

            ph = section1.Headers.Primary.AddParagraph();
            ph.AddText("JUFAV CONSTRUCTIONS AND SUPPLY");
            //list reports ang nakalagay dapat dyan

            ph.Format.Alignment = ParagraphAlignment.Center;
            ph.AddLineBreak();




            ph.AddText(titletouse.ToUpper() + " Date: ");
            ph.AddFormattedText(DateTime.Now.ToShortDateString(), TextFormat.Bold);
            ph.AddLineBreak();

            var table = docu1.LastSection.AddTable();
            table.Borders.Width = 0.5;

            //collumn creation
            table.AddColumn("3.2cm");
            table.AddColumn("2.0cm");
            table.AddColumn("2.0cm");
            table.AddColumn("2.5cm");
            table.AddColumn("2.5cm");
            table.AddColumn("2.5cm");
            table.AddColumn("2.5cm");


            //row creationUSERID,CUSTOMERNAME,CUSTOMERADDRESS,DATEOFSALE,TOTALITEMS,TOTALPRICE,PAYMENTVALUE,DISCOUNT,PAYMENTTYPE,CUSTOMERPAYMENT,ORDERTYPE,GCASHREFERENCE
            Row row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;
            row1.HeightRule = RowHeightRule.Auto;
            row1.Cells[0].AddParagraph("CUSTOMER NAME");
            row1.Cells[1].AddParagraph("DATE OF SALES");
            row1.Cells[2].AddParagraph("PAYMENT METHOD");
            row1.Cells[3].AddParagraph("NUMBER OF ITEMS");
            row1.Cells[4].AddParagraph("DISCOUNT");
            row1.Cells[5].AddParagraph("PAID AMOUNT");
            row1.Cells[6].AddParagraph("TOTAL AMOUNT");
            //query type
            switch (caseQuery)
            {
                case 0:
                    Qerytouse = "SELECT * FROM SALES WHERE DATEOFSALE = '" + DateTime.Now.ToShortDateString() + "'";
                    break;
                case 1:
                    Qerytouse = "SELECT * FROM SALES WHERE date(substr(DATEOFSALE,7,4)|| '-' || substr(DATEOFSALE,4,2) || '-' || substr(DATEOFSALE,1,2)) BETWEEN date('now','weekday 0','-6 days') AND date('now','weekday 0');";
                    break;
                case 2:
                    Qerytouse = "SELECT * FROM SALES WHERE substr(DATEOFSALE,7,4) || '-' || substr(DATEOFSALE,4,2) = strftime('%Y-%m','now');";
                    break;
                case 3:
                    Qerytouse = "SELECT * FROM SALES WHERE DATEOFSALE BETWEEN '" + DateTime.Parse(dateTimePicker1.Text).ToShortDateString() + "' AND '" + DateTime.Parse(dateTimePicker2.Text).ToShortDateString() + "';";
                    break;
                case 4:
                    Qerytouse = "SELECT * FROM SALES WHERE CUSTOMERNAME LIKE '%" + textBox1.Text + "%';";
                    break;
            }

            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            //add items
            List<double> tosum = new List<double>();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand(Qerytouse, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                row1 = table.AddRow();
                row1.Cells[0].AddParagraph(sread1["CUSTOMERNAME"].ToString());
                row1.Cells[1].AddParagraph(sread1["DATEOFSALE"].ToString());
                row1.Cells[2].AddParagraph(sread1["PAYMENTTYPE"].ToString());

                tosum.Add(Convert.ToDouble(sread1["TOTALPRICE"]));
                row1.Cells[3].AddParagraph(sread1["TOTALITEMS"].ToString());
                row1.Cells[4].AddParagraph(Convert.ToDouble(sread1["DISCOUNT"]).ToString());
                row1.Cells[5].AddParagraph(Convert.ToDouble(sread1["CUSTOMERPAYMENT"]).ToString());
                row1.Cells[6].AddParagraph(Convert.ToDouble(sread1["TOTALPRICE"]).ToString());


            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
            //talbe
            initd.con1.Close();
            var table2 = docu1.LastSection.AddTable();
            table2.Borders.Width = 0.5;

            //collumn creation
            table2.AddColumn("3.2cm");
            table2.AddColumn("2.0cm");
            table2.AddColumn("2.0cm");
            table2.AddColumn("2.5cm");
            table2.AddColumn("2.5cm");
            table2.AddColumn("2.5cm");
            table2.AddColumn("2.5cm");


            //row creationUSERID,CUSTOMERNAME,CUSTOMERADDRESS,DATEOFSALE,TOTALITEMS,TOTALPRICE,PAYMENTVALUE,DISCOUNT,PAYMENTTYPE,CUSTOMERPAYMENT,ORDERTYPE,GCASHREFERENCE
            Row row12 = table.AddRow();
            row12.HeadingFormat = true;
            row12.Format.Font.Bold = true;
            row12.HeightRule = RowHeightRule.Auto;
            row12.Cells[0].Borders.Width = 0;

            row12.Cells[1].Borders.Width = 0;
            row12.Cells[2].Borders.Width = 0;
            row12.Cells[3].Borders.Width = 0;
            row12.Cells[4].Borders.Width = 0;

            row12.Cells[5].AddParagraph("TOTAL : ");
            row12.Cells[6].AddParagraph(tosum.Sum().ToString());
            // tofilter(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text, row1, table);
            //footer

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
           
            
            saveFileDialog1.FileName = titletouse + "_"+ DateTime.Now.Day.ToString()+"_"+DateTime.Now.Month.ToString() + "_"+DateTime.Now.Year.ToString() + "_" + genID();
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

        private void tdyBTN_Click(object sender, EventArgs e)
        {
            caseQuery = 0;
            title.Text = "TODAYS SALES";
            titletouse = "TODAYS SALES";
            TodaysSale();
        }
        private void WeekBTN_Click(object sender, EventArgs e)
        {
            caseQuery = 1;
            title.Text = "THIS WEEK SALES";
            titletouse = "THIS WEEK SALES";
            WeeksSale();
        }
        private void MonthBTN_Click(object sender, EventArgs e)
        {
            caseQuery = 2;
            title.Text = "THIS MONTH SALES";
            titletouse = "THIS MONTH SALES";
            MonthSale();
        }
        private void filterBTNDAte_Click(object sender, EventArgs e)
        {
            caseQuery = 3;
            ClearItems();
            titletouse = "FILTER FROM: " + DateTime.Parse(dateTimePicker1.Text).ToShortDateString() + " TO: " + DateTime.Parse(dateTimePicker2.Text).ToShortDateString();
            title.Text = "FILTER FROM: " + DateTime.Parse(dateTimePicker1.Text).ToShortDateString() + " TO: " + DateTime.Parse(dateTimePicker2.Text).ToShortDateString();
            LoadData("SELECT * FROM SALES WHERE DATEOFSALE BETWEEN '"+DateTime.Parse(dateTimePicker1.Text).ToShortDateString()+"' AND '"+ DateTime.Parse(dateTimePicker2.Text).ToShortDateString() + "';");
        }
        private void srchBTN_Click(object sender, EventArgs e)
        {
            caseQuery = 4;
            ClearItems();
            title.Text = "SEARCH BY NAME: " + textBox1.Text ;
            titletouse = "SEARCH BY NAME: " + textBox1.Text;
            LoadData("SELECT * FROM SALES WHERE CUSTOMERNAME LIKE '%"+textBox1.Text+"%';");
        }
        private void PRINT_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            initd.titleofprint = "SALES_REPORTS";
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
        private void GENPDF_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DownloadPDF();
            this.Cursor = Cursors.Default;
        }
    }
}
