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
    public partial class StockAdjustment : UserControl
    {
        public StockAdjustment()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loadData();
        }
        public void releaseLeak()
        {
            //realase leake when this control is disposed
            CrtPOBTN.Click -= CrtPOBTN_Click;


        }
        private void loadData()
        {
            SQLiteCommand sq1 = new SQLiteCommand("SELECT * FROM STOCKADJUSTMENTS;", initd.scon);
            SQLiteDataReader sread1 = sq1.ExecuteReader();
            while (sread1.Read())
            {
                Components.StockAdjustmentsDatabox stck1 = new Components.StockAdjustmentsDatabox(sread1["DATEOFADJUSTMENT"].ToString(), sread1["PRODUCTNAME"].ToString(), sread1["ADJUSTMENTTYPE"].ToString(), Convert.ToInt32(sread1["PREVIOUSQUANTITY"]), Convert.ToInt32(sread1["ADJUSTEDQUANTITY"]), sread1["REASON"].ToString(), sread1["OTHERS"].ToString());
                ItemsBox.Controls.Add(stck1);
            }
            sread1.Close();
            sq1 = null;
            sread1 = null;
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
