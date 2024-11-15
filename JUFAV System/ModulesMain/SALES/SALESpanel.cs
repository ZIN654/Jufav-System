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
        Dictionary<int, string> category;
        Dictionary<int, string> Subcategory;
        Dictionary<int, string> UoM;
    

        Dictionary<string, int> category2;
        Dictionary<string, int> Subcategory2;
        Dictionary<string, int> UoM2;
        ArrayList pageoffset = new ArrayList();//offsetbank
        int pages = 0;
        int rowcount = 0;
        int currentpage = 0;
        public SALES()
        {
           
            InitializeComponent();
            category = new Dictionary<int, string>();
            Subcategory = new Dictionary<int, string>();
            UoM = new Dictionary<int, string>();
            // limitsearch();
            initd.salestoexe = this;
            initd.itemsboxselected = ItemsBoxSelected;
            category2 = new Dictionary<string, int>();
            Subcategory2 = new Dictionary<string, int>();
            UoM2 = new Dictionary<string, int>();
            this.Dock = DockStyle.Fill;
            initd.QueryIDsSALES.Clear();
            limitsearch();
            loadUnits();



            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), srchbox.Text);
            //filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
            label10.Text = "PAGE: " + currentpage + " of " + pages.ToString();
           // textBox4.Text = (rowcount - 1).ToString();
        }
        public void totalallSales()
        {
            initd.salestotal.Clear();
            GC.Collect();
            foreach (UserControl i in ItemsBoxSelected.Controls)
            {
                initd.salestotal.Add(Convert.ToDouble(i.Controls.Find("total", true)[0].Text));
            }
            subtotalvallbl.Text = "SUB TOTAL: " + initd.salestotal.Sum().ToString() + ".00";
            //verifier for non character input
           // totalamount.Text = (initd.number.Sum() + (Convert.ToDouble(Tax.Text) + Convert.ToDouble(Shipping.Text) + Convert.ToDouble(others.Text))).ToString() + ".00";
        }
        private void loadUnits()
        {

            category.Clear();
            Subcategory.Clear();
            UoM.Clear();
           
            comboBox1.Items.Add("ALL ITEMS");
            comboBox2.Items.Add("ALL ITEMS");
            category2.Add("ALL ITEMS", 1001);
            Subcategory2.Add("ALL ITEMS", 1002);

            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYID,CATEGORYDESC FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                category.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());
                category2.Add(sq1["CATEGORYDESC"].ToString(), Convert.ToInt32(sq1["CATEGORYID"]));
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());



            }
            sq1.Close();
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                Subcategory.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]), sq1["SUBCATEGORYDESC"].ToString());
                Subcategory2.Add(sq1["SUBCATEGORYDESC"].ToString(), Convert.ToInt32(sq1["SUBCATEGORYID"]));
                comboBox2.Items.Add(sq1["SUBCATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT UNITDESC,UNITID FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                UoM.Add(Convert.ToInt32(sq1["UNITID"]), sq1["UNITDESC"].ToString());
                UoM2.Add(sq1["UNITDESC"].ToString(), Convert.ToInt32(sq1["UNITID"]));

            }
            sq1.Close();
            comboBox1.SelectedIndex = 0;//
            sq1 = null;
            scom1 = null;
        }
        private void limitsearch()
        {
            pageoffset = null;
            pageoffset = new ArrayList();
            GC.Collect();
            //pageoffset.Add(0); para 1 agad
            SQLiteCommand scom1 = new SQLiteCommand("SELECT COUNT(*) AS ROWS FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + srchbox.Text + "%';", initd.scon);
            rowcount = Convert.ToInt32(scom1.ExecuteScalar());//all rows in tables products for instance 43
            int displaylimit = Convert.ToInt32(textBox4.Text); // limit display
            int test =0;
            pages = 0; //total pages //for display
            int count = 0;// offset taker/for sqlite query
            int remainder = rowcount % displaylimit;
            pageoffset.Add(0);
            for (int i = 0; i <= displaylimit; i++,count++)
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
           
           
        }
        private void limitsearch2()
        {
            pageoffset.Clear();
            //pageoffset.Add(0); para 1 agad
            SQLiteCommand scom1 = new SQLiteCommand("SELECT COUNT(*) AS ROWS FROM PRODUCTS WHERE CATEGORYID = " + Convert.ToInt32(category2[comboBox1.Text]) +  " ;", initd.scon);
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


        }
        private void limitsearch3()
        {
            pageoffset.Clear();
            //pageoffset.Add(0); para 1 agad
            SQLiteCommand scom1 = new SQLiteCommand("SELECT COUNT(*) AS ROWS FROM PRODUCTS WHERE CATEGORYID = " + Convert.ToInt32(category2[comboBox1.Text]) + " AND SUBCATEGORYID = "+ Convert.ToInt32(Subcategory2[comboBox2.Text]) + " ;", initd.scon);
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


        }
        private void filterall(int offset,int limit)
        {
            foreach (UserControl items in ITEMSBOX.Controls)
            {
                items.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            //test
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS LIMIT " + limit+" OFFSET "+offset+";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                ITEMSBOX.Controls.Add(as1);
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;

        }
        private void filtersearchbox(String text)
        {
           
            //search anything 
            foreach (UserControl items in ITEMSBOX.Controls)
            {
                items.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + text + "%' LIMIT "+ Convert.ToInt32(textBox4.Text) + " OFFSET "+ Convert.ToInt32(pageoffset[currentpage]) + ";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                ITEMSBOX.Controls.Add(as1);
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;



        }
        private void tofilter2(int Category, int Subcat, String search)
        {
            foreach (UserControl items in ITEMSBOX.Controls)
            {
                items.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            SQLiteDataReader sread1;

            //allitems
            if (Category == 1001)
            {
                limitsearch();
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + search + "%' ORDER BY PRODUCTNAME DESC LIMIT " + Convert.ToInt32(textBox4.Text) + " OFFSET " + Convert.ToInt32(pageoffset[currentpage]) + ";";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(),Convert.ToInt32(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], (Convert.ToInt32(sread1["ORIGINALPICE"])+ Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                    ITEMSBOX.Controls.Add(as1);

                }
                sread1.Close();
            }
            else if(Category != 1001 && Subcat == 1002)
            {
                limitsearch2();
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " ORDER BY PRODUCTNAME DESC LIMIT " + Convert.ToInt32(textBox4.Text) + " OFFSET " + Convert.ToInt32(pageoffset[currentpage]) + ";";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                    ITEMSBOX.Controls.Add(as1);

                }
                sread1.Close();
            }else
            {
                limitsearch3();
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " AND SUBCATEGORYID = "+Subcat+ " ORDER BY PRODUCTNAME DESC LIMIT " + Convert.ToInt32(textBox4.Text) + " OFFSET " + Convert.ToInt32(pageoffset[currentpage]) + ";";
                sread1 = scom1.ExecuteReader(); ;
                while (sread1.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.SalesProductList as1 = new Components.SalesProductList(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], (Convert.ToInt32(sread1["ORIGINALPICE"]) + Convert.ToInt32(sread1["MARKUPVALUE"])).ToString(), Convert.ToInt32(sread1["PRODUCTID"]));
                    ITEMSBOX.Controls.Add(as1);

                }
                sread1.Close();




            }
          
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
        private void setitem()
        {

            comboBox2.Items.Clear();
            comboBox2.Items.Add("ALL ITEMS");
            //if statement
            if (comboBox1.Text == "ALL ITEMS")
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {

                SQLiteCommand scom1 = new SQLiteCommand("SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY WHERE CATEGORYID = " + Convert.ToInt32(category2[comboBox1.Text]) + ";", initd.scon);
                SQLiteDataReader sq1 = scom1.ExecuteReader();
                while (sq1.Read())
                {
                    comboBox2.Items.Add(sq1["SUBCATEGORYDESC"].ToString());
                }
                comboBox2.SelectedIndex = 0;
                sq1.Close();
                scom1 = null;
                sq1 = null;

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
            SQLiteCommand scom1 = new SQLiteCommand("",initd.scon);

            foreach (KeyValuePair<int,String> i in initd.QueryIDsSALES)
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

            if (CustomerName.Text == "" || CustomerAddress.Text == "")
            {
                Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(clearitems, 1, "CUSTOMER INFO", "UNABLE TO PROCESS SALES \n ADDRESS AND USERNAME MAY NOT HAVE VALUES", "OK", 2);
                msg2.Show();

            }
            else
            {
                if (Regex.IsMatch(CustomerName.Text, @"[^a-zA-Z0-9,\s]") == true || Regex.IsMatch(CustomerAddress.Text, @"[^a-zA-Z0-9,\s]") == true)
                {
                    Messageboxes.MessageboxConfirmation msg2 = new Messageboxes.MessageboxConfirmation(clearitems, 1, "DATA INPUTS", "UNABLE TO PROCESS SALES \n ADDRESS AND USERNAME MAY HAVE NON CHARACTER VALUES", "OK", 2);
                    msg2.Show();
                }
                else
                {
                    Messageboxes.typeoforder ps1 = new Messageboxes.typeoforder(Inserintodatabase,CustomerName.Text,CustomerAddress.Text);
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bugs here
           
            setitem();
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), srchbox.Text);
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), srchbox.Text);
            
        }
        private void srachbox_Click(object sender, EventArgs e)
        {
            filtersearchbox(srchbox.Text);
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
                textBox4.Text = rowcount.ToString() ;
                }
                else
                {
                 limitsearch();
                 tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), srchbox.Text);
                //filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
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
                    tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), srchbox.Text);
                   // filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
                    GC.Collect();
                    label10.Text = "PAGE: " + currentpage + " of " + pageoffset.Count.ToString() ;
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
                    tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), srchbox.Text);
                  // filterall(Convert.ToInt32(pageoffset[currentpage]), Convert.ToInt32(textBox4.Text));
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
    }
}
