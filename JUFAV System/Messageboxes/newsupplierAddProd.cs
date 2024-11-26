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
using System.Data.SQLite;
using System.Text.RegularExpressions;


namespace JUFAV_System.Messageboxes
{
    public partial class newsupplierAddProd : Form
    {
        Panel itemsbox1;
        int prodid1;
        Action actoexe;
        int supplierID = 0;
        public bool isverfied1 = true;
        public bool isverfied2 = true;
        public bool isverified3 = true;
        public newsupplierAddProd(Panel itemtoadd,int productID,Action ac1)
        {
            InitializeComponent();
            itemsbox1 = itemtoadd;
            actoexe = ac1;
            prodid1 = productID;
        }
        private int grablastIDSUPP()
        {
            initd.con1.Close();
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            int ID = 0;

            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUPPLIERID FROM SUPPLIERS ORDER BY SUPPLIERID DESC LIMIT 1;", initd.con1);
            ID = Convert.ToInt32(sq1.ExecuteScalar());
            initd.con1.Close();
            return ID + 1;
        }
        private void INSERTINTODB()
        {
            this.Cursor = Cursors.WaitCursor;
          
            //query to use when user pressed add products
            //"INSERT INTO SUPPLIERLISTPROD(PRODUCTID,COMPANYNAME,CONTACTPERSON,CONTACTNUM,ADDRESS) VALUES ("+prodid1+",'"+compname.Text+"','"+conper.Text+"','"+conum.Text+"','"+conadd.Text+"');"
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("", initd.con1);
            // sq1.ExecuteNonQuery();
            //  Thread.Sleep(100);
            supplierID = grablastIDSUPP();
            //error DIOOOOOOOn
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            sq1.CommandText = "INSERT INTO SUPPLIERS (SUPPLIERID,USERID,SUPPLIERNAME,CONTACTPERSON,CONTACTNUMBER,COMPANYADDRESS)VALUES("+supplierID+"," + initd.UserID+",'" + compname.Text + "','" + conper.Text + "','" + conum.Text + "','" + conadd.Text + "');";
            sq1.ExecuteNonQuery();
            sq1 = null;
            GC.Collect();
            


           //paano namn pag galing sa new supplier tas aad mo sa loob ng add products
           Components.SupplierComponentAddprod sup1 = new Components.SupplierComponentAddprod(compname.Text,conper.Text,conum.Text,conadd.Text,generateQueryAndID(),0,prodid1,000);//query palang den to
            itemsbox1.Controls.Add(sup1);
            this.Cursor = Cursors.Default;
            actoexe();
            initd.con1.Close();
            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(this.Dispose, 0, "ADD PRODUCT", "ITEM SUCCESSFULLY ADDED!", "OK", 2);
            msg2.Show();
        }
        private int generateQueryAndID()
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
            initd.QueryIDsProd.Add(Convert.ToInt32(ID), "INSERT INTO PRODUCTSUPPLIER(PRODUCTID,SUPPLIERID) VALUES (" + prodid1 + "," + supplierID + ");");
            return Convert.ToInt32(ID);
        }
        private int grablastID()
        {
            initd.con1.Close();
            if (initd.con1.State == System.Data.ConnectionState.Closed) { initd.con1.Open(); }
            int ID = 0;
            MySql.Data.MySqlClient.MySqlCommand sq1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT PRODUCTID FROM PRODUCTS ORDER BY PRODUCTID DESC LIMIT 1;", initd.con1);
            ID = Convert.ToInt32(sq1.ExecuteScalar());
            initd.con1.Close();
            return ID + 1;
        }
        public void verify()
        {
            isverfied1 = true;
            isverfied2 = true;
            isverified3 = true;
            TextBox[] textboxes = { compname,conadd, conum, conadd };
         
            //check pass and conf is =
            if (compname.Text == "" || conadd.Text == "" || conum.Text == "" || conadd.Text == "")
            {
                for (int i = 0; i != 4; i++)
                {
                    if (textboxes[i].Text == "")
                    {
                        // MessageBox.Show("error please Enter input from textbox text : " + textboxes[i].Name);
         
                        isverfied1 = false;
                        break;
                    }


                }


            }
            else
            {
                for (int i = 0; i != 1; i++)
                {
                    // \\W\\S
                    if (Regex.IsMatch(textboxes[i].Text, @"[^\w\s\d]"))
                    {
                        Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "NON CHARACTER INPUT", "Please Remove a non - letter character in " + textboxes[i].Name + " field where text '" + textboxes[i].Text + "' contains the non letter character.", "RETRY", 1);
                        ms.Show();
                        isverfied2 = false;
                        break;
                    }


                }
            }
            //
                if (isverfied2 == true && isverfied1 == true && algos1.DetectInputifDupplicate(new String[] { compname.Text.Normalize().ToLower().Trim(), conadd.Text.Normalize().ToLower().Trim(), conum.Text.Normalize().ToLower().Trim(), conadd.Text.Normalize().ToLower().Trim() }, 0) == false)
                {
                    isverified3 = false;
                }
         
            ///
            if (isverfied2 == true && isverfied1 == true && isverified3 == true)
            {
                //are you sure 
              
                    Messageboxes.MessageboxConfirmation msg1 = new Messageboxes.MessageboxConfirmation(INSERTINTODB, 0, "ADD NEW SUPPLIER", "ARE YOU SURE YOU WANT TO ADD THIS NEW SUPPLIER?", "ADD", 2);
                    msg1.Show();



              

            }

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            verify();
        }
        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
