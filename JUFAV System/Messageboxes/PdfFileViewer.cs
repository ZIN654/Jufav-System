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
            var printer = new PDFtoPrinterPrinter();
            printer.Print(new PrintingOptions(comboBox1.Text,path1));

        }
        private void fetchprinters()
        {
            foreach (String printers in PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(printers);

            }


        }
        private void Print_Click(object sender, EventArgs e)
        {
            printPDf();
        }
    }
}
