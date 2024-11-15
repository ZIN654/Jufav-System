using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;

namespace JUFAV_System.Components
{
    public partial class SalesPaymentMethodOrderList : UserControl
    {
        int id1;
        
        public SalesPaymentMethodOrderList(string prodname1,int quantity1,int price,int id,int originalprice)
        {
            InitializeComponent();
           
            this.Dock = DockStyle.Top;
            id1 = id;
            label1.Text = originalprice.ToString();
            Prodname.Text = prodname1;
            quantity.Text = quantity1.ToString();
            Price.Text = price.ToString();
        }
      
    }
}
