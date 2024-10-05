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
    public partial class CategoryComponent : UserControl
    {
        int id1;
        public CategoryComponent(String text,int id)
        {
            InitializeComponent();
            this.id1 = id;
            this.Dock = DockStyle.Top;
            label1.Text = text;
        }






        private void edit()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Category.AddCategory sup1 = new ModulesSecond.FileMaintenance.Category.AddCategory(0, id1);
            sup1.Name = "editCategory";
            ResponsiveUI1.title = "editCategory";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);


        }
        private void archive()
        {




        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CategoryComponent_Leave(object sender, EventArgs e)
        {
            pictureBox2.Click += null;
            pictureBox1.Click += null;
        }
    }
}
