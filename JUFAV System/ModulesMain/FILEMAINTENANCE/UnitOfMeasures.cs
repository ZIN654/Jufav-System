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
    public partial class UnitOfMeasures : UserControl
    {
        public UnitOfMeasures()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevents();

        }
        public void addevents()
        {
            addUoMBTN.Click += AddnewUoM;

        }
        private void AddnewUoM(object sender,EventArgs e)
        {
           // data box must have parameters  Components.UOMDataBox data = new Components.UOMDataBox(String KG,String Abbreviation);
           //its usable for data box array and insert using loop such as kgvalue[i] "i" loop 
            Components.UOMDataBox data = new Components.UOMDataBox();
            ItemsBox.Controls.Add(data);

        }
        //when the entry count was changed the items will lod also 
        
    }
}
