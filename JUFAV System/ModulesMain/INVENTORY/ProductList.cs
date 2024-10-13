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

namespace JUFAV_System.ModulesMain.INVENTORY
{
    public partial class ProductList : UserControl
    {
        Dictionary<int, string> category;
        Dictionary<int, string> Subcategory;
        Dictionary<int, string> UoM;
        Dictionary<int, string> Supplier;
        public ProductList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            category = new Dictionary<int, string>();
            Subcategory = new Dictionary<int, string>();
            UoM = new Dictionary<int, string>();
            Supplier = new Dictionary<int, string>();
            loadUnits();
            onloadAll();
            
        }
        private void loadUnits()
        {
            category.Clear();
            Subcategory.Clear();
            UoM.Clear();
            Supplier.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYID,CATEGORYDESC FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
              
                category.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());



            }
            sq1.Close();
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
               
                Subcategory.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]),sq1["SUBCATEGORYDESC"].ToString());
             ;

            }
            sq1.Close();
            scom1.CommandText = "SELECT UNITDESC,UNITID FROM UNITOFMEASURE";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                UoM.Add(Convert.ToInt32(sq1["UNITID"]),sq1["UNITDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT SUPPLIERNAME,SUPPLIERID FROM SUPPLIERS";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                Supplier.Add(Convert.ToInt32(sq1["SUPPLIERID"]), sq1["SUPPLIERNAME"].ToString());

            }
            sq1 = null;
            scom1 = null;
        }
        private void onloadAll()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS",initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while(sread1.Read())
            {//USERID,CATEGORYID,SUBCATEGORYID,UOMID,PRODUCTNAME,ORIGINALPICE,MARKUPVALUE,QUANTITY,SUPPLIERID,PERISHABLEPRODUCT,ISBATCH,EXPIRINGDATE
                //supplier boss kullang
                Components.ProdListtDataBoxComponent as1 = new Components.ProdListtDataBoxComponent(sread1["PRODUCTNAME"].ToString(), category[Convert.ToInt32(sread1["CATEGORYID"])], Subcategory[Convert.ToInt32(sread1["SUBCATEGORYID"])], Convert.ToDouble(sread1["QUANTITY"]), UoM[Convert.ToInt32(sread1["UOMID"])], Convert.ToDouble(sread1["ORIGINALPICE"]), Convert.ToDouble(sread1["MARKUPVALUE"]),determineVal(Convert.ToInt32(sread1["PERISHABLEPRODUCT"])), DateTime.Parse(sread1["EXPIRINGDATE"].ToString()).ToShortDateString(), determineVal(Convert.ToInt32(sread1["ISBATCH"])), Convert.ToInt32(sread1["PRODUCTID"]));
             ItemsBox.Controls.Add(as1);
             
            }   
        }
        private void tofilter()
        {




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
    }
}
