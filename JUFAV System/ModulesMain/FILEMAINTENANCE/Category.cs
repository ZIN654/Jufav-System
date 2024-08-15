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
    public partial class Category : UserControl
    {
        public Category()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public void releaseMemory()
        {
            //invoke when this was disposed
            addCatBTN.Click -= addCatBTN_Click;


        }
        private void addCatBTN_Click(object sender, EventArgs e)
        {
            Components.CategoryComponent cat1 = new Components.CategoryComponent();
            ItemsBox.Controls.Add(cat1);

            //temporary

        }
    }
}
