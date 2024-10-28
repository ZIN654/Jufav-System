using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.Components
{
    public partial class SelectProductToAdjustDataBox : UserControl
    {
        int ProductID;
        string cat;
        string subcat;
        bool pershable;
        public SelectProductToAdjustDataBox(String name,double Quantity,String Category,String Subcategory,bool isperishable,String UoM,int ProdID)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            ProductID = ProdID;//to use for adjusting
            label1.Text = name;
            label2.Text = Quantity.ToString();
            label3.Text = UoM;
            cat = Category;
            subcat = Subcategory;
            pershable = isperishable;


        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            //edits the item quantity
            //records each adjustments to a table records
            changescence();
        }
        private void changescence()
        {

           Messageboxes.StockAdjustmentEditQuantity as1 = new Messageboxes.StockAdjustmentEditQuantity(label1.Text,Convert.ToDouble(label2.Text),cat,subcat,pershable,label3.Text,ProductID);
           as1.ShowDialog(this);
        }
    }
}
