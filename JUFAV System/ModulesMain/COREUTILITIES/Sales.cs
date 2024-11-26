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
    public partial class Sales : UserControl
    {
        private int switch1 = 1;
        private int sizewidth = 234;
        private Hashtable accountaccesslevel = new Hashtable();
        public Sales()
        {
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
            loadandinsertAccesslevel();
        }
        public void Addevents()
        {
            //use static variables for allocation
            SalesPanelBTN.Click += SalesMain;
            //when this clicked the user setting will appear this is just an divider
            SalesBTN.Click += (sender, e) =>
            {
                sales1();


            };
        }
        public void releaseleaks()
        {
            SalesPanelBTN.Click -= SalesMain;


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
        }
        //=============================================METHODS CLICK============================
        public void sales1()
        {
            this.Cursor = Cursors.WaitCursor;
            ResponsiveUI1.asigntext("SALES");
            if (Convert.ToInt32(accountaccesslevel["Saleschbx"]) == 1) 
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.SALES.SALES sales = new ModulesMain.SALES.SALES();
                ResponsiveUI1.title = "SALES";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(sales);


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
            ResponsiveUI1.asigntext("SALES");
            if (switch1 == 1)
            {
                //226
                this.Size = new Size(sizewidth, 114);
                switch1 = 0;
            }
            else
            {
                //36
                this.Size = new Size(sizewidth, 38);
                switch1 = 1;
            }
            GC.Collect();
            this.Cursor = Cursors.Default;
        }

        private void SalesMain(object sender,EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (ResponsiveUI1.spl1.Controls.Contains(new ModulesMain.FILEMAINTENANCE.UserSettings()))
            {
                GC.Collect();
            }
            else
            {
                if (Convert.ToInt32(accountaccesslevel["Saleschbx"]) == 1)
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    ResponsiveUI1.title = "SALES";
                    ModulesMain.SALES.SALES sales = new ModulesMain.SALES.SALES();
                    ResponsiveUI1.spl1.Controls.Add(sales);
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();


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
            this.Cursor = Cursors.Default;
        }
        public void ReservedProd()
        {
            if (Convert.ToInt32(accountaccesslevel["ResprodChbox"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.SALES.ReservedProducts RP = new ModulesMain.SALES.ReservedProducts();
                ResponsiveUI1.title = RP.Name.ToUpper();
                ResponsiveUI1.title2 ="RESERVED PRODUCTS";
                ResponsiveUI1.spl1.Controls.Add(RP);
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
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

        private void RprodBTN_Click(object sender, EventArgs e)
        {
            ReservedProd();
        }
    }
    }


