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
using System.Collections;
namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class Sub_category : UserControl
    {
        private Hashtable subcatinfo = new Hashtable();
        private Hashtable subfilter = new Hashtable();
        public Sub_category()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            onload();
            comboBox1.Items.Add("All items");
            onloadcombo();

            //add filtering tools select from where cat = combobox.text : woods then add emm only with cat that has woods
        }
        private void onload()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            subcatinfo.Clear();
            foreach(UserControl i in ItemsBox.Controls)
            {
                i.Dispose();
            }
            ItemsBox.Controls.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT CATEGORYDESC,CATEGORYID FROM CATEGORY;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read()) {
                subcatinfo.Add(sq1["CATEGORYID"], sq1["CATEGORYDESC"]);
            }
            sq1.Close();
            ///delay a bit
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC,MARKUPVALUE,CATEGORYID FROM SUBCATEGORY;";
            MySql.Data.MySqlClient.MySqlDataReader sq2 = scom1.ExecuteReader();
            while (sq2.Read())
            {
                Components.Sub_Category item1 = new Components.Sub_Category(sq2["SUBCATEGORYDESC"].ToString(), subcatinfo[sq2["CATEGORYID"]].ToString(), sq2["MARKUPVALUE"].ToString(),Convert.ToInt32(sq2["SUBCATEGORYID"]));
                ItemsBox.Controls.Add(item1);
            }
            sq2.Close();
            sq1.Close();
            initd.con1.Close();
        }
        private void Filter(String filterval)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            subfilter.Clear();
            subcatinfo.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT CATEGORYDESC,CATEGORYID FROM CATEGORY WHERE CATEGORYDESC = '" +filterval+"';", initd.con1);//where category is only woods
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                subfilter.Add(sq1["CATEGORYDESC"], sq1["CATEGORYID"]);
                subcatinfo.Add(sq1["CATEGORYID"], sq1["CATEGORYDESC"]);
            }
            sq1.Close();
            ///delay a bit
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC,MARKUPVALUE,CATEGORYID FROM SUBCATEGORY WHERE CATEGORYID = "+subfilter[filterval]+ ";";
            MySql.Data.MySqlClient.MySqlDataReader sq2 = scom1.ExecuteReader();
            ItemsBox.Controls.Clear();//much better kung dispose ang gagamitin
            while (sq2.Read())
            {
                Components.Sub_Category item1 = new Components.Sub_Category(sq2["SUBCATEGORYDESC"].ToString(), subcatinfo[sq2["CATEGORYID"]], sq2["MARKUPVALUE"].ToString(),Convert.ToInt32(sq2["SUBCATEGORYID"]));
                ItemsBox.Controls.Add(item1);
            }
            sq2.Close();
            sq1.Close();

            initd.con1.Close();
        }

        private void onloadcombo()
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT CATEGORYDESC,CATEGORYID FROM CATEGORY;", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                comboBox1.Items.Add(sq1["CATEGORYDESC"]);
            }
            sq1.Close();
            initd.con1.Close();

        }
        public void releaseMem()
        {
            addSubCatBTN.Click -= addSubCatBTN_Click;
            srchBTN.Click -= srchBTN_Click;


        }
        private void addSubCatBTN_Click(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.SubCategory.AddSubCategory unit1 = new ModulesSecond.FileMaintenance.SubCategory.AddSubCategory(1,0,"");
            ResponsiveUI1.title = "AddSubCategory";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(unit1);
        }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            search(txtboxSearchBox.Text);
        }
        private  void search(String text)
        {
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            foreach (UserControl i in ItemsBox.Controls)
            {
                i.Dispose();
            }
            ItemsBox.Controls.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUBCATEGORYID,SUBCATEGORYDESC,MARKUPVALUE,CATEGORYID FROM SUBCATEGORY WHERE SUBCATEGORYDESC LIKE '%"+text+ "%';", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sq2 = scom1.ExecuteReader();
            while (sq2.Read())
            {
                Components.Sub_Category item1 = new Components.Sub_Category(sq2["SUBCATEGORYDESC"].ToString(), subcatinfo[sq2["CATEGORYID"]].ToString(), sq2["MARKUPVALUE"].ToString(), Convert.ToInt32(sq2["SUBCATEGORYID"]));
                ItemsBox.Controls.Add(item1);
            }
            sq2.Close();
            scom1 = null;
            sq2 = null;
            initd.con1.Close();
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //kung yung combobox ay wlang laman use load else 
            if (comboBox1.Text == "")
            {
                onload();
            }
            else if (comboBox1.Text == "All items")
            {

                onload();

            }
            else
            {
                Filter(comboBox1.Text);
            }
          //on close items box dispose
        }

        private void txtboxSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtboxSearchBox.Text != "")
            {
                txtboxSearchBox.Text = "";

            }
        }
    }
}
