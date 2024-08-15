using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.ModulesMain.INVENTORY
{
    public partial class PurchaseOrderReceive : UserControl
    {
        public PurchaseOrderReceive()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loaditems();
        }
        public void releaseLeaks()
        {
            CmpltBTN.Click -= CmpltBTN_Click;
            toRcvBTN.Click -= toRcvBTN_Click;

        }
        private void toRcvBTN_Click(object sender, EventArgs e)
        {

        }

        private void CmpltBTN_Click(object sender, EventArgs e)
        {

        }
        public void loaditems()
        {
            //database open load 
            //use for loop to insert items while reading in the database


        }
    }
}
