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
        public SALES()
        {
           
            InitializeComponent();
            category = new Dictionary<int, string>();
            Subcategory = new Dictionary<int, string>();
            UoM = new Dictionary<int, string>();
           // limitsearch();

            category2 = new Dictionary<string, int>();
            Subcategory2 = new Dictionary<string, int>();
            UoM2 = new Dictionary<string, int>();
            this.Dock = DockStyle.Fill;
            loadUnits();

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
            int rowcount = 43;
            int displaylimit = 10;
            int pages = 0;
            int count = 0;
            int [] pageoffset = { };
            for (int i = 0; i <= displaylimit; i++,count++)
            {
                if (i == displaylimit)
                {
                    Console.WriteLine("ADDING 1 OAGES");
                    i = 0;
                  //  pageoffset[pages] = count;
                    pages++;
                    break;
                }
            }
            //fix bug id at PURCHASEORDER
            //for limitung SELECT * FROM POITEMORDERTABLE ORDER BY ORDERID ASC LIMIT 3 OFFSET 5
            //dapata pala nasa loob ito ng tofilter2 since un ung ginagamit ng dalawang combobox
        }
        private void filtersearchbox(String text)
        {
           
            //search anything 
            foreach (UserControl items in ITEMSBOX.Controls)
            {
                items.Dispose();
            }
            ITEMSBOX.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + text + "%';", initd.scon);
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

                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + search + "%' ORDER BY PRODUCTNAME DESC";
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

                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " ORDER BY PRODUCTNAME DESC;";
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
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " AND SUBCATEGORYID = "+Subcat+" ORDER BY PRODUCTNAME DESC;";
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
        private void cnfBTN_Click(object sender, EventArgs e)
        {
            ResponsiveUI1.spl1.Controls.Find(ResponsiveUI1.title, false)[0].Dispose();
            ModulesSecond.Sales.SalesPaymentMethod cat1 = new ModulesSecond.Sales.SalesPaymentMethod();
            ResponsiveUI1.title = "SalesPaymentMethod";
            ResponsiveUI1.headingtitle.Text = ResponsiveUI1.title.ToUpper();
            ResponsiveUI1.spl1.Controls.Add(cat1);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
