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
    public partial class RemarksBox : UserControl
    {
        public RemarksBox(string message)
        {
            InitializeComponent();
            remarks.Text = "OTHERS : " + message;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }
    }
}
