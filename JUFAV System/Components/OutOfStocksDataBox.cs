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
    public partial class OutOfStocksDataBox : UserControl
    {
        public OutOfStocksDataBox(String ProdName,int Quantity)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label1.Text = ProdName;
            label2.Text = Quantity.ToString();
        }
    }
}
