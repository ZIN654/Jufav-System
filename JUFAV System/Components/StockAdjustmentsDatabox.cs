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
    public partial class StockAdjustmentsDatabox : UserControl
    {
        public StockAdjustmentsDatabox(String Date, String Prodname,String  Adjustmenttype,int previousquantity,int Adjustedquantity,String Reason)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label1.Text = Date;
            label2.Text = Prodname;
            label3.Text = Adjustmenttype;
            label4.Text = previousquantity.ToString();
            label5.Text = Adjustedquantity.ToString();
            label6.Text = Reason;
            

        }
    }
}
