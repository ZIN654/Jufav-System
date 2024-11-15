using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using JUFAV_System.dll;
using System.Data.SqlClient;
//EMAIL SMTP LIBS
using System.Net.Mail;
using System.Net;
//network detection
using System.Net.NetworkInformation;
using System.Globalization;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel.Shapes;
using JUFAV_System.dll;






using System.Data.SQLite;


namespace JUFAV_System
{
    public partial class SANDBOX : Form
    {
        public static String[] users = {"admin1","admin2","admin3","admin4","admin5","admin6","admin7","admin8","admin9","admin10","admin11","admin12","admin13","admin14","admin15","admin16","admin17","admin18","admin19","admin20","admin21","admin22","admin23","admin24"};
        public static int lastcount;
        public static int loopset = 0;//kung saan mag iistart ulet yung loop
        public static int current = 0;//kung saan last tumigil yung loop
        public static int countlimit = 10;
        //networking

       

        //check length /record the index start count if 10 na yung item record mo kung saang index so we can read it based on that gaya ng starting point 0
        //ang starting point ay 0 then ang show count ay 10  
        public SANDBOX()
        {
            InitializeComponent();

          //  algos1.
            // set();
            // Thread.Sleep(1500);
            // set();
            // Thread.Sleep(1500);
            // set();
           // loaddata();

        }
        public void loaddata()
        {
         
        }
        public void set()
        {
            //for changing array starting point to read
          //  LastIndex.Text = users.Length.ToString();


            //before loop begins musst check kung yung natirang last part ay equally or greater 10
            //if not set the last ammount to  the count limit to avoid exception
            //but kung greater set to 10
            // int check = lastcount - users.Length;

            Console.WriteLine("LAST COUNT :" + lastcount + "   " + "LOOP SET: " + loopset + "   " + "COUNT LIMIT " + countlimit + "    " + "CURRENT" + current);
            for (int i = loopset;i != countlimit;i++)
            {
                Console.WriteLine("DISPLAYING DATA 10 Entry Data : " + users[i]);
                lastcount = i;
            }
          
            current = users.Length - lastcount;//ilan nalng ang natitira 10
           // Console.WriteLine("nasaanoart na ? :" + lastcount);//9

            loopset = lastcount ;//iseset nito kung saan sya mag iistart 

            //check sa natitira
            int check =  users.Length -lastcount ;
            if (check > 10)
            {
                countlimit += 10;
            }
            else
            {
                countlimit += check - 1;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //salt
            //hash algorithm
         //implement hashing algorithm using SHA-256 with salting technique
            // finds any non word character \\W
            //finds any space white character \\S
            /*
            if (Regex.IsMatch(textBox1.Text,"\\W\\S")){
                MessageBox.Show("FIND ONE");



            }
            else
            {

                MessageBox.Show("FIND NOT ONE");

            }
            */
        }
        private void detectNet()
        {
           
            String hostnam = Dns.GetHostName().ToString();
            String ip = Dns.GetHostByName(hostnam).AddressList[0].ToString();
            if ("127.0.0.1" == ip){
                MessageBox.Show(this, "PLEASE CONNECT TO INTERNET AND TRY AGAIN", "INTERNET CONNECTION", MessageBoxButtons.OK); }
            else {
                //sendemail();
                MessageBox.Show(this, "NETWORK IS AVAILABLE SENDING EMAIL", "INTERNET CONNECTION", MessageBoxButtons.OK);
            }
            hostnam = null;
            ip = null; 
        }
        private void sendemail()
        {
            //email sending test study
            string fromMail = "";
            string frompassword = "";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "TEST SUBJECT";
            message.To.Add(new MailAddress("RECEIVERGMAIL"));
            message.Body = "<html><body>TEST BODY</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                //another way to setup the properties of a class.librariy
                Port = 587,
                Credentials = new NetworkCredential(fromMail,frompassword),
                EnableSsl = true,

            };
            //sends the message
            smtpClient.Send(message);
          
        }


        public int[] sample = new int[23];
        
        private void button1_Click(object sender, EventArgs e)
        {
            //String[] sam1 = { "sample1","gunpla","sample","Tarlac"};
            //String[] sam2 = { "sample2","matrx", "sm" };
            // label1.Text=;

            //Console.WriteLine(algos1.determinewhichpart(sam1,new String[] { "sample","gunpla2", "s2m" },2));
            // algos1.DetectInputifDupplicate(sam1,0);
            // detectNet();
            //   Components.SalesPaymentMethodOrderList sample = new Components.SalesPaymentMethodOrderList("SAMPLE");
            // panel1.Controls.Add(sample);
            Document document = new Document();
            topdetail(document);
           
           



            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false,PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string filename = "C://Users//asus//Desktop//00//DONE//HelloWorld3.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            

            // label1.Text = DateTime.Parse("26/11/2025").ToShortDateString();
            //Console.WriteLine(algos1.determineifidentical(EMAIL.Text,MESSAGE.Text));




        }
        private void topdetail(Document document )
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
            
            
            MIddetail(document,section);
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
           

            FormattedText fs = row.Cells[0].AddParagraph().AddFormattedText("PURCHASE ORDER #P-043242",TextFormat.Bold);
            row.Cells[0].Shading.Color =Color.FromRgb(12, 27, 52);
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

            middledet(document,section2);

        }
        private void middledet(Document doc,Section sec)
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
            Last(doc,sec);
        }
        private void Last(Document doc1,Section sc1)
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

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }
    }
}
