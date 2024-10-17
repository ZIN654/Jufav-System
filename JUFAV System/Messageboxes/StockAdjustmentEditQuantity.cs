using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;
namespace JUFAV_System.Messageboxes
{
    public partial class StockAdjustmentEditQuantity : Form
    {
        int ProductID1 = 0;//to use when Updating // to place later :
        public StockAdjustmentEditQuantity(String Name, double quantity, String Category, String SubCategory,bool isperishable,String Uom, int ProductID)
        {
            InitializeComponent();
            ProductID1 = ProductID;
            if (isperishable == false)
            {
                EXPIRED.Enabled = false;
            }
            else
            {
                EXPIRED.Enabled = true;
            }
        }
        
        private void UpdateDatabase()
        {
            SQLiteCommand scom1 = new SQLiteCommand("UPDATE PRODUCTS SET  ",initd.scon);
            scom1.ExecuteNonQuery();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void CANCELbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
