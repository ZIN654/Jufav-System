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
        String Remarks1 = "";
        public StockAdjustmentsDatabox(String Date, String Prodname,String  Adjustmenttype,int previousquantity,int Adjustedquantity,String Reason,String Remarks)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label1.Text = Date;
            label2.Text = Prodname;
            label3.Text = Adjustmenttype;
            label4.Text = previousquantity.ToString();
            label5.Text = Adjustedquantity.ToString();
            label6.Text = Reason;
            Remarks1 = Remarks;
            if (Remarks == "")
            {
                viewRemarks.Visible = false;
            }
        }

        private void viewRemarks_Click(object sender, EventArgs e)
        {  
                Components.RemarksBox rm1 = new RemarksBox(Remarks1);
                this.Parent.Controls.Add(rm1);
                rm1.BringToFront();
                rm1.Location = new Point(viewRemarks.Location.X - 150,this.Location.Y);
        }
    }
}
