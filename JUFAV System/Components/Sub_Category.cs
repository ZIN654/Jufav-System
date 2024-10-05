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
    public partial class Sub_Category : UserControl
    {
        int Idtoedit1= 0;
        String categoryname;
        public Sub_Category(String Subcatname,object Catname,String markup,int idtoedit)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            Idtoedit1=  idtoedit;
            categoryname = Catname.ToString();
            label5.Text = Subcatname;
            label6.Text = Catname.ToString();
            label7.Text = markup;

        }
        private void CallEdit(int summontype)
        {
            //revise paano kung same yung name
            //how do we fetch the data if it has a same name ?
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.SubCategory.AddSubCategory sup1 = new ModulesSecond.FileMaintenance.SubCategory.AddSubCategory(summontype,Idtoedit1, categoryname);
            sup1.Name = "editSubCategory";
            ResponsiveUI1.title = "editSubCategory";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CallEdit(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {



        }

        private void Sub_Category_Leave(object sender, EventArgs e)
        {
            pictureBox1.Click += null;
            pictureBox2.Click += null;
        }
    }
}
