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
using System.Threading;

namespace JUFAV_System.ModulesMain
{
    public partial class DASHBOARD : UserControl
    {
        public DASHBOARD()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loaddata();
            loadLowOnstocks();
        }
        private void loaddata()
        {
            initd.titleofprint = "LOW ON STOCKS PRODUCTS";
            String[] queries = { "SELECT COUNT(*) AS VALUE FROM PRODUCTS WHERE QUANTITY < 3;", "SELECT COUNT(*) AS VALUE FROM PRODUCTS WHERE QUANTITY < 5;", "SELECT COUNT(*) AS VALUE FROM PRODUCTS WHERE QUANTITY = 0;", "SELECT COUNT(*) AS VALUE FROM PRODUCTS WHERE QUANTITY < 3;" };
            Label[] labels = {label5,label6,label8};
            SQLiteCommand scom1 = new SQLiteCommand("", initd.scon);
            SQLiteDataReader sread1;
            for (int i = 0;i != 3;i++)
            {
                scom1.CommandText = queries[i];
                sread1 = scom1.ExecuteReader();
                while (sread1.Read())
                {
                    determineiftoomany(Convert.ToInt32(sread1["VALUE"]),labels[i]);
                    labels[i].Text = sread1["VALUE"].ToString();
                    break;
                }
                sread1.Close();
                Thread.Sleep(250);
            }
        }
        private void determineiftoomany(int count,Label toedit)
        {

            switch (count)
            {
                
                case 1:
                case 2:
                case 3:
                    toedit.ForeColor = Color.DarkGreen;
                    break;
                case 4:
                case 5:
                case 6:
                    toedit.ForeColor = Color.Orange;
                    break;
                case 7:
                case 8:
                case 9:
                    toedit.ForeColor = Color.DarkGoldenrod;
                    break;
                default:
                    toedit.ForeColor = Color.Black;
                    break;
            }
         
        }
        private void loadOutOfstocks()
        {
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "OUT OF STOCKS PRODUCTS";
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE QUANTITY = 0;",initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["PRODUCTNAME"].ToString(),Convert.ToInt32(sread1["QUANTITY"]));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;

        }
        private void loadLowOnstocks()
        {
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "LOW ON STOCKS PRODUCTS";
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE QUANTITY < 3;", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
        }
        private void loadProdWithinReorder()
        {
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "PRODUCTS WITHIN REORDER POINT";
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE QUANTITY < 3;", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
        }
        private void loadExpiredProd()
        {
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "EXPIRED PRODUCTS";
            SQLiteCommand scom1 = new SQLiteCommand("SELECT * FROM PRODUCTS WHERE QUANTITY < 3;", initd.scon);
            SQLiteDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            sread1 = null;
            scom1 = null;
        }
        private void OutOfStocksbtn_Click(object sender, EventArgs e)
        {
            
            loadOutOfstocks();
            initd.titleofprint = "OUT_OF_STOCKS";
        }
        private void LowStocksProd_Click(object sender, EventArgs e)
        {
            loadLowOnstocks();
            initd.titleofprint = "LOW_ON_STOCKS_PRODUCTS";
        }
        private void ProdWithinreorder_Click(object sender, EventArgs e)
        {
            loadOutOfstocks();
            initd.titleofprint = "OUT_OF_STOCKS_PRODUCTS";
        }
        private void ExpiredBTN_Click(object sender, EventArgs e)
        {
            loadExpiredProd();
            initd.titleofprint = "EXPIRED_PRODUCTS";
        }
        private void Options_Click(object sender, EventArgs e)
        {
            Components.SmalloptionDashBoard item1 = new Components.SmalloptionDashBoard();
            item1.Location = new Point(Options.Location.X - 150, Options.Location.Y +150);//fic bug
            this.Controls.Add(item1);
            item1.BringToFront();
        }
    }
}
