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
        Dictionary<int,string> Uom;
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
        private void loadinfo() {



        }
        private void LoadData()
        {
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS",initd.scon);
            SQLiteDataReader sread = scom1.ExecuteReader();
            while (sread.Read())
            {
                Components.SelectProductToAdjustDataBox db1 = new Components.SelectProductToAdjustDataBox(,,,);
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
