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
    public partial class PurchaseOrderComponent : UserControl
    {
        public PurchaseOrderComponent()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }
        private void releaseLeaks(object sender,EventArgs e)
        {

        }

        private void CnclPOBTN_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseOrderComponent_Leave(object sender, EventArgs e)
        {
            pictureBox1.Click += null;
            pictureBox2.Click += null;
        }
    }
}
