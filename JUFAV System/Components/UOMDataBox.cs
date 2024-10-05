using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUFAV_System.dll;

namespace JUFAV_System.Components
{
    public partial class UOMDataBox : UserControl
    {
        int ID1;
        public UOMDataBox(String KG, String Abbreviation, int ID)
        {
            InitializeComponent();
            ID1 = ID;
            this.Dock = DockStyle.Top;
            Abbreviationlbl.Text = KG;
            Unitofmelbl.Text = Abbreviation;

        }

        private void editbut_Click(object sender, EventArgs e)
        {
           //0for edit  1 for default
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure sup1 = new ModulesSecond.FileMaintenance.UnitOfMeasure.AddUnitOfMeasure(0, ID1);
            sup1.Name = "editunitofmeasures";
            ResponsiveUI1.title = "editunitofmeasures";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            //archive 
        }

        private void UOMDataBox_Leave(object sender, EventArgs e)
        {
            editbut.Click += null;
            deletebtn.Click += null;

        }
    }
}
