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
    public partial class DataBox : UserControl
    {
        public DataBox()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            addevents();
        }
        public void addevents()
        {
            deletebtn.Click += deleteBTNClick;

        }
        private void deleteBTNClick(object sender,EventArgs e)
        {
            //here items from database must be delete
            this.Dispose();

        }
    }
}
