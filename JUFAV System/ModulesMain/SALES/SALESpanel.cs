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
using System.Text.RegularExpressions;
using System.Collections;


namespace JUFAV_System.ModulesMain.SALES
{
    public partial class SALES : UserControl
    {
        //tempo remove error
        TextBox CustomerName2 = new TextBox();
        TextBox CustomerAdress2 = new TextBox();
        Dictionary<int, string> UoM;



        Dictionary<string, int> UoM2;
        ArrayList pageoffset = new ArrayList();//offsetbank
        int pages = 0;
        int rowcount = 0;
        int currentpage = 0;
        public SALES()
        {

            InitializeComponent();

            UoM = new Dictionary<int, string>();
            // limitsearch();
            initd.salestoexe = this;
            initd.itemsboxselected = ItemsBoxSelected;

            UoM2 = new Dictionary<string, int>();
            this.Dock = DockStyle.Fill;
            initd.QueryIDsSALES.Clear();

            loadUnits();
            limitsearch();
            srchbox.Focus();

          
            //filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
            label10.Text = "PAGE: " + currentpage + " of " + pages.ToString();
            // textBox4.Text = (rowcount - 1).ToString();
        }

        private void limitsearch()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            pageoffset = null;
            pageoffset = new ArrayList();
            GC.Collect();
            //pageoffset.Add(0); para 1 agad
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM PRODUCTS;", initd.con1);
            rowcount = Convert.ToInt32(scom1.ExecuteScalar());//all rows in tables products for instance 43
            int displaylimit = Convert.ToInt32(textBox4.Text); // limit display
            int test = 0;
            pages = 0; //total pages //for display
            int count = 0;// offset taker/for sqlite query
            int remainder = rowcount % displaylimit;
            pageoffset.Add(0);
            for (int i = 0; i <= displaylimit; i++, count++)
            {
                if (i == displaylimit)
                {
                    i = 0;
                    pageoffset.Add(count);
                    pages++;
                }
                if (count == rowcount)
                {
                    break;
                }
            }
            test = pages;
            if (remainder < displaylimit && rowcount > 10)//kapag may natira for instance 143 "3" remainder ng 143 is 3 
            {
                pageoffset.Add(Convert.ToInt32(pageoffset[test - 1]) + displaylimit);

            }

            initd.con1.Close();
        }
        public void totalallSales()
        {
            initd.salestotal.Clear();
            GC.Collect();
            foreach (UserControl i in ItemsBoxSelected.Controls)
            {
                initd.salestotal.Add(Convert.ToDouble(i.Controls.Find("total", true)[0].Text));
            }
            subtotalvallbl.Text = "SUB TOTAL: " + initd.salestotal.Sum().ToString() + ".00" + "₱";
            //verifier for non character input
            // totalamount.Text = (initd.number.Sum() + (Convert.ToDouble(Tax.Text) + Convert.ToDouble(Shipping.Text) + Convert.ToDouble(others.Text))).ToString() + ".00";
        }
        private void loadUnits()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            UoM.Clear();
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT UNITDESC,UNITID FROM UNITOFMEASURE", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                UoM.Add(Convert.ToInt32(sread1["UNITID"]), sread1["UNITDESC"].ToString());
                UoM2.Add(sread1["UNITDESC"].ToString(), Convert.ToInt32(sread1["UNITID"]));

            }
            sread1.Close();
            scom1.CommandText = "SELECT * FROM PRODUCTS;";
            sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                ITEMSBOX.Controls.Add(as1);
            }
            sread1.Close();
            initd.con1.Close();
            sread1 = null;
            scom1 = null;
        }
        private void filterall(int offset, int limit)
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            foreach (UserControl items in ITEMSBOX.Controls)
            {
                items.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            //test
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS LIMIT " + limit + " OFFSET " + offset + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                ITEMSBOX.Controls.Add(as1);
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
            initd.con1.Close();

        }
        private void filtersearchbox(String text)
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            //search anything 
            foreach (UserControl items in ITEMSBOX.Controls)
            {
                items.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            //bug filtering sales
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + text + "%' LIMIT " + Convert.ToInt32(textBox4.Text) + " OFFSET " + Convert.ToInt32(pageoffset[currentpage]) + ";", initd.con1);
            MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                ITEMSBOX.Controls.Add(as1);
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;

            initd.con1.Close();

        }

        private bool determineVal(int todet)
        {
            if (todet == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int determineVal2(bool todet)
        {
            if (todet == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        private void Inserintodatabase()
        {
            //Console.WriteLine("SAMPLE TEXT");

            Cursor = Cursors.WaitCursor;
            MySql.Data.MySqlClient.MySqlCommand scom1 = new MySql.Data.MySqlClient.MySqlCommand("", initd.con1);

            foreach (KeyValuePair<int, String> i in initd.QueryIDsSALES)
            {
                Console.WriteLine("QUERYIES :" + i.Value.ToString());
                scom1.CommandText = i.Value.ToString();
                scom1.ExecuteNonQuery();
            }
            scom1 = null;
            GC.Collect();
            Cursor = Cursors.Default;

        }
        private void clearitems()
        {
            foreach (UserControl i in ItemsBoxSelected.Controls)
            {
                i.Dispose();
            }
            ItemsBoxSelected.Controls.Clear();
            initd.QueryIDsSALES.Clear();

            GC.Collect();
        }
        private void DeterminehasValue()
        {
            if (ItemsBoxSelected.Controls.Count == 0)
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(clearitems, 1, "SALES", "UNABLE TO PROCESS SALES \n NO ITEMS WHERE SELECTED", "OK", 2);
                msg2.Show();
            }
            else
            {
                determineinputs();
            }

        }
        private void determineinputs()
        {

            if (CustomerName2.Text == "")
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(clearitems, 1, "CUSTOMER INFO", "UNABLE TO PROCESS SALES \n ADDRESS AND USERNAME MAY NOT HAVE VALUES", "OK", 2);
                msg2.Show();

            }
            else

            {
                if (Regex.IsMatch(CustomerName2.Text, @"[^a-zA-Z0-9,\s]") == true || Regex.IsMatch(CustomerAdress2.Text, @"[^a-zA-Z0-9,\s]") == true)
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(clearitems, 1, "DATA INPUTS", "UNABLE TO PROCESS SALES \n ADDRESS AND USERNAME MAY HAVE NON CHARACTER VALUES", "OK", 2);
                    msg2.Show();
                }
                else
                {
                    Messageboxes.typeoforder ps1 = new Messageboxes.typeoforder(Inserintodatabase, CustomerName2.Text, CustomerAdress2.Text);
                    ps1.Show();
                }

            }
        }

        private void cnfBTN_Click(object sender, EventArgs e)
        {
            //determine kung maylaman ung items box at kung naiput lahat ng value sa fields
            DeterminehasValue();



            /*
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.Sales.SalesPaymentMethod cat1 = new ModulesSecond.Sales.SalesPaymentMethod();
            ResponsiveUI1.title = "SalesPaymentMethod";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
            */
        }
        private void srachbox_Click(object sender, EventArgs e)
        {

        }
        private void CLEARITEMSbtn_Click(object sender, EventArgs e)
        {
            if (ItemsBoxSelected.Controls.Count == 0)
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(null, 1, "CLEAR ITEMS", "NO SELECTED ITEMS YET, PLEASE CHOOSE ITEMS.", "CLEAR", 2);
                msg2.Show();


            }
            else
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(clearitems, 0, "CLEAR ITEMS", "ARE YOU SURE YOU WANT TO CLEAR ALL ITEMS IN ORDER LIST?", "CLEAR", 2);
                msg2.Show();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //sets agan to page zero 

            currentpage = 0;
            if (textBox4.Text == "" || Regex.IsMatch(textBox4.Text, @"[^0-9]") || Convert.ToInt32(textBox4.Text) >= rowcount)
            {
                textBox4.Text = rowcount.ToString();

            }
            else
            {


                filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
                limitsearch();
                label10.Text = "PAGE: " + currentpage + " of " + pageoffset.Count.ToString();
            }
        }
        private void nxtpage_Click(object sender, EventArgs e)
        {
            if (pageoffset.Count != 1)
            {
                if (currentpage == pages)
                {
                    currentpage = (currentpage - 1);
                }
                else
                {
                    currentpage++;

                    filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
                    GC.Collect();
                    label10.Text = "PAGE: " + currentpage + " of " + pageoffset.Count.ToString();
                }
            }

        }
        private void bckpage_Click(object sender, EventArgs e)
        {
            if (pageoffset.Count != 1)
            {
                if (currentpage == 0)
                {
                    currentpage = 0;
                }
                else
                {
                    currentpage--;

                    filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
                    GC.Collect();
                    label10.Text = "PAGE: " + currentpage + " of " + pageoffset.Count.ToString();
                }
            }

        }
        private void ItemsBoxSelected_ControlAdded(object sender, ControlEventArgs e)
        {
            totalallSales();
        }
        private void ItemsBoxSelected_ControlRemoved(object sender, ControlEventArgs e)
        {
            totalallSales();
        }
        private void SALES_Leave(object sender, EventArgs e)
        {
            initd.QueryIDsSALES.Clear();
        }

        private void srchbox_TextChanged(object sender, EventArgs e)
        {
            filtersearchbox(srchbox.Text);
            //filter products 
        }

        private void srchbox_Click(object sender, EventArgs e)
        {
            if (srchbox.Text == "SEARCH BOX")
            {
                srchbox.Text = "";


            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.SelectAll();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
