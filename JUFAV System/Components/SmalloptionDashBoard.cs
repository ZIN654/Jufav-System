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
    public partial class SmalloptionDashBoard : UserControl
    {
        public SmalloptionDashBoard()
        {
            InitializeComponent();
        }

        private void SmalloptionDashBoard_MouseLeave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SmalloptionDashBoard_Leave(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
