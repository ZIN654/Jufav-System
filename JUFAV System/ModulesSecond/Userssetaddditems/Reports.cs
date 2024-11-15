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
using System.Threading;
using System.Collections;

namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    public partial class Reports : UserControl
    {
        public Hashtable items1 = new Hashtable();
        public String usertoedit;
        public Reports(int RoleType,int summontype,String username)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.usertoedit = username;
            if (summontype == 1)
            {
                switch (RoleType)
                {
                    case 1:
                        check();
                        break;
                    case 2:
                        //sales
                      
                        uncheckall();
                      
                        break;
                    case 3:
                     
                        uncheckall();
                        //inventory
                        break;



                }
            }
            else
            {
                LoadAccesslevel(username);
                //load data for uppdating



            }
        }
     
       
        public void update1()
        {

            //forlopp each check box
            CheckBox[] items = { stcwhchbx, prodlstChbox, rtrnChbx, T10Lchbx, SalsRprChbox, FinChbx, T10Mchbx, StckAdjuChkbx, audTChbx };
            for (int i = 0; i != 9; i++)
            {
                //UPDATE ANOMALY  mga na edit
                SQLiteCommand SCOM1 = new SQLiteCommand("UPDATE SUBMODULES SET HASACCESS =" + items[i].Checked + " WHERE USERID = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + this.usertoedit + "') AND SUBMODULENAME LIKE '" + items[i].Name.ToString() + "%';", initd.scon);
                SCOM1.ExecuteNonQuery();
                Thread.Sleep(500);


            }



        }
        private void LoadAccesslevel(String ussername)
        {
            CheckBox[] items = { stcwhchbx, prodlstChbox, rtrnChbx, T10Lchbx, SalsRprChbox, FinChbx, T10Mchbx, StckAdjuChkbx, audTChbx };
            items1.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUBMODULES WHERE USERID = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + ussername + "');", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                items1.Add(sq1["SUBMODULENAME"], determinenum(Convert.ToInt32(sq1["HASACCESS"])));
                Console.WriteLine(sq1["SUBMODULENAME"].ToString() + sq1["HASACCESS"].ToString());
            }
            //do checks for access levels in the tables of submodules access level if all required is inserted
            for (int i = 0;i != 8;i++)
            {
                items[i].Checked = (bool)items1[items[i].Name.ToString()];
            }
           
            sq1.Close();


        }
        public bool determinenum(int val)
        {
            bool returnval = false;
            if (val == 1)
            {
                returnval = true;
            }
            else
            {
                returnval = false;
            }
            return returnval;
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
           
            Thread.Sleep(200);
            CheckBox[] chboxes = {stcwhchbx,SalsRprChbox,prodlstChbox,FinChbx,rtrnChbx,T10Mchbx,T10Lchbx,StckAdjuChkbx,audTChbx };
            for (int i = 0; i != 8; i++)
            {

                scom1.CommandText = "INSERT INTO SUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "'," + determineval(chboxes[i]) + ");";
                scom1.ExecuteNonQuery();
                Thread.Sleep(100);
            }
            
            /*
            for (int i = 0; i != 8; i++)
            {

                scom1.CommandText = "INSERT INTO ARCSUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "'," + determineval(chboxes[i]) + ");";
                scom1.ExecuteNonQuery();
            }
            */
            scom1 = null;
            GC.Collect();
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
            for (int g = 0; g != 5; g++)
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
