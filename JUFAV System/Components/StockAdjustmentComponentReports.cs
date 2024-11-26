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
    public partial class StockAdjustmentComponentReports : UserControl
    {
        String Adjustmentreason1;
        int ADJUSTMENTID;
        public StockAdjustmentComponentReports(String Productname,String Quantity,String Date,String Time,String AdjustmentType,String QuantityAdjusted,String Adjustmentreason,int ID)

        {
            InitializeComponent();
            ADJUSTMENTID = ID;
            Dock = DockStyle.Top;
            label1.Text = Productname;
            label2.Text = Quantity;
            label3.Text = Date;
            label4.Text = Time;
            label5.Text = AdjustmentType;
            label6.Text = QuantityAdjusted;
            Adjustmentreason1 = Adjustmentreason;
            //adjustment reason sa kabilang panel 
        }

        private void viewreason_Click(object sender, EventArgs e)
        {
            Components.RemarksBox rm1 = new RemarksBox(Adjustmentreason1);
            rm1.Controls.Find("remarks", true)[0].Text = "REASON : " + Adjustmentreason1;
            this.Parent.Controls.Add(rm1);
            rm1.BringToFront();
            rm1.Location = new Point(viewreason.Location.X - 100, this.Location.Y);
        }
    }
}
