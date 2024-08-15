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
    public partial class Inventory : UserControl
    {
        private int switch1 = 1;
        private int sizewidth = 234;
        public Inventory()
        {
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
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
        //===================================DEFINE YOUR METHOD HERE===========================================
        //FOR EACH BUTTON  CLICKS 
        public void InventorySwtich()
        {
            ResponsiveUI1.asigntext("INVENTORY");

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
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ResponsiveUI1.title = "PurchaseOrder";
            ModulesMain.INVENTORY.PurchaseOrder prchOrder = new ModulesMain.INVENTORY.PurchaseOrder();
            ResponsiveUI1.spl1.Controls.Add(prchOrder);
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
           
        }
        private void Purchase_Order_receive(object sender,EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ResponsiveUI1.title = "PurchaseOrderReceive";
            ModulesMain.INVENTORY.PurchaseOrderReceive prchOrderrec = new ModulesMain.INVENTORY.PurchaseOrderReceive();
            ResponsiveUI1.spl1.Controls.Add(prchOrderrec);
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
        }
        private void Stock_Adjustments(object sender,EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ResponsiveUI1.title = "StockAdjustment";
            ModulesMain.INVENTORY.StockAdjustment stockadjustments = new ModulesMain.INVENTORY.StockAdjustment();
            ResponsiveUI1.spl1.Controls.Add(stockadjustments);
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
        }
        private void Product_list(object sender,EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title,false)[0].Dispose();
            ResponsiveUI1.title = "ProductList";
            ModulesMain.INVENTORY.ProductList prdlist = new ModulesMain.INVENTORY.ProductList();
            ResponsiveUI1.spl1.Controls.Add(prdlist);
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
           
        }
    }
}
