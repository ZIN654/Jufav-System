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
using System.Data.SQLite;

namespace JUFAV_System.ModulesMain.INVENTORY
{
    public partial class PurchaseOrder : UserControl
    {
        public PurchaseOrder()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Disposed += ondispose;
            STATUSHEADING.Text = "PENDING PURCHASE ORDER";
            loddataPending();
          
        }
        public void ReleaseLeaks()
        {
           
           
            CrtPOBTN.Click -= CrtPOBTN_Click;
            srchBTN.Click -= srchBTN_Click;
        }
        private void loddataPending(int type = 0)
        {
            String type1="PENDING";
            if(type == 1) {type1= "CANCELLED"; }
            foreach (UserControl i in ItemsBox.Controls)
            {
                i.Dispose();
            }
            ItemsBox.Controls.Clear();
            GC.Collect();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PURCHASEORDER WHERE ORDERSTATUS = '"+type1+"';", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //POID,USERID,ORDERDATE,EXPECTEDORDERDATE,SUPPLIER,TIMES,TOTALPRODUCTS,TOTALCOST,ORDERSTATUS
                Components.PurchaseOrderComponent ps1 = new Components.PurchaseOrderComponent(Convert.ToInt32(sread1["POID"]),sread1["ORDERDATE"].ToString(), sread1["SUPPLIER"].ToString(), sread1["TIMES"].ToString(),Convert.ToInt32(sread1["TOTALPRODUCTS"]), Convert.ToDouble(sread1["TOTALCOST"].ToString()), sread1["ORDERSTATUS"].ToString(), sread1["EXPECTEDORDERDATE"].ToString(),1);
                ItemsBox.Controls.Add(ps1);
                //pass PO ID sa component then pag initialize ng component sa ID dun mag eexecute ilolod ung data
                //dito load ng data
            }
        }
      
        private void CrtPOBTN_Click(object sender, EventArgs e)
        {
    
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

        private void CANCELED_PO_CheckedChanged(object sender, EventArgs e)
        {
            STATUSHEADING.Text = "CANCELED PURCHASE ORDER";
            loddataPending(1);
        }

        private void PENDING_PO_CheckedChanged(object sender, EventArgs e)
        {
            STATUSHEADING.Text = "PENDING PURCHASE ORDER";
            loddataPending(0);
        }
    }
}
