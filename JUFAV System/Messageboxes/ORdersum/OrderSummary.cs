using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using JUFAV_System.dll;

namespace JUFAV_System.Messageboxes.ORdersum
{
    public partial class OrderSummary : Form
    {
        int orderID1;
        Action toexe2;
        Action toexe3;
        public OrderSummary(int OrderID,Action toexe,Action toclose)
        {
            InitializeComponent();
            orderID1 = OrderID;
            loadInfo(OrderID);
            toexe2 = toexe;
            toexe3 = toclose;
        }
        private void loadInfo(int ID)
        {
            SQLiteCommand sq1 = new SQLiteCommand("SELECT * FROM ORDERSTABLE WHERE SALEID = "+ID+";", initd.scon);
            SQLiteDataReader sread1 = sq1.ExecuteReader();
            while (sread1.Read())
            {
                double total = Convert.ToInt32(sread1["QUANTITY"]) * Convert.ToDouble(sread1["ITEMPRICE"]);
                Components.OrderSummaryProducts as1 = new Components.OrderSummaryProducts(sread1["ITEMNAME"].ToString(),Convert.ToInt32(sread1["QUANTITY"]),total);
                ITEMSBOXPROD.Controls.Add(as1);
            }
            sread1.Close();
            sq1.CommandText = "SELECT SALEID FROM ORDERSTABLE WHERE SALEID = " + ID + " ORDER BY SALEID ASC LIMIT 1;";
            int SALEID = Convert.ToInt32(sq1.ExecuteScalar());
            sq1.CommandText = "SELECT * FROM SALES WHERE SALEID = "+SALEID+";";
            sread1 = sq1.ExecuteReader();
            while (sread1.Read())
            {
                label4.Text = sread1["SALEID"].ToString();
                label11.Text = sread1["CUSTOMERNAME"].ToString();
                label10.Text = Convert.ToDouble(Convert.ToDouble(sread1["TOTALPRICE"]) / 1.12 * 0.12).ToString();
                label9.Text = sread1["TOTALPRICE"].ToString();
              
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            toexe2();
            toexe3();
            this.Dispose();

        }
    }
}
