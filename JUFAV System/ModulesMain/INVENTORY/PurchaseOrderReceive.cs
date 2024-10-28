﻿using System;
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
            loddataPending(0);
        }
        public void releaseLeaks()
        {
            CmpltBTN.Click -= CmpltBTN_Click;
            toRcvBTN.Click -= toRcvBTN_Click;

        }
        private void loddataPending(int l)
        {
            string toload = "PENDING";
            if (l == 1){toload = "COMPLETED";}
            foreach (UserControl i in ItemsBox.Controls)
            {
                i.Dispose();
            }
            ItemsBox.Controls.Clear();
            GC.Collect();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PURCHASEORDER WHERE ORDERSTATUS = '"+toload+"';", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                //POID,USERID,ORDERDATE,EXPECTEDORDERDATE,SUPPLIER,TIMES,TOTALPRODUCTS,TOTALCOST,ORDERSTATUS
                Components.PurchaseOrderComponent ps1 = new Components.PurchaseOrderComponent(Convert.ToInt32(sread1["POID"]), sread1["ORDERDATE"].ToString(), sread1["SUPPLIER"].ToString(), sread1["TIMES"].ToString(), Convert.ToInt32(sread1["TOTALPRODUCTS"]), Convert.ToDouble(sread1["TOTALCOST"].ToString()), sread1["ORDERSTATUS"].ToString(), sread1["EXPECTEDORDERDATE"].ToString(),0);
                if (l == 1){ps1.Controls.Find("CnclPOBTN",true)[0].Visible = false;}
                ItemsBox.Controls.Add(ps1);
                //pass PO ID sa component then pag initialize ng component sa ID dun mag eexecute ilolod ung data
                //dito load ng data
            }
        }
        private void toRcvBTN_Click(object sender, EventArgs e)
        {
            loddataPending(0);
            STATUSHEADING.Text = "TO RECEIVE ORDERS";
        }
        private void CmpltBTN_Click(object sender, EventArgs e)
        {
            loddataPending(1);
            STATUSHEADING.Text = "COMPLETED ORDERS";
        }
       
    }
}
