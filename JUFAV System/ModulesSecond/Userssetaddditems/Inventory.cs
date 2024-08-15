using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    public partial class Inventory : UserControl
    {
        public Inventory()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }
        public void releasemem()
        {



        }
        Color onenter = Color.LightGray;
        Color onLeave = Color.WhiteSmoke;
        //MOUSE ENTER ===========================================================
        public static void onenter1(CheckBox h1, Color cl1)
        {
            h1.BackColor = cl1;

        }
        public static void onleave(CheckBox h1, Color cl1)
        {
            h1.BackColor = cl1;


        }

        private void Inventorychbox11_MouseEnter(object sender, EventArgs e)
        {
            onenter1(Inventorychbox11,onenter);
        }

        private void StckAdj_MouseEnter(object sender, EventArgs e)
        {
            onenter1(StckAdj, onenter);
        }

        private void PurchOrde_MouseEnter(object sender, EventArgs e)
        {
            onenter1(PurchOrde, onenter);

        }

        private void ProdList_MouseEnter(object sender, EventArgs e)
        {
            onenter1(ProdList, onenter);
        }

        private void PurchOrdRec_MouseEnter(object sender, EventArgs e)
        {
            onenter1(PurchOrdRec, onenter);
        }



        //MOUSE LEAVE ===========================================================
        private void Inventorychbox11_MouseLeave(object sender, EventArgs e)
        {
            onleave(Inventorychbox11,onLeave);
        }

        private void StckAdj_MouseLeave(object sender, EventArgs e)
        {
            onleave(StckAdj, onLeave);
        }

        private void PurchOrde_MouseLeave(object sender, EventArgs e)
        {
            onleave(PurchOrdRec, onLeave);
        }

        private void ProdList_MouseLeave(object sender, EventArgs e)
        {
            onleave(ProdList, onLeave);
        }

        private void PurchOrdRec_MouseLeave(object sender, EventArgs e)
        {
            onleave(PurchOrdRec, onLeave);
        }
    }
}
