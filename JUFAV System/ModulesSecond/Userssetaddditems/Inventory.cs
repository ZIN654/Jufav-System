using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;

namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    public partial class Inventory : UserControl
    {
        public Inventory(int RoleType)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            if (RoleType == 0)
            {
                uncheckall();


            }
            else
            {

                check();

            }
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
            onleave(PurchOrde, onLeave);
        }

        private void ProdList_MouseLeave(object sender, EventArgs e)
        {
            onleave(ProdList, onLeave);
        }

        private void PurchOrdRec_MouseLeave(object sender, EventArgs e)
        {
            onleave(PurchOrdRec, onLeave);
        }



        //funtions DATA INSERTION
        public void InsertData(int id)
        {
            Random rand = new Random();
            String ModuleID = "";//Modules table each ID is 4

            for (int i = 0; i != 7; i++)
            {
                //take note sa concat
                ModuleID = string.Concat(ModuleID, rand.Next(0, 9).ToString());
            }
            //generate id of module 
            SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO MAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id + ",'Inventory');", initd.scon);
            scom1.ExecuteNonQuery();

            CheckBox[] chboxes = {StckAdj,PurchOrde,PurchOrdRec,ProdList };
            for (int i = 0; i != 3; i++)
            {

                scom1.CommandText = "INSERT INTO SUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "'," + determineval(chboxes[i]) + ");";
                scom1.ExecuteNonQuery();
            }

        }
        public int determineval(CheckBox ch1)
        {
            int val = 0;
            if (ch1.Checked)
            {
                val = 1;


            }
            else
            {


                val = 0;
            }
            return val;
        }
        private int generate_submoduleID()
        {
            Random rt = new Random();
            String SubModuleID = "";// each sub modules table 11
            for (int g = 0; g != 9; g++)
            {

                SubModuleID = string.Concat(SubModuleID, rt.Next(0, 9).ToString());
            }
            return Convert.ToInt32(SubModuleID);


        }

        private void Inventorychbox11_CheckedChanged(object sender, EventArgs e)
        {
            if (Inventorychbox11.Checked == false)
            {
                uncheckall();


            }
            else
            {

                check();

            }
        }
        private void uncheckall()
        {
            StckAdj.Checked = false;
            PurchOrde.Checked = false;
            PurchOrdRec.Checked = false;
            ProdList.Checked = false;
        }
        private void check()
        {
            StckAdj.Checked = true;
            PurchOrde.Checked = true;
            PurchOrdRec.Checked = true;
            ProdList.Checked = true;


        }

    }
}
