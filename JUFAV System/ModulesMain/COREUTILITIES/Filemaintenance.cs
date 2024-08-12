using System;
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

namespace JUFAV_System.ModulesMain.COREUTILITIES
{
    public partial class Filemaintenance : UserControl
    {
       private int switch1 = 1;
       
        private int sizewidth = 234;
      
       //make this univaersal so when i click it just assign which method then ok
      
        public Filemaintenance()
        {
           
            
            InitializeComponent();
            Addevents();
            this.Dock = DockStyle.Top;
            this.Size = new Size(234, 38);

        }
      
        public void Addevents()
        { //=============FILE MAINTENANCE EVENT==================
            UsrSetBTN.Click += Userssettings;

            FmBTN.Click += FileMaintenance;
            
            SplrBTN.Click += Supplier;
            UoMBTN.Click += Unit_of_Measure;
            CategoryBTN.Click += Category;
            SubCatBTN.Click += Sub_category;
            VatBTN.Click += Vat;
            ProdBTN.Click += Product;
            MkupBTN.Click += Markup;
            
           

        }
        //===================================DEFINE YOUR METHOD HERE===========================================
        //FOR EACH BUTTON  CLICKS 
        private void FileMaintenance(object sender,EventArgs e)
        {
            ResponsiveUI1.asigntext("FILE MAINTENANCE");
           
            //adds the first setting :USERSETTINGS
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title,false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.UserSettings US1 = new ModulesMain.FILEMAINTENANCE.UserSettings();
            ResponsiveUI1.title = "UserSettings";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(US1);

            if (switch1 == 1)
                {
                //226
                //Size.Height = new Size();
               // AnimationFunctions01.Lerp1(38f, 342, 1, 1, this.Size);
                    this.Size = new Size(sizewidth, 342);
                    switch1 = 0;
                }
                else
                {
                    //36
                    this.Size = new Size(sizewidth, 38);
                    switch1 = 1;
                }

           
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
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            
                ModulesMain.FILEMAINTENANCE.UserSettings US1 = new ModulesMain.FILEMAINTENANCE.UserSettings();
                ResponsiveUI1.title = "UserSettings";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(US1);

            }
        }
        private void Supplier(object sender,EventArgs e)
        {
           
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Supplier Sup = new ModulesMain.FILEMAINTENANCE.Supplier();
            ResponsiveUI1.title = "Supplier";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Sup);
        }
        private void Markup(object sender, EventArgs e)
        {
            //debug
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.MarkUp mkup = new ModulesMain.FILEMAINTENANCE.MarkUp();
            ResponsiveUI1.title = "MarkUp";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(mkup);
        }
        private void Unit_of_Measure(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.UnitOfMeasures UoM = new ModulesMain.FILEMAINTENANCE.UnitOfMeasures();
            ResponsiveUI1.title = "UnitOfMeasures";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(UoM);
        }
        private void Category(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Category cat = new ModulesMain.FILEMAINTENANCE.Category();
            ResponsiveUI1.title = "Category";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat);

        }
        private void Sub_category(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Sub_category Sub_category = new ModulesMain.FILEMAINTENANCE.Sub_category();
            ResponsiveUI1.title = "Sub_category";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Sub_category);
        }
        private void Product(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.Products Products = new ModulesMain.FILEMAINTENANCE.Products();
            ResponsiveUI1.title = "Products";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(Products);
        }
        private void Vat(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesMain.FILEMAINTENANCE.VAT VAT = new ModulesMain.FILEMAINTENANCE.VAT();
            ResponsiveUI1.title = "VAT";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(VAT);
        }
      
    }
}
