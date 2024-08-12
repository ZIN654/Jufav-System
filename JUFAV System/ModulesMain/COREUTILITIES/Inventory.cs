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
            InvBTN.Click += (sender,e) => { Inventory_Press(); };
            PoBTN.Click += (sender, e) => { Purchase_Order(); };
            poRBTN.Click += (sender, e) => { Purchase_Order_receive(); };
            StckAdjBTN.Click += (sender, e) => { Stock_Adjustments(); };
            ProdLstBTN.Click += (sender, e) => { Product_list(); };
           

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
        public void Inventory_Press()
        {
            InventorySwtich();
        }
        public void Purchase_Order()
        {
            
        }
        public  void Purchase_Order_receive()
        {

        }
        public void Stock_Adjustments()
        {

        }
        public void Product_list()
        {

        }
    }
}
