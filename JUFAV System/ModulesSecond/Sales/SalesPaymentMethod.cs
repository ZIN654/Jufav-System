using System;
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
using System.Text.RegularExpressions;

namespace JUFAV_System.ModulesSecond.Sales
{
    public partial class SalesPaymentMethod : UserControl
    {
        TextBox texttouse;
        double VATtouse = 0.0;
        int IDtouse1;
        int totalITEMS;
        String firstrun;
        List<int> IDtoUse = new List<int>();
        List<double> subtotal = new List<double>();
        List<double> total = new List<double>();
        int index = 0;
        public SalesPaymentMethod(String custname,String Custaddress)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            texttouse = Payment;
            label2.Text = custname;
            label4.Text = Custaddress;
            loaddata();
            totalall();
            genereteTransactionID();
        }
        private void totalall()
        {
            totalITEMS = 0;
            foreach(UserControl i in itemlist.Controls)
            {
                subtotal.Add(Convert.ToDouble(i.Controls.Find("Price", true)[0].Text));
                total.Add(Convert.ToDouble(i.Controls.Find("label1", true)[0].Text) * VATtouse);//vat 12
                totalITEMS++;
            }
            label11.Text = VATtouse.ToString();
            label12.Text = subtotal.Sum().ToString() + ".00";
            label16.Text = (subtotal.Sum() + total.Sum()).ToString();
            //vat and subottal are also here



        }
        private void loaddata()
        {
            //load vat here 
            foreach (UserControl i in itemlist.Controls)
            {
                i.Dispose();

            }
            itemlist.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM ORDERSTEMPO;",initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesPaymentMethodOrderList orderlist1 = new Components.SalesPaymentMethodOrderList(sread1["ProductDesc"].ToString(),Convert.ToInt32(sread1["QUANTITY"]), Convert.ToInt32(sread1["TOTALPRICE"]), Convert.ToInt32(sread1["PRODUCTID"]), Convert.ToInt32(sread1["PRICE"]));
                itemlist.Controls.Add(orderlist1);
            }
            //new part
            sread1.Close();
            scom1.CommandText = "SELECT VATVALUE FROM VAT;";
            VATtouse = Convert.ToDouble(scom1.ExecuteScalar());
            //must have a table for sales and if the sale was success fuly piurchased 
            //it will insert to sales table and it will clear the salesqueue
            sread1.Close();
            scom1 = null;
            sread1 = null;
            GC.Collect();


        }
        private void goback()
        {
            if (cleardata() == true) {
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.SALES.SALES cat1 = new ModulesMain.SALES.SALES();
                ResponsiveUI1.title = "SALES";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);
            }else
            {
                cleardata();
                ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
                ModulesMain.SALES.SALES cat1 = new ModulesMain.SALES.SALES();
                ResponsiveUI1.title = "SALES";
                ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
                ResponsiveUI1.spl1.Controls.Add(cat1);
            }
            //itemlist.Controls.Clear();
           
        }
        public bool cleardata()
        {
            bool test1 = false;
            Cursor = Cursors.WaitCursor;
            //bug when deleting
            ArrayList ar1 = new ArrayList();
            
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM ORDERSTEMPO;", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                ar1.Add(Convert.ToInt32(sread1["PRODUCTID"]));
            }
            sread1.Close();
            foreach(int i in ar1)
            {
                scom1.CommandText = "DELETE FROM ORDERSTEMPO WHERE PRODUCTID = "+i+";";
                scom1.ExecuteNonQuery();
            }
            scom1.CommandText = "SELECT COUNT(*) FROM ORDERSTABLE";
            int count = Convert.ToInt32(scom1.ExecuteScalar());
            Console.WriteLine(count);
            if (count != 0){
               
                test1 = false;
            }
            else
            {
                test1 = true;
            }
            scom1 = null;
            GC.Collect();
            Cursor = Cursors.Default;

            return test1;
         
        }   
        public void gcash(object sender,EventArgs e) { }
        public void COP(object sender,EventArgs e) { }
        public void COD(object sender,EventArgs e) { }
        private void genereteTransactionID()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT SALEID FROM SALES ORDER BY SALEID DESC LIMIT 1;", initd.scon);
            int intouse = Convert.ToInt32(scom1.ExecuteScalar());
            IDtouse1 = generateSALEID();
            label21.Text = IDtoUse.ToString();

            firstrun = "INSERT INTO SALES(SALEID,USERID,CUSTOMERNAME,CUSTOMERADDRESS,DATEOFSALE,TOTALITEMS,TOTALPRICE) VALUES (" + IDtouse1 + "," + initd.UserID + ",'" + label2.Text + "','" + label4.Text + "','" + DateTime.Now.ToShortDateString() + "'," + totalITEMS + "," + label16.Text + ");";
            /*
            if (intouse != 0)   
                        {
                        }
                        else
                        {
                            label21.Text = "00000" + Convert.ToInt32(intouse + 1).ToString();
                            firstrun = "INSERT INTO SALES(USERID,CUSTOMERNAME,CUSTOMERADDRESS,DATEOFSALE,TOTALITEMS,TOTALPRICE) VALUES (" + initd.UserID + ",'" + label2.Text + "','" + label4.Text + "','" + DateTime.Now.ToShortDateString() + "'," + totalITEMS + "," + label16.Text + ");";

                            //use query instead

                        }

                */

        }
        private int generateSALEID()
        {
            this.Cursor = Cursors.WaitCursor;
            Random rs1 = new Random();
            String unitid = "";//Users table

            //retreive make sure it doesnt match any in the db
            //CATEGORY 8
            for (int i = 0; i != 8; i++)
            {
                unitid = unitid + rs1.Next(0, 9).ToString();
            }
            IDtoUse.Add(Convert.ToInt32(unitid));
            return Convert.ToInt32(unitid);
        }
        private void Confirmsales()
        {
            Cursor = Cursors.WaitCursor;
            if (Payment.Text == "0" || Regex.IsMatch(Payment.Text,@"[^0-9]"))
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "PAYMENT", "PLEASE ADD VALUE TO PAYMENT FIELD.", "RETRY", 1);
                ms.Show();

            }else
            {
                
                    insertintodatabase();
                
                //deduct to database and insert sales
                
            }
            Cursor = Cursors.Default;
        }
        private void insertintodatabase()
        {
            //pag iinsert mo na sa sales table dapat naka set den kung magkano ang binayad.sino ang kustomer at mag kano ang sukli
            SQLiteCommand scom2 = new SQLiteCommand("", initd.scon);
            SQLiteCommand scom1 = new SQLiteCommand(firstrun, initd.scon);
            scom1.ExecuteNonQuery();
            Thread.Sleep(500);
            scom1.CommandText = "SELECT * FROM ORDERSTEMPO;";
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read()) {
                
                scom2.CommandText = "INSERT INTO ORDERSTABLE(SALEID,ITEMID,ITEMNAME,ITEMPRICE,QUANTITY,TOTALPURCHASE) VALUES ("+IDtouse1+","+Convert.ToInt32(sread1["ProductID"])+",'"+ sread1["ProductDesc"].ToString() + "',"+ Convert.ToInt32(sread1["PRICE"]) + "," + Convert.ToInt32(sread1["QUANTITY"]) + "," + Convert.ToInt32(sread1["TOTALPRICE"]) + ");";
                scom2.ExecuteNonQuery();
                Thread.Sleep(500);
                
            }
            //deduction ng quatity
            sread1.Close();
            sread1 = null;
            scom1.CommandText = "SELECT * FROM ORDERSTABLE WHERE SALEID = "+ IDtouse1 + ";";
            Console.WriteLine("ID TO USE : " + IDtouse1);
            sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {//tempo yung 2
                //error to
                scom2.CommandText = "UPDATE PRODUCTS SET QUANTITY = QUANTITY -" + Convert.ToInt32(sread1["QUANTITY"]) + " WHERE PRODUCTID = "+Convert.ToInt32(sread1["ITEMID"]) +";";
                scom2.ExecuteNonQuery();
                Thread.Sleep(500);
                
                Console.WriteLine(" itemquantity" +Convert.ToInt32(sread1["QUANTITY"]));
                Console.WriteLine("ITEM ID" +Convert.ToInt32(sread1["ITEMID"]));
            }


            //deduction here 
            sread1.Close();
            scom1 = null;
            scom2 = null;
            GC.Collect();
          

            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(showChanges, 0, "SALES", "SALES ARE SUCCESSFULY PROCESSED", "YES", 0);
            msg2.Controls.Find("btnclose",true)[0].Visible = false;
            msg2.Show();
           
        }
        private void showChanges()
        {
            Messageboxes.ShowChanges pas1 = new Messageboxes.ShowChanges(Convert.ToDouble(Payment.Text) - (Convert.ToDouble(label16.Text)- Convert.ToDouble(Discount.Text)), goback);
            pas1.Show();

        }
        private void textBox3_MouseCaptureChanged(object sender, EventArgs e)
        {
            texttouse = Deliveryfee;
            //set text box to  edit 
        }
        private void textBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            texttouse = Discount;
        }
        private void textBox2_MouseCaptureChanged(object sender, EventArgs e)
        {
            texttouse = Payment;
        }
        private void confirmorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("test 2 pressed");
        }
        private void one_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "1";
        }
        private void ttwo_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "2";
        }
        private void threee_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "3";
        }
        private void four_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "4";
        }
        private void five_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "5";
        }
        private void six_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "6";
        }
        private void seven_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "7";
        }
        private void eight_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "8";
        }
        private void nine_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "9";
        }
        private void dot_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + ".";
        }
        private void doublezero_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "00";
        }
        private void zero_Click(object sender, EventArgs e)
        {
            texttouse.Text = texttouse.Text + "0";
        }
        private void clear_Click(object sender, EventArgs e)
        {
            texttouse.Clear();
        }
        private void Backsoace_Click(object sender, EventArgs e)
        {
            if (texttouse.Text == "")
            {
                texttouse.Text = 0.ToString();
            }else
            {
                texttouse.Text = texttouse.Text.Remove(texttouse.Text.Length - 1);
            }
          
        }
        private void backtosales_Click(object sender, EventArgs e)
        {
            Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(goback, 0, "CANCEL ORDER", "ARE YOU SURE YOU WANT TO GO BACK TO ORDER LIST? \n ALL ITEMS WILL BE REMOVED", "YES", 2);
            msg2.Show();  
        }
        private void SalesPaymentMethod_Leave(object sender, EventArgs e)
        {
            cleardata();
            initd.QueryIDsSALES.Clear();
            GC.Collect();
        }
        private void SalesPaymentMethod_ControlRemoved(object sender, ControlEventArgs e)
        {
            cleardata();
            initd.QueryIDsSALES.Clear();
            GC.Collect();
        }
        private void SalesPaymentMethod_VisibleChanged(object sender, EventArgs e)
        {
            cleardata();
            initd.QueryIDsSALES.Clear();
            GC.Collect();
          
        }
        private void confirmorder_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Payment.Text) < Convert.ToDouble(label16.Text))
            {
                Messageboxes.MessageboxConfirmation ms = new Messageboxes.MessageboxConfirmation(null, 1, "PAYMENT", "PAYMENT VALUE NOT ENOUGH", "RETRY", 2);
                ms.Show();
            }
            else
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(Confirmsales, 0, " CONFIRM SALES", "ARE YOU SURE YOU WANT TO PROCESS THIS SALE?", "YES", 2);
                msg2.Show();
            }
            
        }
    }
}
