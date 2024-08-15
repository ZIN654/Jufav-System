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

namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    public partial class FileMaintenenance : UserControl
    {
        public FileMaintenenance()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }
        public void releaseMemory() { }
        Color onenter = Color.LightGray;
        Color onLeave = Color.WhiteSmoke;
        //MOUSE ENTER ===========================================================
        public static void onenter1(CheckBox h1,Color cl1)
        {
            h1.BackColor = cl1;

        }
        public static void onleave(CheckBox h1, Color cl1)
        {
            h1.BackColor = cl1;


        }
        private void UserSettings_MouseEnter(object sender, EventArgs e)
        {
            // ResponsiveUI1
            onenter1(UserSettings,onenter);
        }
        private void Supplier_MouseEnter(object sender, EventArgs e)
        {
            onenter1(Supplier, onenter);
        }
        private void UOM_MouseEnter(object sender, EventArgs e)
        {
            onenter1(UOM, onenter);
        }
        private void Category_MouseEnter(object sender, EventArgs e)
        {
            onenter1(Category, onenter);
        }
        private void subcat_MouseEnter(object sender, EventArgs e)
        {
            onenter1(subcat, onenter);
        }
        private void MarkUp_MouseEnter(object sender, EventArgs e)
        {
            onenter1(MarkUp, onenter);
        }
        private void Products_MouseEnter(object sender, EventArgs e)
        {
            onenter1(Products, onenter);
        }
        private void vat_MouseEnter(object sender, EventArgs e)
        {
            onenter1(vat, onenter);
        }
        private void FILEMAINTENANCE_MouseEnter(object sender, EventArgs e)
        {
            onenter1(FILEMAINTENANCE, onenter);
        }

        //MOUSE LEAVE ===========================================================
        private void UserSettings_MouseLeave(object sender, EventArgs e)
        {
            onleave(UserSettings,onLeave);
        }
        private void Supplier_MouseLeave(object sender, EventArgs e)
        {
            onleave(Supplier, onLeave);
        }
        private void UOM_MouseLeave(object sender, EventArgs e)
        {
            onleave(UOM, onLeave);
        }
        private void Category_MouseLeave(object sender, EventArgs e)
        {
            onleave(Category, onLeave);
        }
        private void subcat_MouseLeave(object sender, EventArgs e)
        {
            onleave(subcat, onLeave);
        }
        private void MarkUp_MouseLeave(object sender, EventArgs e)
        {
            onleave(MarkUp, onLeave);
        }
        private void Products_MouseLeave(object sender, EventArgs e)
        {
            onleave(Products, onLeave);
        }
        private void vat_MouseLeave(object sender, EventArgs e)
        {
            onleave(vat, onLeave);
        }
        private void FILEMAINTENANCE_MouseLeave(object sender, EventArgs e)
        {
            onleave(FILEMAINTENANCE, onLeave);
        }
    }

}
