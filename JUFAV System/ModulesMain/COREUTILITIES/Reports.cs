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

namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    public partial class Reports : UserControl
    {
       private int switch1 = 1;
       private int sizewidth = 234;
        public Reports()
        {
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
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
            ResponsiveUI1.asigntext("REPORTS");
            if (this.switch1 == 1)
            {
                //226
                this.Size = new Size(this.sizewidth, 380);
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
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.REPORTS.InventoryReports cat1 = new ModulesMain.REPORTS.InventoryReports();
            ResponsiveUI1.title = "InventoryReports";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
        }
        public void Sales_reports()
        {

        }
        public void Prod_List()
        {

        }
        public void Return_Orders()
        {

        }
        public void Financial_reports()
        {

        }
        public void top10most()
        {

        }
        public void top10Least()
        {

        }
        public void StockAdj()
        {

        }
        public void AudTrail()
        {

        }

        private void InvRprtBTN_Click(object sender, EventArgs e)
        {
            Inventory_reports();
        }
    }
}
