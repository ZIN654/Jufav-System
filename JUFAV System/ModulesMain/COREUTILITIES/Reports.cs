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
using System.Collections;
using System.Data.SQLite;

namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    public partial class Reports : UserControl
    {
       private int switch1 = 1;
       private int sizewidth = 234;
        private Hashtable accountaccesslevel = new Hashtable();
        public Reports()
        {
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
            loadandinsertAccesslevel();
        }
        private void loadandinsertAccesslevel()
        {
            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUBMODULENAME,HASACCESS FROM SUBMODULES WHERE USERID = " + initd.UserID + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom.ExecuteReader();
            while (sq1.Read())
            {
                accountaccesslevel.Add(sq1["SUBMODULENAME"], sq1["HASACCESS"]);
            }
            sq1.Close();
            sq1 = null;
            scom = null;
        }
        public void Addevents()
        {
            //use static variables for allocation
           
            //when this clicked the user setting will appear this is just an divider
            RprtBTN.Click += (sender, e) =>{ Reports1(); };

        }

        //================================================METHODS ============================
        public void Reports1()
        {
            if (Convert.ToInt32(accountaccesslevel["stcwhchbx"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.REPORTS.InventoryReports cat1 = new ModulesMain.REPORTS.InventoryReports();
                ResponsiveUI1.title = "InventoryReports";
                ResponsiveUI1.title2 = "Inventory Reports";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
            ResponsiveUI1.asigntext("INVETORY REPORTS");
            if (this.switch1 == 1)
            {
                //226
                this.Size = new Size(this.sizewidth, 228);
                this.switch1 = 0;
            }
            else
            {
                //36
                this.Size = new Size(this.sizewidth, 38);
                switch1 = 1;
            }
            GC.Collect();



        }

        public void Inventory_reports()
        {
            if (ResponsiveUI1.spl1.Controls.Contains(new ModulesMain.REPORTS.InventoryReports()))
            {
                Console.WriteLine("this object was exist instantiating it might lead to memory ");
            }
            else
            {
                if (Convert.ToInt32(accountaccesslevel["stcwhchbx"]) == 1)
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    ModulesMain.REPORTS.InventoryReports cat1 = new ModulesMain.REPORTS.InventoryReports();
                    ResponsiveUI1.title = "InventoryReports";
                    ResponsiveUI1.title2 = "Inventory Reports";
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                    ResponsiveUI1.spl1.Controls.Add(cat1);

                }
                else
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    Components.AccessDenied as1 = new Components.AccessDenied();
                    ResponsiveUI1.title = "AccessDenied";
                    ResponsiveUI1.title2 = "Access Denied";
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                    ResponsiveUI1.spl1.Controls.Add(as1);
                }


            }


          
        }
        public void Sales_reports()
        {
            if (Convert.ToInt32(accountaccesslevel["SalsRprChbox"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.REPORTS.SalesReports cat1 = new ModulesMain.REPORTS.SalesReports();
                ResponsiveUI1.title = "SalesReports";
                ResponsiveUI1.title2 = "Sales Reports";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);
            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
          
        }
       
        public void Return_Orders()
        {
            if (Convert.ToInt32(accountaccesslevel["rtrnChbx"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.REPORTS.ReturnOrdersReports cat1 = new ModulesMain.REPORTS.ReturnOrdersReports();
                ResponsiveUI1.title = "ReturnOrdersReports";
                ResponsiveUI1.title2 = "Return Orders Reports";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);
            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
        }
     
        public void top10most()
        {

        }
        public void top10Least()
        {

        }
        public void StockAdj()
        {
            if (Convert.ToInt32(accountaccesslevel["StckAdjuChkbx"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.REPORTS.StockAdjustmentsReports cat1 = new ModulesMain.REPORTS.StockAdjustmentsReports();
                ResponsiveUI1.title = "StockAdjustmentsReports";
                ResponsiveUI1.title2 = "Stock Adjustments Reports";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);
            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
        }
        public void AudTrail()
        {
            if (Convert.ToInt32(accountaccesslevel["audTChbx"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.REPORTS.AuditTrailReports cat1 = new ModulesMain.REPORTS.AuditTrailReports();
                ResponsiveUI1.title = "AuditTrailReports";
                ResponsiveUI1.title2 = "Audit Trail Reports";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);
            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
        }

        private void InvRprtBTN_Click(object sender, EventArgs e)
        {
            Inventory_reports();
        }

        private void SlsRprtBTN_Click(object sender, EventArgs e)
        {
            Sales_reports();
        }

        private void AdtTrlBTN_Click(object sender, EventArgs e)
        {
            AudTrail();
        }

        private void StckAdjBTN_Click(object sender, EventArgs e)
        {
            StockAdj();
        }

      

        private void RtrnBTN_Click(object sender, EventArgs e)
        {
            Return_Orders();
        }
    }
}
