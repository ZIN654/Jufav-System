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
    public partial class FileMaintenenance : UserControl
    {
        public Hashtable items1 = new Hashtable();
        public String usertoedit;
        public FileMaintenenance(int RoleType,int summontype, String username)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.usertoedit = username;
            if (summontype == 1)
            {
                ///load it in usual way 
                    if (RoleType == 0)
                    {
                        uncheckall();


                    }
                    else
                    {

                        check();

                    }
            }
            else
            {
                //load it with the current data infp of the user
                LoadAccesslevel(username);

            }
            //chech if employee or admin  if admin kapag inedit ny info nya maalter nya but kung  employee
            //hindi
            //make sure na yung database is naka open na sa CORE
            //wag ka na  mag oopen dito dahil mag kakaroon ng exception
        }
        //
        public void update1()
        {

            //forlopp each check box
            CheckBox[] items = { UserSettings, Supplier, UOM, Category, subcat, MarkUp, Products, vat };
            for (int i = 0; i != 8; i++)
            {
                //UPDATE ANOMALY
                SQLiteCommand SCOM1 = new SQLiteCommand("UPDATE SUBMODULES SET HASACCESS =" + items[i].Checked + " WHERE SUBMODULENAME LIKE '" + items[i].Name.ToString() + "%' AND USERID = (SELECT USERID FROM USER_INFO WHERE USERNAME = '" + this.usertoedit + "');", initd.scon);
                SCOM1.ExecuteNonQuery();
                Thread.Sleep(500);


            }
        }
        private void LoadAccesslevel(String ussername)
        {
            CheckBox[] items = { UserSettings, Supplier, UOM, Category, subcat, MarkUp, Products, vat };
            items1.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUBMODULES WHERE USERID = (SELECT USERIDS FROM USER_INFO WHERE USERNAME = '" + ussername + "');", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
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
        private void OnloadType0()
        {
            //if employee fetch all data of acccess level of the emplyee


        }


        ///DATA INSERTION ======================================WHEN CREATING A NEW ACCOUNT
        /// 
        ///

        public void InsertData(int id) {
            Random rand = new Random();
            String ModuleID = "";//Modules table each ID is 4
          
            for (int i = 0; i != 7; i++)
            {
                //take note sa concat
                ModuleID = string.Concat(ModuleID, rand.Next(0, 9).ToString());
            }
            //generate id of module 
            SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO MAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id +",'FileMaintenance');",initd.scon);
            scom1.ExecuteNonQuery();
            scom1.CommandText = "INSERT INTO ARCMAINMODULES VALUES (" + Convert.ToInt32(ModuleID) + "," + id + ",'FileMaintenance');";
            scom1.ExecuteNonQuery();

            CheckBox [] chboxes = {UserSettings,Supplier,UOM,Category,subcat,MarkUp,Products,vat};
            for(int i = 0;i != 8;i++)
            {
                scom1.CommandText = "INSERT INTO SUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "',"+determineval(chboxes[i])+");";
                scom1.ExecuteNonQuery();
            }
            Thread.Sleep(1500);
            for (int i = 0; i != 8; i++)
            {
                scom1.CommandText = "INSERT INTO ARCSUBMODULES VALUES (" + generate_submoduleID() + "," + id + ",'" + chboxes[i].Name + "'," + determineval(chboxes[i]) + ");";
                scom1.ExecuteNonQuery();
            }
        }
        public int determineval(CheckBox ch1)
        {
            int val = 0;
            if (ch1.Checked)
            {
                val = 1;


            }else
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

        private void FILEMAINTENANCE_CheckedChanged(object sender, EventArgs e)
        {
            if (FILEMAINTENANCE.Checked == false)
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
            UserSettings.Checked = false;
            Supplier.Checked = false;
            Category.Checked = false;
            subcat.Checked = false;
            vat.Checked = false;
            UOM.Checked = false;
            MarkUp.Checked = false;
            Products.Checked = false;
        }
        private void check()
        {
            UOM.Checked = true;
            UserSettings.Checked = true;
            Supplier.Checked = true;
            Category.Checked = true;
            subcat.Checked = true;
            vat.Checked = true;
            MarkUp.Checked = true;
            Products.Checked = true;


        }
    }

}
