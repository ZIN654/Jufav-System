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
        FileStream fs1;
        PDFViewer pdfviwer1;
        String path1;
        String path2s;
        public PdfFileViewer(String path,int summontype,String path2)
        {
            InitializeComponent();
            
            if (summontype == 0)
            {
                OPTIONS.Visible = false;
            }else
            {
                OPTIONS.Visible = true;
                path1 = path;
                path2s = path2;
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
                fs1 = new FileStream(path1,FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);
                pdfviwer1.Document = new Document(fs1);
               /// fs1.Unlock(0, 100);
                //fs1.Close();//prevents from beinng used

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
                MessageBox.Show(this,"Please Choose A printer to use In order to print the document","Select Printer",MessageBoxButtons.OK);
            }
            else
            {

                this.Cursor = Cursors.WaitCursor;
                //bug here the file is being used 
                var printer = new PDFtoPrinterPrinter();
                //prints the path in the app data
                printer.Print(new PrintingOptions(comboBox1.Text, path2s));
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

        private void PdfFileViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //realease memory
            fs1 = null;
            pdfviwer1 = null;
            this.Dispose();
           
        }
    }
}
