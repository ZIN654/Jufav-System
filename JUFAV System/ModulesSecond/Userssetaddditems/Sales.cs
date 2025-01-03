﻿using System;
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
    public partial class Sales : UserControl
    {
        public Hashtable items1 = new Hashtable();
        public String usertoedit;
        public Sales(int RoleType,int summontype, String username)
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
                        check();
                       
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
                //load data for updating



            }
        }
        public void update1()
        {
            //forlopp each check box
            Console.WriteLine("this is from sales " + usertoedit);
            CheckBox[] items = {Saleschbx,ResprodChbox };
            for (int i = 0; i != 2; i++)
            {
                //UPDATE ANOMALY
                MySql.Data.MySqlClient.MySqlCommand SCOM1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE SUBMODULES SET HASACCESS =" + items[i].Checked + " WHERE USERID = (SELECT USERID FROM USER_INFO WHERE USERNAME = '" + this.usertoedit + "') AND SUBMODULENAME LIKE '%" + items[i].Name.ToString() + "%';", initd.con1);
                SCOM1.ExecuteNonQuery();
                Thread.Sleep(100);


            }
        }
        // 
        private void LoadAccesslevel(String ussername)
        {
            
            items1.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SUBMODULES WHERE USERID = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + ussername + "');", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                items1.Add(sq1["SUBMODULENAME"], determinenum(Convert.ToInt32(sq1["HASACCESS"])));
                Console.WriteLine(sq1["SUBMODULENAME"].ToString() + sq1["HASACCESS"].ToString());
            }
            ResprodChbox.Checked = (bool)items1[ResprodChbox.Name.ToString()];
            Saleschbox.Checked = (bool)items1[Saleschbx.Name.ToString()];

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
        Color onenter = Color.LightGray;
        Color onLeave = Color.WhiteSmoke;
        private void Saleschbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(Saleschbox,onenter); 
        }

        private void Saleschbx_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(Saleschbx,onenter);
        }

        private void ResprodChbox_MouseEnter(object sender, EventArgs e)
        {
            ResponsiveUI1.onenter1(ResprodChbox,onenter);
        }

        private void Saleschbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(Saleschbox, onLeave);
        }

        private void Saleschbx_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(Saleschbx,onLeave);
        }

        private void ResprodChbox_MouseLeave(object sender, EventArgs e)
        {
            ResponsiveUI1.onleave(ResprodChbox,onLeave);
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
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO MAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id + ",'Sales');", initd.con1);
            scom1.ExecuteNonQuery();
           
            Thread.Sleep(200);
            CheckBox[] chboxes = {Saleschbx,ResprodChbox };
            for (int i = 0; i != 2; i++)
            {

                scom1.CommandText = "INSERT INTO SUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "'," + determineval(chboxes[i]) + ");";
                scom1.ExecuteNonQuery();
                Thread.Sleep(100);
            }
          
            /*
            for (int i = 0; i != 2; i++)
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
        private void uncheckall()
        {
            Saleschbx.Checked = false;
            ResprodChbox.Checked = false;


        }
        private void check()
        {
            Saleschbx.Checked = true;
            ResprodChbox.Checked = true;



        }
    }
}
