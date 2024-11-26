using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Apitron.PDF.Rasterizer;
using PDFtoPrinter;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apitron.PDF.Controls;

namespace JUFAV_System.Messageboxes
{
 
    public partial class SalesPrintreceipt2 : Form
    {
        System.IO.FileStream fs1;
        PDFViewer pdfviwer1;
        public SalesPrintreceipt2(String path2)
        {
            InitializeComponent();
            createprinter(path2);
        }
        private void createprinter(String path1)
        {
            pdfviwer1 = new PDFViewer();
            pdfviwer1.Enabled = true;
            pdfviwer1.Visible = true;
            pdfviwer1.Dock = DockStyle.Fill;

            controlprinterview.Controls.Add(pdfviwer1);
            pdfviwer1.BringToFront();
            try
            {
                fs1 = new FileStream(path1, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                pdfviwer1.Document = new Document(fs1);
                /// fs1.Unlock(0, 100);
                //fs1.Close();//prevents from beinng used

            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("Pdf does not exist");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
