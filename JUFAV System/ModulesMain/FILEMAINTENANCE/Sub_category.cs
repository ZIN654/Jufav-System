using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class Sub_category : UserControl
    {
        public Sub_category()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public void releaseMem()
        {
            addSubCatBTN.Click -= addSubCatBTN_Click;
            srchBTN.Click -= srchBTN_Click;


        }
        private void addSubCatBTN_Click(object sender, EventArgs e)
        {
            Components.Sub_Category item1 = new Components.Sub_Category();
            ItemsBox.Controls.Add(item1);
        }

        private void srchBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
