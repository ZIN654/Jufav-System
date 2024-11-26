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
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SQLite;
using System.Threading;

namespace JUFAV_System.ModulesMain.REPORTS
{
    
    public partial class InventoryReports : UserControl
    {
        Document doc2;
        PdfDocumentRenderer pfd2;
        int count = 0;
        String Qerytouse;
        int caseQuery = 0;
        String titletouse = "";
        public InventoryReports()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loaddata();
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
        private void LoadData2(String querytoues)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = sq.ExecuteReader();
            while (sread1.Read())
            {
                Components.InverntoryReportsComponents test1 = new Components.InverntoryReportsComponents(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["QUANTITY"]));
                ITEMSBOX.Controls.Add(test1);
            }
            sread1.Close();
            sq = null;
            sread1 = null;
            GC.Collect();
            initd.con1.Close();
        }
        private void loaddata()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS WHERE QUANTITY <= 3 OR 0;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = sq.ExecuteReader();
            while (sread1.Read())
            {
                Components.InverntoryReportsComponents test1 = new Components.InverntoryReportsComponents(sread1["PRODUCTNAME"].ToString(),Convert.ToDouble(sread1["QUANTITY"]));
                ITEMSBOX.Controls.Add(test1);

            }
            sread1.Close();
            initd.con1.Close();
        }
        private int LoadDataCount(String querytoues)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            int count = 0;
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            count = Convert.ToInt32(sq.ExecuteScalar());
            sq = null;
            GC.Collect();
            return count;
            initd.con1.Close();
        }
        private void LoadData(String querytoues)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }//stops here 
            MySql.Data.MySqlClient.MySqlCommand sq = new MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = sq.ExecuteReader();
            while (sread1.Read())
            {
                Components.InverntoryReportsComponents test1 = new Components.InverntoryReportsComponents(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["QUANTITY"]));
                ITEMSBOX.Controls.Add(test1);
            }
            sread1.Close();
            sq = null;
            sread1 = null;
            GC.Collect();
            initd.con1.Close();
        }

        //pdf gen
        private void GeneratePdf2(String path)
        {

            doc2 = null;
            pfd2 = null;

            doc2 = new Document();
            pfd2 = new PdfDocumentRenderer();
            //case switch gawa ka tas kapag summon type is 3 dun and sales
         
            CreateOutOfStocks(doc2);
        


            pfd2.Document = doc2;
            pfd2.RenderDocument();
            pfd2.PdfDocument.Save(path);//file is being used exception paag prinint
            pfd2.PdfDocument.Close();
            doc2 = null;
            pfd2 = null;

        }
        private void CreateOutOfStocks(Document docu1)
        {
            //define sectiomn
            this.Cursor = Cursors.WaitCursor;
            Section section1 = docu1.AddSection();
            //insert image logo kapag gagawa ng purchase order

            section1.Headers.Primary.Format.Alignment = ParagraphAlignment.Center;
            section1.Headers.Primary.AddParagraph().AddFormattedText("INVENTORY REPORTS", TextFormat.Bold).Size = "19";


            var ph = section1.AddParagraph();
            ph = section1.Headers.Primary.AddParagraph();
            ph.AddText("JUFAV CONSTRUCTIONS AND SUPPLY");//list reports ang nakalagay dapat dyan

            ph.Format.Alignment = ParagraphAlignment.Center;
            ph.AddLineBreak();




            ph.AddText("OUT OF STOCK PRODUCTS    Date: ");
            ph.AddFormattedText(DateTime.Now.ToShortDateString(), TextFormat.Bold);
            ph.AddLineBreak();

            var table = docu1.LastSection.AddTable();
            table.Borders.Width = 0.5;

            //collumn creation
            table.AddColumn("10.2cm");
            table.AddColumn("6cm");


            //row creation
            Row row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;
            row1.Cells[0].AddParagraph("PRODUCT NAME");
            row1.Cells[1].AddParagraph("CURRENT STOCK");

            //add items
            switch (caseQuery)
            {
                case 0:
                    Qerytouse = "SELECT * FROM PRODUCTS WHERE QUANTITY <= 3 AND QUANTITY > 0;";
                    break;
                case 1:
                    Qerytouse = "SELECT * FROM PRODUCTS WHERE QUANTITY = 0;";
                    break;
            }
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand(Qerytouse, initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                row1 = table.AddRow();
                row1.Cells[0].AddParagraph(sread1["PRODUCTNAME"].ToString());
                row1.Cells[1].AddParagraph(sread1["QUANTITY"].ToString());
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
            initd.con1.Close();
            //talbe

            // tofilter(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text, row1, table);
            //footer

            ph = section1.Footers.Primary.AddParagraph();
            ph.AddText("PAGE ");
            ph.Format.Alignment = ParagraphAlignment.Right;


            this.Cursor = Cursors.Default;
        }
        private void previewfile()
        {
            this.Cursor = Cursors.WaitCursor;
            Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(saveFileDialog1.FileName, 0, "");//just view
            pdfviewer1.Text = "Preview of PDF file";
            this.Cursor = Cursors.Default;
            pdfviewer1.Show();

        }
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
        private String processdate(DateTime dt1)
        {
            String datetostring = Regex.Replace(dt1.ToShortDateString(), "/", "_");
            return datetostring;
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
            caseQuery = 0;
            ClearItems();
            label17.Text = "LOW ON STOCKS";
            LoadData("SELECT * FROM PRODUCTS WHERE QUANTITY <= 3 AND QUANTITY > 0;");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearItems();
            caseQuery = 1;
            label17.Text = "OUT O STOCKS";
            LoadData("SELECT * FROM PRODUCTS WHERE QUANTITY = 0;");
        }

        private void button6_Click(object sender, EventArgs e)
        {
          //  caseQuery = 1;
            //label17.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            DownloadPDF();
        }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = 0.ToString();
                ClearItems();
                LoadData("SELECT * FROM PRODUCTS WHERE QUANTITY <= " + textBox1.Text + ";");
            }else
            {


                ClearItems();
                LoadData("SELECT * FROM PRODUCTS WHERE QUANTITY <= " + textBox1.Text + ";");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text,@"[^0-9]"))
            {
                textBox1.Text = 0.ToString();
                Messageboxes.MessageboxConfirmation con1 = new Messageboxes.MessageboxConfirmation(null,1,"TEXT SEARCH","INVALID TEXT INPUT , PLEASE USE NUMBERS.","CLOSE",2);
                con1.ShowDialog();
            }
        }
    }
}
