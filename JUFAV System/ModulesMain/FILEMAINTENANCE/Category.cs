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

namespace JUFAV_System.ModulesMain.FILEMAINTENANCE
{
    public partial class Category : UserControl
    {
        public Category()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loaddata();
        }
        public void releaseMemory()
        {
            //invoke when this was disposed
            addCatBTN.Click -= addCatBTN_Click;


        }
        private void addCatBTN_Click(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Category.AddCategory cat1 = new ModulesSecond.FileMaintenance.Category.AddCategory();
            ResponsiveUI1.title = "AddCategory";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);

            //temporary

        }
        private void loaddata()
        {

            SQLiteCommand scom = new SQLiteCommand("SELECT CATEGORYDESC FROM CATEGORY;", initd.scon);
            //
            SQLiteDataReader sq1 = scom.ExecuteReader();
            while (sq1.Read())
            {
                //much better approach insted of using Find()
                Components.CategoryComponent cat1 = new Components.CategoryComponent(sq1["CATEGORYDESC"].ToString());
                ItemsBox.Controls.Add(cat1);


            }



        }
    }
}
