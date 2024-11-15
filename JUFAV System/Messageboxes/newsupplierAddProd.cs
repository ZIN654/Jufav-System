using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;
using System.Threading;

namespace JUFAV_System.Messageboxes
{
    public partial class newsupplierAddProd : Form
    {
        Panel itemsbox1;
        int prodid1;
        Action actoexe;
        public newsupplierAddProd(Panel itemtoadd,int productID,Action ac1)
        {
            InitializeComponent();
            itemsbox1 = itemtoadd;
            actoexe = ac1;
            prodid1 = productID;
        }
        private void INSERTINTODB()
        {
            this.Cursor = Cursors.WaitCursor;
            //query to use when user pressed add products
            //"INSERT INTO SUPPLIERLISTPROD(PRODUCTID,COMPANYNAME,CONTACTPERSON,CONTACTNUM,ADDRESS) VALUES ("+prodid1+",'"+compname.Text+"','"+conper.Text+"','"+conum.Text+"','"+conadd.Text+"');"
            SQLiteCommand sq1 = new SQLiteCommand("", initd.scon);
           // sq1.ExecuteNonQuery();
          //  Thread.Sleep(100);
            sq1.CommandText = "INSERT INTO SUPPLIERS (USERID,SUPPLIERNAME,CONTACTPERSON,CONTACTNUMBER,COMPANYADDRESS)VALUES(" + initd.UserID+",'" + compname.Text + "','" + conper.Text + "','" + conum.Text + "','" + conadd.Text + "');";
            sq1.ExecuteNonQuery();
            sq1 = null;
            GC.Collect();
            //paano namn pag galing sa new supplier tas aad mo sa loob ng add products
            Components.SupplierComponentAddprod sup1 = new Components.SupplierComponentAddprod(compname.Text,conper.Text,conum.Text,conadd.Text,generateQueryAndID(compname.Text, conper.Text, conum.Text, conadd.Text),0);
            itemsbox1.Controls.Add(sup1);
            this.Cursor = Cursors.Default;
            actoexe();
            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ADD PRODUCT", "ITEM SUCCESSFULLY ADDED!", "GO BACK", 1);
            msg2.Show();
        }
        private int generateQueryAndID(String compname, String Cntacperson, String contactnum, String Address)
        {

            String ID = "";
            Random ran1 = new Random();
            for (int i = 0; i != 7; i++)
            {
                ID = ID + ran1.Next(1, 9).ToString();
            }
            ran1 = null;
            GC.Collect();
            //for displaying 
            initd.QueryIDsProd.Add(Convert.ToInt32(ID), "INSERT INTO SUPPLIERLISTPROD(PRODUCTID,COMPANYNAME,CONTACTPERSON,CONTACTNUM,ADDRESS) VALUES (" + grablastID() + ",'" + compname + "','" + Cntacperson + "','" + contactnum + "','" + Address + "');");
            return Convert.ToInt32(ID);
        }
        private int grablastID()
        {
            int ID = 0;
            SQLiteCommand sq1 = new SQLiteCommand("SELECT PRODUCTID FROM PRODUCTS ORDER BY PRODUCTID DESC LIMIT 1;", initd.scon);
            ID = Convert.ToInt32(sq1.ExecuteScalar());
            return ID + 1;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(INSERTINTODB, 0, "ADD PRODUCT", "ARE YOU SURE YOU WANT TO ADD THIS NEW SUPPLIER?", "YES", 2);
            msg2.Show();
        }

        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
