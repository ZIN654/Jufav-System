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
        public SelectProductToAdjustDataBox(String name,double Quantity,String UoM,int ProdID)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            ProductID = ProdID;//to use for adjusting
            label1.Text = name;
            label2.Text = Quantity.ToString();
            label3.Text = UoM;

        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            //edits the item quantity
            //records each adjustments to a table records
            changescence();
        }
        private void changescence()
        {
            Messageboxes.StockAdjustmentEditQuantity as1 = new Messageboxes.StockAdjustmentEditQuantity();
            as1.ShowDialog(this);
        }
    }
}
