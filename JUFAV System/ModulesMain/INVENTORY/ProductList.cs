using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;
using System.Text.RegularExpressions;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;


namespace JUFAV_System.ModulesMain.INVENTORY
{
    public partial class ProductList : UserControl
    {
        int count = 2; //avoids exeception being used create function to increase when exception occured
        Dictionary<int, string> category;
        Dictionary<int, string> Subcategory;
        Dictionary<int, string> UoM;
        Dictionary<int, string> Supplier;

        Dictionary<string,int> category2;
        Dictionary<string, int> Subcategory2;
        Dictionary<string, int> UoM2;
       
        PdfDocumentRenderer pfd1;
        Document doc;
        Document doc2;
        PdfDocumentRenderer pfd2;
        public ProductList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Cursor = Cursors.WaitCursor;
            category = new Dictionary<int, string>();
            Subcategory = new Dictionary<int, string>();
            UoM = new Dictionary<int, string>();
            Supplier = new Dictionary<int, string>();

            category2 = new Dictionary<string, int>();
            Subcategory2 = new Dictionary<string, int>();
            UoM2 = new Dictionary<string, int>();


            loadUnits();
          
            this.Cursor = Cursors.Default; ;
        }
        private void loadUnits()
        {
           
            category.Clear();
            Subcategory.Clear();
            UoM.Clear();
            Supplier.Clear();
            comboBox1.Items.Add("ALL ITEMS");
            comboBox2.Items.Add("ALL ITEMS");
            category2.Add("ALL ITEMS",1001);
            Subcategory2.Add("ALL ITEMS", 1002);
           
            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYID,CATEGORYDESC FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
              
                category.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());
                category2.Add(sq1["CATEGORYDESC"].ToString(), Convert.ToInt32(sq1["CATEGORYID"]));
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());



            }
            sq1.Close();
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
               
                Subcategory.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]),sq1["SUBCATEGORYDESC"].ToString());
                Subcategory2.Add(sq1["SUBCATEGORYDESC"].ToString(), Convert.ToInt32(sq1["SUBCATEGORYID"]));
                comboBox2.Items.Add(sq1["SUBCATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT UNITDESC,UNITID FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                UoM.Add(Convert.ToInt32(sq1["UNITID"]),sq1["UNITDESC"].ToString());
                UoM2.Add(sq1["UNITDESC"].ToString(), Convert.ToInt32(sq1["UNITID"]));

            }
            sq1.Close();
            scom1.CommandText = "SELECT SUPPLIERNAME,SUPPLIERID FROM SUPPLIERS";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Supplier.Add(Convert.ToInt32(sq1["SUPPLIERID"]), sq1["SUPPLIERNAME"].ToString());
               

            }
            comboBox1.SelectedIndex = 0;
            sq1 = null;
            scom1 = null;
        }
        private void tofilter(int Category, int Subcat, int perishable, int batched, String search, Row row1,Table table)
        {
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            SQLiteDataReader sread1;
            //allitems
            if (Category == 1001)
            {

                scom1.CommandText = "SELECT * FROM PRODUCTS ORDER BY PRODUCTNAME ASC";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang

                    row1.Cells[0].AddParagraph(sread1["PRODUCTNAME"].ToString());
                    row1.Cells[1].AddParagraph(sread1["QUANTITY"].ToString());
                    row1.Cells[2].AddParagraph(UoM[Convert.ToInt32(sread1["UOMID"])].ToString());
                    row1.Cells[3].AddParagraph(sread1["ORIGINALPICE"].ToString());
                    row1.Cells[4].AddParagraph((Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString());
                    row1 = table.AddRow();
                }
                sread1.Close();
            }
            else if (Category != 1001 && Subcat == 1002)
            {
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " ORDER BY PRODUCTNAME ASC;";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    row1.Cells[0].AddParagraph(sread1["PRODUCTNAME"].ToString());
                    row1.Cells[1].AddParagraph(sread1["QUANTITY"].ToString());
                    row1.Cells[2].AddParagraph(UoM[Convert.ToInt32(sread1["UOMID"])].ToString());
                    row1.Cells[3].AddParagraph(sread1["ORIGINALPICE"].ToString());
                    row1.Cells[4].AddParagraph((Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString());
                    row1 = table.AddRow();

                }
                sread1.Close();
            }
            else
            {
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " AND SUBCATEGORYID = " + Subcat + " AND ISBATCH = " + batched + " AND PERISHABLEPRODUCT = " + perishable + " ORDER BY PRODUCTNAME ASC;";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    row1.Cells[0].AddParagraph(sread1["PRODUCTNAME"].ToString());
                    row1.Cells[1].AddParagraph(sread1["QUANTITY"].ToString());
                    row1.Cells[2].AddParagraph(UoM[Convert.ToInt32(sread1["UOMID"])].ToString());
                    row1.Cells[3].AddParagraph(sread1["ORIGINALPICE"].ToString());
                    row1.Cells[4].AddParagraph((Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString());
                    row1 = table.AddRow();

                }
                sread1.Close();


            }
            scom1 = null;
            sread1 = null;



        }
        private void tofilter2(int Category,int Subcat,int perishable,int batched,String search)
        {
            foreach (UserControl items in topdf.Controls){
                items.Dispose();
            }
            topdf.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            SQLiteDataReader sread1;

            //allitems
            if (Category == 1001)
            {
               
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%"+search+"%' ORDER BY PRODUCTNAME DESC";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.ProdListtDataBoxComponent as1 = new Components.ProdListtDataBoxComponent(sread1["PRODUCTNAME"].ToString(), category[Convert.ToInt32(sread1["CATEGORYID"])], Subcategory[Convert.ToInt32(sread1["SUBCATEGORYID"])], Convert.ToDouble(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], Convert.ToDouble(sread1["ORIGINALPICE"]), Convert.ToDouble(sread1["MARKUPVALUE"]), determineVal(Convert.ToInt32(sread1["PERISHABLEPRODUCT"])), DateTime.Parse(sread1["EXPIRINGDATE"].ToString()).ToShortDateString(), determineVal(Convert.ToInt32(sread1["ISBATCH"])), Convert.ToInt32(sread1["PRODUCTID"]));
                    topdf.Controls.Add(as1);

                }
                sread1.Close();
            }
            else if (Category != 1001 && Subcat == 1002)
            {
              
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = "+Category+ " ORDER BY PRODUCTNAME DESC;";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.ProdListtDataBoxComponent as1 = new Components.ProdListtDataBoxComponent(sread1["PRODUCTNAME"].ToString(), category[Convert.ToInt32(sread1["CATEGORYID"])], Subcategory[Convert.ToInt32(sread1["SUBCATEGORYID"])], Convert.ToDouble(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], Convert.ToDouble(sread1["ORIGINALPICE"]), Convert.ToDouble(sread1["MARKUPVALUE"]), determineVal(Convert.ToInt32(sread1["PERISHABLEPRODUCT"])), DateTime.Parse(sread1["EXPIRINGDATE"].ToString()).ToShortDateString(), determineVal(Convert.ToInt32(sread1["ISBATCH"])), Convert.ToInt32(sread1["PRODUCTID"]));
                    topdf.Controls.Add(as1);

                }
                sread1.Close();
            }
            else
            {
             
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " AND SUBCATEGORYID = " + Subcat + " AND ISBATCH = " + batched + " AND PERISHABLEPRODUCT = " + perishable + " ORDER BY PRODUCTNAME DESC;";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.ProdListtDataBoxComponent as1 = new Components.ProdListtDataBoxComponent(sread1["PRODUCTNAME"].ToString(), category[Convert.ToInt32(sread1["CATEGORYID"])], Subcategory[Convert.ToInt32(sread1["SUBCATEGORYID"])], Convert.ToDouble(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], Convert.ToDouble(sread1["ORIGINALPICE"]), Convert.ToDouble(sread1["MARKUPVALUE"]), determineVal(Convert.ToInt32(sread1["PERISHABLEPRODUCT"])), DateTime.Parse(sread1["EXPIRINGDATE"].ToString()).ToShortDateString(), determineVal(Convert.ToInt32(sread1["ISBATCH"])), Convert.ToInt32(sread1["PRODUCTID"]));
                    topdf.Controls.Add(as1);

                }
                sread1.Close();


            }
           


        }
        private bool determineVal(int todet)
        {
            if (todet == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int determineVal2(bool todet)
        {
            if (todet == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private String processdate(DateTime dt1)
        {
            String datetostring = Regex.Replace(dt1.ToShortDateString(), "/", "_");
            return datetostring;
        }
        private void GeneratePdf(String path)
        {
            doc = null;
            pfd1 = null;
         
            doc = new Document();
            pfd1 = new PdfDocumentRenderer();
                Insertdata(doc);
                pfd1.Document = doc;
                pfd1.RenderDocument();
                pfd1.PdfDocument.Save(path);
           // pfd2.PdfDocument.Close();
            doc2 = null;
            pfd2 = null;

        }
        private void GeneratePdf2(String path)
        {
            doc2 = null;
            pfd2 = null;
          
            doc2 = new Document();
            pfd2 = new PdfDocumentRenderer();
            Insertdata(doc2);
            pfd2.Document = doc2;
            pfd2.RenderDocument();
            pfd2.PdfDocument.Save(path);//file is being used exception
            pfd2.PdfDocument.Close();
            doc2 = null;
            pfd2 = null;
        }
        private void Insertdata(Document docu1)
        {
            //define sectiomn
            this.Cursor = Cursors.WaitCursor;
            Section section1 = docu1.AddSection();
            //insert image logo kapag gagawa ng purchase order




            var ph = section1.AddParagraph();
            ph = section1.Headers.Primary.AddParagraph();
            ph.AddText("JUFAV CONSTRUCTIONS AND SUPPLY");
            ph.AddLineBreak();
            ph.AddText("ZONE 6,SITIO MALIGAYA,MALIWALO,TARLAC CITY");
            ph.AddLineBreak();
            ph.AddText("Contact No. +63956-679-7330 , +63942-010-8528");
            ph.Format.Alignment = ParagraphAlignment.Center;
            ph.AddLineBreak();
           

            //ph = section1.AddParagraph();
            //ph.AddText("");
            /*
           
            ph.AddText("SMAPLE TEXT");
            ph.AddLineBreak();
            ph.AddText("SMAPLE TEXT 222222222");
            ph.Format.SpaceAfter = 20;

            ph = section1.AddParagraph();
            ph.AddText("SMAPLE TEXT22222");
            ph.AddLineBreak();
            ph.AddText("SMAPLE TEXT adssa");
            ph.Format.SpaceAfter = 20;
            */

            // section1.AddPageBreak();
            //table creation 

            ph.AddText("ALL ITEMS LIST");
            ph.AddLineBreak();
           
            var table = docu1.LastSection.AddTable();
            table.Borders.Width = 0.5;
            
            //collumn creation
            table.AddColumn("10.2cm");
            table.AddColumn("1cm");
            table.AddColumn("1cm");
            table.AddColumn("2cm");
            table.AddColumn("2cm");

            //row creation
            Row row1 = table.AddRow();
            row1.HeadingFormat = true;
            row1.Format.Font.Bold = true;
            row1.Cells[0].AddParagraph("PRODUCT NAME");
            row1.Cells[1].AddParagraph("Qty.");
            row1.Cells[2].AddParagraph("UNIT");
            row1.Cells[3].AddParagraph("UNIT PRICE");
            row1.Cells[4].AddParagraph("SELLING PRICE");
            //add items
            row1 = table.AddRow();

            //talbe
  
            tofilter(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text,row1,table);   
         //footer

            ph = section1.Footers.Primary.AddParagraph();
           ph.AddText("PAGE ");
           ph.Format.Alignment = ParagraphAlignment.Right;


            this.Cursor = Cursors.Default;
        }
        private void previewfile()
        {
            this.Cursor = Cursors.WaitCursor;
            Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(saveFileDialog1.FileName,0,"");//just view
            pdfviewer1.Text = "Preview of PDF file";
            this.Cursor = Cursors.Default;
            pdfviewer1.Show();
          
            saveFileDialog1.FileName = "ListofProducts.pdf";
           
           
        }


        private void setitem()
        {
            
            comboBox2.Items.Clear();
            comboBox2.Items.Add("ALL ITEMS");
            //if statement
            if (comboBox1.Text == "ALL ITEMS")
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {

                SQLiteCommand scom1 = new SQLiteCommand("SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY WHERE CATEGORYID = " + Convert.ToInt32(category2[comboBox1.Text]) + ";", initd.scon);
                SQLiteDataReader sq1 = scom1.ExecuteReader();
                while (sq1.Read())
                {
                    comboBox2.Items.Add(sq1["SUBCATEGORYDESC"].ToString());
                }
                comboBox2.SelectedIndex = 0;
                sq1.Close();
                scom1 = null;
                sq1 = null;
              
            }


            
        }
        private void filtersearchbox(String text)
        {
            //search anything 
            foreach (UserControl items in topdf.Controls)
            {
                items.Dispose();
            }
            topdf.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%"+text+ "%';", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Components.ProdListtDataBoxComponent as1 = new Components.ProdListtDataBoxComponent(sq1["PRODUCTNAME"].ToString(), category[Convert.ToInt32(sq1["CATEGORYID"])], Subcategory[Convert.ToInt32(sq1["SUBCATEGORYID"])], Convert.ToDouble(sq1["QUANTITY"]), UoM[Convert.ToInt32(sq1["UOMID"])], Convert.ToDouble(sq1["ORIGINALPICE"]), Convert.ToDouble(sq1["MARKUPVALUE"]), determineVal(Convert.ToInt32(sq1["PERISHABLEPRODUCT"])), DateTime.Parse(sq1["EXPIRINGDATE"].ToString()).ToShortDateString(), determineVal(Convert.ToInt32(sq1["ISBATCH"])), Convert.ToInt32(sq1["PRODUCTID"]));
                topdf.Controls.Add(as1);
            }
            sq1.Close();
            scom1 = null;
            sq1 = null;
           


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pick path then save it there then if we want to view it just use messagebox
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
        private void printBtn_Click(object sender, EventArgs e)
        {
            String path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JUFAVSQLITE/REPORTSTemp/" + "ProductListJufav_" + processdate(DateTime.Now) + "_" + count + ".pdf";
            //uses two path one for documents and next is for printing purposes which is created in Appdata Folder
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "ProductListJufav_" + processdate(DateTime.Now) + "_"+count+".pdf";
                 this.Cursor = Cursors.WaitCursor;
                 GeneratePdf2(path);//path to app data
                 GeneratePdf2(path2);
            Messageboxes.PdfFileViewer pdfviewer1 = new Messageboxes.PdfFileViewer(path, 1,path2);
                 pdfviewer1.Text = "PRINT DOCUMENT FILE";
                 pdfviewer1.ShowDialog(this);
                 this.Cursor = Cursors.Default;
            count++;
            //file save would you like to preview it?   
            
           // Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "ProductListJufav" + processdate(DateTime.Now) + ".pdf");
        }
        private void ProductList_Leave(object sender, EventArgs e)
        {
            
            category = null;
            Subcategory = null;
            UoM = null;
            Supplier = null;

            category2 = null;
            Subcategory2 = null;
            UoM2 = null;
           
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            setitem();
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]),determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked),srchbox.Text);
        }
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text);
            if (comboBox2.Text == "ALL ITEMS")
            {
                prshblchbx.Enabled = false;
                batchdchbx.Enabled = false;
            }else
            {
                prshblchbx.Enabled = true;
                batchdchbx.Enabled = true;

            }
        }
        private void prshblchbx_CheckStateChanged(object sender, EventArgs e)
        {
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text);
        }
        private void batchdchbx_CheckStateChanged(object sender, EventArgs e)
        {
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            filtersearchbox(srchbox.Text); 
        }
    }
}
