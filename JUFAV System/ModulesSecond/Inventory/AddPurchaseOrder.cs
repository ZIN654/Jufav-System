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
    public partial class AddPurchaseOrder : UserControl
    {
        Dictionary<String, int> splr1;
       
        private static int total = 0;
        int swtichtriger = 0;
        public AddPurchaseOrder()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            initd.tousetotalPO = subtotalvallbl;
            // panel4.Refresh();
            initd.Subtotal = null;//garbage collector na bahala
            splr1 = new Dictionary<String, int>();
            initd.Subtotal = new Dictionary<int, int>();

            loaddatabase();
            dateissued.Text = "DATE ISSUED: " + DateTime.Now.ToShortDateString(); ;
        }
        public void loaddatabase()
        {
            splr1.Clear();

            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM SUPPLIERS",initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                splr1.Add(sread1["SUPPLIERNAME"].ToString(),Convert.ToInt32(sread1["SUPPLIERID"]));
                splr.Items.Add(sread1["SUPPLIERNAME"].ToString());
                
            }
            sread1.Close();
            if (splr1.Count != 0)
            {
               splr.SelectedIndex = 0;
                scom1.CommandText = "SELECT * FROM PRODUCTS WHERE SUPPLIERID = " + splr1[splr.Text] + ";";
                sread1 = scom1.ExecuteReader();
                while (sread1.Read())
                {
                    //insert into items box
                    ///ItemsBoxOfferd.Controls.Add();
                    Components.OfferedProdsPODataBox prod1 = new Components.OfferedProdsPODataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["ORIGINALPICE"]), sread1["UOMID"].ToString(), Convert.ToInt32(sread1["PRODUCTID"]),ItemsBoxPoList);
                    ItemsBoxOfferd.Controls.Add(prod1);
                }

            }

            sread1.Close();
            scom1 = null;
            sread1 = null;
            swtichtriger = 1;

        }
        private void filterer()
        {
            //delete all items
            foreach (UserControl items in ItemsBoxOfferd.Controls){items.Dispose();}
            ItemsBoxOfferd.Controls.Clear();
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE SUPPLIERID = " + splr1[splr.Text] + ";", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OfferedProdsPODataBox prod1 = new Components.OfferedProdsPODataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToDouble(sread1["ORIGINALPICE"]), sread1["UOMID"].ToString(), Convert.ToInt32(sread1["PRODUCTID"]), ItemsBoxPoList);
                ItemsBoxOfferd.Controls.Add(prod1);
            }
            sread1.Close();
            scom1 = null;
            sread1 = null;
        }



        private void splr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (swtichtriger == 1)
            {
                filterer();
            }
        }
        private void AddPurchaseOrder_Leave(object sender, EventArgs e)
        {
            splr1 = null;
           
           
        }
        public static void totals(Label lbltoset)//calls in the each button press
        {
          
           
        }
        private void ItemsBoxPoList_ControlAdded(object sender, ControlEventArgs e)
        {
            totals(subtotalvallbl);
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }  
    }
}
