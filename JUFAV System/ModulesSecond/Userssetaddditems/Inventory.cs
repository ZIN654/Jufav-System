﻿using System;
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
using System.Threading;
using System.Collections;

namespace JUFAV_System.ModulesSecond.Userssetaddditems
{
    public partial class Inventory : UserControl
    {
        public Hashtable items1 = new Hashtable();
        public String usertoedit;
        public Inventory(int RoleType,int summontype, String username)
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
                        check();
                        Inventorychbox11.Enabled = false;
                        //inventory
                        break;



                }
            }
            else
            {
                LoadAccesslevel(username);
                //load current access level of the user


            }
        }
        // 
     
       
        public void update1()
        {

            //forlopp each check box
            CheckBox[] items = { StckAdj, PurchOrde, ProdList, PurchOrdRec };
            for (int i = 0; i != 4; i++)
            {
                //UPDATE ANOMALY
                MySql.Data.MySqlClient.MySqlCommand SCOM1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE SUBMODULES SET HASACCESS =" + items[i].Checked + " WHERE USERID = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + this.usertoedit + "') AND SUBMODULENAME LIKE '%" + items[i].Name.ToString() + "%';", initd.con1);
                SCOM1.ExecuteNonQuery();
                Thread.Sleep(100);


            }
        }
        private void LoadAccesslevel(String ussername)
        {
            CheckBox[] items = { StckAdj, PurchOrde, ProdList, PurchOrdRec };
            items1.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUBMODULES WHERE USERID = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + ussername + "');", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                items1.Add(sq1["SUBMODULENAME"], determinenum(Convert.ToInt32(sq1["HASACCESS"])));
                Console.WriteLine(sq1["SUBMODULENAME"].ToString() + sq1["HASACCESS"].ToString());
            }
            for (int i = 0; i != items.Length; i++)
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
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO MAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id + ",'Inventory');", initd.con1);
            scom1.ExecuteNonQuery();
            
            Thread.Sleep(200);
            CheckBox[] chboxes = {StckAdj,PurchOrde,PurchOrdRec,ProdList };
            for (int i = 0; i != 4; i++)
            {

                scom1.CommandText = "INSERT INTO SUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "'," + determineval(chboxes[i]) + ");";
                scom1.ExecuteNonQuery();
                Thread.Sleep(100);
            }
            
            /*
            for (int i = 0; i != 4; i++)
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
