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
        Dictionary<int, string> Category;
        public AddStockAdjustment()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            Uom = new Dictionary<int, string>();
            Category = new Dictionary<int, string>();
            SubCat = new Dictionary<int, string>();
            this.Dock = DockStyle.Fill;
            loadinfo();
            LoadData();
            this.Cursor = Cursors.Default;

        }
        private void loadinfo()
        {
            Category.Clear();
            SubCat.Clear();
            Uom.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT CATEGORYID,CATEGORYDESC FROM CATEGORY;", initd.scon);
            SQLiteDataReader sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {

                Category.Add(Convert.ToInt32(sq1["CATEGORYID"]), sq1["CATEGORYDESC"].ToString());

            }
            sq1.Close();
            scom1.CommandText = "SELECT SUBCATEGORYID,SUBCATEGORYDESC FROM SUBCATEGORY";
            sq1 = scom1.ExecuteReader();
            while (sq1.Read())
            {
                SubCat.Add(Convert.ToInt32(sq1["SUBCATEGORYID"]), sq1["SUBCATEGORYDESC"].ToString());
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
                Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(sread["PRODUCTNAME"].ToString(),Convert.ToDouble(sread["QUANTITY"]),Uom[Convert.ToInt32(sread["UOMID"])],Convert.ToInt32(sread["PRODUCTID"]));
                itemsBoxs.Controls.Add(db1);
            }


        }

        private void AddStockAdjustment_Leave(object sender, EventArgs e)
        {
            Uom = null;
            Category = null;
            SubCat = null;
           
        }
    }
}
