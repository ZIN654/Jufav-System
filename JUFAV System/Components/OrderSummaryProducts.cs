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
    public partial class OrderSummaryProducts : UserControl
    {
        public OrderSummaryProducts(String Productname,int Quantity,Double total)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label1.Text = Productname;
            label2.Text = Quantity.ToString();
            label3.Text = total.ToString();
        }
    }
}
