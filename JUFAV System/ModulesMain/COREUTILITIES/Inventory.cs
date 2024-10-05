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
    public partial class Inventory : UserControl
    {
        private int switch1 = 1;
        
        private Hashtable accountaccesslevel = new Hashtable();
        private int sizewidth = 234;
        public Inventory()
        {
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
            loadandinsertAccesslevel();
        }
        public void Addevents()
        {
            //INVENTORY
            InvBTN.Click += Inventory_Press;
            PoBTN.Click += Purchase_Order;
            poRBTN.Click += Purchase_Order_receive;
            StckAdjBTN.Click += Stock_Adjustments;
            ProdLstBTN.Click +=Product_list;
           

        }
        private void loadandinsertAccesslevel()
        {
            SQLiteCommand scom = new SQLiteCommand("SELECT SUBMODULENAME,HASACCESS FROM SUBMODULES WHERE USERID = " + initd.UserID + ";", initd.scon);
            SQLiteDataReader sq1 = scom.ExecuteReader();
            while (sq1.Read())
            {
                accountaccesslevel.Add(sq1["SUBMODULENAME"], sq1["HASACCESS"]);
            }
            sq1.Close();
        }
        //===================================DEFINE YOUR METHOD HERE===========================================
        //FOR EACH BUTTON  CLICKS 
        public void InventorySwtich()
        {
            ResponsiveUI1.asigntext("INVENTORY");
         
            if (Convert.ToInt32(accountaccesslevel["PurchOrde"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.INVENTORY.PurchaseOrder US1 = new ModulesMain.INVENTORY.PurchaseOrder();
                ResponsiveUI1.title = "PurchaseOrder";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(US1);


            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
          

            if (switch1 == 1)
            {
                //226
                this.Size = new Size(sizewidth, 190);
                switch1 = 0;
            }
            else
            {
                //36
                this.Size = new Size(sizewidth, 38);
                switch1 = 1;
            }
        }
        private void Inventory_Press(object sender,EventArgs e)
        {
            InventorySwtich();
        }
        private void Purchase_Order(object sender,EventArgs e)
        {
            if (ResponsiveUI1.spl1.Controls.Contains(new ModulesMain.INVENTORY.PurchaseOrder()))
            {
                Console.WriteLine("this object was exist instantiating it might lead to memory ");
            }
            else
            {
                if (Convert.ToInt32(accountaccesslevel["PurchOrde"]) == 1)
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    ResponsiveUI1.title = "PurchaseOrder";
                    ModulesMain.INVENTORY.PurchaseOrder prchOrder = new ModulesMain.INVENTORY.PurchaseOrder();
                    ResponsiveUI1.spl1.Controls.Add(prchOrder);
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();

                }
                else
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    Components.AccessDenied as1 = new Components.AccessDenied();
                    ResponsiveUI1.title = "AccessDenied";
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                    ResponsiveUI1.spl1.Controls.Add(as1);
                }


            }
          
           
        }
        private void Purchase_Order_receive(object sender,EventArgs e)
        {
            //get names of columns
            if (Convert.ToInt32(accountaccesslevel["PurchOrdRec"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ResponsiveUI1.title = "PurchaseOrderReceive";
                ModulesMain.INVENTORY.PurchaseOrderReceive prchOrderrec = new ModulesMain.INVENTORY.PurchaseOrderReceive();
                ResponsiveUI1.spl1.Controls.Add(prchOrderrec);
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
           
        }
        private void Stock_Adjustments(object sender,EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["StckAdj"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ResponsiveUI1.title = "StockAdjustment";
                ModulesMain.INVENTORY.StockAdjustment stockadjustments = new ModulesMain.INVENTORY.StockAdjustment();
                ResponsiveUI1.spl1.Controls.Add(stockadjustments);
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
          
        }
        private void Product_list(object sender,EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["ProdList"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ResponsiveUI1.title = "ProductList";
                ModulesMain.INVENTORY.ProductList prdlist = new ModulesMain.INVENTORY.ProductList();
                ResponsiveUI1.spl1.Controls.Add(prdlist);
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
           
           
        }
    }
}
