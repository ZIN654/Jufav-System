using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.dll;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SQLite;

namespace JUFAV_System.Components
{
    public partial class SmalloptionDashBoard : UserControl
    {
        Document doc2;
        PdfDocumentRenderer pfd2;
        int count = 0;
        int SMTYPE;
        public SmalloptionDashBoard(int summontype)
        {
            InitializeComponent();
            SMTYPE = summontype;
        }

        private void SmalloptionDashBoard_MouseLeave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SmalloptionDashBoard_Leave(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void CreatePO()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.Inventory.AddPurchaseOrder unit1 = new ModulesSecond.Inventory.AddPurchaseOrder();
            ResponsiveUI1.title = "AddPurchaseOrder";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        private void GoReprots()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.REPORTS.InventoryReports unit1 = new ModulesMain.REPORTS.InventoryReports();
            ResponsiveUI1.title = "InventoryReports";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);

        }
        //print part
        private void GeneratePdf2(String path)
        {

            doc2 = null;
            pfd2 = null;

            doc2 = new Document();
            pfd2 = new PdfDocumentRenderer();
            //case switch gawa ka tas kapag summon type is 3 dun and sales
            switch (SMTYPE)
            {
                case 0:
                    CreateLowOnstocksProducts(doc2);
                    break;
                case 1:
                    CreateOutOfStocks(doc2);
                    break;
                case 2:
                    CreateTotalSalesoftheDay(doc2);
                    break;
            }


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
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS WHERE QUANTITY = 0;", initd.con1);
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
            //talbe

            // tofilter(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text, row1, table);
            //footer

            ph = section1.Footers.Primary.AddParagraph();
            ph.AddText("PAGE ");
            ph.Format.Alignment = ParagraphAlignment.Right;


            this.Cursor = Cursors.Default;
        }
        private void CreateLowOnstocksProducts(Document docu1)
        {
            //define sectiomn
            this.Cursor = Cursors.WaitCursor;
            Section section1 = docu1.AddSection();
            //insert image logo kapag gagawa ng purchase order




            var ph = section1.AddParagraph();
            ph = section1.Headers.Primary.AddParagraph();
            ph.AddText("JUFAV CONSTRUCTIONS AND SUPPLY");//list reports ang nakalagay dapat dyan
            ph.Format.Alignment = ParagraphAlignment.Center;
            ph.AddLineBreak();





            ph.AddText("LOW ON STOCKS PRODUCTS     Date: ");
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
            row1.Cells[1].AddParagraph("CURRENT STOCKS");

            //add items

            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS WHERE QUANTITY <= 3 AND QUANTITY > 0;", initd.con1);
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
            //talbe

            // tofilter(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text, row1, table);
            //footer

            ph = section1.Footers.Primary.AddParagraph();
            ph.AddText("PAGE ");
            ph.Format.Alignment = ParagraphAlignment.Right;


            this.Cursor = Cursors.Default;
        }
        private void CreateTotalSalesoftheDay(Document docu1)
        {
            //define sectiomn
            this.Cursor = Cursors.WaitCursor;
            Section section1 = docu1.AddSection();
            //insert image logo kapag gagawa ng purchase order




            var ph = section1.AddParagraph();
            ph = section1.Headers.Primary.AddParagraph();
            ph.AddText("JUFAV CONSTRUCTIONS AND SUPPLY");//list reports ang nakalagay dapat dyan
            ph.Format.Alignment = ParagraphAlignment.Center;
            ph.AddLineBreak();


            ph.AddText("TODAYS SALES REPORT      Date: ");
            ph.AddFormattedText(DateTime.Now.ToShortDateString(), TextFormat.Bold);
            ph.AddLineBreak();

            var table = docu1.LastSection.AddTable();
            table.Borders.Width = 0.5;

            //collumn creation
            table.AddColumn("4.2cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");

            //row creation
            Row row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;
            row1.Cells[0].AddParagraph("CUSTOMER NAME");
            row1.Cells[1].AddParagraph("TOTAL ITEMS");
            row1.Cells[2].AddParagraph("TOTAL PRICE");
            row1.Cells[3].AddParagraph("DISCOUNT");
            row1.Cells[4].AddParagraph("PAYMENT VALUE");
            //add items

            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SALES WHERE DATEOFSALE = '" + DateTime.Now.ToShortDateString() + "';", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                row1 = table.AddRow();
                row1.Cells[0].AddParagraph(sread1["CUSTOMERNAME"].ToString());
                row1.Cells[1].AddParagraph(sread1["TOTALITEMS"].ToString());
                row1.Cells[2].AddParagraph(sread1["TOTALPRICE"].ToString());
                row1.Cells[3].AddParagraph(sread1["DISCOUNT"].ToString());
                row1.Cells[4].AddParagraph(sread1["PAYMENTVALUE"].ToString());


            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();

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
            saveFileDialog1.FileName = "ListofProducts.pdf";

        }
        private String processdate(DateTime dt1)
        {
            String datetostring = Regex.Replace(dt1.ToShortDateString(), "/", "_");
            return datetostring;
        }
        private void PrintLSt()
        {
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
                pdfviewer1.Text = "PRINT LIST OF: " + initd.titleofprint;
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
                pdfviewer1.Text = "PRINT LIST OF: " + initd.titleofprint;
                pdfviewer1.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }


        }



        private void CreatePOBTN_Click(object sender, EventArgs e)
        {
            CreatePO();
        }
        private void RportsBTN_Click(object sender, EventArgs e)
        {
            GoReprots();
        }
        private void PrntLst_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PrintLSt();
            this.Cursor = Cursors.Default;
        }
    }
}
