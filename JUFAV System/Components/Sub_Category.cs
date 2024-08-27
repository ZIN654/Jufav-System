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
    public partial class Sub_Category : UserControl
    {
        public Sub_Category(String Subcatname,object Catname,String markup)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label5.Text = Subcatname;
            label6.Text = Catname.ToString();
            label7.Text = markup;
        }

    }
}
