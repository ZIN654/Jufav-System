using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;


namespace JUFAV_System.ModulesMain.INVENTORY
{
    public partial class PurchaseOrderReceive : UserControl
    {
        public PurchaseOrderReceive()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loddataPending();
        }
        public void releaseLeaks()
        {
            CmpltBTN.Click -= CmpltBTN_Click;
            toRcvBTN.Click -= toRcvBTN_Click;

        }
        private void loddataPending()
        {
            
            foreach (UserControl i in ItemsBox.Controls)
            {
                i.Dispose();
            }
            ItemsBox.Controls.Clear();
            GC.Collect();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PURCHASEORDER WHERE ORDERSTATUS = 'PENDING';", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //POID,USERID,ORDERDATE,EXPECTEDORDERDATE,SUPPLIER,TIMES,TOTALPRODUCTS,TOTALCOST,ORDERSTATUS
                Components.PurchaseOrderComponent ps1 = new Components.PurchaseOrderComponent(Convert.ToInt32(sread1["POID"]), sread1["ORDERDATE"].ToString(), sread1["SUPPLIER"].ToString(), sread1["TIMES"].ToString(), Convert.ToInt32(sread1["TOTALPRODUCTS"]), Convert.ToDouble(sread1["TOTALCOST"].ToString()), sread1["ORDERSTATUS"].ToString(), sread1["EXPECTEDORDERDATE"].ToString());
                ps1.Controls.Find("CnclPOBTN", true)[0].Text = "RECEIVE ORDERS";
                ps1.Controls.Find("CnclPOBTN", true)[0].Click -= ps1.CnclPOBTN_Click;
                ps1.Controls.Find("CnclPOBTN", true)[0].Click += ps1.receiveOrder;
                ItemsBox.Controls.Add(ps1);
                //pass PO ID sa component then pag initialize ng component sa ID dun mag eexecute ilolod ung data
                //dito load ng data
            }
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
