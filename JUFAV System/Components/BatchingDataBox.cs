using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.Components
{
    public partial class BatchingDataBox : UserControl
    {
        
        public BatchingDataBox(String prodName,String batchNo,String Date,int Quantity)
        {

            InitializeComponent();
            this.Dock = DockStyle.Top;
            label1.Text = prodName;
            label2.Text = batchNo;
            label3.Text = Date;
            label4.Text = Quantity.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
