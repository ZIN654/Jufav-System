using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.dll;
namespace JUFAV_System.Components
{
    public partial class SupplierComponentAddprod : UserControl
    {
        int QueryID;
        public SupplierComponentAddprod(String Compname,String ConPer,String ConNum,String ConAdd,int queryID1,int summonmode)
        {
            //if summon mode EDIT tangal rekta sa query
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label1.Text = Compname;
            label2.Text = ConPer;
            label3.Text = ConNum;
            label4.Text = ConAdd;
            QueryID = queryID1;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            this.Dispose();
            initd.QueryIDsProd.Remove(QueryID);
            //removes itslef froom querybank also
        }
    }
}
