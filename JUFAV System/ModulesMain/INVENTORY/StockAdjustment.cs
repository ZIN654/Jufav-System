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
    public partial class StockAdjustment : UserControl
    {
        public StockAdjustment()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            
        }
        public void releaseLeak()
        {
            //realase leake when this control is disposed
            CrtPOBTN.Click -= CrtPOBTN_Click;


        }

        private void CrtPOBTN_Click(object sender, EventArgs e)
        {

            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.Inventory.AddStockAdjustment cat1 = new ModulesSecond.Inventory.AddStockAdjustment();
            ResponsiveUI1.title = "AddStockAdjustment";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);

            // Components.StockAdjustmentsDatabox item1 = new Components.StockAdjustmentsDatabox();
            // ItemsBox.Controls.Add(item1);
        }

    }
}
