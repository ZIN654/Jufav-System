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

namespace JUFAV_System.Components
{
    public partial class ProductComponent : UserControl
    {
        int id;
        public ProductComponent(String prodname,String Category,String Subcategory,int quantity,String Uom,Double UnitCost,Double Srp,int prodID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            label11.Text = prodname;
            label12.Text = Category;
            label13.Text = Subcategory;
            label14.Text = quantity.ToString();
            label15.Text = Uom;
            label16.Text = UnitCost.ToString();
            label17.Text = Srp.ToString();
            id = prodID;

        }
        private void edit()
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.FileMaintenance.Products.AddProducts sup1 = new ModulesSecond.FileMaintenance.Products.AddProducts(0, id);
            sup1.Name = "editMarkup";
            ResponsiveUI1.title = "editMarkup";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(sup1);


        }
        private void archive()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("INSERT INTO ARCPRODUCTS (PRODUCTID,USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE) SELECT * FROM PRODUCTS WHERE PRODUCTID = " + id + ";", initd.scon);
            scom1.ExecuteNonQuery();
            Thread.Sleep(2000);
            scom1.CommandText = "DELETE FROM PRODUCTS WHERE PRODUCTID = " + id + ";";//references bug
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ARCHIVE RECORD", "RECORD SUCCESSFULLY ARCHIVED!", "OK", 0);
            ms.Show();
        }
        private void delete()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLiteCommand scom1 = new SQLiteCommand("DELETE FROM PRODUCTS WHERE PRODUCTID = " + id + ";", initd.scon);
            scom1.ExecuteNonQuery();
            scom1 = null;
            GC.Collect();
            this.Cursor = Cursors.Default;
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "DELETE RECORD", "RECORD SUCCESSFULLY DELETED!", "OK", 0);
            ms.Show();

        }
        private void ProductComponent_Leave(object sender, EventArgs e)
        {
            EditBTN.Click += null;
            TrashBTN.Click += null;
        }
        private void EditBTN_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void TrashBTN_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(delete, 0, "DELETE RECORD", "ARE YOU SURE YOU WANT TO DELETE THIS RECORD?\n", "OK", 1);
            ms.Show();
        }
        private void ArcBTN_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(archive, 0, "ARCHIVE RECORD", "ARE YOU SURE YOU WANT TO ARCHIVE THIS RECORD?\n THIS TAKES TIME AROUND 1-2 MINUTES WOULD YOU LIKE PROCEED?.", "OK", 2);
            ms.Show();
        }
    }
}
