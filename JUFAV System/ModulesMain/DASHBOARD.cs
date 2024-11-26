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
        int generatereportype = 0;
        public DASHBOARD()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loaddata();
            loadLowOnstocks();
            label8.Text = LoadDataCount("SELECT COUNT(*) FROM SALES WHERE DATEOFSALE = '" + DateTime.Now.ToShortDateString() + "';").ToString();
        }
        private void loaddata()
        {
            if (initd.con1.State == ConnectionState.Closed) { initd.con1.Open(); }
            initd.titleofprint = "LOW ON STOCKS PRODUCTS";
            String[] queries = { "SELECT COUNT(*) AS VALUE FROM PRODUCTS WHERE QUANTITY <= 3 AND QUANTITY > 0;", "SELECT COUNT(*) AS VALUE FROM PRODUCTS WHERE QUANTITY = 0;" };
            Label[] labels = {label5,label6};
             MySql.Data.MySqlClient.MySqlCommand scom1 = new  MySql.Data.MySqlClient.MySqlCommand("", initd.con1);
             MySql.Data.MySqlClient.MySqlDataReader sread1;
            for (int i = 0;i != 2;i++)
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
            initd.con1.Close();
            sread1 = null;
            scom1 = null;
            GC.Collect();
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
            initd.con1.Open();
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "OUT OF STOCKS PRODUCTS";
             MySql.Data.MySqlClient.MySqlCommand scom1 = new  MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS WHERE QUANTITY = 0;",initd.con1);
             MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["PRODUCTNAME"].ToString(),Convert.ToInt32(sread1["QUANTITY"]));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            initd.con1.Close();
            GC.Collect();

        }
        private void loadLowOnstocks()
        {
            initd.con1.Close();
            initd.con1.Open();
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "LOW ON STOCKS PRODUCTS";
             MySql.Data.MySqlClient.MySqlCommand scom1 = new  MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM PRODUCTS WHERE QUANTITY <= 3 AND QUANTITY > 0;", initd.con1);
             MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            while (sread1.Read())
            {
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["PRODUCTNAME"].ToString(), Convert.ToInt32(sread1["QUANTITY"]));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            initd.con1.Close();
            GC.Collect();
        }
        private void LoadSalesOftheDay()
        {
            initd.con1.Open();
            foreach (UserControl i in itemsbox1.Controls)
            {
                i.Dispose();
            }
            itemsbox1.Controls.Clear();
            label9.Text = "TOTAL SALES OF THE DAY";
             MySql.Data.MySqlClient.MySqlCommand scom1 = new  MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM SALES WHERE DATEOFSALE = '"+DateTime.Now.ToShortDateString()+"';", initd.con1);
             MySql.Data.MySqlClient.MySqlDataReader sread1 = scom1.ExecuteReader();
            Double value = 0;
            while (sread1.Read())
            {
                value = Convert.ToDouble(sread1["TOTALPRICE"]);
                Components.OutOfStocksDataBox db1 = new Components.OutOfStocksDataBox(sread1["CUSTOMERNAME"].ToString(),Convert.ToInt32(value));
                itemsbox1.Controls.Add(db1);
            }
            sread1.Close();
            initd.con1.Close();
            sread1 = null;
            scom1 = null;
        }
        private int LoadDataCount(String querytoues)
        {
            initd.con1.Open();
            int count = 0;
             MySql.Data.MySqlClient.MySqlCommand sq = new  MySql.Data.MySqlClient.MySqlCommand(querytoues, initd.con1);
            count = Convert.ToInt32(sq.ExecuteScalar());
            sq = null;
            GC.Collect();
            initd.con1.Close();
            return count;
        }
       
      
        private void LowStocksProd_Click(object sender, EventArgs e)
        {
            generatereportype = 0;
            loadLowOnstocks();
            initd.titleofprint = "LOW_ON_STOCKS_PRODUCTS";
        }
        private void ProdWithinreorder_Click(object sender, EventArgs e)
        {
            generatereportype = 1;
            loadOutOfstocks();
            initd.titleofprint = "OUT_OF_STOCKS_PRODUCTS";
        }
        private void ExpiredBTN_Click(object sender, EventArgs e)
        {
            generatereportype = 2;
            LoadSalesOftheDay();
            initd.titleofprint = "TOTAL SALES OF THE DAY";
        }
        private void Options_Click(object sender, EventArgs e)
        {
            Components.SmalloptionDashBoard item1 = new Components.SmalloptionDashBoard(generatereportype);
            item1.Location = new Point(Options.Location.X - 150, Options.Location.Y +150);//fic bug
            this.Controls.Add(item1);
            item1.BringToFront();
        }
    }
}
