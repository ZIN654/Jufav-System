﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//include this to access
using JUFAV_System.dll;
using JUFAV_System.ModulesMain;
using System.Collections;
using System.Data.SQLite;

namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    public partial class Filemaintenance : UserControl
    {
       private int switch1 = 1;
        private Hashtable accountaccesslevel = new Hashtable();
        private int sizewidth = 234;
      
       //make this univaersal so when i click it just assign which method then ok
       //each load nitong buttons load sa sql database tas insert sa hashtable
      
        public Filemaintenance()
        {
           
            
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);
            loadandinsertAccesslevel();

        }
      private void loadandinsertAccesslevel()
        {
            MySql.Data.MySqlClient.MySqlCommand scom = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUBMODULENAME,HASACCESS FROM SUBMODULES WHERE USERID = " + initd.UserID+";",initd.con1);
             MySql.Data.MySqlClient.MySqlDataReader sq1 = scom.ExecuteReader();
            while (sq1.Read())
            {
                accountaccesslevel.Add(sq1["SUBMODULENAME"],sq1["HASACCESS"]);
            }
            sq1.Close();
        }
        public void Addevents()
        { //=============FILE MAINTENANCE EVENT==================
            UsrSetBTN.Click += Userssettings;

            FmBTN.Click += FileMaintenance;
            
            SplrBTN.Click += Supplier;
          
            CategoryBTN.Click += Category;
            SubCatBTN.Click += Sub_category;
            VatBTN.Click += Vat;
            ProdBTN.Click += Product;
           
            
           

        }
        //===================================DEFINE YOUR METHOD HERE===========================================
        //FOR EACH BUTTON  CLICKS 
        private void FileMaintenance(object sender,EventArgs e)
        {
            ResponsiveUI1.asigntext("FILE MAINTENANCE");
            if (Convert.ToInt32(accountaccesslevel["UserSettings"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.FILEMAINTENANCE.UserSettings US1 = new ModulesMain.FILEMAINTENANCE.UserSettings();
                ResponsiveUI1.title = "UserSettings";
                ResponsiveUI1.title2 = "USER SETTINGS";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(US1);


            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AcccessDenied";
                ResponsiveUI1.title2 = "ACCESS DENIED";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);
            }
            //adds the first setting :USERSETTINGS
           

            if (switch1 == 1)
                {
                //226
                //Size.Height = new Size();


                this.Size = new Size(sizewidth, 266);
               // AnimationFunctions01.Lerp1(38, 342, 1, this);
                switch1 = 0;
                }
                else
                {
                    //36
                    this.Size = new Size(sizewidth, 38);
                    switch1 = 1;
                }

            GC.Collect();
            // ResponsiveUI1.Switchnum(this, DropdownIcon, 0, sizewidth, 48, 434);
        }
        private void Userssettings(object sender,EventArgs e)
        {
            //fxix this
            //bug here exceptopm
            if(ResponsiveUI1.spl1.Controls.Contains(new ModulesMain.FILEMAINTENANCE.UserSettings()))
            {
                Console.WriteLine("this object was exist instantiating it might lead to memory ");
            }
            else
            {
                if (Convert.ToInt32(accountaccesslevel["UserSettings"]) == 1)
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    ModulesMain.FILEMAINTENANCE.UserSettings US1 = new ModulesMain.FILEMAINTENANCE.UserSettings();
                    ResponsiveUI1.title = "UserSettings";
                    ResponsiveUI1.title2 = "USER SETTINGS";
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                    ResponsiveUI1.spl1.Controls.Add(US1);


                }
                else
                {
                    ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                    Components.AccessDenied as1 = new Components.AccessDenied();
                    ResponsiveUI1.title2 = "AccessDenied";
                    ResponsiveUI1.title2 = "ACCESS DENIED";
                    ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                    ResponsiveUI1.spl1.Controls.Add(as1);
                }


            }
        }
        private void Supplier(object sender,EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["Supplier"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.FILEMAINTENANCE.Supplier Sup = new ModulesMain.FILEMAINTENANCE.Supplier();
                ResponsiveUI1.title = "Supplier";
                ResponsiveUI1.title2 = "SUPPLIER";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(Sup);

            }else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "ACCESS DENIED";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);


            }
          
        }
        
       
        private void Category(object sender, EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["Category"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.FILEMAINTENANCE.Category cat = new ModulesMain.FILEMAINTENANCE.Category();
                ResponsiveUI1.title = "Category";
                ResponsiveUI1.title2 = "Category";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat);

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);


            }
          

        }
        private void Sub_category(object sender, EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["subcat"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.FILEMAINTENANCE.Sub_category Sub_category = new ModulesMain.FILEMAINTENANCE.Sub_category();
                ResponsiveUI1.title = "Sub_category";
                ResponsiveUI1.title2 = "Sub category";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(Sub_category);

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);


            }
           
        }
        private void Product(object sender, EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["Products"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.FILEMAINTENANCE.Products Products = new ModulesMain.FILEMAINTENANCE.Products();
                ResponsiveUI1.title = "Products";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(Products);

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);


            }
         
        }
        private void Vat(object sender, EventArgs e)
        {
            if (Convert.ToInt32(accountaccesslevel["vat"]) == 1)
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.FILEMAINTENANCE.VAT VAT = new ModulesMain.FILEMAINTENANCE.VAT();
                ResponsiveUI1.title = "VAT";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(VAT);

            }
            else
            {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                Components.AccessDenied as1 = new Components.AccessDenied();
                ResponsiveUI1.title = "AccessDenied";
                ResponsiveUI1.title2 = "Access Denied";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title2.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(as1);


            }
           


            ///sample
            ///



        }
      
    }
}
