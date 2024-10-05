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
    public partial class MarkUpDatabox : UserControl
    {
        int id;
        public MarkUpDatabox(String value ,int IDtoedit)
        {

            InitializeComponent();
            id = IDtoedit;
            label1.Text = value;
            this.Dock = DockStyle.Top;
        }

        private void edit()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.markup.AddMarkup sup1 = new ModulesSecond.FileMaintenance.markup.AddMarkup(0, id);
            sup1.Name = "editMarkup";
            ResponsiveUI1.title = "editMarkup";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void MarkUpDatabox_Leave(object sender, EventArgs e)
        {
            pictureBox1.Click += null;
            pictureBox2.Click += null;
        }
    }
}
