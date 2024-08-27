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
    public partial class Reports : UserControl
    {
        public Reports(int RoleType)
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
        //ON ENTER
        Color onenter = Color.LightGray;
        Color onLeave = Color.WhiteSmoke;
        private void rprtsChbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(rprtsChbx,onenter);
        }

        private void stcwhchbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(stcwhchbx, onenter);
        }

        private void prodlstChbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(prodlstChbox, onenter);
        }

        private void rtrnChbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(rtrnChbx, onenter);
        }

        private void T10Lchbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(T10Lchbx, onenter);
        }

        private void audTChbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(audTChbx, onenter);
        }

        private void SalsRprChbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(SalsRprChbox, onenter);
        }

        private void FinChbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(FinChbx, onenter);
        }

        private void T10Mchbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(T10Mchbx, onenter);
        }

        private void StckAdjuChkbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(StckAdjuChkbx, onenter);
        }
        //=============================ON LEAVE=========================
        private void rprtsChbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(rprtsChbx,onLeave);
        }

        private void stcwhchbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(stcwhchbx, onLeave);
        }

        private void SalsRprChbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(SalsRprChbox, onLeave);
        }

        private void prodlstChbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(prodlstChbox, onLeave);
        }

        private void FinChbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(FinChbx, onLeave);
        }

        private void rtrnChbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(rtrnChbx, onLeave);
        }

        private void T10Mchbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(T10Mchbx, onLeave);
        }

        private void T10Lchbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(T10Lchbx, onLeave);
        }

        private void StckAdjuChkbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(StckAdjuChkbx, onLeave);
        }

        private void audTChbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(audTChbx, onLeave);
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
            SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO MAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id + ",'Reports');", initd.scon);
            scom1.ExecuteNonQuery();

            CheckBox[] chboxes = {stcwhchbx,SalsRprChbox,prodlstChbox,FinChbx,rtrnChbx,T10Mchbx,T10Lchbx,StckAdjuChkbx,audTChbx };
            for (int i = 0; i != 8; i++)
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

        private void rprtsChbx_CheckedChanged(object sender, EventArgs e)
        {
            if (rprtsChbx.Checked == false)
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
            stcwhchbx.Checked = false;
            audTChbx.Checked = false;
            rtrnChbx.Checked = false;
            SalsRprChbox.Checked = false;
            FinChbx.Checked = false;
            T10Lchbx.Checked = false;
            T10Mchbx.Checked = false;
            StckAdjuChkbx.Checked = false;
            prodlstChbox.Checked = false;


        }
        private void check()
        {
            stcwhchbx.Checked = true;
            audTChbx.Checked = true;
            rtrnChbx.Checked = true;
            SalsRprChbox.Checked = true;
            FinChbx.Checked = true;
            T10Lchbx.Checked = true;
            T10Mchbx.Checked = true;
            StckAdjuChkbx.Checked = true;
            prodlstChbox.Checked = true;


        }
    }
}
