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
    public partial class BatchDataBox : UserControl
    {
     
        int queryID1;
        public BatchDataBox(String Prodname,String BatchNo,String Date,int Quantity,int queryID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            Productname.Text = Prodname;
            label2.Text = BatchNo;
            label3.Text = Date;
            label4.Text = Quantity.ToString();
            queryID1 = queryID;
        }

        private void DeltebTN_Click(object sender, EventArgs e)
        {
            //initd.querybatch.remove(queryID1]);
            this.Dispose();
        }
    }
}
