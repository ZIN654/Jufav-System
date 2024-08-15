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
    public partial class MarkUp : UserControl
    {
        public MarkUp()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public void releasemem()
        {
            addmkupBTN.Click -= addmkupBTN_Click;


        }

        private void addmkupBTN_Click(object sender, EventArgs e)
        {
            Components.MarkUpDatabox item1 = new Components.MarkUpDatabox();
            ItemsBox.Controls.Add(item1);
        }
    }
}
