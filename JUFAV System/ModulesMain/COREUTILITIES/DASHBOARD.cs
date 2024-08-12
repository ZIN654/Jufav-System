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

namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    public partial class DASHBOARD : UserControl
    {
        private Label TitleHeading1;
        public DASHBOARD(Label TitleHeading)
        {
            this.TitleHeading1 = TitleHeading;
            InitializeComponent();
            addevent();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
            //this.Controls.SetChildIndex(this, 0);
        }
        public void addevent()
        {
            DasBTN.Click += DasBTNClick;
            //this.ControlRemoved



        }
        
        private void DasBTNClick(object sender,EventArgs e)
        {
            this.TitleHeading1.Text = "DASHBOARD";
            //deletion and set title for idnetifirer to delete
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title,false)[0].Dispose();
            ResponsiveUI1.title = "DASHBOARD";


           ModulesMain.DASHBOARD dash = new ModulesMain.DASHBOARD();
            ResponsiveUI1.spl1.Controls.Add(dash);

        }
    }
}
