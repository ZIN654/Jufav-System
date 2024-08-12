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
    public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevent();
        }
        public void addevent()
        {

            addprdBTN.Click += addprod;


        }
        private void addprod(object sender,EventArgs e)
        {
            Components.ProductComponent item1 = new Components.ProductComponent();
            ItemsBox.Controls.Add(item1);

            
        }
    }
}
