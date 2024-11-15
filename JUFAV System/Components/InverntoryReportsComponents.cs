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
    public partial class InverntoryReportsComponents : UserControl
    {
        public InverntoryReportsComponents(string ProductName, double RemainingStock, double ReorderPoint, double OrderQuantity, String UnitofMeasurement)
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;

            label1.Text = ProductName;
            label2.Text = RemainingStock.ToString();
            label3.Text = ReorderPoint.ToString();
            label4.Text = OrderQuantity.ToString();
            label5.Text = UnitofMeasurement;
  
        }
    }
}
