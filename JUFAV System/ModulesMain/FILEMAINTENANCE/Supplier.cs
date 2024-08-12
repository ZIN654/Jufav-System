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
    public partial class Supplier : UserControl
    {
        public Supplier()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            addevents();
        }
        public void addevents()
        {
            this.Leave += Onleave;
            addSupplierBTN.Click += AddSupBtn;
        }
        private void Onleave(object sender,EventArgs e)
        {
            Console.WriteLine("THIS CONTROLL IS REMOVED");
        }
        private void AddSupBtn(object sender,EventArgs e)
        {
            Components.SUPDatabox databox = new Components.SUPDatabox();
            ItemsBox.Controls.Add(databox);

        }


        public static void realeaseLeak()
        {
            Console.WriteLine("THIS CONTROLL IS REMOVED");


        }
    }
}
