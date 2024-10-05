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
    public partial class ProductComponent : UserControl
    {
        int id;
        public ProductComponent(String prodname,String Category,String Subcategory,int quantity,String Uom,Double UnitCost,Double Srp,int prodID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label11.Text = prodname;
            label12.Text = Category;
            label13.Text = Subcategory;
            label14.Text = quantity.ToString();
            label15.Text = Uom;
            label16.Text = UnitCost.ToString();
            label17.Text = Srp.ToString();
            id = prodID;

        }
        private void edit()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Products.AddProducts sup1 = new ModulesSecond.FileMaintenance.Products.AddProducts(0, id);
            sup1.Name = "editMarkup";
            ResponsiveUI1.title = "editMarkup";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ProductComponent_Leave(object sender, EventArgs e)
        {
            pictureBox1.Click += null;
            pictureBox2.Click += null;
        }
    }
}
