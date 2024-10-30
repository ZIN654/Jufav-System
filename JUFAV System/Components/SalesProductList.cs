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
    public partial class SalesProductList : UserControl
    {
        int prodid1;
        public SalesProductList(String Productname,int quantity,String  UnitOfMeasure,String Price,int ProdID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            prodid1 = ProdID;
            label1.Text = Productname;
            label2.Text = quantity.ToString();
            label3.Text = UnitOfMeasure;
            label4.Text = Price.ToString();
        }
    }
}
