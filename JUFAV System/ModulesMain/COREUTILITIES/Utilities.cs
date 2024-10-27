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
    public partial class Utilities : UserControl
    {
        private int switch1 = 1;
        private int sizewidth = 234;
     
        public Utilities()
        {
            
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234,38);
        }
        public void Addevents()
        {
            //use static variables for allocation
          
            //when this clicked the user setting will appear this is just an divider
            UtlBTN.Click += (sender, e) => { Utilitiesbtn(); };
            BkRstrBTN.Click += (sender, e) => { Backup(); };

        }

        public void Utilitiesbtn()
        {
            ResponsiveUI1.asigntext("UTILITIES");
            if (switch1 == 1)
            {
                //226
                this.Size = new Size(sizewidth, 114);
                switch1 = 0;
            }
            else
            {
                //36
                this.Size = new Size(sizewidth, 38);
                switch1 = 1;
            }
            GC.Collect();
        }
        public void Backup()
        {
           


            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ResponsiveUI1.title = "BCKRS";
            ResponsiveUI1.headingtitle.Text = "Backup and restore".ToUpper();
         
            ModulesMain.UTILITIES.BCKRS sp1 = new ModulesMain.UTILITIES.BCKRS();
            ResponsiveUI1.spl1.Controls.Add(sp1);
        }
        public void ArchivedFiles()
        {

        }
    }
}
