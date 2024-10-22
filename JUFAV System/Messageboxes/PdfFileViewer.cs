using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apitron.PDF.Controls;
using Apitron.PDF.Rasterizer;
using System.IO;
using System.Drawing.Printing;
using PDFtoPrinter;
using JUFAV_System.Properties;
using System.ServiceProcess;

namespace JUFAV_System.Messageboxes
{
    public partial class PdfFileViewer : Form
    {
       
        PDFViewer pdfviwer1;
        String path1;
        public PdfFileViewer(String path,int summontype)
        {
            InitializeComponent();
            
            if (summontype == 0)
            {
                OPTIONS.Visible = false;
            }else
            {
                OPTIONS.Visible = true;
                path1 = path;
                fetchprinters();

            }
            loadBox(path);
        }
        private void loadBox(String path1)
        {
            pdfviwer1 = new PDFViewer();
            pdfviwer1.Enabled = true;
            pdfviwer1.Visible = true;
            pdfviwer1.Dock = DockStyle.Fill;
           
            this.Controls.Add(pdfviwer1);
            pdfviwer1.BringToFront();
            try
            {
                FileStream fs1 = new FileStream(path1,FileMode.Open);
                pdfviwer1.Document = new Document(fs1);


            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("Pdf does not exist");


            }


        }
        private void printPDf()
        {
            //if the specified printer is non message bo will appear  and if printer is not active messag box will appear
            if (comboBox1.Text == "")
            {
                MessageBox.Show(this,"Please Choose A printer to use In order to print the document","Select Printer",MessageBoxButtons.YesNo);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                //bug here the file is being used 
                var printer = new PDFtoPrinterPrinter();
                printer.Print(new PrintingOptions(comboBox1.Text, path1));
                this.Cursor = Cursors.Default;


            }

        }
        private void fetchprinters()
        {
            try { 
            foreach (String printers in PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(printers);
            }
                }catch (Exception e)
            {
               MessageBox.Show("Spooler is not active. Please try again later OR manually start the Print Spooler in Services");
               
                    //Occurs when "Print Spooler" is not active or running

                    //ServiceController spoolerrun = new ServiceController("Spooler",SystemInformation.UserName.ToString());
                   // spoolerrun.Start();
            }
            

        }
        private void Print_Click(object sender, EventArgs e)
        {
            printPDf();
        }
    }
}
