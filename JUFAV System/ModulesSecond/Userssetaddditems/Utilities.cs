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
using System.Data.SQLite;
namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    public partial class Utilities : UserControl
    {
        public Utilities(int RoleType)
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
        Color onenter = Color.LightGray;
        Color onLeave = Color.WhiteSmoke;
        private void Saleschbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(Saleschbox,onenter);
        }

        private void BaRChbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(BaRChbox, onenter);
        }

        private void archChbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(archChbox, onenter);
        }

        private void Saleschbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(Saleschbox,onLeave);
        }

        private void BaRChbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(BaRChbox, onLeave);
        }

        private void archChbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(archChbox, onLeave);
        }



        //FUNCTIONS
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
            SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO MAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id + ",'Utilities');", initd.scon);
            scom1.ExecuteNonQuery();

            CheckBox[] chboxes = { BaRChbox,archChbox};
            for (int i = 0; i != 1; i++)
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

        private void Saleschbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Saleschbox.Checked == false)
            {
                uncheckall();


            }
            else
            {
                check();

            }
          
        }
        private void check()
        {
            BaRChbox.Checked =true;
            archChbox.Checked = true;
        }
        private void uncheckall()
        {
            archChbox.Checked = false;
            BaRChbox.Checked = false;
        }
    }
}
