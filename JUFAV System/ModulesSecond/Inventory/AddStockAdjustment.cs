using System;
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


namespace JUFAV_System.ModulesSecond.Inventory
{
    public partial class AddStockAdjustment : UserControl
    {
        Dictionary<int, string> Uom;
        Dictionary<int, string> SubCat;
        Dictionary<int, string> Category11;

        Dictionary<string, int> category2;
        Dictionary<string, int> Subcategory2;
        Dictionary<string, int> UoM2;
        public AddStockAdjustment()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            Uom = new Dictionary<int, string>();
            Category11 = new Dictionary<int, string>();
            SubCat = new Dictionary<int, string>();
            category2 = new Dictionary<string, int>();
            Subcategory2 = new Dictionary<string, int>();
            UoM2 = new Dictionary<string, int>();
            this.Dock = DockStyle.Fill;
           //loadinfo();
           // LoadData();
            loadUnits();
            this.Cursor = Cursors.Default;

        }
   
        private void loadinfo()
        {
            Category11.Clear();
            SubCat.Clear();
            Uom.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYID,CATEGORYDESC FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                Category11.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
               
                SubCat.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]), sq1["SUBCATEGORYDESC"].ToString());
                comboBox2.Items.Add(sq1["SUBCATEGORYDESC"].ToString());
            }
            sq1.Close();
            scom1.CommandText = "SELECT UNITDESC,UNITID FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Uom.Add(Convert.ToInt32(sq1["UNITID"]), sq1["UNITDESC"].ToString());
            }
            sq1.Close();
            sq1 = null;
            scom1 = null;
        }
        private void LoadData()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS",initd.scon);
            SQLiteDataReader sread = scom1.ExecuteReader();
            while (sread.Read())
            {
                Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(sread["PRODUCTNAME"].ToString(),Convert.ToDouble(sread["QUANTITY"]),Category11[Convert.ToInt32(sread["CATEGORYID"])].ToString(),SubCat[Convert.ToInt32(sread["SUBCATEGORYID"])].ToString(),determineperishable(Convert.ToInt32(sread["PERISHABLEPRODUCT"])), Uom[Convert.ToInt32(sread["UOMID"])].ToString(),Convert.ToInt32(sread["PRODUCTID"]));
                itemsBoxs.Controls.Add(db1);
            }


        }
        private bool determineperishable(int i)
        {
            bool todeter = false;
            if (i == 1)
            {
                todeter = true;
            }
            return todeter;
        }
        private void loadUnits()
        {

          //  category.Clear();
           // Subcategory.Clear();
           // UoM.Clear();
            
            comboBox1.Items.Add("ALL ITEMS");
            comboBox2.Items.Add("ALL ITEMS");
            category2.Add("ALL ITEMS", 1001);
            Subcategory2.Add("ALL ITEMS", 1002);

            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYID,CATEGORYDESC FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                Category11.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());
                category2.Add(sq1["CATEGORYDESC"].ToString(), Convert.ToInt32(sq1["CATEGORYID"]));
                comboBox1.Items.Add(sq1["CATEGORYDESC"].ToString());



            }
            sq1.Close();
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

              SubCat.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]), sq1["SUBCATEGORYDESC"].ToString());
                Subcategory2.Add(sq1["SUBCATEGORYDESC"].ToString(), Convert.ToInt32(sq1["SUBCATEGORYID"]));
                comboBox2.Items.Add(sq1["SUBCATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT UNITDESC,UNITID FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Uom.Add(Convert.ToInt32(sq1["UNITID"]), sq1["UNITDESC"].ToString());
                UoM2.Add(sq1["UNITDESC"].ToString(), Convert.ToInt32(sq1["UNITID"]));

            }
            sq1.Close();
         
           comboBox1.SelectedIndex = 0;
            sq1 = null;
            scom1 = null;
        }
        private void tofilter2(int Category, int Subcat, int perishable, int batched, String search)
        {
            foreach (UserControl items in itemsBoxs.Controls)//itemsbixS
            {
                items.Dispose();
            }
            itemsBoxs.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            SQLiteDataReader sread;

            //allitems
            if (Category == 1001)
            {

                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + search + "%' ORDER BY PRODUCTNAME DESC";
                sread = scom1.ExecuteReader(); ;
                while (sread.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                   
                    Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(sread["PRODUCTNAME"].ToString(), Convert.ToDouble(sread["QUANTITY"]), Category11[Convert.ToInt32(sread["CATEGORYID"])].ToString(), SubCat[Convert.ToInt32(sread["SUBCATEGORYID"])].ToString(), determineperishable(Convert.ToInt32(sread["PERISHABLEPRODUCT"])), Uom[Convert.ToInt32(sread["UOMID"])].ToString(), Convert.ToInt32(sread["PRODUCTID"]));
                    itemsBoxs.Controls.Add(db1);

                }
                sread.Close();
            }
            else if (Category != 1001 && Subcat == 1002)
            {

                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " ORDER BY PRODUCTNAME DESC;";
                sread = scom1.ExecuteReader(); ;
                while (sread.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(sread["PRODUCTNAME"].ToString(), Convert.ToDouble(sread["QUANTITY"]), Category11[Convert.ToInt32(sread["CATEGORYID"])].ToString(), SubCat[Convert.ToInt32(sread["SUBCATEGORYID"])].ToString(), determineperishable(Convert.ToInt32(sread["PERISHABLEPRODUCT"])), Uom[Convert.ToInt32(sread["UOMID"])].ToString(), Convert.ToInt32(sread["PRODUCTID"]));
                    itemsBoxs.Controls.Add(db1);

                }
                sread.Close();
            }
            else
            {

                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE CATEGORYID = " + Category + " AND SUBCATEGORYID = " + Subcat + " AND ISBATCH = " + batched + " AND PERISHABLEPRODUCT = " + perishable + " ORDER BY PRODUCTNAME DESC;";
                sread = scom1.ExecuteReader(); ;
                while (sread.Read())
                {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                 //supplier boss kullang
                    Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(sread["PRODUCTNAME"].ToString(), Convert.ToDouble(sread["QUANTITY"]), Category11[Convert.ToInt32(sread["CATEGORYID"])].ToString(), SubCat[Convert.ToInt32(sread["SUBCATEGORYID"])].ToString(), determineperishable(Convert.ToInt32(sread["PERISHABLEPRODUCT"])), Uom[Convert.ToInt32(sread["UOMID"])].ToString(), Convert.ToInt32(sread["PRODUCTID"]));
                    itemsBoxs.Controls.Add(db1);

                }
                sread.Close();


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
        private void filtersearchbox(String text)
        {
            //search anything 
            foreach (UserControl items in itemsBoxs.Controls)
            {
                items.Dispose();
            }
            itemsBoxs.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE PRODUCTNAME LIKE '%" + text + "%';", initd.scon);
            SQLiteDataReader sread = scom1.ExecuteReader();
            while (sread.Read())
            {
                Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(sread["PRODUCTNAME"].ToString(), Convert.ToDouble(sread["QUANTITY"]), Category11[Convert.ToInt32(sread["CATEGORYID"])].ToString(), SubCat[Convert.ToInt32(sread["SUBCATEGORYID"])].ToString(), determineperishable(Convert.ToInt32(sread["PERISHABLEPRODUCT"])), Uom[Convert.ToInt32(sread["UOMID"])].ToString(), Convert.ToInt32(sread["PRODUCTID"]));
                itemsBoxs.Controls.Add(db1);
            }
            sread.Close();
            scom1 = null;
            sread = null;



        }

        private void AddStockAdjustment_Leave(object sender, EventArgs e)
        {
            Uom = null;
            Category11 = null;
            SubCat = null;
            GC.Collect();
        }
        private void CatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setitem();
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text);          
        }
        private void SubCatComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tofilter2(Convert.ToInt32(category2[comboBox1.Text]), Convert.ToInt32(Subcategory2[comboBox2.Text]), determineVal2(prshblchbx.Checked), determineVal2(batchdchbx.Checked), srchbox.Text);
            if (comboBox2.Text == "ALL ITEMS")
            {
                prshblchbx.Enabled = false;
                batchdchbx.Enabled = false;
            }
            else
            {
                prshblchbx.Enabled = true;
                batchdchbx.Enabled = true;

            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            filtersearchbox(srchbox.Text);
        }
    }
}
