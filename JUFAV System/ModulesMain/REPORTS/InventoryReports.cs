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

namespace JUFAV_System.ModulesMain.REPORTS
{
    public partial class InventoryReports : UserControl
    {
        public InventoryReports()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            loaddata();
          



        }

        private void loaddata()
        {
            SQLiteCommand sq = new SQLiteCommand("SELECT * FROM PRODUCTS;", initd.scon);
            SQLiteDataReader sread1 = sq.ExecuteReader();
            while (sread1.Read())
            {
                Components.InverntoryReportsComponents test1 = new Components.InverntoryReportsComponents(sread1["PRODUCTNAME"].ToString(),Convert.ToDouble(sread1["QUANTITY"]),23.3,32.2,"TEST");
                ITEMSBOX.Controls.Add(test1);

            }
        }
    }
}
