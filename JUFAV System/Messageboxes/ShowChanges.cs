using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.Messageboxes
{
    public partial class ShowChanges : Form
    {
        Action toexe1;
        int saleID1;
        public ShowChanges(double changes,Action toexe,int saleID)
        {
            InitializeComponent();
            saleID1 = saleID;
            double removedecimals = Convert.ToDouble(changes);
            label2.Text = removedecimals.ToString() + "₱";
            toexe1 = toexe;
        }

        private void CONFRIMBTN_Click(object sender, EventArgs e)
        {
           
            Messageboxes.ORdersum.OrderSummary ordersum1 = new ORdersum.OrderSummary(saleID1,toexe1,this.Close);
            ordersum1.ShowDialog();
            
        }
    }
}
