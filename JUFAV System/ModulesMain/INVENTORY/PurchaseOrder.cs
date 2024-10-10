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

namespace JUFAV_System.ModulesMain.INVENTORY
{
    public partial class PurchaseOrder : UserControl
    {
        public PurchaseOrder()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Disposed += ondispose;
            STATUSHEADING.Text = "COMPLETED PURCHASE ORDER";
        }
        public void ReleaseLeaks()
        {
            CmpltBTN.Click -= CmpltBTN_Click;
            CnclBTN.Click -= CnclBTN_Click;
            PndBTN.Click -= PndBTN_Click;
            CrtPOBTN.Click -= CrtPOBTN_Click;
            srchBTN.Click -= srchBTN_Click;
        }

        private void CmpltBTN_Click(object sender, EventArgs e)
        {
            STATUSHEADING.Text = "COMPLETED PURCHASE ORDER";
        }

        private void CnclBTN_Click(object sender, EventArgs e)
        {
            STATUSHEADING.Text = "CANCELED PURCHASE ORDER";
        }

        private void PndBTN_Click(object sender, EventArgs e)
        {
            STATUSHEADING.Text = "PENDING PURCHASE ORDER";
        }

        private void CrtPOBTN_Click(object sender, EventArgs e)
        {
            //temporary 
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.Inventory.AddPurchaseOrder cat1 = new ModulesSecond.Inventory.AddPurchaseOrder();
            ResponsiveUI1.title = "AddPurchaseOrder";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
        }

        private void srchBTN_Click(object sender, EventArgs e)
        {

        }
        private void ondispose(object sender,EventArgs e)
        {
            ReleaseLeaks();
        }

    }
}
