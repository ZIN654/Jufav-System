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
    public partial class ProdListtDataBoxComponent : UserControl
    {
        private Size sz1 = new Size(0,0);
        private int ProdID1;
        public ProdListtDataBoxComponent(String Prodname,String Categpry,String SubCat,Double Quantity,String UOM,Double UniCost,Double MarkUp,bool isPerishable,String ExpiringDate,bool Isbatch,int ProdID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            if (Isbatch == true)
            {
                BATCPROD.Visible = true;
                dataGridView1.Visible = true;
                retrieveBatch(ProdID);

            }
            
            
            label1.Text = Prodname;
            label2.Text = Categpry;
            label3.Text = SubCat;
            label4.Text = Quantity.ToString();
            label5.Text = UOM;
            label6.Text = Convert.ToDouble(UniCost).ToString();
            label7.Text = Convert.ToDouble(MarkUp).ToString();
            label8.Text = isPerishable.ToString();
            label10.Text = Isbatch.ToString();
            ProdID1= ProdID;
            if (ExpiringDate == "01/12/1999")
            {
                label9.Text = "00/00/0000";
            }else
            {
                label9.Text = ExpiringDate;
            }
        }
        private void retrieveBatch(int BD)
        {

            //queries the table and insert it in the data grid view 217 79


        }

        private void BATCPROD_Click(object sender, EventArgs e)
        {
            if (this.Size.Height == 79)
            {
                sz1.Height = 217;
                this.Size = sz1;
            }
            else {
                sz1.Height = 79;
                this.Size = sz1;
            }
            
        }
    }
}
